using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HangThietBiController : Controller
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public HangThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }
        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "loaiHangThietBis", "loaiHangThietBis.LoaiThietBi" };
            var data = uow.hangThietBis.GetAll(t => !t.IsDeleted && (t.MaHangThietBi.ToLower().Contains(keyword.ToLower()) || t.TenHang.ToLower().Contains(keyword.ToLower())),null,include).Select(x => new
            {
                x.Id,
                x.MaHangThietBi,
                x.TenHang,
                x.HeThong_Id,
                LstLoai = x.loaiHangThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenHang));
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] include = { "loaiHangThietBis" };
            var duLieu = uow.hangThietBis.GetAll(x => !x.IsDeleted && x.Id == id, null, include);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        public class ChiTietHangThietBi
        {
            public Guid LoaiThietBi_Id { get; set; }
            
            public string TenLoaiThietBi { get; set; }
        }

        [HttpGet("GetChiTietHang")]
        public ActionResult GetChiTietHang(Guid idHeThong,Guid idLoaiThietBi)
        {
            string[] include = { "Hang" };
            var data = uow.hangThietBis.GetAll(x => x.HeThong_Id == idHeThong && !x.IsDeleted).GroupBy(x => x.HeThong_Id).Select(x => new { x.Key });
            var dataHang = uow.loaiThietBis.GetAll(x => !x.IsDeleted).Select(x => new { x.Id, x.TenLoaiThietBi });
            List<ChiTietHangThietBi> list = new List<ChiTietHangThietBi>();
            foreach (var x in data)
            {
                var item = dataHang.FirstOrDefault(y => y.Id == x.Key);
                list.Add(new ChiTietHangThietBi { LoaiThietBi_Id = item.Id, TenLoaiThietBi = item.TenLoaiThietBi });
            }
            return Ok(list.OrderBy(x => x.TenLoaiThietBi));
        }

        [HttpPost]
        public ActionResult Post(HangThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.hangThietBis.Exists(x => x.MaHangThietBi == data.MaHangThietBi && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaHangThietBi + " đã tồn tại trong hệ thống");
                else if (uow.hangThietBis.Exists(x => x.MaHangThietBi == data.MaHangThietBi && !x.IsDeleted))
                {
                    var hangtb = uow.hangThietBis.GetAll(x => x.MaHangThietBi == data.MaHangThietBi).ToArray();
                    hangtb[0].IsDeleted = false;
                    hangtb[0].DeletedBy = null;
                    hangtb[0].DeletedDate = null;
                    hangtb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    hangtb[0].UpdatedDate = DateTime.Now;
                    hangtb[0].MaHangThietBi = data.MaHangThietBi;
                    hangtb[0].TenHang = data.TenHang;
                    hangtb[0].HeThong_Id = data.HeThong_Id;
                    uow.hangThietBis.Update(hangtb[0]);
                    foreach (var item in data.LstLoai)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.HangThietBi_Id = hangtb[0].Id;
                        uow.loaiHangThietBis.Add(item);
                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.hangThietBis.Add(data);
                    foreach (var item in data.LstLoai)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.HangThietBi_Id = id;
                        uow.loaiHangThietBis.Add(item);
                    }
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, HangThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != data.Id)
                {
                    return BadRequest();
                }
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.hangThietBis.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                HangThietBi duLieu = uow.hangThietBis.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.hangThietBis.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.hangThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }

    }
}
