using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
  public class NhaCungCapController : ControllerBase
  {
    private readonly IUnitofWork uow;
    private readonly UserManager<ApplicationUser> userManager;
    public static IWebHostEnvironment environment;
    public NhaCungCapController(IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
    {
      uow = _uow;
      userManager = _userManager;
      environment = _environment;
    }

    [HttpGet]
    public ActionResult Get(string keyword)
    {
            if (keyword == null) keyword = "";
            string[] include = { };
            var data = uow.NhaCungCaps.GetAll(t => !t.IsDeleted && (t.MaNhaCungCap.ToLower().Contains(keyword.ToLower()) || t.TenNhaCungCap.ToLower().Contains(keyword.ToLower())),null,include).Select(x => new
      {
        x.Id,
        x.MaNhaCungCap,
        x.TenNhaCungCap,
        x.NguoiLienHe,
        x.SoDienThoai,
        x.DiaChi,
        x.Email
      });
      if (data == null)
      {
        return NotFound();
      }
      return Ok(data);
    }

    [HttpGet("{id}")]
    public ActionResult Get(Guid id)
    {
      NhaCungCap duLieu = uow.NhaCungCaps.GetById(id);
      if (duLieu == null)
      {
        return NotFound();
      }
      return Ok(duLieu);
    }

        private string CheckPhoneNumber(string phoneNumber)
        {
            string mobilePattern = @"^(09[6-8]|03[2-9]|07[0-9]|05[6-9]|08[6-9])\d{7}$";
            string landlinePattern = @"^(02[4-9]|08[3-5])\d{7}$";

            if (Regex.IsMatch(phoneNumber, mobilePattern) || Regex.IsMatch(phoneNumber, landlinePattern))
            {
                return "Số điện thoại hợp lệ";
            }
            else
            {
                return "Số điện thoại không hợp lệ";
            }
        }

        [HttpPost]
    public ActionResult Post(NhaCungCap data)
    {
      lock (Commons.LockObjectState)
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        if (uow.NhaCungCaps.Exists(x => x.MaNhaCungCap == data.MaNhaCungCap && !x.IsDeleted))
          return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaNhaCungCap + " đã tồn tại trong hệ thống");
                var phoneCheckResult = CheckPhoneNumber(data.SoDienThoai);
                if (phoneCheckResult != "Số điện thoại hợp lệ")
                {
                    return BadRequest(phoneCheckResult);
                }
                data.CreatedDate = DateTime.Now;
        data.CreatedBy = Guid.Parse(User.Identity.Name);
        uow.NhaCungCaps.Add(data);
        uow.Complete();
        return Ok();
      }
    }

    [HttpPut("{id}")]
    public ActionResult Put(Guid id, NhaCungCap data)
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
                if (uow.NhaCungCaps.Exists(x => x.MaNhaCungCap == data.MaNhaCungCap && x.Id != data.Id && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã " + data.MaNhaCungCap + " đã tồn tại trong hệ thống");
                data.UpdatedBy = Guid.Parse(User.Identity.Name);
        data.UpdatedDate = DateTime.Now;
        uow.NhaCungCaps.Update(data);
        uow.Complete();
        return StatusCode(StatusCodes.Status204NoContent);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
      lock (Commons.LockObjectState)
      {
        NhaCungCap duLieu = uow.NhaCungCaps.GetById(id);
                if (!uow.thongTinThietBis.Exists(x => x.NhaCungCap_Id == id))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.NhaCungCaps.Update(duLieu);
                    uow.Complete();
                    return Ok(duLieu);
                }
                return StatusCode(StatusCodes.Status409Conflict, "Nhà cung cấp này đã có ở thiết bị không được xóa");
            }

    }
    [HttpDelete("Remove/{id}")]
    public ActionResult Delete_Remove(Guid id)
    {
      lock (Commons.LockObjectState)
      {
        uow.NhaCungCaps.Delete(id);
        uow.Complete();
        return Ok();
      }
    }
  }
}