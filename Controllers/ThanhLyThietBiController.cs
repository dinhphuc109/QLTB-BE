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
    public class ThanhLyThietBiController : ControllerBase
    {
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public ThanhLyThietBiController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
        }
        [HttpGet]
        public ActionResult Get(string keyword)
        {
            if (keyword == null) keyword = "";

            string[] include = { "User", "thanhLyKhos", "thanhLyKhos.ThongTinThietBi" };
            var data = uow.thanhLyThietBis.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.MaThanhLy,
                x.User,
                x.ThoiGianThanhLy,
                x.Kho_Id,
                Lsttlk = x.thanhLyKhos.Select(y => new
                {
                    y.ThongTinThietBi_Id,
                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaThanhLy));
        }

        [HttpGet("search-thanh-ly-thiet-bi")]
        public IActionResult SearchThanhLyThietBi(string keyword, DateTime? TuNgay, DateTime? DenNgay)
        {
            if (keyword == null) keyword = "";
            string[] include = { "User", "thanhLyKhos", "thanhLyKhos.ThongTinThietBi" };
            var data = uow.thanhLyThietBis.GetAll(x => !x.IsDeleted
            && x.ThoiGianThanhLy>=TuNgay && x.ThoiGianThanhLy<=DenNgay, null, include).Select(x => new
            {
                x.Id,
                x.MaThanhLy,
                x.User,
                x.ThoiGianThanhLy,
                x.Kho_Id,
                Lsttlk = x.thanhLyKhos.Select(y => new
                {
                    y.ThongTinThietBi_Id,
                })
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaThanhLy));
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            string[] includes = { "User", "thanhLyKhos", "thanhLyKhos.Kho" };
            var duLieu = uow.thanhLyThietBis.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
            if (duLieu == null)
            {
                return NotFound();
            }
            return Ok(duLieu);
        }

        [HttpPost]
        public ActionResult Post(ThanhLyThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.thanhLyThietBis.Exists(x => x.MaThanhLy == data.MaThanhLy && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaThanhLy + " đã tồn tại trong hệ thống");
                else if (uow.thanhLyThietBis.Exists(x => x.MaThanhLy == data.MaThanhLy && x.IsDeleted))
                {
                    var thanhlytb = uow.thanhLyThietBis.GetAll(x => x.Id == data.Id).ToArray();
                    thanhlytb[0].IsDeleted = false;
                    thanhlytb[0].DeletedBy = null;
                    thanhlytb[0].DeletedDate = null;
                    thanhlytb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    thanhlytb[0].UpdatedDate = DateTime.Now;
                    thanhlytb[0].MaThanhLy = data.MaThanhLy;
                    thanhlytb[0].User_Id=data.User_Id;
                    thanhlytb[0].ThoiGianThanhLy = data.ThoiGianThanhLy;
                    thanhlytb[0].Kho_Id = data.Kho_Id;

                    foreach (var item in data.Lsttlk)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.ThanhLyThietBi_Id = thanhlytb[0].Id;
                        uow.thanhLyKhos.Add(item);

                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);

                    var kho = uow.khos.GetAll(x => x.Id == data.Kho_Id).ToArray();
                    foreach (var item in data.Lsttlk)
                    {
                        if (uow.khoThongTinThietBis.Exists(x => x.Kho_Id == kho[0].Id && x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            var tttb = uow.khoThongTinThietBis.GetAll(t => !t.IsDeleted  && t.Id == item.ThongTinThietBi_Id).ToArray();
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            item.CreatedDate = DateTime.Now;
                            item.ThanhLyThietBi_Id = id;
                    
                            uow.thanhLyKhos.Add(item);
                     
                        }
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
                                var appUser = userManager.FindByIdAsync(data.User_Id.ToString()).Result;
                                lichsuthietbi.CreatedBy = Guid.Parse(User.Identity.Name);
                                lichsuthietbi.CreatedDate = DateTime.Now;
                                lichsuthietbi.Id = lstbid;
                                lichsuthietbi.User_Id = data.User_Id;
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
                                existingLichSu[0].NgayKetThuc = DateTime.Now;
                                uow.lichSuThietBis.Update(existingLichSu[0]);
                                var appUser = userManager.FindByIdAsync(data.User_Id.ToString()).Result;
                                lichsuthietbi.CreatedBy = Guid.Parse(User.Identity.Name);
                                lichsuthietbi.CreatedDate = DateTime.Now;
                                lichsuthietbi.Id = lstbid;
                                lichsuthietbi.User_Id = data.User_Id;
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
                    uow.thanhLyThietBis.Add(data);
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, ThanhLyThietBi data)
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
                if (uow.thanhLyThietBis.Exists(x => x.MaThanhLy == data.MaThanhLy && x.Id!=data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaThanhLy + " đã tồn tại trong hệ thống");
                /*var existingEntity = uow.thanhLyThietBis.GetById(id); // Lấy thực thể từ cơ sở dữ liệu
                if (existingEntity == null)
                {
                    return NotFound(); // Xử lý trường hợp thực thể không tồn tại
                }

                // Cập nhật các thuộc tính của thực thể hiện tại
                int soluongsau = existingEntity.SoLuong + data.SoLuong;
                existingEntity.SoLuong = data.SoLuong;
                existingEntity.UpdatedBy = Guid.Parse(User.Identity.Name);
                existingEntity.UpdatedDate = DateTime.Now;

                uow.thanhLyThietBis.Update(existingEntity);
                //uow.thanhLyThietBis.Update(data);
                var thanhly = uow.thanhLyThietBis.GetAll(x => !x.IsDeleted && x.Id == data.Id, null, null).Select(x => new { x.SoLuong }).ToArray();*/

                
                var Lsttlk = data.Lsttlk;
                var dataCheck = uow.thanhLyKhos.GetAll(x => !x.IsDeleted && x.ThanhLyThietBi_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!Lsttlk.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            uow.thanhLyKhos.Delete(item.Id);
                        }
                    }
                    foreach (var item in Lsttlk)
                    {
                        if (dataCheck.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            item.ThanhLyThietBi_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            var kho = uow.khos.GetAll(x => !x.IsDeleted && x.Id == data.Kho_Id, null, null).ToArray();
                            uow.thanhLyKhos.Add(item);
                        }
                    }
                    
                }

                else
                {
                    foreach (var item in Lsttlk)
                    {
                        item.ThanhLyThietBi_Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        var kho = uow.khos.GetAll(x => !x.IsDeleted && x.Id == data.Kho_Id, null, null).ToArray();
                        uow.thanhLyKhos.Add(item);
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
                ThanhLyThietBi duLieu = uow.thanhLyThietBis.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    var dataCheck = uow.thanhLyKhos.GetAll(x => !x.IsDeleted && x.ThanhLyThietBi_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.thanhLyKhos.Delete(item.Id);
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.thanhLyThietBis.Update(duLieu);
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
                uow.thanhLyThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
    }
}
