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
    public class BanGiaoTBController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public BanGiaoTBController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }
        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";

            string[] include = { "banGiaoThongTinThietBis.TinhTrangThietBi", "User", "banGiaoThongTinThietBis.DonViTinh", "banGiaoThongTinThietBis", "banGiaoThongTinThietBis.Kho", "banGiaoThongTinThietBis.Kho.DanhMucKho", "banGiaoThongTinThietBis.ThongTinThietBi", "banGiaoThongTinThietBis.ThongTinThietBi.DanhMucThietBi" };
            var data = uow.banGiaoTBs.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.MaBanGIao,
                x.UserGiao_Id,
                x.UserNhan_Id,
                Lstbgtttb = x.banGiaoThongTinThietBis.Select(y => new
                {
                    y.ThongTinThietBi.DanhMucThietBi.TenThietBi,
                    y.ThongTinThietBi.CauHinh,
                    y.ThongTinThietBi.ThoiGianBaoHanh,
                    y.ThongTinThietBi.SoSeri,
                    y.ThongTinThietBi.ModelThietBi,
                    y.TinhTrangThietBi_Id,
                    y.NgayNhan,
                    y.DonViTinh.TenDonViTinh,
                    y.SoLuong,
                    y.GhiChu,
                    y.Kho?.DanhMucKho.TenKho,
                })
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaBanGIao));
        }

        public class ClassListBanGiaoTB
        {
            public Guid Id { get; set; }
            public string MaBanGiao { get; set; }
            public string NguoiGiao { get; set; }
            public string TenDonVi { get; set; }
            public string TenBoPhan { get; set; }
            public string TenChucVu { get; set; }
            public string TenPhongBan { get; set; }
            public string MaNguoiNhan { get; set; }
            public string NguoiNhan { get; set; }
            public string TenDonViNguoiNhan { get; set; }
            public string TenBoPhanNguoiNhan { get; set; }
            public string TenChucVuNguoiNhan { get; set; }
            public string TenPhongBanNguoiNhan { get; set; }
            public string MaThietBi { get; set; }
            public string TenThietBi { get; set; }
            public string Cauhinh { get; set; }
            public string SoSeri { get; set; }
            public string ModelThietBi { get; set; }
            public string DonViTinh { get; set; }
            public int SoLuong { get; set; }
            public DateTime NgayNhan { get; set; }
            public string TinhTrangThietBi { get; set; }
            public string GhiChu { get; set; }
            public string Kho { get; set; }

        }

        [HttpGet("GetDataPagnigation")]
        public ActionResult GetDataPagnigation(int page = 1, int pageSize = 20, string keyword = null)
        {
            if (keyword == null) keyword = "";
            string[] include = { "User", "banGiaoThongTinThietBis.DonViTinh", "banGiaoThongTinThietBis", "banGiaoThongTinThietBis.Kho", "banGiaoThongTinThietBis.Kho.DanhMucKho", "banGiaoThongTinThietBis.ThongTinThietBi", "banGiaoThongTinThietBis.ThongTinThietBi.DanhMucThietBi"};
            var query = uow.banGiaoTBs.GetAll(t => !t.IsDeleted && (t.MaBanGIao.ToLower().Contains(keyword.ToLower()) || t.MaBanGIao.ToLower().Contains(keyword.ToLower())), null, include)
            .Select(x => new
            {
                x.MaBanGIao,
                x.Id,
                x.UserGiao_Id,
                x.UserNhan_Id,

                Lstbgtttb = x.banGiaoThongTinThietBis.Select(y => new
                {
                    y.ThongTinThietBi.DanhMucThietBi.TenThietBi,
                    y.ThongTinThietBi.CauHinh,
                    y.ThongTinThietBi.ThoiGianBaoHanh,
                    y.ThongTinThietBi.SoSeri,
                    y.ThongTinThietBi.ModelThietBi,
                    y.TinhTrangThietBi_Id,
                    y.NgayNhan,
                    y.DonViTinh.TenDonViTinh,
                    y.SoLuong,
                    y.GhiChu,
                    y.Kho?.DanhMucKho.TenKho,
                })
            })
            .OrderBy(x => x.MaBanGIao);

            var queryResult = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            /*            List<ClassListBanGiaoTB> list = new List<ClassListBanGiaoTB>();

                        foreach (var item in query)
                        {
                            var donvi = uow.DonVis.GetAll(x => !x.IsDeleted && x.Id == item.DonVi_Id, null, null).Select(x => new { x.TenDonVi }).ToList();
                            var bophan = uow.BoPhans.GetAll(x => !x.IsDeleted && x.Id == item.BoPhan_Id, null, null).Select(x => new { x.TenBoPhan }).ToList();
                            var phongban = uow.phongbans.GetAll(x => !x.IsDeleted && x.Id == item.PhongBan_Id, null, null).Select(x => new { x.TenPhongBan }).ToList();
                            var chucvu = uow.chucVus.GetAll(x => !x.IsDeleted && x.Id == item.ChucVu_Id, null, null).Select(x => new { x.TenChucVu }).ToList();
                            var infor = new ClassListBanGiaoTB();
                            infor.Id = item.Id;
                            infor.NguoiGiao = item.FullName;
                            infor.MaBanGiao = item.MaBanGIao;

                            infor.TenBoPhan = bophan[0].TenBoPhan;
                            infor.TenDonVi = donvi[0].TenDonVi;
                            infor.TenChucVu = chucvu[0].TenChucVu;
                            infor.TenPhongBan = phongban[0].TenPhongBan;

                            var ttbt = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == item.Id, null, null).Select(x => new { x.ThongTinThietBi }).ToList();
                            var ttbtdvt = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == item.Id, null, null).Select(x => new { x.DonViTinh }).ToList();
                            var ttbtkho = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == item.Id, null, null).Select(x => new { x.Kho }).ToList();
                            var ttbt2 = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == item.Id, null, null).ToList();

                            infor.Kho = ttbtkho[0].Kho?.DanhMucKho.TenKho;
                            foreach (var x in ttbt)
                            {
                                infor.TenThietBi = ttbt[0].ThongTinThietBi.DanhMucThietBi.TenThietBi;
                                infor.MaThietBi = ttbt[0].ThongTinThietBi.DanhMucThietBi.MaThietBi;
                                infor.Cauhinh = ttbt[0].ThongTinThietBi.DanhMucThietBi.CauHinh;
                                infor.SoSeri = ttbt[0].ThongTinThietBi.SoSeri;
                                infor.ModelThietBi = ttbt[0].ThongTinThietBi.ModelThietBi;
                                infor.TinhTrangThietBi = ttbt2[0].TinhTrangThietBi;
                                infor.NgayNhan = ttbt2[0].NgayNhan;
                                infor.SoLuong = ttbt2[0].SoLuong;
                                infor.GhiChu = ttbt2[0].GhiChu;
                                infor.DonViTinh = ttbtdvt[0].DonViTinh.TenDonViTinh;

                            }
                            var nvnn = uow.banGiaoNguoiNhans.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == item.Id, null, null).Select(x => new { x.User }).ToList();
                            foreach(var nn in nvnn)
                            {
                                var donvinhan = uow.DonVis.GetAll(x => !x.IsDeleted && x.Id == nn.User.DonVi_Id, null, null).Select(x => new { x.TenDonVi }).ToList();
                                var bophannhan = uow.BoPhans.GetAll(x => !x.IsDeleted && x.Id == nn.User.BoPhan_Id, null, null).Select(x => new { x.TenBoPhan }).ToList();
                                var phongbannhan = uow.phongbans.GetAll(x => !x.IsDeleted && x.Id == nn.User.PhongBan_Id, null, null).Select(x => new { x.TenPhongBan }).ToList();
                                var chucvunhan = uow.chucVus.GetAll(x => !x.IsDeleted && x.Id == nn.User.ChucVu_Id, null, null).Select(x => new { x.TenChucVu }).ToList();
                                foreach (var x in nvnn)
                                {
                                    infor.MaNguoiNhan = nvnn[0].User.MaNhanVien;
                                    infor.NguoiNhan = nvnn[0].User.FullName;
                                    infor.TenBoPhanNguoiNhan = bophannhan[0].TenBoPhan;
                                    infor.TenDonViNguoiNhan = donvinhan[0].TenDonVi;
                                    infor.TenChucVuNguoiNhan = chucvunhan[0].TenChucVu;
                                    infor.TenPhongBanNguoiNhan = phongbannhan[0].TenPhongBan;
                                }
                            }
                            list.Add(infor);
                        }
                        int totalRow = list.Count();
                        int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
                        var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);*/
            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User", "DonViTinh", "banGiaoThongTinThietBis", "banGiaoThongTinThietBis.ThongTinThietBi" };
            var duLieu = uow.banGiaoTBs.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(BanGiaoTB data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.banGiaoTBs.Exists(x => x.MaBanGIao == data.MaBanGIao && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaBanGIao + " đã tồn tại trong hệ thống");
                else if (uow.banGiaoTBs.Exists(x => x.MaBanGIao == data.MaBanGIao && x.IsDeleted))
                {
                    var banGiaotb = uow.banGiaoTBs.GetAll(x => x.Id == data.Id).ToArray();
                    var appUser2 = userManager.FindByIdAsync(data.UserNhan_Id.ToString()).Result;
                    var donvi = uow.DonVis.GetAll(x => x.Id == appUser2.DonVi_Id).ToArray();
                    string kyTuDau = "BG" + donvi[0].MaDonVi;

                    // Lấy danh sách các mã đã tồn tại để kiểm tra trùng lặp
                    var existingMaBanGiao = uow.banGiaoThongTinThietBis.GetAll(x => x.NgayNhan.Date == DateTime.Now.Date).Select(x=>x.BanGiaoTB.MaBanGIao).ToList();

                    int count = 1;
                    string MaBanGiao = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";

                    // Kiểm tra và tăng giá trị của biến đếm cho đến khi không có trùng lặp
                    while (existingMaBanGiao.Contains(MaBanGiao))
                    {
                        count++;
                        MaBanGiao = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";
                    }
                    banGiaotb[0].MaBanGIao = MaBanGiao;
                    banGiaotb[0].IsDeleted = false;
                    banGiaotb[0].DeletedBy = null;
                    banGiaotb[0].DeletedDate = null;
                    banGiaotb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    banGiaotb[0].UpdatedDate = DateTime.Now;
                    banGiaotb[0].UserGiao_Id = data.UserGiao_Id;
                    banGiaotb[0].UserNhan_Id = data.UserNhan_Id;
                    uow.banGiaoTBs.Update(banGiaotb[0]);
                    foreach (var item in data.Lstbgtttb)
                    {
                        var tttb = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && t.Id == item.ThongTinThietBi_Id).ToArray();
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.BanGiaoTB_Id = banGiaotb[0].Id;
                     
                        var bangiaotttb = uow.banGiaoThongTinThietBis.GetAll(x => x.BanGiaoTB_Id == item.BanGiaoTB_Id).ToArray();
                        var kho = uow.khos.GetAll(x => x.Id == item.Kho_Id).ToArray();
                        var khotttb=uow.khoThongTinThietBis.GetAll(x => x.Id == item.Kho_Id).ToArray();
                        var tttb2 =uow.thongTinThietBis.GetAll(x=>x.Id==item.ThongTinThietBi_Id).ToArray();
                        if (kho != null && kho[0].Id == item.Kho_Id && khotttb[0].Id == item.Kho_Id)
                        {
                            if (!uow.khoThongTinThietBis.Exists(x => x.ThongTinThietBi_Id == bangiaotttb[0].ThongTinThietBi_Id))
                            {
                                foreach (var k in khotttb)
                                {
                                    k.Kho_Id = (Guid)bangiaotttb[0].Kho_Id;
                                    k.CreatedBy = Guid.Parse(User.Identity.Name);
                                    k.CreatedDate = DateTime.Now;
                                    k.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                                  
                                    k.SoLuong = item.SoLuong;
                                    k.DonViTinh_Id = item.DonViTinh_Id;
                                    k.TinhTrangThietBi_Id = item.TinhTrangThietBi_Id;
                                    uow.khoThongTinThietBis.Add(k);
                                    tttb2[0].TinhTrangThietBi_Id = k.TinhTrangThietBi_Id;
                                    uow.thongTinThietBis.Update(tttb2[0]);
                                }

                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status409Conflict, "Mã " + khotttb[0].ThongTinThietBi.DanhMucThietBi.MaThietBi + " đã tồn tại trong hệ thống");
                            }

                            uow.khos.Update(kho[0]);
                        }
                        /*if (kho!=null && kho[0].Id == item.Kho_Id && khotttb[0].Id==item.Kho_Id)
                        {
                            if (!uow.khoThongTinThietBis.Exists(x => x.ThongTinThietBi_Id == bangiaotttb[0].ThongTinThietBi_Id))
                            {
                                foreach(var k in khotttb)
                                {
                                    k.Kho_Id = (Guid)bangiaotttb[0].Kho_Id;
                                    k.CreatedBy = Guid.Parse(User.Identity.Name);
                                    k.CreatedDate = DateTime.Now;
                                    k.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
                                    k.SoLuong = item.SoLuong;
                                    k.DonViTinh_Id = item.DonViTinh_Id;
                                    k.TinhTrangThietBi = item.TinhTrangThietBi;
                                    uow.khoThongTinThietBis.Add(k);
                                }

                            }

                            uow.khos.Update(kho[0]);
                        }*/
                        uow.banGiaoThongTinThietBis.Add(item);
                    }
                }
                else
                {
                    var banGiaotb = uow.banGiaoTBs.GetAll(x => x.Id == data.Id).ToArray();
                    var appUser2 = userManager.FindByIdAsync(data.UserNhan_Id.ToString()).Result;
                    var donvi = uow.DonVis.GetAll(x => x.Id == appUser2.DonVi_Id).ToArray();
                    string kyTuDau = "BG" + donvi[0].MaDonVi;

                    // Lấy danh sách các mã đã tồn tại để kiểm tra trùng lặp
                    var existingMaBanGiao = uow.banGiaoTBs.GetAll(x => !x.IsDeleted).Select(x => x.MaBanGIao ).ToList();

                    int count = 1;
                    string MaBanGiao = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";

                    // Kiểm tra và tăng giá trị của biến đếm cho đến khi không có trùng lặp
                    while (existingMaBanGiao.Contains(MaBanGiao))
                    {
                        count++;
                        MaBanGiao = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";
                    }
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    data.MaBanGIao = MaBanGiao;
                    uow.banGiaoTBs.Add(data);
                    foreach (var item in data.Lstbgtttb)
                    {
                        var tttb = uow.thongTinThietBis.GetAll(t => !t.IsDeleted  && t.Id == item.ThongTinThietBi_Id).ToArray();
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.BanGiaoTB_Id = id;
                        var bangiaotttb = uow.banGiaoThongTinThietBis.GetAll(x => x.BanGiaoTB_Id == item.BanGiaoTB_Id).ToArray();
                        var kho = uow.khos.GetAll(x => x.Id == item.Kho_Id).ToArray();
                        
                        
                        if (item.Kho_Id != null && kho[0].Id == item.Kho_Id)
                        {
                            if (!uow.khoThongTinThietBis.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                            {
                                Kho_ThongTinThietBi khotb = new Kho_ThongTinThietBi();
                                Guid idkho = Guid.NewGuid();
                                khotb.Id = idkho;
                                khotb.Kho_Id = item.Kho_Id;
                                    khotb.CreatedBy = Guid.Parse(User.Identity.Name);
                                    khotb.CreatedDate = DateTime.Now;
                                    khotb.ThongTinThietBi_Id = item.ThongTinThietBi_Id;
              
                                khotb.SoLuong = item.SoLuong;
                                    khotb.DonViTinh_Id = item.DonViTinh_Id;
                                    khotb.TinhTrangThietBi_Id = item.TinhTrangThietBi_Id;
                                    uow.khoThongTinThietBis.Add(khotb);
                                tttb[0].TinhTrangThietBi_Id = khotb.TinhTrangThietBi_Id;
                                uow.thongTinThietBis.Update(tttb[0]);
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status409Conflict, "Mã đã tồn tại trong hệ thống");
                            }
                        }
                        uow.banGiaoThongTinThietBis.Add(item);
               
                  
                        LichSuThietBi lichsuthietbi = new LichSuThietBi();                               
                                if (!uow.lichSuThietBis.Exists(x => x.User_Id == data.UserNhan_Id))
                                {
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
                                else if (uow.lichSuThietBis.Exists(x => x.User_Id == data.UserNhan_Id))
                                {
                                    Guid lstbid = Guid.NewGuid();
                                    var existingLichSu = uow.lichSuThietBis.GetAll(x => x.User_Id == data.UserNhan_Id && x.NgayKetThuc == null).ToArray();
                                    /*existingLichSu[0].NgayKetThuc = DateTime.Now;
                                    uow.lichSuThietBis.Update(existingLichSu[0]);*/
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
                }
                uow.Complete();
                return Ok();
            }
        

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, BanGiaoTB data)
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
                if (uow.banGiaoTBs.Exists(x => x.MaBanGIao == data.MaBanGIao && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaBanGIao + " đã tồn tại trong hệ thống");
                else if (uow.banGiaoTBs.Exists(x => x.MaBanGIao == data.MaBanGIao && x.IsDeleted))
                {
                    var banGiaotb = uow.banGiaoTBs.GetAll(x => x.Id == data.Id).ToArray();
                    var appUser2 = userManager.FindByIdAsync(data.UserNhan_Id.ToString()).Result;
                    var donvi = uow.DonVis.GetAll(x => x.Id == appUser2.DonVi_Id).ToArray();
                    string kyTuDau ="BG" + donvi[0].MaDonVi;

                    // Lấy danh sách các mã đã tồn tại để kiểm tra trùng lặp
                    var existingMaBanGiao = uow.banGiaoThongTinThietBis.GetAll(x => x.NgayNhan.Date == DateTime.Now.Date).Select(x => x.BanGiaoTB.MaBanGIao).ToList();

                    int count = 1;
                    string MaBanGiao = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";

                    // Kiểm tra và tăng giá trị của biến đếm cho đến khi không có trùng lặp
                    while (existingMaBanGiao.Contains(MaBanGiao))
                    {
                        count++;
                        MaBanGiao = $"{kyTuDau}/{DateTime.Now.ToString("yyMMdd")}/{count}";
                    }
                    banGiaotb[0].MaBanGIao = MaBanGiao;
                    banGiaotb[0].IsDeleted = false;
                    banGiaotb[0].DeletedBy = null;
                    banGiaotb[0].DeletedDate = null;
                    banGiaotb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    banGiaotb[0].UpdatedDate = DateTime.Now;
                    banGiaotb[0].UserGiao_Id = data.UserGiao_Id;
                    banGiaotb[0].UserNhan_Id = data.UserNhan_Id;
                    uow.banGiaoTBs.Update(banGiaotb[0]);
                }
                else
                {
                    data.UpdatedBy = Guid.Parse(User.Identity.Name);
                    data.UpdatedDate = DateTime.Now;
                    uow.banGiaoTBs.Update(data);
                }

                var Lstbgtttb = data.Lstbgtttb;
                var dataCheck = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!Lstbgtttb.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            var lstb = uow.lichSuThietBis.GetAll(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id).ToArray();
                            uow.banGiaoThongTinThietBis.Delete(item.Id);
                            uow.lichSuThietBis.Delete(lstb[0].Id);
                        }
                    }
                    foreach (var item in Lstbgtttb)
                    {
                        if (!dataCheck.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            item.BanGiaoTB_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.banGiaoThongTinThietBis.Add(item);

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
                else
                {
                    foreach (var item in Lstbgtttb)
                    {
                        item.BanGiaoTB_Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        uow.banGiaoThongTinThietBis.Add(item);
                        var tttb = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && t.Id == item.ThongTinThietBi_Id).ToArray();
                        tttb[0].TinhTrangThietBi_Id = item.TinhTrangThietBi_Id;
                        uow.thongTinThietBis.Update(tttb[0]);
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
                uow.Complete();
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            lock (Commons.LockObjectState)
            {
                BanGiaoTB duLieu = uow.banGiaoTBs.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataChecktttb = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == id).ToList();
                    foreach (var item in dataChecktttb)
                    {
                        uow.banGiaoThongTinThietBis.Delete(item.Id);
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.banGiaoTBs.Update(duLieu);
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
                uow.banGiaoTBs.Delete(id);
                uow.Complete();
                return Ok();
            }
        }

    }
}
