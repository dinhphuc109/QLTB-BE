using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using OfficeOpenXml;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        private readonly IConfiguration config;
        public AccountController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment, IConfiguration _config)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
            config = _config;
        }
        // GET api/account
        [HttpPost]
        public async Task<IActionResult> Post(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var UserName = model.Email.Split(new[] { '@' })[0];
            var exit = await userManager.FindByEmailAsync(model.Email);
            // Kiểm tra tài khoản, email có tồn tại không
            //Nếu tài khoản không tồn tại -- Thêm mới
            var Password = config.GetValue<string>("DefaultPass");
            if (exit == null)
            {
                var user = new ApplicationUser() { UserName = UserName, FullName = model.FullName, MaNhanVien = model.MaNhanVien, Email = model.Email, PhoneNumber=model.PhoneNumber,
                    IsActive = model.IsActive, MustChangePass = true, CreatedDate = DateTime.Now, DonVi_Id = model.DonVi_Id, BoPhan_Id = model.BoPhan_Id, ChucVu_Id=model.ChucVu_Id,
                    PhongBan_Id=model.PhongBan_Id, DonViTraLuong_Id=model.DonViTraLuong_Id };
                IdentityResult result = await userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    foreach (string RoleName in model.RoleNames)
                    {
                        await userManager.AddToRoleAsync(user, RoleName);
                    }
                    return StatusCode(StatusCodes.Status201Created);
                }
                return BadRequest(string.Join(",", result.Errors));
            }
            else
            {
                if (exit.IsDeleted)
                {
                    exit.UpdatedDate = DateTime.Now;
                    exit.DeletedDate = null;
                    exit.IsDeleted = false;
                    exit.IsActive = model.IsActive;
                    exit.MustChangePass = true;
                    exit.PasswordHash = userManager.PasswordHasher.HashPassword(exit, Password);
                    var result = await userManager.UpdateAsync(exit);
                    if (result.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(exit);
                        foreach (string item_remove in roles)
                        {
                            await userManager.RemoveFromRoleAsync(exit, item_remove);
                        }
                        foreach (string RoleName in model.RoleNames)
                        {
                            await userManager.AddToRoleAsync(exit, RoleName);
                        }
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
                    return BadRequest(string.Join(",", result.Errors));
                }
                return StatusCode(StatusCodes.Status409Conflict, "Thông tin email tài khoản đã tồn tại");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != model.Id)
            {
                return BadRequest();
            }
            var UserName = model.Email.Split(new[] { '@' })[0];
            var exit = await userManager.FindByEmailAsync(model.Email);
            // Kiểm tra tài khoản, email có tồn tại không
            if (exit != null && exit.Id.ToString() != id)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Thông tin tài khoản, email đã tồn tại");
            }
            var appUser = await userManager.FindByIdAsync(model.Id);
/*            DieuChuyenNhanVien dieuChuyenNhanVien = new DieuChuyenNhanVien();
            Guid dcnvId = Guid.NewGuid();
            if (uow.dieuChuyenNhanViens.Exists(x => x.User_Id.ToString() == model.Id 
            && x.DonViNew_Id==model.DonVi_Id
            && x.BoPhanNew_Id==model.BoPhan_Id
            && x.PhongBanNew_Id==model.PhongBan_Id
            && x.ChucVuNew_Id==model.ChucVu_Id))
            {
                var dieuchuyen = uow.dieuChuyenNhanViens.GetAll(x => x.User_Id.ToString() == model.Id).ToArray();
                dieuchuyen[0].MaNhanVien = model.MaNhanVien;
                dieuchuyen[0].UserName = model.UserName;
                uow.dieuChuyenNhanViens.Update(dieuchuyen[0]);
            }
            else if (!uow.dieuChuyenNhanViens.Exists(x => x.User_Id.ToString() == model.Id))
            {
                var user = await userManager.Users.ToListAsync();
                
                dieuChuyenNhanVien.Id = dcnvId;
                dieuChuyenNhanVien.CreatedDate = DateTime.Now;
                dieuChuyenNhanVien.CreatedBy = Guid.Parse(User.Identity.Name);
                dieuChuyenNhanVien.User_Id = appUser.Id;
                dieuChuyenNhanVien.MaNhanVien = appUser.MaNhanVien;
                dieuChuyenNhanVien.UserName = appUser.UserName;
                dieuChuyenNhanVien.DonVi_Id = appUser.DonVi_Id;
                dieuChuyenNhanVien.ChucVu_Id = appUser.ChucVu_Id;
                dieuChuyenNhanVien.PhongBan_Id = appUser.PhongBan_Id;
                dieuChuyenNhanVien.BoPhan_Id = appUser.BoPhan_Id;
                dieuChuyenNhanVien.DonViTraLuong_Id = appUser.DonViTraLuong_Id;
                dieuChuyenNhanVien.DonViNew_Id = appUser.DonVi_Id;
                dieuChuyenNhanVien.ChucVuNew_Id = appUser.ChucVu_Id;
                dieuChuyenNhanVien.PhongBanNew_Id = appUser.PhongBan_Id;
                dieuChuyenNhanVien.BoPhanNew_Id = appUser.BoPhan_Id;
                dieuChuyenNhanVien.DonViTraLuongNew_Id = appUser.DonViTraLuong_Id;
                dieuChuyenNhanVien.NgayDieuChuyen = DateTime.Now;
                uow.dieuChuyenNhanViens.Add(dieuChuyenNhanVien);
            }
            else if(uow.dieuChuyenNhanViens.Exists(x => x.User_Id.ToString() == model.Id 
            ))
            {
                dieuChuyenNhanVien.Id = dcnvId;
                dieuChuyenNhanVien.CreatedDate = DateTime.Now;
                dieuChuyenNhanVien.CreatedBy = Guid.Parse(User.Identity.Name);
                dieuChuyenNhanVien.User_Id = appUser.Id;
                dieuChuyenNhanVien.MaNhanVien = appUser.MaNhanVien;
                dieuChuyenNhanVien.UserName = appUser.UserName;
                dieuChuyenNhanVien.DonVi_Id = appUser.DonVi_Id;
                dieuChuyenNhanVien.ChucVu_Id = appUser.ChucVu_Id;
                dieuChuyenNhanVien.PhongBan_Id = appUser.PhongBan_Id;
                dieuChuyenNhanVien.BoPhan_Id = appUser.BoPhan_Id;
                dieuChuyenNhanVien.DonViTraLuong_Id = appUser.DonViTraLuong_Id;
                dieuChuyenNhanVien.DonViNew_Id = null;
                dieuChuyenNhanVien.ChucVuNew_Id = null;
                dieuChuyenNhanVien.PhongBanNew_Id = null;
                dieuChuyenNhanVien.BoPhanNew_Id = null;
                dieuChuyenNhanVien.DonViTraLuongNew_Id = null;
                dieuChuyenNhanVien.NgayDieuChuyen = DateTime.Now;
                uow.dieuChuyenNhanViens.Add(dieuChuyenNhanVien);
            }*/
            appUser.UserName = UserName;
            appUser.NormalizedUserName = UserName.ToUpper();
            appUser.FullName = model.FullName;
            appUser.MaNhanVien = model.MaNhanVien;
            appUser.Email = model.Email;
            appUser.PhoneNumber = model.PhoneNumber;
            appUser.IsActive = model.IsActive;
            appUser.UpdatedDate = DateTime.Now;
            appUser.DonVi_Id = model.DonVi_Id;
            appUser.BoPhan_Id = model.BoPhan_Id;
            appUser.ChucVu_Id = model.ChucVu_Id;
            appUser.PhongBan_Id = model.PhongBan_Id;
            appUser.DonViTraLuong_Id = model.DonViTraLuong_Id;
            var result = await userManager.UpdateAsync(appUser);
/*            if (uow.dieuChuyenNhanViens.Exists(x => x.User_Id.ToString() == model.Id
                && x.DonViNew_Id == model.DonVi_Id
                && x.BoPhanNew_Id == model.BoPhan_Id
                && x.PhongBanNew_Id == model.PhongBan_Id
                && x.ChucVuNew_Id == model.ChucVu_Id))
            {
                
            }
            else if (uow.dieuChuyenNhanViens.Exists(x => x.User_Id.ToString() == model.Id && x.DonViNew_Id == null))
            {
                var dieuchuyen = uow.dieuChuyenNhanViens.GetAll(x => x.User_Id.ToString() == model.Id && x.Id==dcnvId).ToArray();
                if (dieuchuyen[0].BoPhan_Id != model.BoPhan_Id)
                {
                    dieuchuyen[0].BoPhanNew_Id = model.BoPhan_Id;
                }
                else
                {
                    dieuchuyen[0].BoPhanNew_Id = model.BoPhan_Id;
                }
                if (dieuchuyen[0].ChucVu_Id != model.ChucVu_Id)
                {
                    dieuchuyen[0].ChucVuNew_Id = model.ChucVu_Id;
                }
                else
                {
                    dieuchuyen[0].ChucVuNew_Id = model.ChucVu_Id;
                }
                if (dieuchuyen[0].DonVi_Id != model.DonVi_Id)
                {
                    dieuchuyen[0].DonViNew_Id = model.DonVi_Id;
                }
                else
                {
                    dieuchuyen[0].DonViNew_Id = model.DonVi_Id;
                }
                if (dieuchuyen[0].PhongBan_Id != model.PhongBan_Id)
                {
                    dieuchuyen[0].PhongBanNew_Id = model.PhongBan_Id;
                }
                else
                {
                    dieuchuyen[0].PhongBanNew_Id = model.PhongBan_Id;
                }
                if (dieuchuyen[0].DonViTraLuong_Id != model.DonViTraLuong_Id)
                {
                    dieuchuyen[0].DonViTraLuongNew_Id = model.DonViTraLuong_Id;
                }
                else
                {
                    dieuchuyen[0].DonViTraLuongNew_Id = model.DonViTraLuong_Id;
                }

                uow.dieuChuyenNhanViens.Update(dieuchuyen[0]);
                LichSuThietBi lichSuThietBi = new LichSuThietBi();
                //thêm vòng lặp chứ không sai!! chưa thêm
                if (uow.lichSuThietBis.Exists(x => x.User_Id == dieuchuyen[0].User_Id))
                {
                    var lichsutb = uow.lichSuThietBis.GetAll(x => x.User_Id == dieuchuyen[0].User_Id).ToArray();
                    lichsutb[0].NgayKetThuc = DateTime.Now;
                    uow.lichSuThietBis.Update(lichsutb[0]);
                    Guid lstbId = Guid.NewGuid();
                    lichSuThietBi.Id = lstbId;
                    lichSuThietBi.CreatedDate = DateTime.Now;
                    lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                    lichSuThietBi.User_Id = dieuchuyen[0].User_Id;
                    lichSuThietBi.ThongTinThietBi_Id = lichsutb[0].ThongTinThietBi_Id;
                    lichSuThietBi.TinhTrangThietBi = lichsutb[0].TinhTrangThietBi;
                    lichSuThietBi.DonVi_Id = dieuchuyen[0].DonViNew_Id;
                    lichSuThietBi.PhongBan_Id = dieuchuyen[0].PhongBanNew_Id;
                    lichSuThietBi.BoPhan_Id = dieuchuyen[0].BoPhanNew_Id;
                    lichSuThietBi.ChucVu_Id = dieuchuyen[0].ChucVuNew_Id;
                    lichSuThietBi.DonViTraLuong_Id = dieuchuyen[0].DonViTraLuongNew_Id;
                    lichSuThietBi.NgayBatDau = DateTime.Now;
                    lichSuThietBi.NgayKetThuc = null;
                    uow.lichSuThietBis.Add(lichSuThietBi);
                }
            }
            else
            {
                var dieuchuyen = uow.dieuChuyenNhanViens.GetAll(x => x.User_Id.ToString() == model.Id && x.Id == dcnvId).ToArray();

                    if (dieuchuyen[0].BoPhan_Id != model.BoPhan_Id)
                    {
                        dieuchuyen[0].BoPhanNew_Id = model.BoPhan_Id;
                    }
                    else
                    {
                        dieuchuyen[0].BoPhanNew_Id = model.BoPhan_Id;
                    }
                    if (dieuchuyen[0].ChucVu_Id != model.ChucVu_Id)
                    {
                        dieuchuyen[0].ChucVuNew_Id = model.ChucVu_Id;
                    }
                    else
                    {
                        dieuchuyen[0].ChucVuNew_Id = model.ChucVu_Id;
                    }
                    if (dieuchuyen[0].DonVi_Id != model.DonVi_Id)
                    {
                        dieuchuyen[0].DonViNew_Id = model.DonVi_Id;
                    }
                    else
                    {
                        dieuchuyen[0].DonViNew_Id = model.DonVi_Id;
                    }
                    if (dieuchuyen[0].PhongBan_Id != model.PhongBan_Id)
                    {
                        dieuchuyen[0].PhongBanNew_Id = model.PhongBan_Id;
                    }
                    else
                    {
                        dieuchuyen[0].PhongBanNew_Id = model.PhongBan_Id;
                    }
                    if (dieuchuyen[0].DonViTraLuong_Id != model.DonViTraLuong_Id)
                    {
                        dieuchuyen[0].DonViTraLuongNew_Id = model.DonViTraLuong_Id;
                    }
                    else
                    {
                        dieuchuyen[0].DonViTraLuongNew_Id = model.DonViTraLuong_Id;
                    }
                    uow.dieuChuyenNhanViens.Update(dieuchuyen[0]);
                LichSuThietBi lichSuThietBi = new LichSuThietBi();
                if (uow.lichSuThietBis.Exists(x => x.User_Id == dieuchuyen[0].User_Id))
                {
                    var lichsutb = uow.lichSuThietBis.GetAll(x=>x.User_Id==dieuchuyen[0].User_Id).ToArray();
                    lichsutb[0].NgayKetThuc = DateTime.Now;
                    uow.lichSuThietBis.Update(lichsutb[0]);
                    Guid lstbId = Guid.NewGuid();
                    lichSuThietBi.Id = lstbId;
                    lichSuThietBi.CreatedDate = DateTime.Now;
                    lichSuThietBi.CreatedBy = Guid.Parse(User.Identity.Name);
                    lichSuThietBi.User_Id = dieuchuyen[0].User_Id;
                    lichSuThietBi.ThongTinThietBi_Id = lichsutb[0].ThongTinThietBi_Id;
                    lichSuThietBi.TinhTrangThietBi = lichsutb[0].TinhTrangThietBi;
                    lichSuThietBi.DonVi_Id= dieuchuyen[0].DonViNew_Id;
                    lichSuThietBi.PhongBan_Id= dieuchuyen[0].PhongBanNew_Id;
                    lichSuThietBi.BoPhan_Id = dieuchuyen[0].BoPhanNew_Id;
                    lichSuThietBi.ChucVu_Id = dieuchuyen[0].ChucVuNew_Id;
                    lichSuThietBi.DonViTraLuong_Id = dieuchuyen[0].DonViTraLuongNew_Id;
                    lichSuThietBi.NgayBatDau = DateTime.Now;
                    lichSuThietBi.NgayKetThuc = null;
                    uow.lichSuThietBis.Add(lichSuThietBi);
                }
                } */         
            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(appUser);
                foreach (string item_remove in roles)
                {
                    await userManager.RemoveFromRoleAsync(appUser, item_remove);
                }
                foreach (string RoleName in model.RoleNames)
                {
                    await userManager.AddToRoleAsync(appUser, RoleName);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
                return BadRequest(string.Join(",", result.Errors));
        }


        [HttpPut("nghi-viec/{id}")]
        public async Task<IActionResult> PutNghiViec(string id, UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != model.Id)
            {
                return BadRequest();
            }
            var UserName = model.Email.Split(new[] { '@' })[0];
            var exit = await userManager.FindByEmailAsync(model.Email);
            // Kiểm tra tài khoản, email có tồn tại không
            if (exit != null && exit.Id.ToString() != id)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Thông tin tài khoản, email đã tồn tại");
            }
            var appUser = await userManager.FindByIdAsync(model.Id);
            appUser.UserName = appUser.UserName;
            appUser.NormalizedUserName = appUser.UserName.ToUpper();
            appUser.FullName = appUser.FullName;
            appUser.MaNhanVien = appUser.MaNhanVien;
            appUser.Email = appUser.Email;
            appUser.PhoneNumber = appUser.PhoneNumber;
            appUser.IsActive = appUser.IsActive;
            appUser.UpdatedDate = DateTime.Now;
            appUser.DonVi_Id = appUser.DonVi_Id;
            appUser.BoPhan_Id = appUser.BoPhan_Id;
            appUser.ChucVu_Id = appUser.ChucVu_Id;
            appUser.PhongBan_Id = appUser.PhongBan_Id;
            appUser.DonViTraLuong_Id = appUser.DonViTraLuong_Id;
            appUser.NghiViec = true;
            appUser.NgayNghiViec = model.NgayNghiViec;
            appUser.GhiChu = model.GhiChu;
            appUser.IsActive = model.IsActive;
            appUser.UpdatedDate = DateTime.Now;

            var result = await userManager.UpdateAsync(appUser);

            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(appUser);
                foreach (string item_remove in roles)
                {
                    await userManager.RemoveFromRoleAsync(appUser, item_remove);
                }
                foreach (string RoleName in model.RoleNames)
                {
                    await userManager.AddToRoleAsync(appUser, RoleName);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
                return BadRequest(string.Join(",", result.Errors));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var appUser = await userManager.FindByIdAsync(id);
            if (appUser == null)
                return NotFound();
            else
            {
                var role = await userManager.GetRolesAsync(appUser);
                if (role.Count > 0)
                {
                    if (appUser.NghiViec == false && (appUser.NgayNghiViec == DateTime.Now || appUser.NgayNghiViec <= DateTime.Now))
                    {
                        return Ok(new UserInfoModel
                        {

                            Id = id,
                            Email = appUser.Email,
                            PhoneNumber = appUser.PhoneNumber,
                            UserName = appUser.UserName,
                            MaNhanVien = appUser.MaNhanVien,
                            FullName = appUser.FullName,
                            IsActive = appUser.IsActive,
                            RoleNames = role.ToList(),
                            BoPhan_Id = appUser.BoPhan_Id,
                            DonVi_Id = appUser.DonVi_Id,
                            ChucVu_Id = appUser.ChucVu_Id,
                            PhongBan_Id = appUser.PhongBan_Id,
                            DonViTraLuong_Id = appUser.DonViTraLuong_Id
                            // DonVi_Id = appUser.DonVi_Id
                        });
                    }

                }
                return BadRequest();
            }
        }
        [HttpGet("GetListUser")]
        public async Task<ActionResult> GetListUser(string keyword = null)
        {
            var query = userManager.Users.Where(x => (string.IsNullOrEmpty(keyword) || x.Email.ToLower().Contains(keyword.ToLower()) || x.UserName.ToLower().Contains(keyword.ToLower()) || x.FullName.ToLower().Contains(keyword.ToLower())) && !x.IsDeleted)
            .Include(u => u.DonVi)
            .Include(u => u.BoPhan)
            .Include(u => u.ChucVu)
            .Include(u => u.Phongban)
            .Include(u => u.DonViTraLuong); 
            List<ListUserModel> list = new List<ListUserModel>();

            foreach (var item in query)
            {
                
                var infor = new ListUserModel();
                if (item.NghiViec == false && (item.NgayNghiViec==DateTime.Now || item.NgayNghiViec<=DateTime.Now))
                {
                    
                    infor.Id = item.Id.ToString();
                    infor.FullName = item.FullName;
                    infor.TenBoPhan = item.BoPhan.TenBoPhan;
                    infor.TenDonVi = item.DonVi.TenDonVi;
                    infor.TenChucVu = item.ChucVu.TenChucVu;
                    infor.TenPhongBan = item.Phongban.TenPhongBan;
                    infor.TenDonViTraLuong = item.DonViTraLuong.TenDonViTraLuong;
                    list.Add(infor);
                }

            }
            return Ok(list);
        }

        [HttpGet("Get-List-User-nghi-viec")]
        public async Task<ActionResult> GetListUserNghiViec(string keyword = null)
        {
            var query = userManager.Users.Where(x => (string.IsNullOrEmpty(keyword) || x.Email.ToLower().Contains(keyword.ToLower()) || x.UserName.ToLower().Contains(keyword.ToLower()) || x.FullName.ToLower().Contains(keyword.ToLower())) && !x.IsDeleted)
           .Include(u => u.DonVi)
           .Include(u => u.BoPhan)
           .Include(u => u.ChucVu)
           .Include(u => u.Phongban)
           .Include(u => u.DonViTraLuong);
            List<ListUserModelNghiViec> list = new List<ListUserModelNghiViec>();

            foreach (var item in query)
            {
                var infor = new ListUserModelNghiViec();
                if(item.NghiViec == true)
                {
                    infor.Id = item.Id.ToString();
                    infor.FullName = item.FullName;
                    infor.TenBoPhan = item.BoPhan.TenBoPhan;
                    infor.TenDonVi = item.DonVi.TenDonVi;
                    infor.TenChucVu = item.ChucVu.TenChucVu;
                    infor.TenPhongBan = item.Phongban.TenPhongBan;
                    infor.TenDonViTraLuong = item.DonViTraLuong.TenDonViTraLuong;
                    infor.NgayNghiViec = item.NgayNghiViec;
                    infor.GhiChu = item.GhiChu;
                    list.Add(infor);
                }

            }
            return Ok(list);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int page = 1, int pageSize = 20, string keyword = null)
        {
            var query = userManager.Users.Where(x => (string.IsNullOrEmpty(keyword) || x.Email.ToLower().Contains(keyword.ToLower()) || x.UserName.ToLower().Contains(keyword.ToLower()) || x.FullName.ToLower().Contains(keyword.ToLower())) && !x.IsDeleted)
            .Include(u => u.DonVi)
            .Include(u => u.BoPhan)
            .Include(u=>u.ChucVu)
            .Include(u=>u.Phongban)
            .Include(u=>u.DonViTraLuong);
            List<UserInfoModel> list = new List<UserInfoModel>();
            foreach (var item in query)
            {
                var role = await userManager.GetRolesAsync(item);
                if (role.Count > 0)
                {
                    if (item.NghiViec == false)
                    {
                        var info = new UserInfoModel();
                        info.Id = item.Id.ToString();
                        info.Email = item.Email;
                        info.UserName = item.UserName;
                        info.MaNhanVien = item.MaNhanVien;
                        info.FullName = item.FullName;
                        info.IsActive = item.IsActive;
                        info.RoleNames = role.ToList();
                        info.TenBoPhan = item.BoPhan.TenBoPhan;
                        info.TenDonVi = item.DonVi.TenDonVi;
                        info.TenChucVu = item.ChucVu.TenChucVu;
                        info.TenPhongBan = item.Phongban.TenPhongBan;
                        info.TenDonViTraLuong = item.DonViTraLuong.TenDonViTraLuong;
                        list.Add(info);
                    }

                }
            }
            int totalRow = list.Count();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(new
            {
                totalRow,
                totalPage,
                data
            });
        }
        [HttpPut("Active/{id}")]
        public async Task<ActionResult> Active(string id)
        {
            var appUser = await userManager.FindByIdAsync(id);
            appUser.IsActive = !appUser.IsActive;
            appUser.UpdatedDate = DateTime.Now;
            var result = await userManager.UpdateAsync(appUser);
            if (result.Succeeded)
            {
                if (appUser.IsActive)
                {
                    return StatusCode(StatusCodes.Status200OK, "Mở khóa tài khoản thành công");
                }
                return StatusCode(StatusCodes.Status200OK, "Khóa tài khoản thành công");
            }
            return BadRequest(string.Join(",", result.Errors));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var appUser = await userManager.FindByIdAsync(id);
            appUser.IsDeleted = true;
            appUser.DeletedDate = DateTime.Now;
            var result = await userManager.UpdateAsync(appUser);
            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK, "Xóa tài khoản thành công");
            }
            return BadRequest(string.Join(",", result.Errors));
        }
        [HttpPut("ResetPassword/{id}")]
        public async Task<ActionResult> ResetPassword(string id)
        {
            var Password = config.GetValue<string>("DefaultPass");
            var appUser = await userManager.FindByIdAsync(id);
            appUser.UpdatedDate = DateTime.Now;
            appUser.MustChangePass = true;
            appUser.PasswordHash = userManager.PasswordHasher.HashPassword(appUser, Password);
            var result = await userManager.UpdateAsync(appUser);
            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK, "Khôi phục mật khẩu mặc định thành công");
            }
            return BadRequest(string.Join(",", result.Errors));
        }
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var appUser = await userManager.FindByIdAsync(User.Identity.Name);
            appUser.MustChangePass = false;
            appUser.UpdatedDate = DateTime.Now;
            var result = await userManager.ChangePasswordAsync(appUser, model.Password, model.NewPassword);
            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK, "Đổi mật khẩu thành công");
            }
            return BadRequest("Mật khẩu hiện tại không đúng");
        }
        [HttpPost("Import")]
        public async Task<ActionResult> Import(IFormFile file)
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            DateTime dt = DateTime.Now;
            // Rename file
            string fileName = (long)timeSpan.TotalSeconds + "_" + Commons.TiengVietKhongDau(file.FileName);
            string fileExt = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
            string[] supportedTypes = new[] { "xls", "xlsx" };
            if (supportedTypes.Contains(fileExt))
            {
                string webRootPath = environment.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                }
                string fullPath = Path.Combine(webRootPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                byte[] file_byte = System.IO.File.ReadAllBytes(fullPath);
                //Kiểm tra tồn tại file và xóa
                System.IO.File.Delete(fullPath);
                using (MemoryStream ms = new MemoryStream(file_byte))
                using (ExcelPackage package = new ExcelPackage(ms))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    for (int i = 2; i <= rowCount; i++)
                    {
                        object hoten = worksheet.Cells[i, 1].Value;
                        string HoTen = hoten.ToString().Trim().Replace("\t", "").Replace("\n", "");
                        object email = worksheet.Cells[i, 2].Value;
                        string Email = email.ToString().Trim().Replace("\t", "").Replace("\n", "");
                        object vaitro = worksheet.Cells[i, 3].Value;
                        string VaiTro = vaitro.ToString().Trim().Replace("\t", "").Replace("\n", "");
                        var UserName = Email.Split(new[] { '@' })[0];
                        var exit_username = await userManager.FindByNameAsync(UserName);
                        var exit_email = await userManager.FindByEmailAsync(Email);
                        // Kiểm tra tài khoản, email có tồn tại không
                        if (exit_username == null && exit_email == null)
                        {
                            var Password = config.GetValue<string>("DefaultPass");
                            var user = new ApplicationUser() { UserName = UserName, FullName = HoTen, Email = Email, IsActive = true, MustChangePass = true, CreatedDate = DateTime.Now };
                            IdentityResult result = await userManager.CreateAsync(user, Password);
                            if (result.Succeeded)
                            {
                                await userManager.AddToRoleAsync(user, VaiTro);
                            }
                        }
                    }
                    return Ok();
                }
            }
            return BadRequest("Định dạng tệp tin không cho phép");
        }
    }
}