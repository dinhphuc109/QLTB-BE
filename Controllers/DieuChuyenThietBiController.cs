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

            string[] include = { "User", "Kho", "DonVi", "DieuChuyenThietBi_Khos", "DieuChuyenThietBi_Khos.TinhTrangThietBi", "DieuChuyenThietBi_Khos.ThongTinThietBi" };
            var data = uow.dieuChuyenThietBis.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.Kho?.DanhMucKho_Id,
                x.MaDieuChuyen,
                x.UserLap_Id,
                x.UserNhan_Id,
                x.NgayDieuChuyen,
                Lstkho = x.DieuChuyenThietBi_Khos.Select(y => new
                {
                    y.ThongTinThietBi_Id,
                    y.SoLuong,
                    y.GhiChu,
                    y.TinhTrangThietBi_Id,
                })

            }); 
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaDieuChuyen));
        }

        [HttpGet("search-dieu-chuyen-thiet-bi")]
        public IActionResult SearchDieuChuyenThietBi(string keyword, DateTime? TuNgay, DateTime? DenNgay)
        {
            if (keyword == null) keyword = "";
            string[] include = { "User", "Kho", "DonVi", "DieuChuyenThietBi_Khos", "DieuChuyenThietBi_Khos.TinhTrangThietBi", "DieuChuyenThietBi_Khos.ThongTinThietBi" };
            var data = uow.dieuChuyenThietBis.GetAll(x => !x.IsDeleted
            && x.NgayDieuChuyen >= TuNgay && x.NgayDieuChuyen <= DenNgay, null, include).Select(x => new
            {
                x.Id,
                x.Kho?.DanhMucKho_Id,
                x.UserLap_Id,
                x.UserNhan_Id,
                x.MaDieuChuyen,
                x.User,
                x.NgayDieuChuyen,
                Lstkho = x.DieuChuyenThietBi_Khos.Select(y => new
                {
                    y.ThongTinThietBi_Id,
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


        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User", "Kho", "DonVi", "DieuChuyenThietBi_Khos", "DieuChuyenThietBi_Khos.TinhTrangThietBi", "DieuChuyenThietBi_Khos.ThongTinThietBi" };
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
                if (uow.dieuChuyenThietBis.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaDieuChuyen + " đã tồn tại trong hệ thống");
                else if (uow.dieuChuyenThietBis.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && x.IsDeleted))
                {
                    var dieuchuyentb = uow.dieuChuyenThietBis.GetAll(x => x.MaDieuChuyen == data.MaDieuChuyen).ToArray();
                    dieuchuyentb[0].IsDeleted = false;
                    dieuchuyentb[0].DeletedBy = null;
                    dieuchuyentb[0].DeletedDate = null;
                    dieuchuyentb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    dieuchuyentb[0].UpdatedDate = DateTime.Now;
                    dieuchuyentb[0].MaDieuChuyen = data.MaDieuChuyen;
                    dieuchuyentb[0].Kho_Id = data.Kho_Id;
                    dieuchuyentb[0].NgayDieuChuyen = data.NgayDieuChuyen;
                    dieuchuyentb[0].UserLap_Id = data.UserLap_Id;
                    dieuchuyentb[0].UserNhan_Id = data.UserNhan_Id;


                    uow.dieuChuyenThietBis.Update(dieuchuyentb[0]);
                    foreach( var item in data.Lstkho)
                    {
                        var tttb = uow.khoThongTinThietBis.GetAll(t => !t.IsDeleted  && t.Id == item.ThongTinThietBi_Id).ToArray();
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.DieuChuyenThietBi_Id = dieuchuyentb[0].Id;
                     
                        uow.dieuChuyenThietBiKhos.Add(item);
 
                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);

                    uow.dieuChuyenThietBis.Add(data);
                    var kho = uow.khos.GetAll(x => x.Id == data.Kho_Id).ToArray();
                    
                    foreach (var item in data.Lstkho)
                    {
                            var ktb = uow.khoThongTinThietBis.GetAll(t => !t.IsDeleted  && t.ThongTinThietBi_Id == item.ThongTinThietBi_Id).ToArray();
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            item.CreatedDate = DateTime.Now;
                            item.DieuChuyenThietBi_Id = id;                  
                            uow.dieuChuyenThietBiKhos.Add(item);
                            uow.khoThongTinThietBis.Delete(ktb[0].Id);
                
                        
                        LichSuThietBi lichsuthietbi = new LichSuThietBi();
                        if (data.Kho_Id != null)
                        {

                            var lichsutb = uow.lichSuThietBis.GetAll(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id && x.NgayKetThuc == null).ToArray();
                            if (!uow.lichSuThietBis.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                                {
                                    Guid lstbid = Guid.NewGuid();
                                /*UserInfoModel model;
                                model.Id = item2.User_Id.ToString();*/
                                lichsutb[0].NgayKetThuc = DateTime.Now;
                                uow.lichSuThietBis.Update(lichsutb[0]);
                                var appUser = userManager.FindByIdAsync(data.UserNhan_Id.ToString()).Result;
                                    lichsuthietbi.CreatedBy = Guid.Parse(User.Identity.Name);
                                    lichsuthietbi.CreatedDate = DateTime.Now;
                                    lichsuthietbi.Id = lstbid;
                                    lichsuthietbi.User_Id = data.UserNhan_Id;
                                    lichsuthietbi.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                                    lichsuthietbi.DonVi_Id = appUser.DonVi_Id;
                                    lichsuthietbi.PhongBan_Id = appUser.PhongBan_Id;
                                    lichsuthietbi.BoPhan_Id = appUser.BoPhan_Id;
                                    lichsuthietbi.ChucVu_Id = appUser.ChucVu_Id;
                                    lichsuthietbi.DonViTraLuong_Id = appUser.DonViTraLuong_Id;
                                    lichsuthietbi.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                                    lichsuthietbi.TinhTrangThietBi = item.TinhTrangThietBi;
                                    lichsuthietbi.NgayBatDau = DateTime.Now;
                                    lichsuthietbi.NgayKetThuc = null;
                                    uow.lichSuThietBis.Add(lichsuthietbi);
                                }
                                else if (uow.lichSuThietBis.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                                {
                                    Guid lstbid = Guid.NewGuid();
                                    var existingLichSu = uow.lichSuThietBis.GetAll(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id && x.NgayKetThuc == null).ToArray();
                                /*existingLichSu[0].NgayKetThuc = DateTime.Now;
                                uow.lichSuThietBis.Update(existingLichSu[0]);*/
                                lichsutb[0].NgayKetThuc = DateTime.Now;
                                uow.lichSuThietBis.Update(lichsutb[0]);
                                var appUser = userManager.FindByIdAsync(data.UserNhan_Id.ToString()).Result;
                                    lichsuthietbi.CreatedBy = Guid.Parse(User.Identity.Name);
                                    lichsuthietbi.CreatedDate = DateTime.Now;
                                    lichsuthietbi.Id = lstbid;
                                    lichsuthietbi.User_Id = data.UserNhan_Id;
                                    lichsuthietbi.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                                    lichsuthietbi.DonVi_Id = appUser.DonVi_Id;
                                    lichsuthietbi.PhongBan_Id = appUser.PhongBan_Id;
                                    lichsuthietbi.BoPhan_Id = appUser.BoPhan_Id;
                                    lichsuthietbi.ChucVu_Id = appUser.ChucVu_Id;
                                    lichsuthietbi.DonViTraLuong_Id = appUser.DonViTraLuong_Id;
                                    lichsuthietbi.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                                    lichsuthietbi.TinhTrangThietBi = item.TinhTrangThietBi;
                                    lichsuthietbi.NgayBatDau = DateTime.Now;
                                    lichsuthietbi.NgayKetThuc = null;
                                    uow.lichSuThietBis.Add(lichsuthietbi);
                                }
                            }

                        
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
                LichSuThietBi lichsuthietbi = new LichSuThietBi();
                if (uow.dieuChuyenThietBis.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaDieuChuyen + " đã tồn tại trong hệ thống");
                else if (uow.dieuChuyenThietBis.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && x.Id != data.Id && x.IsDeleted))
                {
                    var dieuchuyentb = uow.dieuChuyenThietBis.GetAll(x => x.MaDieuChuyen == data.MaDieuChuyen).ToArray();
                    dieuchuyentb[0].IsDeleted = false;
                    dieuchuyentb[0].DeletedBy = null;
                    dieuchuyentb[0].DeletedDate = null;
                    dieuchuyentb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    dieuchuyentb[0].UpdatedDate = DateTime.Now;
                    dieuchuyentb[0].MaDieuChuyen = data.MaDieuChuyen;
                    dieuchuyentb[0].Kho_Id = data.Kho_Id;
                    dieuchuyentb[0].NgayDieuChuyen = data.NgayDieuChuyen;
                    dieuchuyentb[0].UserLap_Id = data.UserLap_Id;
                    dieuchuyentb[0].UserNhan_Id = data.UserNhan_Id;
                    uow.dieuChuyenThietBis.Update(dieuchuyentb[0]);
                    foreach( var item in data.Lstkho)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.DieuChuyenThietBi_Id = dieuchuyentb[0].Id;
                        uow.dieuChuyenThietBiKhos.Add(item);
                    }
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
                var Lstkho = data.Lstkho;
                var dataCheckkho = uow.dieuChuyenThietBiKhos.GetAll(x => !x.IsDeleted && x.DieuChuyenThietBi_Id == id).ToList();
                if (dataCheckkho.Count() > 0)
                {
                    foreach (var item in dataCheckkho)
                    {
                        if (!Lstkho.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            Guid ktbid = Guid.NewGuid();
                            var ktb = uow.khoThongTinThietBis.GetAll(t => !t.IsDeleted && t.ThongTinThietBi_Id == item.ThongTinThietBi_Id).ToArray();
                            var lstb = uow.lichSuThietBis.GetAll(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id).ToArray();
                            ktb[0].ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                            ktb[0].Id = ktbid;
                            ktb[0].Kho_Id = data.Kho_Id;
                            ktb[0].TinhTrangThietBi_Id = item.TinhTrangThietBi_Id;
                            uow.khoThongTinThietBis.Add(ktb[0]);
                            uow.lichSuThietBis.Delete(lstb[0].Id);
                            uow.dieuChuyenThietBiKhos.Delete(item.Id);
                            
                            
                        }
                    }
                    foreach (var item in Lstkho)
                    {
                        if (!dataCheckkho.Exists(x => x.DieuChuyenThietBi_Id == item.DieuChuyenThietBi_Id))
                        {
                            var ktb = uow.khoThongTinThietBis.GetAll(t => !t.IsDeleted && t.ThongTinThietBi_Id == item.ThongTinThietBi_Id).ToArray();
                            item.DieuChuyenThietBi_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.dieuChuyenThietBiKhos.Add(item);
                            uow.khoThongTinThietBis.Delete(ktb[0].Id);
                            Guid lstbid = Guid.NewGuid();
                            /*UserInfoModel model;
                            model.Id = item2.User_Id.ToString();*/
                            var appUser = userManager.FindByIdAsync(data.UserNhan_Id.ToString()).Result;
                            lichsuthietbi.CreatedBy = Guid.Parse(User.Identity.Name);
                            lichsuthietbi.CreatedDate = DateTime.Now;
                            lichsuthietbi.Id = lstbid;
                            lichsuthietbi.User_Id = data.UserNhan_Id;
                            lichsuthietbi.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                            lichsuthietbi.DonVi_Id = appUser.DonVi_Id;
                            lichsuthietbi.PhongBan_Id = appUser.PhongBan_Id;
                            lichsuthietbi.BoPhan_Id = appUser.BoPhan_Id;
                            lichsuthietbi.ChucVu_Id = appUser.ChucVu_Id;
                            lichsuthietbi.DonViTraLuong_Id = appUser.DonViTraLuong_Id;
                            lichsuthietbi.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                            lichsuthietbi.TinhTrangThietBi_Id = item.TinhTrangThietBi_Id;
                            lichsuthietbi.NgayBatDau = DateTime.Now;
                            lichsuthietbi.NgayKetThuc = null;
                            uow.lichSuThietBis.Add(lichsuthietbi);
                        }
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
                    var dataChecktttb = uow.dieuChuyenThietBiKhos.GetAll(x => !x.IsDeleted && x.DieuChuyenThietBi_Id == id).ToList();
                    foreach (var item in dataChecktttb)
                    {
                        var lstb = uow.lichSuThietBis.GetAll(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id).ToArray();
                        uow.dieuChuyenThietBiKhos.Delete(item.Id);
                        uow.lichSuThietBis.Delete(lstb[0].Id);
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
