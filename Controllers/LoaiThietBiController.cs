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
            var data = uow.loaiThietBis.GetAll(t => !t.IsDeleted && (t.MaLoaiThietBi.ToLower().Contains(keyword.ToLower()) || t.TenLoaiThietBi.ToLower().Contains(keyword.ToLower()))).Select(x => new
            {
                x.Id,
                x.MaLoaiThietBi,
                x.TenLoaiThietBi,
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
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.loaiThietBis.Add(data);
                uow.Complete();
                return Ok();
            }
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
                if (uow.loaiThietBis.Exists(x => x.MaLoaiThietBi == data.MaLoaiThietBi && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaLoaiThietBi + " đã tồn tại trong hệ thống");
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
