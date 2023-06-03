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
    public class DieuChuyenThietBiController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public DieuChuyenThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";

            string[] include = { "User", "Kho", "DonVi", "nguoiNhanDieuChuyens", "nguoiNhanDieuChuyens.User" };
            var data = uow.dieuChuyenThietBis.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.Kho?.DanhMucKho_Id,
                x.MaDieuChuyen,
                x.User,
                x.NgayDieuChuyen,
                x.DonVi_Id,
                Lstnndc = x.nguoiNhanDieuChuyens.Select(y => new
                {
                    y.User.MaNhanVien,
                    y.User.FullName,
                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaDieuChuyen));
        }

        public class ClassListDieuChuyenTB
        {
            public Guid Id { get; set; }
            public string MaDieuChuyen { get; set; }
            public string Tenkho { get; set; }
            public string DonVi { get; set; }
            public string MaThietBi { get; set; }
            public string TenThietBi { get; set; }
            public string CauHinh { get; set; }
            public int SoLuong { get; set; }
            public string DonViTinh { get; set; }
            public string TinhTrangMay { get; set; }
            public string NguoiNhanDieuChuyen { get; set; }
            public string TenDonViNguoiNhan { get; set; }
            public string TenPhongBanNguoiNhan { get; set; }
            public string NguoiLapDieuChuyen { get; set; }
            public DateTime NgayDieuChuyen { get; set; }


        }

        [HttpGet("GetDataPagnigation")]
        public ActionResult GetDataPagnigation(int page = 1, int pageSize = 20, string keyword = null)
        {
            if (keyword == null) keyword = "";
            string[] include = { "User", "Kho", "DonVi", "nguoiNhanDieuChuyens", "nguoiNhanDieuChuyens.User" };
            var query = uow.dieuChuyenThietBis.GetAll(t => !t.IsDeleted && (t.MaDieuChuyen.ToLower().Contains(keyword.ToLower()) || t.MaDieuChuyen.ToLower().Contains(keyword.ToLower())), null, include)
            .Select(x => new
            {
                x.MaDieuChuyen,
                x.Id,
                x.User?.FullName,
                x.Kho_Id,
                x.Kho.DanhMucKho_Id,
                x.NgayDieuChuyen,
                x.DonVi.TenDonVi,
                Lstnndc = x.nguoiNhanDieuChuyens.Select(y => new
                {
                    y.User.FullName,
                    y.User.Phongban,
                    y.User.DonVi
                }),

            })
            .OrderBy(x => x.MaDieuChuyen);
            List<ClassListDieuChuyenTB> list = new List<ClassListDieuChuyenTB>();

            foreach (var item in query)
            {
                 
                var khotttb = uow.danhMucKhos.GetAll(x => !x.IsDeleted && x.Id == item.DanhMucKho_Id, null, null).Select(x => new { x.TenKho }).ToList();             
                var infor = new ClassListDieuChuyenTB();
                infor.Id = item.Id;
                infor.MaDieuChuyen = item.MaDieuChuyen;
                infor.Tenkho = khotttb[0].TenKho;
                infor.DonVi = item.TenDonVi;
                var tbtt = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == item.Kho_Id, null, null).Select(x => new { x.ThongTinThietBi_Id, x.SoLuong, x.DonViTinh.TenDonViTinh, x.TinhTrangThietBi }).ToList();
                var kho = uow.khoThongTinThietBis.GetAll(x => !x.IsDeleted && x.Kho_Id == item.Kho_Id, null, null).Select(x => new { x.TinhTrangThietBi }).ToList();
                foreach (var l in tbtt)
                {
                    var tenthietbi = uow.thongTinThietBis.GetAll(x => !x.IsDeleted && x.Id == l.ThongTinThietBi_Id, null, null).Select(x => new { x.DanhMucThietBi.TenThietBi }).ToList();
                    var mathietbi = uow.thongTinThietBis.GetAll(x => !x.IsDeleted && x.Id == l.ThongTinThietBi_Id, null, null).Select(x => new { x.DanhMucThietBi.MaThietBi }).ToList();
                    var cauhinh = uow.thongTinThietBis.GetAll(x => !x.IsDeleted && x.Id == l.ThongTinThietBi_Id, null, null).Select(x => new { x.DanhMucThietBi.CauHinh }).ToList();
                    infor.MaThietBi = mathietbi[0].MaThietBi;
                    infor.TenThietBi = tenthietbi[0].TenThietBi;
                    infor.CauHinh = cauhinh[0].CauHinh;

                }
                infor.SoLuong = tbtt[0].SoLuong;
                infor.DonViTinh = tbtt[0].TenDonViTinh;
                infor.TinhTrangMay = tbtt[0].TinhTrangThietBi;
                infor.NgayDieuChuyen = item.NgayDieuChuyen;
                var nvnn = uow.nguoiNhanDieuChuyens.GetAll(x => !x.IsDeleted && x.DieuChuyenThietBi_Id == item.Id, null, null).Select(x => new { x.User }).ToList();
                foreach (var nn in nvnn)
                {
                    var donvinhan = uow.DonVis.GetAll(x => !x.IsDeleted && x.Id == nn.User.DonVi_Id, null, null).Select(x => new { x.TenDonVi }).ToList();
                    var bophannhan = uow.BoPhans.GetAll(x => !x.IsDeleted && x.Id == nn.User.BoPhan_Id, null, null).Select(x => new { x.TenBoPhan }).ToList();
                    var phongbannhan = uow.phongbans.GetAll(x => !x.IsDeleted && x.Id == nn.User.PhongBan_Id, null, null).Select(x => new { x.TenPhongBan }).ToList();
                    var chucvunhan = uow.chucVus.GetAll(x => !x.IsDeleted && x.Id == nn.User.ChucVu_Id, null, null).Select(x => new { x.TenChucVu }).ToList();
                    foreach (var x in nvnn)
                    {
                        infor.NguoiNhanDieuChuyen = nvnn[0].User.FullName;
                        infor.TenDonViNguoiNhan = donvinhan[0].TenDonVi;
                        infor.TenPhongBanNguoiNhan = phongbannhan[0].TenPhongBan;
                    }
                }
                infor.NguoiLapDieuChuyen = item.FullName;
                list.Add(infor);
            }
            int totalRow = list.Count();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(new { data, totalPage, totalRow });
        }


        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User", "Kho", "DonVi", "nguoiNhanDieuChuyens", "nguoiNhanDieuChuyens.User" };
            var duLieu = uow.dieuChuyenThietBis.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(DieuChuyenThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.dieuChuyenThietBis.Exists(x => x.Id == data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaDieuChuyen + " đã tồn tại trong hệ thống");
                else if (uow.khos.Exists(x => x.Id == data.Id && x.IsDeleted))
                {
                    var banGiaotb = uow.dieuChuyenThietBis.GetAll(x => x.Id == data.Id).ToArray();
                    banGiaotb[0].IsDeleted = false;
                    banGiaotb[0].DeletedBy = null;
                    banGiaotb[0].DeletedDate = null;
                    banGiaotb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    banGiaotb[0].UpdatedDate = DateTime.Now;
                    banGiaotb[0].MaDieuChuyen = data.MaDieuChuyen;
                    banGiaotb[0].Kho_Id = data.Kho_Id;
                    banGiaotb[0].NgayDieuChuyen = data.NgayDieuChuyen;
                    banGiaotb[0].DonVi_Id = data.DonVi_Id;
                    banGiaotb[0].User_Id = data.User_Id;


                    uow.dieuChuyenThietBis.Update(banGiaotb[0]);
                    foreach (var item in data.Lstnndc)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.DieuChuyenThietBi_Id = banGiaotb[0].Id;
                        uow.nguoiNhanDieuChuyens.Add(item);
                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);

                    uow.dieuChuyenThietBis.Add(data);
                    foreach (var item in data.Lstnndc)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.DieuChuyenThietBi_Id = id;
                        uow.nguoiNhanDieuChuyens.Add(item);
                    }
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, DieuChuyenThietBi data)
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
                if (uow.dieuChuyenThietBis.Exists(x => x.Id == data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaDieuChuyen + " đã tồn tại trong hệ thống");
                else if (uow.khos.Exists(x => x.Id == data.Id && x.IsDeleted))
                {
                    var banGiaotb = uow.dieuChuyenThietBis.GetAll(x => x.Id == data.Id).ToArray();
                    banGiaotb[0].IsDeleted = false;
                    banGiaotb[0].DeletedBy = null;
                    banGiaotb[0].DeletedDate = null;
                    banGiaotb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    banGiaotb[0].UpdatedDate = DateTime.Now;
                    banGiaotb[0].MaDieuChuyen = data.MaDieuChuyen;
                    banGiaotb[0].Kho_Id = data.Kho_Id;
                    banGiaotb[0].NgayDieuChuyen = data.NgayDieuChuyen;
                    banGiaotb[0].DonVi_Id = data.DonVi_Id;
                    banGiaotb[0].User_Id = data.User_Id;


                    uow.dieuChuyenThietBis.Update(banGiaotb[0]);
                }
                else
                {
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.dieuChuyenThietBis.Update(data);
                }
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.dieuChuyenThietBis.Update(data);
                var Lstnndc = data.Lstnndc;
                var dataCheck = uow.nguoiNhanDieuChuyens.GetAll(x => !x.IsDeleted && x.DieuChuyenThietBi_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!Lstnndc.Exists(x => x.User_Id == item.User_Id))
                        {
                            uow.nguoiNhanDieuChuyens.Delete(item.Id);
                        }
                    }
                    foreach (var item in Lstnndc)
                    {
                        if (!dataCheck.Exists(x => x.User_Id == item.User_Id))
                        {
                            item.DieuChuyenThietBi_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.nguoiNhanDieuChuyens.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in Lstnndc)
                    {
                        item.DieuChuyenThietBi_Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        uow.nguoiNhanDieuChuyens.Add(item);
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
                DieuChuyenThietBi duLieu = uow.dieuChuyenThietBis.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataCheck = uow.nguoiNhanDieuChuyens.GetAll(x => !x.IsDeleted && x.DieuChuyenThietBi_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.nguoiNhanDieuChuyens.Delete(item.Id);
                    }
                   
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.dieuChuyenThietBis.Update(duLieu);
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
                uow.dieuChuyenThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }

    }
}
