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
    public class KhoController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public KhoController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";

            string[] include = {"DanhMucKho.User", "DanhMucKho", "DanhMucKho.DonVi",
                "khoThongTinThietBis", "khoThongTinThietBis.ThongTinThietBi", "khoThongTinThietBis.ThongTinThietBi.DanhMucThietBi", "khoThongTinThietBis.DonViTinh"};
            var data = uow.khos.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.DanhMucKho.MaKho,
                x.DanhMucKho.TenKho,
                x.DanhMucKho.DonVi_Id,
                x.DanhMucKho.User_Id,
/*
                LstLoai = x.khoLoaiThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                }),*/
                LstKhotttb = x.khoThongTinThietBis?.Select(y => new
                {
                    y.ThongTinThietBi.DanhMucThietBi.TenThietBi,
                    y.ThongTinThietBi.DanhMucThietBi.CauHinh,
                    y.ThongTinThietBi.ThoiGianBaoHanh,
                    y.ThongTinThietBi.SoSeri,
                    y.ThongTinThietBi.ModelThietBi,
                    y.DonViTinh.TenDonViTinh,
                    y.SoLuong,
                    y.TinhTrangThietBi

                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenKho));
        }



        [HttpGet("GetDataPagnigation")]
        public ActionResult GetDataPagnigation(int page = 1, int pageSize = 20, string keyword = null)
        {
            if (keyword == null) keyword = "";
            string[] include = { "DanhMucKho.User", "DanhMucKho", "DanhMucKho.DonVi",
                "khoThongTinThietBis", "khoThongTinThietBis.ThongTinThietBi", "khoThongTinThietBis.ThongTinThietBi.DanhMucThietBi", "khoThongTinThietBis.DonViTinh" };
            var query = uow.khos.GetAll(t => !t.IsDeleted, null, include)
            .Select(x => new
            {
                x.DanhMucKho,
                x.DanhMucKho_Id,
                x.DanhMucKho.TenKho,
                x.Id,
                x.DanhMucKho.MaKho,
                x.DanhMucKho.DonVi_Id,
                x.DanhMucKho.User_Id,
/*                LstLoai = x.khoLoaiThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                }),*/
                LstKhotttb = x.khoThongTinThietBis?.Select(y => new
                {
                    y.ThongTinThietBi.DanhMucThietBi.TenThietBi,
                    y.ThongTinThietBi.DanhMucThietBi.CauHinh,
                    y.ThongTinThietBi.ThoiGianBaoHanh,
                    y.ThongTinThietBi.SoSeri,
                    y.ThongTinThietBi.ModelThietBi,
                    y.DonViTinh.TenDonViTinh,
                    y.SoLuong,
                    y.TinhTrangThietBi

                })
            })
            .OrderBy(x => x.TenKho);
            List<ClassListKho> list = new List<ClassListKho>();

            foreach (var item in query)
            {
                var donvi = uow.DonVis.GetAll(x => !x.IsDeleted && x.Id == item.DanhMucKho.DonVi_Id, null, null).Select(x => new { x.TenDonVi }).ToList();
                var danhmmuckho = uow.danhMucKhos.GetAll(x => !x.IsDeleted && x.Id == item.DanhMucKho_Id, null, null).Select(x => new { x.TenKho }).ToList();

                var infor = new ClassListKho();
                infor.Id = item.Id;
                infor.TenKho = item.TenKho;
                infor.MaKho = item.MaKho;
                infor.TenDonVi = donvi[0].TenDonVi;
                var ttbt = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == item.Id, null, null).Select(x => new { x.ThongTinThietBi }).ToList();
                var ttbtdvt = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == item.Id, null, null).Select(x => new { x.DonViTinh }).ToList();
                var ttbt2 = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == item.Id, null, null).ToList();
                foreach (var x in ttbt)
                {
                    infor.TenThietBi = ttbt[0].ThongTinThietBi.DanhMucThietBi.TenThietBi;
                    infor.MaThietBi = ttbt[0].ThongTinThietBi.DanhMucThietBi.MaThietBi;
                    infor.Cauhinh = ttbt[0].ThongTinThietBi.DanhMucThietBi.CauHinh;
                    infor.SoSeri = ttbt[0].ThongTinThietBi.SoSeri;
                    infor.ModelThietBi = ttbt[0].ThongTinThietBi.ModelThietBi;
                    infor.TinhTrangThietBi = ttbt2[0].TinhTrangThietBi;
                    infor.SoLuong = ttbt2[0].SoLuong;
                    infor.DonViTinh = ttbtdvt[0].DonViTinh.TenDonViTinh;
                }
                list.Add(infor);
            }
            int totalRow = list.Count();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(new { data, totalPage, totalRow });
        }
        public class ClassKhoDetail
        {
            public Guid Id { get; set; }
            public string MaKho { get; set; }
            public string TenKho { get; set; }
            public string UserName { get; set; }
            public string LoaiThietBi { get; set; }
            public string TenThietBi { get; set; }
            public string CauHinh { get; set; }
            public string ThoiGianBaoHanh { get; set; }
            public string SoSeri { get; set; }
            public string ModelThietBi { get; set; }
            public string TenDonViTinh { get; set; }
            public string SoLuong { get; set; }
            public string TinhTrangThietBi { get; set; }


        }

        [HttpGet("GetKhoDetail/{id}")]
        public ActionResult GetKhoDetail(Guid id)
        {
            string[] include = { "User", "DanhMucKho", "DonVi",
                "khoThongTinThietBis", "khoThongTinThietBis.ThongTinThietBi", "khoThongTinThietBis.DonViTinh" };
            var query = uow.khos.GetAll(t => !t.IsDeleted, null, include)
            .Select(x => new
            {
                x.DanhMucKho,
                x.DanhMucKho_Id,
                x.DanhMucKho.TenKho,
                x.Id,
                x.DanhMucKho.MaKho,
                x.DanhMucKho.DonVi.TenDonVi,
                x.DanhMucKho.User.FullName,
/*                LstLoai = x.khoLoaiThietBis.Select(y => new
                {
                    y.LoaiThietBi.TenLoaiThietBi,
                }),*/
                LstKhotttb = x.khoThongTinThietBis.Select(y => new
                {
                    y.ThongTinThietBi.DanhMucThietBi.TenThietBi,
                    y.ThongTinThietBi.DanhMucThietBi.CauHinh,
                    y.ThongTinThietBi.ThoiGianBaoHanh,
                    y.ThongTinThietBi.SoSeri,
                    y.ThongTinThietBi.ModelThietBi,
                    y.DonViTinh.TenDonViTinh,
                    y.SoLuong,
                    y.TinhTrangThietBi,
                })
            })
            .OrderBy(x => x.TenKho);
            List<ClassListKho> list = new List<ClassListKho>();

            foreach (var item in query)
            {
                var donvi = uow.DonVis.GetAll(x => !x.IsDeleted && x.Id == item.DanhMucKho.DonVi_Id, null, null).Select(x => new { x.TenDonVi }).ToList();
                var danhmmuckho = uow.danhMucKhos.GetAll(x => !x.IsDeleted && x.Id == item.DanhMucKho_Id, null, null).Select(x => new { x.TenKho }).ToList();

                var infor = new ClassListKho();
                infor.Id = item.Id;
                infor.TenKho = item.TenKho;
                infor.MaKho = item.MaKho;
                infor.TenDonVi = donvi[0].TenDonVi;
                list.Add(infor);
            }
            return Ok(list);
        }


        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User", "DanhMucKho", "DonVi", "khoLoaiThietBis", "khoLoaiThietBis.LoaiThietBi",
                "khoThongTinThietBis", "khoThongTinThietBis.ThongTinThietBi", "khoThongTinThietBis.DonViTinh" };
            var duLieu = uow.khos.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }


        [HttpPost]
        public ActionResult Post(Kho data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.khos.Exists(x => x.Id == data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.DanhMucKho.TenKho + " đã tồn tại trong hệ thống");
                else if (uow.khos.Exists(x => x.Id==data.Id && x.IsDeleted))
                {
                    var kho = uow.khos.GetAll(x => x.Id == data.Id).ToArray();
                    kho[0].IsDeleted = false;
                    kho[0].DeletedBy = null;
                    kho[0].DeletedDate = null;
                    kho[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    kho[0].UpdatedDate = DateTime.Now;
                    kho[0].DanhMucKho_Id = data.DanhMucKho_Id;

                    
 
                    uow.khos.Update(kho[0]);
/*                    foreach (var item in data.LstLoai)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.Kho_Id = kho[0].Id;
                        uow.khoLoaiThietBis.Add(item);
                    }*/
                    foreach (var item in data.LstKhotttb)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.Kho_Id = kho[0].Id;
                        uow.khoThongTinThietBis.Add(item);
                    }
                }
                else
                {
                    var kho = uow.khos.GetAll(x => x.Id == data.Id).ToArray();
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
 
                    uow.khos.Add(data);
/*                    foreach (var item in data.LstLoai)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.Kho_Id = id;
                        uow.khoLoaiThietBis.Add(item);
                    }*/
                    foreach (var item in data.LstKhotttb)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.Kho_Id = data.Id;
                        uow.khoThongTinThietBis.Add(item);
                    }
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, Kho data)
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
                if (uow.khos.Exists(x => x.Id == data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.DanhMucKho.TenKho + " đã tồn tại trong hệ thống");
                else if (uow.khos.Exists(x => x.Id == data.Id && x.IsDeleted))
                {
                    var kho = uow.khos.GetAll(x => x.Id == data.Id).ToArray();
                    kho[0].IsDeleted = false;
                    kho[0].DeletedBy = null;
                    kho[0].DeletedDate = null;
                    kho[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    kho[0].UpdatedDate = DateTime.Now;
                    kho[0].DanhMucKho_Id = data.DanhMucKho_Id;

                  

                    uow.khos.Update(kho[0]);
                }
                else
                {
                    data.UpdatedBy = Guid.Parse(User.Identity.Name);
                    data.UpdatedDate = DateTime.Now;
                    uow.khos.Update(data);
                }
                var lstkhotttb = data.LstKhotttb;
                var dataChecktttb = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == data.Id).ToList();
                if (dataChecktttb.Count() > 0)
                {
                    foreach (var item in dataChecktttb)
                    {
                        if (!lstkhotttb.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            uow.khoThongTinThietBis.Delete(item.Id);
                        }
                    }
                    foreach (var item in lstkhotttb)
                    {
                        if (!dataChecktttb.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            item.Kho_Id = data.Id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.khoThongTinThietBis.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in lstkhotttb)
                    {
                        item.Kho_Id = data.Id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        uow.khoThongTinThietBis.Add(item);
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
                Kho duLieu = uow.khos.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataCheck = uow.khoLoaiThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.khoLoaiThietBis.Delete(item.Id);
                    }
                    var kho = uow.khos.GetAll(x => x.Id == id).ToArray();
                    var dataChecktttb = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == kho[0].Id).ToList();
                    foreach (var item in dataChecktttb)
                    {
                        uow.khoThongTinThietBis.Delete(item.Id);
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.khos.Update(duLieu);
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
                uow.khos.Delete(id);
                uow.Complete();
                return Ok();
            }
        }




    }
}
