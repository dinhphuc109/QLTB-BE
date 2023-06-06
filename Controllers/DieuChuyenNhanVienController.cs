using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DieuChuyenNhanVienController : ControllerBase
    {
        private readonly IMyAdapter myAdapter;
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public DieuChuyenNhanVienController(IMyAdapter _myAdapter, IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
            myAdapter = _myAdapter;
        }
        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";

            string[] include = { "User", "DonVi", "BoPhan", "Phongban", "ChucVu" };
            var data = uow.dieuChuyenNhanViens.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.MaNhanVien,
                x.User.FullName,
                x.DonVi_Id,
                x.PhongBan_Id,
                x.BoPhan_Id,
                x.ChucVu_Id,
                x.DonViTraLuong_Id,
                x.DonViNew_Id,
                x.PhongBanNew_Id,
                x.BoPhanNew_Id,
                x.ChucVuNew_Id,
                x.DonViTraLuongNew_Id,
                x.NgayDieuChuyen,

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaNhanVien));
        }

        public class DropdownItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }
        }


        [HttpGet("dropdown")]
        public IActionResult GetDropdownData()
        {
            var dropdownData = new List<DropdownItem>();

            // Lấy danh sách đơn vị và thêm vào dropdownData với Level = 0
            var donvis = uow.DonVis.GetAll(x=>!x.IsDeleted);
            foreach (var donvi in donvis)
            {
                dropdownData.Add(new DropdownItem
                {
                    Id = donvi.Id,
                    Name = donvi.TenDonVi,
                    Level = 0
                });
            }

            // Lấy danh sách phòng ban và thêm vào dropdownData với Level = 1
            var phongbans = uow.phongbans.GetAll(x => !x.IsDeleted);
            foreach (var phongban in phongbans)
            {
                dropdownData.Add(new DropdownItem
                {
                    Id = phongban.Id,
                    Name = phongban.TenPhongBan,
                    Level = 1
                });
            }

            // Lấy danh sách bộ phận và thêm vào dropdownData với Level = 2
            var bophans = uow.BoPhans.GetAll(x => !x.IsDeleted);
            foreach (var bophan in bophans)
            {
                dropdownData.Add(new DropdownItem
                {
                    Id = bophan.Id,
                    Name = bophan.TenBoPhan,
                    Level = 2
                });
            }

            var chucvus=uow.chucVus.GetAll(x => !x.IsDeleted);
            foreach(var chucvu in chucvus)
            {
                dropdownData.Add(new DropdownItem
                {
                    Id = chucvu.Id,
                    Name = chucvu.TenChucVu,
                    Level = 3
                });
            }

            // Sắp xếp dropdownData theo thứ tự đơn vị, phòng ban, bộ phận, chức vụ
            dropdownData = dropdownData.OrderBy(item => item.Level).ToList();

            return Ok(dropdownData);
        }


        [HttpPost]
        public ActionResult Post(List<DieuChuyenNhanVien> data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.dieuChuyenNhanViens.Exists(x => x.MaNhanVien == data[0].MaNhanVien && !x.IsDeleted))
                {
                    foreach (var item in data)
                    {
                        var existingDieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.User_Id == data[0].User_Id).ToArray();
                        var donvi = uow.DonVis.GetAll(x => x.Id == data[0].DonVi_Id).ToArray();
                        if (donvi == null)
                        {
                            // Trả về lỗi nếu đơn vị không tồn tại
                            return BadRequest("đơn vị không tồn tạo.");
                        }
                        var phongban = uow.phongbans.GetAll(x => x.Id == data[0].PhongBan_Id && x.DonVi_Id == data[0].DonVi_Id).ToArray();
                        if (phongban == null)
                        {
                            return BadRequest("not found.");
                        }
                        var bophan = uow.BoPhans.GetAll(x => x.Id == data[0].BoPhan_Id && x.PhongBan_Id == data[0].PhongBan_Id).ToArray();
                        if (bophan == null)
                        {
                            return BadRequest("not found.");
                        }
                        var chucvu = uow.chucVus.GetAll(x => x.Id == data[0].ChucVu_Id && x.BoPhan_Id == data[0].BoPhan_Id).ToArray();
                        if (chucvu == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvitraluong = uow.donViTraLuongs.GetAll(x => x.Id == data[0].DonViTraLuong_Id).ToArray();
                        if (donvitraluong == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvimoi = uow.DonVis.GetAll(x => x.Id == data[0].DonVi_Id).ToArray();
                        if (donvimoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var phongbanmoi = uow.phongbans.GetAll(x => x.Id == data[0].PhongBan_Id && x.DonVi_Id == data[0].DonVi_Id).ToArray();
                        if (phongbanmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var bophanmoi = uow.BoPhans.GetAll(x => x.Id == data[0].BoPhan_Id && x.PhongBan_Id == data[0].PhongBan_Id).ToArray();
                        if (bophanmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var chucvumoi = uow.chucVus.GetAll(x => x.Id == data[0].ChucVu_Id && x.BoPhan_Id == data[0].BoPhan_Id).ToArray();
                        if (chucvumoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvitraluongmoi = uow.donViTraLuongs.GetAll(x => x.Id == data[0].DonViTraLuong_Id).ToArray();
                        if (donvitraluongmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        Guid dcnvId = Guid.NewGuid();
                        data[0].Id = dcnvId;
                        data[0].CreatedDate = DateTime.Now;
                        data[0].CreatedBy = Guid.Parse(User.Identity.Name);
                        data[0].DonVi_Id = donvi[0].Id;
                        data[0].PhongBan_Id = phongban[0].Id;
                        data[0].BoPhan_Id = bophan[0].Id;
                        data[0].ChucVu_Id = chucvu[0].Id;
                        data[0].DonViTraLuong_Id = donvitraluong[0].Id;
                        data[0].DonViNew_Id = donvimoi[0].Id;
                        data[0].ChucVuNew_Id = chucvumoi[0].Id;
                        data[0].PhongBanNew_Id = phongbanmoi[0].Id;
                        data[0].BoPhanNew_Id = bophanmoi[0].Id;
                        data[0].DonViTraLuongNew_Id = donvitraluongmoi[0].Id;
                        data[0].NgayDieuChuyen = DateTime.Now;
                        uow.dieuChuyenNhanViens.Add(data[0]);
                        var appUser = userManager.FindByIdAsync(data[0].User_Id.ToString()).Result;
                        appUser.DonVi_Id = donvimoi[0].Id;
                        appUser.PhongBan_Id = phongbanmoi[0].Id;
                        appUser.BoPhan_Id = bophanmoi[0].Id;
                        appUser.ChucVu_Id = chucvumoi[0].Id;
                        appUser.DonViTraLuong_Id = donvitraluongmoi[0].Id;
                        userManager.UpdateAsync(appUser);
                        LichSuThietBi lichSuThietBi = new LichSuThietBi();
                        //thêm vòng lặp chứ không sai!! chưa thêm
                        if (uow.lichSuThietBis.Exists(x => x.User_Id == data[0].User_Id))
                        {
                            var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == data[0].User_Id && x.NgayKetThuc == null).ToArray();
                            foreach(var item2 in lichsutb)
                            {
                                lichsutb[0].NgayKetThuc = DateTime.Now;
                                uow.lichSuThietBis.Update(lichsutb[0]);
                                Guid lstbId = Guid.NewGuid();
                                lichSuThietBi.Id = lstbId;
                                lichSuThietBi.CreatedDate = DateTime.Now;
                                lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                                lichSuThietBi.User_Id = data[0].User_Id;
                                lichSuThietBi.ThongTinThietBi_Id = item2.ThongTinThietBi_Id;
                                lichSuThietBi.TinhTrangThietBi = item2.TinhTrangThietBi;
                                lichSuThietBi.DonVi_Id = data[0].DonViNew_Id;
                                lichSuThietBi.PhongBan_Id = data[0].PhongBanNew_Id;
                                lichSuThietBi.BoPhan_Id = data[0].BoPhanNew_Id;
                                lichSuThietBi.ChucVu_Id = data[0].ChucVuNew_Id;
                                lichSuThietBi.DonViTraLuong_Id = data[0].DonViTraLuongNew_Id;
                                lichSuThietBi.NgayBatDau = DateTime.Now;
                                lichSuThietBi.NgayKetThuc = null;
                                uow.lichSuThietBis.Add(lichSuThietBi);
                            }

                        }
                    }

                }
                else if (uow.dieuChuyenNhanViens.Exists(x => x.MaNhanVien == data[0].MaNhanVien && x.IsDeleted))
                {
                    foreach (var item in data)
                    {
                        var DieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.Id == data[0].Id).ToArray();
                        var donvi = uow.DonVis.GetAll(x => x.Id == data[0].DonVi_Id).ToArray();
                        if (donvi == null)
                        {
                            // Trả về lỗi nếu đơn vị không tồn tại
                            return BadRequest("đơn vị không tồn tạo.");
                        }
                        var phongban = uow.phongbans.GetAll(x => x.Id == data[0].PhongBan_Id && x.DonVi_Id == data[0].DonVi_Id).ToArray();
                        if (phongban == null)
                        {
                            return BadRequest("not found.");
                        }
                        var bophan = uow.BoPhans.GetAll(x => x.Id == data[0].BoPhan_Id && x.PhongBan_Id == data[0].PhongBan_Id).ToArray();
                        if (bophan == null)
                        {
                            return BadRequest("not found.");
                        }
                        var chucvu = uow.chucVus.GetAll(x => x.Id == data[0].ChucVu_Id && x.BoPhan_Id == data[0].BoPhan_Id).ToArray();
                        if (chucvu == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvitraluong = uow.donViTraLuongs.GetAll(x => x.Id == data[0].DonViTraLuong_Id).ToArray();
                        if (donvitraluong == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvimoi = uow.DonVis.GetAll(x => x.Id == data[0].DonVi_Id).ToArray();
                        if (donvimoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var phongbanmoi = uow.phongbans.GetAll(x => x.Id == data[0].PhongBan_Id && x.DonVi_Id == data[0].DonVi_Id).ToArray();
                        if (phongbanmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var bophanmoi = uow.BoPhans.GetAll(x => x.Id == data[0].BoPhan_Id && x.PhongBan_Id == data[0].PhongBan_Id).ToArray();
                        if (bophanmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var chucvumoi = uow.chucVus.GetAll(x => x.Id == data[0].ChucVu_Id && x.BoPhan_Id == data[0].BoPhan_Id).ToArray();
                        if (chucvumoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvitraluongmoi = uow.donViTraLuongs.GetAll(x => x.Id == data[0].DonViTraLuong_Id).ToArray();
                        if (donvitraluongmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        DieuChuyen[0].IsDeleted = false;
                        DieuChuyen[0].DeletedBy = null;
                        DieuChuyen[0].DeletedDate = null;
                        DieuChuyen[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                        DieuChuyen[0].UpdatedDate = DateTime.Now;
                        DieuChuyen[0].CreatedDate = DateTime.Now;
                        DieuChuyen[0].CreatedBy = Guid.Parse(User.Identity.Name);
                        DieuChuyen[0].DonVi_Id = donvi[0].Id;
                        DieuChuyen[0].PhongBan_Id = phongban[0].Id;
                        DieuChuyen[0].BoPhan_Id = bophan[0].Id;
                        DieuChuyen[0].ChucVu_Id = chucvu[0].Id;
                        DieuChuyen[0].DonViTraLuong_Id = donvitraluong[0].Id;
                        DieuChuyen[0].DonViNew_Id = donvimoi[0].Id;
                        DieuChuyen[0].ChucVuNew_Id = chucvumoi[0].Id;
                        DieuChuyen[0].PhongBanNew_Id = phongbanmoi[0].Id;
                        DieuChuyen[0].BoPhanNew_Id = bophanmoi[0].Id;
                        DieuChuyen[0].DonViTraLuongNew_Id = donvitraluongmoi[0].Id;
                        DieuChuyen[0].NgayDieuChuyen = DateTime.Now;
                        uow.dieuChuyenNhanViens.Add(data[0]);
                    }
                }
                else
                {
                    foreach (var item in data)
                    {
                        var existingDieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.User_Id == data[0].User_Id).ToArray();
                        var appUser = userManager.FindByIdAsync(existingDieuChuyen[0].User_Id.ToString()).Result;
                        var donvi = uow.DonVis.GetAll(x => x.Id == data[0].DonVi_Id).ToArray();
                        if (donvi == null)
                        {
                            // Trả về lỗi nếu đơn vị không tồn tại
                            return BadRequest("đơn vị không tồn tạo.");
                        }
                        var phongban = uow.phongbans.GetAll(x => x.Id == data[0].PhongBan_Id && x.DonVi_Id == data[0].DonVi_Id).ToArray();
                        if (phongban == null)
                        {
                            return BadRequest("not found.");
                        }
                        var bophan = uow.BoPhans.GetAll(x => x.Id == data[0].BoPhan_Id && x.PhongBan_Id == data[0].PhongBan_Id).ToArray();
                        if (bophan == null)
                        {
                            return BadRequest("not found.");
                        }
                        var chucvu = uow.chucVus.GetAll(x => x.Id == data[0].ChucVu_Id && x.BoPhan_Id == data[0].BoPhan_Id).ToArray();
                        if (chucvu == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvitraluong = uow.donViTraLuongs.GetAll(x => x.Id == data[0].DonViTraLuong_Id).ToArray();
                        if (donvitraluong == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvimoi = uow.DonVis.GetAll(x => x.Id == data[0].DonVi_Id).ToArray();
                        if (donvimoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var phongbanmoi = uow.phongbans.GetAll(x => x.Id == data[0].PhongBan_Id && x.DonVi_Id == data[0].DonVi_Id).ToArray();
                        if (phongbanmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var bophanmoi = uow.BoPhans.GetAll(x => x.Id == data[0].BoPhan_Id && x.PhongBan_Id == data[0].PhongBan_Id).ToArray();
                        if (bophanmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var chucvumoi = uow.chucVus.GetAll(x => x.Id == data[0].ChucVu_Id && x.BoPhan_Id == data[0].BoPhan_Id).ToArray();
                        if (chucvumoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        var donvitraluongmoi = uow.donViTraLuongs.GetAll(x => x.Id == data[0].DonViTraLuong_Id).ToArray();
                        if (donvitraluongmoi == null)
                        {
                            return BadRequest("not found.");
                        }
                        Guid dcnvId = Guid.NewGuid();
                        data[0].Id = dcnvId;
                        data[0].CreatedDate = DateTime.Now;
                        data[0].CreatedBy = Guid.Parse(User.Identity.Name);
                        data[0].DonVi_Id = donvi[0].Id;
                        data[0].PhongBan_Id = phongban[0].Id;
                        data[0].BoPhan_Id = bophan[0].Id;
                        data[0].ChucVu_Id = chucvu[0].Id;
                        data[0].DonViTraLuong_Id = donvitraluong[0].Id;
                        data[0].DonViNew_Id = donvimoi[0].Id;
                        data[0].ChucVuNew_Id = chucvumoi[0].Id;
                        data[0].PhongBanNew_Id = phongbanmoi[0].Id;
                        data[0].BoPhanNew_Id = bophanmoi[0].Id;
                        data[0].DonViTraLuongNew_Id = donvitraluongmoi[0].Id;
                        data[0].NgayDieuChuyen = DateTime.Now;
                        uow.dieuChuyenNhanViens.Add(data[0]);
                        appUser.DonVi_Id = donvimoi[0].Id;
                        appUser.PhongBan_Id = phongbanmoi[0].Id;
                        appUser.BoPhan_Id = bophanmoi[0].Id;
                        appUser.ChucVu_Id = chucvumoi[0].Id;
                        appUser.DonViTraLuong_Id = donvitraluongmoi[0].Id;
                        userManager.UpdateAsync(appUser);
                        LichSuThietBi lichSuThietBi = new LichSuThietBi();
                        //thêm vòng lặp chứ không sai!! chưa thêm
                        if (uow.lichSuThietBis.Exists(x => x.User_Id == data[0].User_Id))
                        {
                            var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == data[0].User_Id && x.NgayKetThuc == null).ToArray();
                            foreach (var item2 in lichsutb)
                            {
                                lichsutb[0].NgayKetThuc = DateTime.Now;
                                uow.lichSuThietBis.Update(lichsutb[0]);
                                Guid lstbId = Guid.NewGuid();
                                lichSuThietBi.Id = lstbId;
                                lichSuThietBi.CreatedDate = DateTime.Now;
                                lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                                lichSuThietBi.User_Id = data[0].User_Id;
                                lichSuThietBi.ThongTinThietBi_Id = item2.ThongTinThietBi_Id;
                                lichSuThietBi.TinhTrangThietBi = item2.TinhTrangThietBi;
                                lichSuThietBi.DonVi_Id = data[0].DonViNew_Id;
                                lichSuThietBi.PhongBan_Id = data[0].PhongBanNew_Id;
                                lichSuThietBi.BoPhan_Id = data[0].BoPhanNew_Id;
                                lichSuThietBi.ChucVu_Id = data[0].ChucVuNew_Id;
                                lichSuThietBi.DonViTraLuong_Id = data[0].DonViTraLuongNew_Id;
                                lichSuThietBi.NgayBatDau = DateTime.Now;
                                lichSuThietBi.NgayKetThuc = null;
                                uow.lichSuThietBis.Add(lichSuThietBi);
                            }

                        }
                    }
                }
                    uow.Complete();
                return Ok();
            }
        }


        //truy vấn thủ tục điều chuyển nhân viên
        [HttpGet("get-dieu-chuyen-nhan-vien-data")]
        public IActionResult GetDieuChuyenNhanVienData()
        {
            try
            {
                // Mở kết nối trước khi thực hiện truy vấn
                myAdapter.OpenConnection();

                // Thực hiện truy vấn
                string storedProcedure = "sp_GetDieuChuyenNhanVien";
                DataTable dataTable = myAdapter.ExecuteQuery(storedProcedure);

                // Chuyển đổi DataTable thành danh sách đối tượng hoặc JSON theo ý muốn

                // Đóng kết nối sau khi sử dụng
                myAdapter.CloseConnection();
                //var result = ConvertDataTableToJson(dataTable);
                myAdapter.Dispose();
                return Ok(dataTable);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return BadRequest(ex.Message);
            }
        }
    }
}
