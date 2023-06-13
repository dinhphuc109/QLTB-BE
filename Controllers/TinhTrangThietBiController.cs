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
    public class TinhTrangThietBiController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public TinhTrangThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            var data = uow.tinhTrangThietBis.GetAll(t => !t.IsDeleted && (t.MaTinhTrangThietBi.ToLower().Contains(keyword.ToLower()) || t.TenTinhTrangThietBi.ToLower().Contains(keyword.ToLower()))).Select(x => new
            {
                x.Id,
                x.MaTinhTrangThietBi,
                x.TenTinhTrangThietBi,
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
            TinhTrangThietBi duLieu = uow.tinhTrangThietBis.GetById(id);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(TinhTrangThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.tinhTrangThietBis.Exists(x => x.MaTinhTrangThietBi == data.MaTinhTrangThietBi && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaTinhTrangThietBi + " đã tồn tại trong hệ thống");
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.tinhTrangThietBis.Add(data);
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, TinhTrangThietBi data)
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
                if (uow.tinhTrangThietBis.Exists(x => x.MaTinhTrangThietBi == data.MaTinhTrangThietBi && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaTinhTrangThietBi + " đã tồn tại trong hệ thống");
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.tinhTrangThietBis.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                TinhTrangThietBi duLieu = uow.tinhTrangThietBis.GetById(id);
                if (!uow.thongTinThietBis.Exists(x => x.TinhTrangThietBi_Id == id))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.tinhTrangThietBis.Update(duLieu);
                    uow.Complete();
                    return Ok(duLieu);
                }
                return StatusCode(StatusCodes.Status409Conflict, "Tình trạng này đã có ở thiết bị không được xóa");
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.tinhTrangThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
