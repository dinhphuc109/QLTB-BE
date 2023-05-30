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
    public class DanhMucKhoController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public DanhMucKhoController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "User" };
            var data = uow.danhMucKhos.GetAll(t => !t.IsDeleted && (t.MaKho.ToLower().Contains(keyword.ToLower()) || t.TenKho.ToLower().Contains(keyword.ToLower())), null, include).Select(x => new
            {
                x.Id,
                x.MaKho,
                x.TenKho,
                x.User.FullName
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenKho));
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User" };
            var duLieu = uow.danhMucKhos.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(DanhMucKho data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.danhMucKhos.Exists(x => x.MaKho == data.MaKho && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaKho + " đã tồn tại trong hệ thống");
                else if (uow.danhMucKhos.Exists(x => x.MaKho == data.MaKho && x.IsDeleted))
                {
                    var vattu = uow.danhMucKhos.GetAll(x => x.MaKho == data.MaKho).ToArray();
                    vattu[0].IsDeleted = false;
                    vattu[0].DeletedBy = null;
                    vattu[0].DeletedDate = null;
                    vattu[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    vattu[0].UpdatedDate = DateTime.Now;
                    vattu[0].MaKho = data.MaKho;
                    vattu[0].TenKho = data.TenKho;
                    vattu[0].User.Id = data.User.Id;

                    uow.danhMucKhos.Update(vattu[0]);
 
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);

                    uow.danhMucKhos.Add(data);
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, DanhMucKho data)
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
                if (uow.danhMucKhos.Exists(x => x.MaKho == data.MaKho && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaKho + " đã tồn tại trong hệ thống");
                else if (uow.danhMucKhos.Exists(x => x.MaKho == data.MaKho && x.IsDeleted))
                {
                    var vattu = uow.danhMucKhos.GetAll(x => x.MaKho == data.MaKho).ToArray();
                    vattu[0].IsDeleted = false;
                    vattu[0].DeletedBy = null;
                    vattu[0].DeletedDate = null;
                    vattu[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    vattu[0].UpdatedDate = DateTime.Now;
                    vattu[0].MaKho = data.MaKho;
                    vattu[0].TenKho = data.TenKho;
                    vattu[0].User.Id = data.User.Id;

                    uow.danhMucKhos.Update(vattu[0]);

                }
                else
                {
                    data.UpdatedBy = Guid.Parse(User.Identity.Name);
                    data.UpdatedDate = DateTime.Now;
                    uow.danhMucKhos.Update(data);
                }
                   
             }
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
         }
        

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                DanhMucKho duLieu = uow.danhMucKhos.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.danhMucKhos.Update(duLieu);
                    uow.Complete();
                    return Ok(duLieu);
                }
                return StatusCode(StatusCodes.Status409Conflict, "Bạn chỉ có thể chỉnh sửa thông tin thiết bị này");
            }
        }
        [HttpDelete("Remove/{id}")]
        public ActionResult Delete_Remove(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                uow.danhMucKhos.Delete(id);
                uow.Complete();
                return Ok();
            }
        }

    }
}
