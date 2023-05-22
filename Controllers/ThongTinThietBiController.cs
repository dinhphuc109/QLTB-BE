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
using System.Threading.Tasks;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinThietBiController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public ThongTinThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";
            string[] include = { "Domain", "NhaCungCap", "HangThietBi", "ChiTietLoaiThongTinThietBis", "ChiTietLoaiThongTinThietBis.LoaiThietBi" };
            var data = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && (t.MaThongTinThietBi.ToLower().Contains(keyword.ToLower()) || t.TenThietBi.ToLower().Contains(keyword.ToLower())), null, include).Select(x => new
            {
                x.Id,
                x.MaThongTinThietBi,
                x.TenThietBi,
                x.CauHinh,
                x.Domain.TenDomain,
                x.HangThietBi.TenHang,
                x.SoSeri,
                x.ModelThietBi,
                x.NhaCungCap.TenNhaCungCap,
                x.ThoiGianBaoHanh,
                LstLoai = x.ChiTietLoaiThongTinThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenThietBi));
        }

        public class ClassListThongTinThietBi
        {
            public Guid Id { get; set; }
            public string MaThongTinThietBi { get; set; }
            public string TenThietBi { get; set; }
            public string TenDomain { get; set; }
            public string TenHang { get; set; }
            public string TenNhaCungCap { get; set; }
            public string SoSeri { get; set; }
        }

        [HttpGet("GetDataPagnigation")]
        public ActionResult GetDataPagnigation(int page = 1, int pageSize = 20, string keyword = null)
        {
            if (keyword == null) keyword = "";
            string[] include = { "Domain", "NhaCungCap", "HangThietBi", "ChiTietLoaiThongTinThietBis", "ChiTietLoaiThongTinThietBis.LoaiThietBi" };
            var query = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && (t.TenThietBi.ToLower().Contains(keyword.ToLower()) || t.MaThongTinThietBi.ToLower().Contains(keyword.ToLower())), null, include)
            .Select(x => new
            {
                x.TenThietBi,
                x.Id,
                x.MaThongTinThietBi,
                x.CauHinh,
                x.Domain_Id,
                x.HangThietBi_Id,
                x.SoSeri,
                x.ModelThietBi,
                x.NhaCungCap_Id,
                x.ThoiGianBaoHanh,
                LstLoai = x.ChiTietLoaiThongTinThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                })
            })
            .OrderBy(x => x.TenThietBi);
            List<ClassListThongTinThietBi> list = new List<ClassListThongTinThietBi>();

            foreach (var item in query)
            {
                var domain = uow.domains.GetAll(x => !x.IsDeleted && x.Id == item.Domain_Id, null, null).Select(x => new { x.TenDomain }).ToList();
                var hangtb = uow.hangThietBis.GetAll(x => !x.IsDeleted && x.Id == item.HangThietBi_Id, null, null).Select(x => new { x.TenHang }).ToList();
                var nhaCungCap = uow.NhaCungCaps.GetAll(x => !x.IsDeleted && x.Id == item.NhaCungCap_Id, null, null).Select(x => new { x.TenNhaCungCap }).ToList();

                var infor = new ClassListThongTinThietBi();
                infor.Id = item.Id;
                infor.MaThongTinThietBi = item.MaThongTinThietBi;
                infor.TenThietBi = item.TenThietBi;
                infor.SoSeri = item.SoSeri;
                infor.TenNhaCungCap = nhaCungCap[0].TenNhaCungCap;
                infor.TenDomain = domain[0].TenDomain;
                infor.TenHang = hangtb[0].TenHang;
                list.Add(infor);
            }
            int totalRow = list.Count();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(new { data, totalPage, totalRow });
        }

        public class ClassThongTinThietBiDetail
        {
            public Guid Id { get; set; }
            public string MaThongTinThietBi { get; set; }
            public string TenThietBi { get; set; }
            public string TenDomain { get; set; }
            public string TenHang { get; set; }
            public string TenNhaCungCap { get; set; }
            public string SoSeri { get; set; }
            public string ModelThietBi { get; set; }
            public string CauHinh { get; set; }
            public DateTime ThoiGianBaoHanh { get; set; }
            public string TenLoai { get; set; }

        }

        [HttpGet("GetThongTinThietBiDetail/{id}")]
        public ActionResult GetThongTinThietBiDetail(Guid id)
        {         
            string[] include = { "Domain", "NhaCungCap", "HangThietBi", "ChiTietLoaiThongTinThietBis", "ChiTietLoaiThongTinThietBis.LoaiThietBi" };
            var query = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && t.Id==id, null, include)
            .Select(x => new
            {
                x.TenThietBi,
                x.Id,
                x.MaThongTinThietBi,
                x.CauHinh,
                x.Domain_Id,
                x.HangThietBi_Id,
                x.SoSeri,
                x.ModelThietBi,
                x.NhaCungCap_Id,
                x.ThoiGianBaoHanh,
                LstLoai = x.ChiTietLoaiThongTinThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                }).ToList()
            })
            .OrderBy(x => x.TenThietBi);
            List<ClassThongTinThietBiDetail> list = new List<ClassThongTinThietBiDetail>(); ;
            foreach (var item in query)
            {
                var domain = uow.domains.GetAll(x => !x.IsDeleted && x.Id == item.Domain_Id, null, null).Select(x => new { x.TenDomain }).ToList();
                var hangtb = uow.hangThietBis.GetAll(x => !x.IsDeleted && x.Id == item.HangThietBi_Id, null, null).Select(x => new { x.TenHang }).ToList();
                var nhaCungCap = uow.NhaCungCaps.GetAll(x => !x.IsDeleted && x.Id == item.NhaCungCap_Id, null, null).Select(x => new { x.TenNhaCungCap }).ToList();

                var infor = new ClassThongTinThietBiDetail();
                infor.Id = item.Id;
                infor.MaThongTinThietBi = item.MaThongTinThietBi;
                infor.TenThietBi = item.TenThietBi;
                infor.SoSeri = item.SoSeri;
                infor.CauHinh = item.CauHinh;
                infor.ModelThietBi = item.ModelThietBi;
                infor.ThoiGianBaoHanh = item.ThoiGianBaoHanh;
                infor.TenNhaCungCap = nhaCungCap[0].TenNhaCungCap;
                infor.TenDomain = domain[0].TenDomain;
                infor.TenHang = hangtb[0].TenHang;
                infor.TenLoai = item.LstLoai[0].TenLoaiThietBi;
                list.Add(infor);
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "ChiTietLoaiThongTinThietBis" };
            var duLieu = uow.thongTinThietBis.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(ThongTinThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.thongTinThietBis.Exists(x => x.MaThongTinThietBi == data.MaThongTinThietBi && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaThongTinThietBi + " đã tồn tại trong hệ thống");
                else if (uow.thongTinThietBis.Exists(x => x.MaThongTinThietBi == data.MaThongTinThietBi && !x.IsDeleted))
                {
                    var thongtintb = uow.thongTinThietBis.GetAll(x => x.MaThongTinThietBi == data.MaThongTinThietBi).ToArray();
                    thongtintb[0].IsDeleted = false;
                    thongtintb[0].DeletedBy = null;
                    thongtintb[0].DeletedDate = null;
                    thongtintb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    thongtintb[0].UpdatedDate = DateTime.Now;
                    thongtintb[0].MaThongTinThietBi = data.MaThongTinThietBi;
                    thongtintb[0].TenThietBi = data.TenThietBi;
                    thongtintb[0].Domain_Id = data.Domain_Id;
                    thongtintb[0].HangThietBi_Id = data.HangThietBi_Id;
                    thongtintb[0].SoSeri = data.SoSeri;
                    thongtintb[0].ModelThietBi = data.ModelThietBi;
                    thongtintb[0].ThoiGianBaoHanh = data.ThoiGianBaoHanh;
                    thongtintb[0].CauHinh = data.CauHinh;
                    thongtintb[0].NhaCungCap_Id = data.NhaCungCap_Id;
                    uow.thongTinThietBis.Update(thongtintb[0]);
                    foreach (var item in data.LstLoai)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.ThongTinThietBi_Id = thongtintb[0].Id;
                        uow.chiTietLoaiThongTinThietBis.Add(item);
                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.thongTinThietBis.Add(data);
                    foreach (var item in data.LstLoai)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.ThongTinThietBi_Id = id;
                        uow.chiTietLoaiThongTinThietBis.Add(item);
                    }
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, ThongTinThietBi data)
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
                
                uow.thongTinThietBis.Update(data);
                var lstLoai = data.LstLoai;
                var dataCheck = uow.chiTietLoaiThongTinThietBis.GetAll(x => !x.IsDeleted && x.ThongTinThietBi_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!lstLoai.Exists(x => x.LoaiThietBi_Id == item.LoaiThietBi_Id))
                        {
                            uow.chiTietLoaiThongTinThietBis.Delete(item.Id);
                        }
                    }
                    foreach (var item in lstLoai)
                    {
                        if (!dataCheck.Exists(x => x.LoaiThietBi_Id == item.LoaiThietBi_Id))
                        {
                            item.ThongTinThietBi_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.chiTietLoaiThongTinThietBis.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in lstLoai)
                    {
                        item.ThongTinThietBi_Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        uow.chiTietLoaiThongTinThietBis.Add(item);
                    }
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
                ThongTinThietBi duLieu = uow.thongTinThietBis.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataCheck = uow.chiTietLoaiThongTinThietBis.GetAll(x => !x.IsDeleted && x.ThongTinThietBi_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.chiTietLoaiThongTinThietBis.Delete(item.Id);
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.thongTinThietBis.Update(duLieu);
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
                uow.thongTinThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
