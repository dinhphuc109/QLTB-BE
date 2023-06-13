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

            string[] include = { "User", "DonVi", "BoPhan", "Phongban", "ChucVu", "cBNVDieuChuyens", "cBNVDieuChuyens.User" };
            var data = uow.dieuChuyenNhanViens.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.MaDieuChuyen,
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
                x?.TrangThai,
                x?.XacNhan,
                Lstcbnvdc = x.cBNVDieuChuyens.Select(y => new
                {
                    y.User.MaNhanVien,
                    y.User.FullName,
                    y.GhiChu

                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaDieuChuyen));
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
            var donvis = uow.DonVis.GetAll(x => !x.IsDeleted);
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

            var chucvus = uow.chucVus.GetAll(x => !x.IsDeleted);
            foreach (var chucvu in chucvus)
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

        //thêm điều chuyển nhân viên theo id
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User", "DonVi", "BoPhan", "Phongban", "ChucVu", "cBNVDieuChuyens", "cBNVDieuChuyens.User" };
            var duLieu = uow.dieuChuyenNhanViens.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }
        [HttpPost]
        public ActionResult Post(DieuChuyenNhanVien data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.dieuChuyenNhanViens.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaDieuChuyen + " đã tồn tại trong hệ thống");
                if (uow.dieuChuyenNhanViens.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && x.IsDeleted))
                {
                    var DieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.Id == data.Id).ToArray();
                    string kyTuDau = data.DonVi.MaDonVi;

                    // Lấy danh sách các mã đã tồn tại để kiểm tra trùng lặp
                    var existingMaDieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.NgayDieuChuyen.Date == data.NgayDieuChuyen.Date).Select(x => x.MaDieuChuyen).ToList();

                    int count = 1;
                    string MaDieuChuyen = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";

                    // Kiểm tra và tăng giá trị của biến đếm cho đến khi không có trùng lặp
                    while (existingMaDieuChuyen.Contains(MaDieuChuyen))
                    {
                        count++;
                        MaDieuChuyen = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";
                    }
                    DieuChuyen[0].MaDieuChuyen = MaDieuChuyen;
                    DieuChuyen[0].IsDeleted = false;
                    DieuChuyen[0].DeletedBy = null;
                    DieuChuyen[0].DeletedDate = null;
                    DieuChuyen[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    DieuChuyen[0].UpdatedDate = DateTime.Now;
                    DieuChuyen[0].DonVi_Id = data.DonVi_Id;
                    DieuChuyen[0].PhongBan_Id = data.PhongBan_Id;
                    DieuChuyen[0].BoPhan_Id = data.BoPhan_Id;
                    DieuChuyen[0].ChucVu_Id = data.ChucVu_Id;
                    DieuChuyen[0].DonViTraLuong_Id = data.DonViTraLuong_Id;
                    DieuChuyen[0].DonViNew_Id = data.DonViNew_Id;
                    DieuChuyen[0].ChucVuNew_Id = data.ChucVuNew_Id;
                    DieuChuyen[0].PhongBanNew_Id = data.PhongBanNew_Id;
                    DieuChuyen[0].BoPhanNew_Id = data.BoPhanNew_Id;
                    DieuChuyen[0].DonViTraLuongNew_Id = data.DonViTraLuongNew_Id;
                    DieuChuyen[0].NgayDieuChuyen = DateTime.Now;
                    DieuChuyen[0].TrangThai = "Chưa Xác Nhận";
                    DieuChuyen[0].XacNhan = false;
                    uow.dieuChuyenNhanViens.Update(data);

                    foreach (var item in data.Lstcbnvdc)
                    {
                        item.DieuChuyenNhanVien_Id = data.Id;
                        uow.cBNV_DieuChuyens.Add(item);

                        if (data.XacNhan == true)
                        {
                            var user = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                            var appUser = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                            appUser.DonVi_Id = data.DonViNew_Id;
                            appUser.PhongBan_Id = data.PhongBanNew_Id;
                            appUser.BoPhan_Id = data.BoPhanNew_Id;
                            appUser.ChucVu_Id = data.ChucVuNew_Id;
                            appUser.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                            userManager.UpdateAsync(appUser);
                            if (appUser.NghiViec == false)
                            {

                                LichSuThietBi lichSuThietBi = new LichSuThietBi();
                                //thêm vòng lặp chứ không sai!! chưa thêm
                                if (uow.lichSuThietBis.Exists(x => x.User_Id == item.User_Id))
                                {
                                    var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == item.User_Id && x.NgayKetThuc == null).ToArray();
                                    foreach (var item2 in lichsutb)
                                    {
                                        lichsutb[0].NgayKetThuc = DateTime.Now;
                                        uow.lichSuThietBis.Update(lichsutb[0]);
                                        Guid lstbId = Guid.NewGuid();
                                        lichSuThietBi.Id = lstbId;
                                        lichSuThietBi.CreatedDate = DateTime.Now;
                                        lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                                        lichSuThietBi.User_Id = item.User_Id;
                                        lichSuThietBi.ThongTinThietBi_Id = item2.ThongTinThietBi_Id;
                                        lichSuThietBi.TinhTrangThietBi = item2.TinhTrangThietBi;
                                        lichSuThietBi.DonVi_Id = data.DonViNew_Id;
                                        lichSuThietBi.PhongBan_Id = data.PhongBanNew_Id;
                                        lichSuThietBi.BoPhan_Id = data.BoPhanNew_Id;
                                        lichSuThietBi.ChucVu_Id = data.ChucVuNew_Id;
                                        lichSuThietBi.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                                        lichSuThietBi.NgayBatDau = DateTime.Now;
                                        lichSuThietBi.NgayKetThuc = null;
                                        uow.lichSuThietBis.Add(lichSuThietBi);
                                    }

                                }
                            }
                        }

                    }


                }
                else
                {
                    var DieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.Id == data.Id).ToArray();
                    string kyTuDau = data.DonVi.MaDonVi;

                    // Lấy danh sách các mã đã tồn tại để kiểm tra trùng lặp
                    var existingMaDieuChuyen = uow.dieuChuyenNhanViens.GetAll(x => x.NgayDieuChuyen.Date == data.NgayDieuChuyen.Date).Select(x => x.MaDieuChuyen).ToList();

                    int count = 1;
                    string MaDieuChuyen = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}{count}";

                    // Kiểm tra và tăng giá trị của biến đếm cho đến khi không có trùng lặp
                    while (existingMaDieuChuyen.Contains(MaDieuChuyen))
                    {
                        count++;
                        MaDieuChuyen = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}{count}";
                    }
                    Guid dcnvId = Guid.NewGuid();
                    data.Id = dcnvId;
                    data.MaDieuChuyen = MaDieuChuyen;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    data.TrangThai = "Chưa Xác Nhận";
                    data.XacNhan = false;
                    uow.dieuChuyenNhanViens.Add(data);
                    foreach (var item in data.Lstcbnvdc)
                    {
                        item.DieuChuyenNhanVien_Id = data.Id;
                        uow.cBNV_DieuChuyens.Add(item);
                        if (data.XacNhan == true)
                        {
                            var user = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                            var appUser = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                            appUser.DonVi_Id = data.DonViNew_Id;
                            appUser.PhongBan_Id = data.PhongBanNew_Id;
                            appUser.BoPhan_Id = data.BoPhanNew_Id;
                            appUser.ChucVu_Id = data.ChucVuNew_Id;
                            appUser.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                            userManager.UpdateAsync(appUser);
                            if (appUser.NghiViec == false)
                            {

                                LichSuThietBi lichSuThietBi = new LichSuThietBi();
                                //thêm vòng lặp chứ không sai!! chưa thêm
                                if (uow.lichSuThietBis.Exists(x => x.User_Id == item.User_Id))
                                {
                                    var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == item.User_Id && x.NgayKetThuc == null).ToArray();
                                    foreach (var item2 in lichsutb)
                                    {
                                        lichsutb[0].NgayKetThuc = DateTime.Now;
                                        uow.lichSuThietBis.Update(lichsutb[0]);
                                        Guid lstbId = Guid.NewGuid();
                                        lichSuThietBi.Id = lstbId;
                                        lichSuThietBi.CreatedDate = DateTime.Now;
                                        lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                                        lichSuThietBi.User_Id = item.User_Id;
                                        lichSuThietBi.ThongTinThietBi_Id = item2.ThongTinThietBi_Id;
                                        lichSuThietBi.TinhTrangThietBi = item2.TinhTrangThietBi;
                                        lichSuThietBi.DonVi_Id = data.DonViNew_Id;
                                        lichSuThietBi.PhongBan_Id = data.PhongBanNew_Id;
                                        lichSuThietBi.BoPhan_Id = data.BoPhanNew_Id;
                                        lichSuThietBi.ChucVu_Id = data.ChucVuNew_Id;
                                        lichSuThietBi.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                                        lichSuThietBi.NgayBatDau = DateTime.Now;
                                        lichSuThietBi.NgayKetThuc = null;
                                        uow.lichSuThietBis.Add(lichSuThietBi);
                                    }

                                }
                            }
                        }


                    }


                }
            }


            uow.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, DieuChuyenNhanVien data)
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
                if (uow.dieuChuyenNhanViens.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaDieuChuyen + " đã tồn tại trong hệ thống");
                else if (uow.dieuChuyenNhanViens.Exists(x => x.MaDieuChuyen == data.MaDieuChuyen && x.IsDeleted))
                {
                    var dieuchuyen = uow.dieuChuyenNhanViens.GetAll(x => x.Id == data.Id).ToArray();
                    dieuchuyen[0].IsDeleted = false;
                    dieuchuyen[0].DeletedBy = null;
                    dieuchuyen[0].DeletedDate = null;
                    dieuchuyen[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    dieuchuyen[0].UpdatedDate = DateTime.Now;
                    dieuchuyen[0].MaDieuChuyen = data.MaDieuChuyen;
                    dieuchuyen[0].User_Id = data.User_Id;
                    uow.dieuChuyenNhanViens.Update(dieuchuyen[0]);
                }
                else
                {
                    data.UpdatedBy = Guid.Parse(User.Identity.Name);
                    data.UpdatedDate = DateTime.Now;
                    if (data.XacNhan == true)
                    {
                        data.TrangThai = "Đã Xác Nhận";
                    }
                    uow.dieuChuyenNhanViens.Update(data);
                }

                var Lstcbnvdc = data.Lstcbnvdc;
                var dataCheck = uow.cBNV_DieuChuyens.GetAll(x => x.DieuChuyenNhanVien_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!Lstcbnvdc.Exists(x => x.User_Id == item.User_Id))
                        {
                            uow.cBNV_DieuChuyens.Delete(item.Id);
                        }
                    }
                    foreach (var item in Lstcbnvdc)
                    {
                        if (!dataCheck.Exists(x => x.User_Id == item.User_Id))
                        {
                            item.DieuChuyenNhanVien_Id = id;
                            uow.cBNV_DieuChuyens.Add(item);
                            if (data.XacNhan == true)
                            {
                                var user = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                                var appUser = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                                appUser.DonVi_Id = data.DonViNew_Id;
                                appUser.PhongBan_Id = data.PhongBanNew_Id;
                                appUser.BoPhan_Id = data.BoPhanNew_Id;
                                appUser.ChucVu_Id = data.ChucVuNew_Id;
                                appUser.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                                userManager.UpdateAsync(appUser);
                                if (appUser.NghiViec == false)
                                {

                                    LichSuThietBi lichSuThietBi = new LichSuThietBi();
                                    //thêm vòng lặp chứ không sai!! chưa thêm
                                    if (uow.lichSuThietBis.Exists(x => x.User_Id == item.User_Id))
                                    {
                                        var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == item.User_Id && x.NgayKetThuc == null).ToArray();
                                        foreach (var item2 in lichsutb)
                                        {
                                            lichsutb[0].NgayKetThuc = DateTime.Now;
                                            uow.lichSuThietBis.Update(lichsutb[0]);
                                            Guid lstbId = Guid.NewGuid();
                                            lichSuThietBi.Id = lstbId;
                                            lichSuThietBi.CreatedDate = DateTime.Now;
                                            lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                                            lichSuThietBi.User_Id = item.User_Id;
                                            lichSuThietBi.ThongTinThietBi_Id = item2.ThongTinThietBi_Id;
                                            lichSuThietBi.TinhTrangThietBi = item2.TinhTrangThietBi;
                                            lichSuThietBi.DonVi_Id = data.DonViNew_Id;
                                            lichSuThietBi.PhongBan_Id = data.PhongBanNew_Id;
                                            lichSuThietBi.BoPhan_Id = data.BoPhanNew_Id;
                                            lichSuThietBi.ChucVu_Id = data.ChucVuNew_Id;
                                            lichSuThietBi.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                                            lichSuThietBi.NgayBatDau = DateTime.Now;
                                            lichSuThietBi.NgayKetThuc = null;
                                            uow.lichSuThietBis.Add(lichSuThietBi);
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in Lstcbnvdc)
                    {
                        item.DieuChuyenNhanVien_Id = id;
                        uow.cBNV_DieuChuyens.Add(item);
                        if (data.XacNhan == true)
                        {
                            var user = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                            var appUser = userManager.FindByIdAsync(item.User_Id.ToString()).Result;
                            appUser.DonVi_Id = data.DonViNew_Id;
                            appUser.PhongBan_Id = data.PhongBanNew_Id;
                            appUser.BoPhan_Id = data.BoPhanNew_Id;
                            appUser.ChucVu_Id = data.ChucVuNew_Id;
                            appUser.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                            userManager.UpdateAsync(appUser);
                            if (appUser.NghiViec == false)
                            {

                                LichSuThietBi lichSuThietBi = new LichSuThietBi();
                                //thêm vòng lặp chứ không sai!! chưa thêm
                                if (uow.lichSuThietBis.Exists(x => x.User_Id == item.User_Id))
                                {
                                    var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == item.User_Id && x.NgayKetThuc == null).ToArray();
                                    foreach (var item2 in lichsutb)
                                    {
                                        lichsutb[0].NgayKetThuc = DateTime.Now;
                                        uow.lichSuThietBis.Update(lichsutb[0]);
                                        Guid lstbId = Guid.NewGuid();
                                        lichSuThietBi.Id = lstbId;
                                        lichSuThietBi.CreatedDate = DateTime.Now;
                                        lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                                        lichSuThietBi.User_Id = item.User_Id;
                                        lichSuThietBi.ThongTinThietBi_Id = item2.ThongTinThietBi_Id;
                                        lichSuThietBi.TinhTrangThietBi = item2.TinhTrangThietBi;
                                        lichSuThietBi.DonVi_Id = data.DonViNew_Id;
                                        lichSuThietBi.PhongBan_Id = data.PhongBanNew_Id;
                                        lichSuThietBi.BoPhan_Id = data.BoPhanNew_Id;
                                        lichSuThietBi.ChucVu_Id = data.ChucVuNew_Id;
                                        lichSuThietBi.DonViTraLuong_Id = data.DonViTraLuongNew_Id;
                                        lichSuThietBi.NgayBatDau = DateTime.Now;
                                        lichSuThietBi.NgayKetThuc = null;
                                        uow.lichSuThietBis.Add(lichSuThietBi);
                                    }

                                }
                            }
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
                DieuChuyenNhanVien duLieu = uow.dieuChuyenNhanViens.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataCheck = uow.cBNV_DieuChuyens.GetAll(x=>x.DieuChuyenNhanVien_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.cBNV_DieuChuyens.Delete(item.Id);
                    }

                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.dieuChuyenNhanViens.Update(duLieu);
                    uow.Complete();
                    return Ok(duLieu);
                }
                return StatusCode(StatusCodes.Status409Conflict, "Bạn chỉ có thể chỉnh sửa thông tin thiết bị này");
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
