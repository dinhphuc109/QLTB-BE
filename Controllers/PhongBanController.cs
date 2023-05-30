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
    public class PhongBanController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public PhongBanController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "DonVi" };
            var data = uow.phongbans.GetAll(t => !t.IsDeleted && (t.MaPhongBan.ToLower().Contains(keyword.ToLower()) || t.TenPhongBan.ToLower().Contains(keyword.ToLower())), null, include).Select(x => new
            {
                x.Id,
                x.MaPhongBan,
                x.TenPhongBan,
                x.DonVi.TenDonVi
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
            string[] include = { "DonVi" };
            var duLieu = uow.phongbans.GetAll(x => !x.IsDeleted && x.Id == id, null, include);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(Phongban data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.phongbans.Exists(x => x.MaPhongBan == data.MaPhongBan && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaPhongBan + " đã tồn tại trong hệ thống");
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.phongbans.Add(data);
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, Phongban data)
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
                if (uow.phongbans.Exists(x => x.MaPhongBan == data.MaPhongBan && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaPhongBan + " đã tồn tại trong hệ thống");
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.phongbans.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                Phongban duLieu = uow.phongbans.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.phongbans.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.phongbans.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
