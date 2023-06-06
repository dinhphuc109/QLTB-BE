using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCORE3.Infrastructure;
using NETCORE3.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Controllers
{
    [EnableCors("CorsApi")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinThietBiController : ControllerBase
    {
        private readonly IMyAdapter myAdapter;
        private readonly IUnitofWork uow;
        private readonly UserManager<ApplicationUser> userManager;
        public static IWebHostEnvironment environment;
        public ThongTinThietBiController(IMyAdapter _myAdapter, IUnitofWork _uow, UserManager<ApplicationUser> _userManager, IWebHostEnvironment _environment)
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
            
            string[] include = { "Domain", "NhaCungCap", "DonViTinh", "DanhMucThietBi", "DanhMucThietBi.HangThietBi", "DanhMucThietBi.LoaiThietBi.HeThong" };
            var data = uow.thongTinThietBis.GetAll(t => !t.IsDeleted, null, include).Select(x => new
            {
                x.Id,
                x.DanhMucThietBi_Id,
                x.DanhMucThietBi.MaThietBi,
                x.DanhMucThietBi.TenThietBi,
                x.DanhMucThietBi.CauHinh,
                x.DanhMucThietBi.HangThietBi.TenHang,
                x.DanhMucThietBi.LoaiThietbi_Id,
                x.DanhMucThietBi.LoaiThietBi.HeThong_Id,
                x.Domain.TenDomain,
                x.SoSeri,
                x.ModelThietBi,
                x.NhaCungCap.TenNhaCungCap,
                x.DonViTinh.TenDonViTinh,
                x.TinhTrangThietBi,
                x.ThoiGianBaoHanh,
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenThietBi));
        }

        [HttpGet("search-thong-tin-thiet-bi")]
        public IActionResult SearchThongTinThietBi(string keyword, Guid? HeThongId, Guid? LoaiThietBiId)
        {
            if (keyword == null) keyword = "";
            string[] include = { "Domain", "NhaCungCap", "DonViTinh", 
                                "DanhMucThietBi", "DanhMucThietBi.HangThietBi"
                                , "DanhMucThietBi.LoaiThietBi", "DanhMucThietBi.LoaiThietBi.HeThong" };
            var data = uow.thongTinThietBis.GetAll(x=> !x.IsDeleted 
            &&x.DanhMucThietBi.LoaiThietbi_Id == (LoaiThietBiId==null?x.DanhMucThietBi.LoaiThietbi_Id:LoaiThietBiId)
            && x.DanhMucThietBi.LoaiThietBi.HeThong_Id == (HeThongId==null?x.DanhMucThietBi.LoaiThietBi.HeThong_Id:HeThongId)
            && (x.DanhMucThietBi.TenThietBi.ToLower().Contains(keyword.ToLower())
            || x.DanhMucThietBi.MaThietBi.ToLower().Contains(keyword.ToLower())
            || x.SoSeri.ToLower().Contains(keyword.ToLower())
            || x.ModelThietBi.ToLower().Contains(keyword.ToLower())
            || x.Domain.TenDomain.ToLower().Contains(keyword.ToLower())
            || x.DanhMucThietBi.HangThietBi.TenHang.ToLower().Contains(keyword.ToLower())),null, include).Select(x=> new
            {
                x.Id,
                x.DanhMucThietBi_Id,
                x.DanhMucThietBi.MaThietBi,
                x.DanhMucThietBi.TenThietBi,
                x.DanhMucThietBi.CauHinh,
                x.DanhMucThietBi.HangThietBi.TenHang,
                x.DanhMucThietBi.LoaiThietbi_Id,
                x.Domain.TenDomain,
                x.SoSeri,
                x.ModelThietBi,
                x.NhaCungCap.TenNhaCungCap,
                x.DonViTinh.TenDonViTinh,
                x.TinhTrangThietBi,
                x.ThoiGianBaoHanh,
            });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.OrderBy(x => x.TenThietBi));
        }



        /*        public class ClassListThongTinThietBi
                {
                    public Guid Id { get; set; }
                    public string MaThietBi { get; set; }
                    public string TenThietBi { get; set; }
                    public string TenDomain { get; set; }
                    public string TenHang { get; set; }
                    public string TenNhaCungCap { get; set; }
                    public string SoSeri { get; set; }
                }

                [HttpGet("GetDataPagnigation")]
                public ActionResult GetDataPagnigation(int page = 1, int pageSize = 20, string keyword = null)
                {
                    if (keyword == null) keyword = "";
                    string[] include = { "Domain", "NhaCungCap", "HangThietBi", "LoaiThietBi" };
                    var query = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && (t.TenThietBi.ToLower().Contains(keyword.ToLower()) || t.MaThietBi.ToLower().Contains(keyword.ToLower())), null, include)
                    .Select(x => new
                    {
                        x.TenThietBi,
                        x.Id,
                        x.MaThietBi,
                        x.CauHinh,
                        x.Domain_Id,
                        x.HangThietBi_Id,
                        x.SoSeri,
                        x.ModelThietBi,
                        x.NhaCungCap_Id,
                        x.ThoiGianBaoHanh,
                        x.LoaiThietBi_Id,

                    })
                    .OrderBy(x => x.TenThietBi);
                    List<ClassListThongTinThietBi> list = new List<ClassListThongTinThietBi>();

                    foreach (var item in query)
                    {
                        var domain = uow.domains.GetAll(x => !x.IsDeleted && x.Id == item.Domain_Id, null, null).Select(x => new { x.TenDomain }).ToList();
                        var hangtb = uow.hangThietBis.GetAll(x => !x.IsDeleted && x.Id == item.HangThietBi_Id, null, null).Select(x => new { x.TenHang }).ToList();
                        var nhaCungCap = uow.NhaCungCaps.GetAll(x => !x.IsDeleted && x.Id == item.NhaCungCap_Id, null, null).Select(x => new { x.TenNhaCungCap }).ToList();

                        var infor = new ClassListThongTinThietBi();
                        infor.Id = item.Id;
                        infor.MaThietBi = item.MaThietBi;
                        infor.TenThietBi = item.TenThietBi;
                        infor.SoSeri = item.SoSeri;
                        infor.TenNhaCungCap = nhaCungCap[0].TenNhaCungCap;
                        infor.TenDomain = domain[0].TenDomain;
                        infor.TenHang = hangtb[0].TenHang;
                        list.Add(infor);
                    }
                    int totalRow = list.Count();
                    int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
                    var data = list.OrderByDescending(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize);
                    return Ok(new { data, totalPage, totalRow });
                }

                public class ClassThongTinThietBiDetail
                {
                    public Guid Id { get; set; }
                    public string MaThietBi { get; set; }
                    public string TenThietBi { get; set; }
                    public string TenDomain { get; set; }
                    public string TenHang { get; set; }
                    public string TenNhaCungCap { get; set; }
                    public string SoSeri { get; set; }
                    public string ModelThietBi { get; set; }
                    public string CauHinh { get; set; }
                    public DateTime ThoiGianBaoHanh { get; set; }
                    public string TenLoai { get; set; }

                }

                [HttpGet("GetThongTinThietBiDetail/{id}")]
                public ActionResult GetThongTinThietBiDetail(Guid id)
                {         
                    string[] include = { "Domain", "NhaCungCap", "HangThietBi", "LoaiThietBi" };
                    var query = uow.thongTinThietBis.GetAll(t => !t.IsDeleted && t.Id==id, null, include)
                    .Select(x => new
                    {
                        x.TenThietBi,
                        x.Id,
                        x.MaThietBi,
                        x.CauHinh,
                        x.Domain_Id,
                        x.HangThietBi_Id,
                        x.SoSeri,
                        x.ModelThietBi,
                        x.NhaCungCap_Id,
                        x.ThoiGianBaoHanh,
                        x.LoaiThietBi_Id,

                    })
                    .OrderBy(x => x.TenThietBi);
                    List<ClassThongTinThietBiDetail> list = new List<ClassThongTinThietBiDetail>(); ;
                    foreach (var item in query)
                    {
                        var domain = uow.domains.GetAll(x => !x.IsDeleted && x.Id == item.Domain_Id, null, null).Select(x => new { x.TenDomain }).ToList();
                        var hangtb = uow.hangThietBis.GetAll(x => !x.IsDeleted && x.Id == item.HangThietBi_Id, null, null).Select(x => new { x.TenHang }).ToList();
                        var nhaCungCap = uow.NhaCungCaps.GetAll(x => !x.IsDeleted && x.Id == item.NhaCungCap_Id, null, null).Select(x => new { x.TenNhaCungCap }).ToList();
                        var loaithietbi = uow.loaiThietBis.GetAll(x => !x.IsDeleted && x.Id == item.LoaiThietBi_Id, null, null).Select(x => new { x.TenLoaiThietBi }).ToList();
                        var infor = new ClassThongTinThietBiDetail();
                        infor.Id = item.Id;
                        infor.MaThietBi = item.MaThietBi;
                        infor.TenThietBi = item.TenThietBi;
                        infor.SoSeri = item.SoSeri;
                        infor.CauHinh = item.CauHinh;
                        infor.ModelThietBi = item.ModelThietBi;
                        infor.ThoiGianBaoHanh = item.ThoiGianBaoHanh;
                        infor.TenNhaCungCap = nhaCungCap[0].TenNhaCungCap;
                        infor.TenDomain = domain[0].TenDomain;
                        infor.TenHang = hangtb[0].TenHang;
                        infor.TenLoai = loaithietbi[0].TenLoaiThietBi;
                        list.Add(infor);
                    }
                    return Ok(list);
                }

                [HttpGet("{id}")]
                public ActionResult Get(Guid id)
                {
                    string[] includes = { "ChiTietLoaiThongTinThietBis" };
                    var duLieu = uow.thongTinThietBis.GetAll(x => !x.IsDeleted && x.Id == id, null, includes);
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    return Ok(duLieu);
                }*/

        [HttpPost]
        public ActionResult Post(ThongTinThietBi data)
        {
            lock (Commons.LockObjectState)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (uow.thongTinThietBis.Exists(x => x.SoSeri == data.SoSeri && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã số seri" + data.SoSeri + " đã tồn tại trong hệ thống");
                else if (uow.thongTinThietBis.Exists(x => x.SoSeri == data.SoSeri && x.IsDeleted))
                {
                    var thongtintb = uow.thongTinThietBis.GetAll(x => x.Id == data.Id).ToArray();
                    thongtintb[0].IsDeleted = false;
                    thongtintb[0].DeletedBy = null;
                    thongtintb[0].DeletedDate = null;
                    thongtintb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    thongtintb[0].UpdatedDate = DateTime.Now;
                    thongtintb[0].DanhMucThietBi_Id = data.DanhMucThietBi_Id;
                    thongtintb[0].Domain_Id = data.Domain_Id;
                    thongtintb[0].SoSeri = data.SoSeri;
                    thongtintb[0].ModelThietBi = data.ModelThietBi;
                    thongtintb[0].ThoiGianBaoHanh = data.ThoiGianBaoHanh;
                    thongtintb[0].TinhTrangThietBi = data.TinhTrangThietBi;
                    thongtintb[0].NhaCungCap_Id = data.NhaCungCap_Id;
                    uow.thongTinThietBis.Update(thongtintb[0]);

                }
                else
                {
                    Guid id = Guid.NewGuid();
                    data.Id = id;
                    data.CreatedDate = DateTime.Now;
                    data.CreatedBy = Guid.Parse(User.Identity.Name);
                    uow.thongTinThietBis.Add(data);
                }
                uow.Complete();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, ThongTinThietBi data)
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
                if (uow.thongTinThietBis.Exists(x => x.SoSeri == data.SoSeri && !x.IsDeleted))
                    return StatusCode(StatusCodes.Status409Conflict, "Mã số seri" + data.SoSeri + " đã tồn tại trong hệ thống");
                else if (uow.thongTinThietBis.Exists(x => x.SoSeri == data.SoSeri && x.IsDeleted))
                {
                    var thongtintb = uow.thongTinThietBis.GetAll(x => x.Id == data.Id).ToArray();
                    thongtintb[0].IsDeleted = false;
                    thongtintb[0].DeletedBy = null;
                    thongtintb[0].DeletedDate = null;
                    thongtintb[0].UpdatedBy = Guid.Parse(User.Identity.Name);
                    thongtintb[0].UpdatedDate = DateTime.Now;
                    thongtintb[0].DanhMucThietBi_Id = data.DanhMucThietBi_Id;
                    thongtintb[0].Domain_Id = data.Domain_Id;
                    thongtintb[0].SoSeri = data.SoSeri;
                    thongtintb[0].ModelThietBi = data.ModelThietBi;
                    thongtintb[0].ThoiGianBaoHanh = data.ThoiGianBaoHanh;
                    thongtintb[0].TinhTrangThietBi = data.TinhTrangThietBi;
                    thongtintb[0].NhaCungCap_Id = data.NhaCungCap_Id;
                    uow.thongTinThietBis.Update(thongtintb[0]);
                }
                else
                {
                    data.UpdatedBy = Guid.Parse(User.Identity.Name);
                    data.UpdatedDate = DateTime.Now;

                    uow.thongTinThietBis.Update(data);
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
                ThongTinThietBi duLieu = uow.thongTinThietBis.GetById(id);
                if (duLieu.CreatedBy == Guid.Parse(User.Identity.Name) || Guid.Parse(User.Identity.Name) == Guid.Parse("c662783d-03c0-4404-9473-1034f1ac1caa"))
                {
                    if (duLieu == null)
                    {
                        return NotFound();
                    }
                    duLieu.DeletedDate = DateTime.Now;
                    duLieu.DeletedBy = Guid.Parse(User.Identity.Name);
                    duLieu.IsDeleted = true;
                    uow.thongTinThietBis.Update(duLieu);
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
                uow.thongTinThietBis.Delete(id);
                uow.Complete();
                return Ok();
            }
        }
        //truy vấn thủ tục báo cáo sl thiết bị
        [HttpGet("GetDeviceData")]
        public IActionResult GetDeviceData()
        {
            try
            {
                // Mở kết nối trước khi thực hiện truy vấn
                myAdapter.OpenConnection();

                // Thực hiện truy vấn
                string storedProcedure = "sp_GetThongTinThietBi";
                DataTable dataTable = myAdapter.ExecuteQuery(storedProcedure);

                // Chuyển đổi DataTable thành danh sách đối tượng hoặc JSON theo ý muốn

                // Đóng kết nối sau khi sử dụng
                myAdapter.CloseConnection();
                var result = ConvertDataTableToJson(dataTable);
                myAdapter.Dispose();
                return Ok(dataTable);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return BadRequest(ex.Message);
            }
        }

        private object ConvertDataTableToJson(DataTable dataTable)
        {
            // Lấy thông tin loại thiết bị từ bảng "LoaiThietBi"
            var loaiThietBiData = myAdapter.ExecuteQuery("SELECT * FROM LoaiThietBis");

            // Tạo từ điển để lưu trữ thông tin loại thiết bị
            var loaiThietBiInfo = new Dictionary<string, string>();

            // Duyệt qua dữ liệu loại thiết bị và thêm vào từ điển
            foreach (DataRow row in loaiThietBiData.Rows)
            {
                var maLoaiThietBi = row["MaLoaiThietBi"].ToString();
                var tenLoaiThietBi = row["TenLoaiThietBi"].ToString();

                // Thêm thông tin loại thiết bị vào từ điển
                loaiThietBiInfo[maLoaiThietBi] = tenLoaiThietBi;
            }

            // Chuyển đổi DataTable thành danh sách đối tượng và trả về
            var result = dataTable.AsEnumerable()
                .Select(row => new
                {
                    MaThietBi = row["MaThietBi"],
                    TenThietBi = row["TenThietBi"],
                    LoaiThietBi = GetLoaiThietBiInfo(loaiThietBiInfo, row)
                })
                .ToList();

            return result;
        }

        private Dictionary<string, string> GetLoaiThietBiInfo(Dictionary<string, string> loaiThietBiInfo, DataRow row)
        {
            var loaiThietBi = new Dictionary<string, string>();

            // Duyệt qua các cột loại thiết bị và lấy thông tin tương ứng từ từ điển
            foreach (DataColumn column in row.Table.Columns)
            {
                var columnName = column.ColumnName;

                if (columnName.StartsWith("LoaiThietBis"))
                {
                    var loaiThietBiId = row[columnName].ToString();
                    if (loaiThietBiInfo.ContainsKey(loaiThietBiId))
                    {
                        var tenLoaiThietBi = loaiThietBiInfo[loaiThietBiId];
                        loaiThietBi[columnName] = tenLoaiThietBi;
                    }
                }
            }

            return loaiThietBi;
        }
        // Khai báo lớp đối tượng để lưu trữ thông tin từ dữ liệu truy vấn
        public class BaoCaoItem
        {
            public string TenDonVi { get; set; }
            public string TenMaThietBi { get; set; }
            public string TenThietBi { get; set; }
            public string CauHinh { get; set; }
            public string ModelThietBi { get; set; }
            public int TongSoLuong { get; set; }
        }

/*        [HttpGet("GetByDonViId/{donViId?}")]
        public ActionResult<IEnumerable<BaoCaoItem>> GetByDonViId(Guid? donViId)
        {
            string connectionString = "Server=.;Database=QLTB;User ID=sa;password=123123;TrustServerCertificate=True;MultipleActiveResultSets=true;Timeout=300;"; // Thay thế bằng chuỗi kết nối đến cơ sở dữ liệu của bạn

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_BaoCaoSLTheoDonVi", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonViId", donViId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        List<BaoCaoItem> result = new List<BaoCaoItem>();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            BaoCaoItem item = new BaoCaoItem
                            {
                                TenDonVi = row["TenDonVi"].ToString(),
                                TenThietBi = row["TenThietBi"].ToString(),
                                CauHinh = row["CauHinh"].ToString(),
                                ModelThietBi = row["ModelThietBi"].ToString(),
                                TongSoLuong = Convert.ToInt32(row["TongSoLuong"]),

                            };
                            
                            result.Add(item);
                            //ExportSLDonViToExcel(result);
                        }

                        return Ok(result);
                    }
                }
            }
        }*/

        /*public ActionResult ExportSLDonViToExcel(List<BaoCaoItem> data)
        {
            // Lấy danh sách dữ liệu từ database hoặc bất kỳ nguồn dữ liệu nào

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("BaoCao");

                // Đặt tiêu đề cột
                worksheet.Cells[1, 1].Value = "Tên Đơn Vị";
                worksheet.Cells[1, 2].Value = "Mã Thiết Bị";
                worksheet.Cells[1, 3].Value = "Tên Thiết Bị";
                worksheet.Cells[1, 4].Value = "Cấu Hình";
                worksheet.Cells[1, 5].Value = "Model Thiết Bị";
                worksheet.Cells[1, 6].Value = "Tổng Số Lượng";

                // Đặt kiểu định dạng cho tiêu đề cột
                using (ExcelRange range = worksheet.Cells[1, 1, 1, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Đổ dữ liệu vào các ô
                for (int i = 0; i < data.Count; i++)
                {
                    BaoCaoItem item = data[i];

                    worksheet.Cells[i + 2, 1].Value = item.TenDonVi;
                    worksheet.Cells[i + 2, 2].Value = item.TenMaThietBi;
                    worksheet.Cells[i + 2, 3].Value = item.TenThietBi;
                    worksheet.Cells[i + 2, 4].Value = item.CauHinh;
                    worksheet.Cells[i + 2, 5].Value = item.ModelThietBi;
                    worksheet.Cells[i + 2, 6].Value = item.TongSoLuong;
                }

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Tạo stream để ghi dữ liệu Excel vào
                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);

                byte[] excelBytes = stream.ToArray();
                string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string excelFileName = "BaoCao.xlsx";

                // Trả về đối tượng FileContentResult
                return File(excelBytes, excelContentType, excelFileName);
            }

            return Ok();
        }*/


    }
}
