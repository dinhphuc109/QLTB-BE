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
using ThacoLibs;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucThietBiController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public DanhMucThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = {"HangThietBi", "LoaiThietBi" };
            var data = uow.danhMucThietBis.GetAll(t => !t.IsDeleted && (t.MaThietBi.ToLower().Contains(keyword.ToLower()) || t.TenThietBi.ToLower().Contains(keyword.ToLower())), null, include).Select(x => new
            {
                x.Id,
                x.MaThietBi,
                x.TenThietBi,
                x.CauHinh,
                x.HangThietBi.TenHang,
                x.LoaiThietbi_Id,
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenThietBi));
        }

        [HttpPost]
        public ActionResult Post(DanhMucThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.danhMucThietBis.Exists(x => x.MaThietBi == data.MaThietBi && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaThietBi + " đã tồn tại trong hệ thống");
                else if (uow.danhMucThietBis.Exists(x => x.MaThietBi == data.MaThietBi && x.IsDeleted))
                {
                    var loaihang = uow.loaiHangThietBis.GetAll(x => x.HangThietBi_Id == data.HangThietBi_Id).ToArray();
                    var danhmuctb = uow.danhMucThietBis.GetAll(x => x.MaThietBi == data.MaThietBi).ToArray();
                    danhmuctb[0].IsDeleted = false;
                    danhmuctb[0].DeletedBy = null;
                    danhmuctb[0].DeletedDate = null;
                    danhmuctb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    danhmuctb[0].UpdatedDate = DateTime.Now;
                    danhmuctb[0].MaThietBi = data.MaThietBi;
                    danhmuctb[0].TenThietBi = data.TenThietBi;
                    danhmuctb[0].HangThietBi_Id = data.HangThietBi_Id;
                    if(danhmuctb[0].HangThietBi_Id == loaihang[0].HangThietBi_Id)
                    {
                        danhmuctb[0].LoaiThietbi_Id = data.LoaiThietbi_Id;
                    }
                    else
                        return StatusCode(StatusCodes.Status409Conflict, "Hãng " + data.HangThietBi.TenHang + " không có loại thiết bị này");
                    danhmuctb[0].CauHinh = data.CauHinh;
                    uow.danhMucThietBis.Update(danhmuctb[0]);

                }
                else
                {
                    
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    var loaihang = uow.loaiHangThietBis.GetAll(x => x.HangThietBi_Id == data.HangThietBi_Id && x.LoaiThietBi_Id==data.LoaiThietbi_Id).ToArray();
                    if (data.HangThietBi_Id == loaihang[0].HangThietBi_Id && data.LoaiThietbi_Id==loaihang[0].LoaiThietBi_Id)
                    {
                        uow.danhMucThietBis.Add(data);
                    }
                    else
                        return BadRequest(ModelState);

                }
                uow.Complete();
                return Ok();
            }
        }


    }
}
