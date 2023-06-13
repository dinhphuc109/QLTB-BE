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
    public class TieuChuanBaoTriController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public TieuChuanBaoTriController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            var data = uow.tieuChuanBaoTris.GetAll(t => !t.IsDeleted && (t.MaTieuChuanBaoTri.ToLower().Contains(keyword.ToLower()) || t.TenTieuChuanBaoTri.ToLower().Contains(keyword.ToLower()))).Select(x => new
            {
                x.Id,
                x.MaTieuChuanBaoTri,
                x.TenTieuChuanBaoTri,
                x.ThoiGianTieuChuanBaoTri,
                x.QuyDinh_TaiLieuHuongDan
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
            TieuChuanBaoTri duLieu = uow.tieuChuanBaoTris.GetById(id);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(TieuChuanBaoTri data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.tieuChuanBaoTris.Exists(x => x.MaTieuChuanBaoTri == data.MaTieuChuanBaoTri && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaTieuChuanBaoTri + " đã tồn tại trong hệ thống");
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = Guid.Parse(User.Identity.Name);
                uow.tieuChuanBaoTris.Add(data);
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, TieuChuanBaoTri data)
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
                if (uow.tieuChuanBaoTris.Exists(x => x.MaTieuChuanBaoTri == data.MaTieuChuanBaoTri && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaTieuChuanBaoTri + " đã tồn tại trong hệ thống");
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.tieuChuanBaoTris.Update(data);
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                TieuChuanBaoTri duLieu = uow.tieuChuanBaoTris.GetById(id);
                if (duLieu == null)
                {
                    return NotFound();
                }
                duLieu.DeletedDate = DateTime.Now;
                duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                duLieu.IsDeleted = true;
                uow.tieuChuanBaoTris.Update(duLieu);
                uow.Complete();
                return Ok(duLieu);
            }

        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.tieuChuanBaoTris.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
