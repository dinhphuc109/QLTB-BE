﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoController : Controller
    {
        private readonly IMyAdapter myAdapter;
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public BaoCaoController(IMyAdapter _myAdapter, IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
        {
            uow = _uow;
            userManager = _userManager;
            environment = _environment;
            myAdapter = _myAdapter;
        }


        //truy vấn thủ tục lịch sử thiết bị
        [HttpGet("get-lich-su-thiet-bi-data")]
        public IActionResult GetLichSuThietBiData(Guid? LoaiThietBiId)
        {
            try
            {
                // Mở kết nối trước khi thực hiện truy vấn
                myAdapter.OpenConnection();
                // Thực hiện truy vấn
                string storedProcedure = "sp_GetLichSuThietBi";
                string query = storedProcedure;

                // Kiểm tra giá trị của LoaiThietBiId
                /*                if (LoaiThietBiId != null)
                                {
                                    query = $"{storedProcedure} WHERE dm.LoaiThietBi_Id = @LoaiThietBiId";
                                }*/

                var parameters = new Dictionary<string, object>();
                if (LoaiThietBiId != null)
                {
                    query = $"{storedProcedure} @LoaiThietBiId";
                    parameters["@LoaiThietBiId"] = LoaiThietBiId;
                }

                DataTable dataTable = myAdapter.ExecuteQuery(query, parameters);

                // Kiểm tra kết quả trả về từ stored procedure
/*                if (dataTable.Rows.Count == 0)
                {
                    // Không có loại thiết bị này trong lịch sử thiết bị
                    return NotFound("Không có loại thiết bị này trong lịch sử thiết bị");
                }*/

                // Đóng kết nối sau khi sử dụng
                myAdapter.CloseConnection();
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
