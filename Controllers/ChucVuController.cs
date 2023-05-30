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
    public class ChucVuController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public ChucVuController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "BoPhan" };
            var data = uow.chucVus.GetAll(t => !t.IsDeleted && (t.MaChucVu.ToLower().Contains(keyword.ToLower()) || t.TenChucVu.ToLower().Contains(keyword.ToLower())), null, include
                ).Select(x => new
                {
                    x.Id,
                    x.MaChucVu,
                    x.TenChucVu,
                    x.BoPhan.TenBoPhan
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
            string[] include = { "BoPhan" };
            var duLieu = uow.chucVus.GetAll(x => !x.IsDeleted && x.Id == id, null, include);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(ChucVu data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.chucVus.Exists(x => x.MaChucVu == data.MaChucVu && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaChucVu + " đã tồn tại trong hệ thống");
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.chucVus.Add(data);
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, ChucVu data)
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
                if (uow.chucVus.Exists(x => x.MaChucVu == data.MaChucVu && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaChucVu + " đã tồn tại trong hệ thống");
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.chucVus.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                ChucVu duLieu = uow.chucVus.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.chucVus.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.chucVus.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
