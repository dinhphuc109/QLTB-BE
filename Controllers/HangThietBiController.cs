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
            string[] include = {};
            var data = uow.hangThietBis.GetAll(t => !t.IsDeleted && (t.MaHang.ToLower().Contains(keyword.ToLower()) || t.TenHang.ToLower().Contains(keyword.ToLower())),null,include).Select(x => new
            {
                x.Id,
                x.MaHang,
                x.TenHang,            
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
            string[] include = {};
            var duLieu = uow.hangThietBis.GetAll(x => !x.IsDeleted && x.Id == id, null, include).Select(x => new
            {
                x.Id,
                x.MaHang,
                x.TenHang,


            }); ;
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
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
                if (uow.hangThietBis.Exists(x => x.MaHang == data.MaHang && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaHang + " đã tồn tại trong hệ thống");
                else if (uow.hangThietBis.Exists(x => x.MaHang == data.MaHang && x.IsDeleted))
                {
                    var hangtb = uow.hangThietBis.GetAll(x => x.MaHang == data.MaHang).ToArray();
                    hangtb[0].IsDeleted = false;
                    hangtb[0].DeletedBy = null;
                    hangtb[0].DeletedDate = null;
                    hangtb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    hangtb[0].UpdatedDate = DateTime.Now;
                    hangtb[0].MaHang = data.MaHang;
                    hangtb[0].TenHang = data.TenHang;
                    uow.hangThietBis.Update(hangtb[0]);
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.hangThietBis.Add(data);
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
                if (uow.hangThietBis.Exists(x => x.MaHang == data.MaHang && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaHang + " đã tồn tại trong hệ thống");
                else if (uow.hangThietBis.Exists(x => x.MaHang == data.MaHang && x.IsDeleted))
                {
                    var hangtb = uow.hangThietBis.GetAll(x => x.MaHang == data.MaHang).ToArray();
                    hangtb[0].IsDeleted = false;
                    hangtb[0].DeletedBy = null;
                    hangtb[0].DeletedDate = null;
                    hangtb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    hangtb[0].UpdatedDate = DateTime.Now;
                    hangtb[0].MaHang = data.MaHang;
                    hangtb[0].TenHang = data.TenHang;
                    uow.hangThietBis.Update(hangtb[0]);
                }
                else
                {
                    data.UpdatedBy = Guid.Parse(User.Identity.Name);
                    data.UpdatedDate = DateTime.Now;

                    uow.hangThietBis.Update(data);

                }
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
                if (!uow.danhMucThietBis.Exists(x=>x.HangThietBi_Id==id))
                {
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
                return StatusCode(StatusCodes.Status409Conflict, "Hãng này đã có ở thiết bị không được xóa");
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
