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

            string[] include = {"User","DonViTinh", "banGiaoThongTinThietBis", "banGiaoThongTinThietBis.ThongTinThietBi", "banGiaoNguoiNhans", "banGiaoNguoiNhans.User" };
            var data = uow.banGiaoTBs.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.MaBanGIao,
                x.User_Id,
                x.TinhTrangThietBi,
                x.NgayNhan,
                x.DonViTinh.TenDonViTinh,
                x.SoLuong,
                x.GhiChu,
                Lstbgtttb = x.banGiaoThongTinThietBis.Select(y => new
                {
                    y.ThongTinThietBi.TenThietBi,
                    y.ThongTinThietBi.CauHinh,
                    y.ThongTinThietBi.ThoiGianBaoHanh,
                    y.ThongTinThietBi.SoSeri,
                    y.ThongTinThietBi.ModelThietBi,
                }),
                Lstbgnn = x.banGiaoNguoiNhans.Select(y => new
                {
                    y.User.MaNhanVien,
                    y.User.FullName,

                })

            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.MaBanGIao));
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
                if (uow.banGiaoTBs.Exists(x => x.Id == data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaBanGIao + " đã tồn tại trong hệ thống");
                else if (uow.khos.Exists(x => x.Id == data.Id && !x.IsDeleted))
                {
                    var banGiaotb = uow.banGiaoTBs.GetAll(x => x.Id == data.Id).ToArray();
                    banGiaotb[0].IsDeleted = false;
                    banGiaotb[0].DeletedBy = null;
                    banGiaotb[0].DeletedDate = null;
                    banGiaotb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    banGiaotb[0].UpdatedDate = DateTime.Now;
                    banGiaotb[0].MaBanGIao = data.MaBanGIao;
                    banGiaotb[0].TinhTrangThietBi = data.TinhTrangThietBi;
                    banGiaotb[0].SoLuong = data.SoLuong;
                    banGiaotb[0].DonViTinh_Id = data.DonViTinh_Id;
                    banGiaotb[0].NgayNhan = data.NgayNhan;
                    banGiaotb[0].GhiChu = data.GhiChu;
                    banGiaotb[0].User_Id = data.User_Id;


                    uow.banGiaoTBs.Update(banGiaotb[0]);
                    foreach (var item in data.Lstbgtttb)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.BanGiaoTB_Id = banGiaotb[0].Id;
                        uow.banGiaoThongTinThietBis.Add(item);
                    }
                    foreach (var item in data.Lstbgnn)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.BanGiaoTB_Id = banGiaotb[0].Id;
                        uow.banGiaoNguoiNhans.Add(item);
                    }
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);

                    uow.banGiaoTBs.Add(data);
                    foreach (var item in data.Lstbgtttb)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.BanGiaoTB_Id = id;
                        uow.banGiaoThongTinThietBis.Add(item);
                    }
                    foreach (var item in data.Lstbgnn)
                    {
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        item.CreatedDate = DateTime.Now;
                        item.BanGiaoTB_Id = id;
                        uow.banGiaoNguoiNhans.Add(item);
                    }
                }
                uow.Complete();
                return Ok();
            }
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
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
                data.UpdatedDate = DateTime.Now;
                uow.banGiaoTBs.Update(data);
                var Lstbgtttb = data.Lstbgtttb;
                var dataCheck = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == id).ToList();
                if (dataCheck.Count() > 0)
                {
                    foreach (var item in dataCheck)
                    {
                        if (!Lstbgtttb.Exists(x => x.ThongTinThietBi_Id == item.ThongTinThietBi_Id))
                        {
                            uow.banGiaoThongTinThietBis.Delete(item.Id);
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
                    }
                }
                var lstbgnn = data.Lstbgnn;
                var dataChecktttb = uow.banGiaoNguoiNhans.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == id).ToList();
                if (dataChecktttb.Count() > 0)
                {
                    foreach (var item in dataChecktttb)
                    {
                        if (!lstbgnn.Exists(x => x.User_Id == item.User_Id))
                        {
                            uow.banGiaoNguoiNhans.Delete(item.Id);
                        }
                    }
                    foreach (var item in lstbgnn)
                    {
                        if (!dataChecktttb.Exists(x => x.User_Id == item.User_Id))
                        {
                            item.BanGiaoTB_Id = id;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = Guid.Parse(User.Identity.Name);
                            uow.banGiaoNguoiNhans.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in lstbgnn)
                    {
                        item.BanGiaoTB_Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = Guid.Parse(User.Identity.Name);
                        uow.banGiaoNguoiNhans.Add(item);
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
                    var dataCheck = uow.banGiaoThongTinThietBis.GetAll(x => !x.IsDeleted && x.BanGiaoTB_Id == id).ToList();
                    foreach (var item in dataCheck)
                    {
                        uow.banGiaoThongTinThietBis.Delete(item.Id);
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
