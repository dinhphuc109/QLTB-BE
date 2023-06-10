using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Linq;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiThietBiController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public LoaiThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "HeThong" };
            var data = uow.loaiThietBis.GetAll(t => !t.IsDeleted && (t.MaLoaiThietBi.ToLower().Contains(keyword.ToLower()) || t.TenLoaiThietBi.ToLower().Contains(keyword.ToLower())),null,include).Select(x => new
            {
                x.Id,
                x.MaLoaiThietBi,
                x.TenLoaiThietBi,
                x.HeThong.TenHeThong,
                x.LoaiThietBi_Id,
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            LoaiThietBi duLieu = uow.loaiThietBis.GetById(id);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(LoaiThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (uow.loaiThietBis.Exists(x => x.MaLoaiThietBi == data.MaLoaiThietBi && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaLoaiThietBi + " đã tồn tại trong hệ thống");
                if (!IsValidCayPhanCap(data))
                {
                    return BadRequest("Loại thiết bị không phù hợp với cây phân cấp");
                }
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.loaiThietBis.Add(data);
                uow.Complete();
                return Ok();
            }
        }

        private bool IsValidCayPhanCap(LoaiThietBi loaiThietBi)
        {
            if (loaiThietBi.LoaiThietBi_Id == null)
            {
                return true; // Nếu không có loại cha, cây phân cấp đúng
            }

            // Lấy loại cha từ cơ sở dữ liệu
            var parentLoaiThietBi = uow.loaiThietBis.GetById(loaiThietBi.LoaiThietBi_Id);

            if (parentLoaiThietBi == null)
            {
                return false; // Nếu không tìm thấy loại cha, cây phân cấp không đúng
            }

            // Kiểm tra đệ quy cho loại cha
            return IsValidCayPhanCap(parentLoaiThietBi);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, LoaiThietBi data)
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
                if (uow.loaiThietBis.Exists(x => x.MaLoaiThietBi == data.MaLoaiThietBi && x.Id!=data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaLoaiThietBi + " đã tồn tại trong hệ thống");
                if (!IsValidCayPhanCap(data))
                {
                    return BadRequest("Loại thiết bị không phù hợp với cây phân cấp");
                }
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.loaiThietBis.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                LoaiThietBi duLieu = uow.loaiThietBis.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.loaiThietBis.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.loaiThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
