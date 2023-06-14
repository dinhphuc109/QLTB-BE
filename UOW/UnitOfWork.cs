using System.Collections.Generic;
using NETCORE3.Data;
using NETCORE3.Infrastructure;
using NETCORE3.Repositories;

namespace NETCORE3.UOW
{
  public class UnitofWork : IUnitofWork
  {
        public IMenuRepository Menus { get; private set; }

        public INhomRepository Nhoms { get; private set; }

        public IDonViRepository DonVis { get; private set; }
        public INhaCungCapRepository NhaCungCaps { get; private set; }

        public IDonViTinhRepository DonViTinhs { get; private set; }

        public IPhanHoiRepository PhanHois { get; private set; }
        public IPhuongThucDangNhapRepository PhuongThucDangNhaps { get; private set; }
        public IMenu_RoleRepository Menu_Roles { get; private set; }
        public ILogRepository Logs { get; private set; }
        public IBoPhanRepository BoPhans { get; private set; }
        public ITapDoanRepository tapDoans { get; private set; }
        public IPhongbanRepository phongbans { get; private set; }
        public IChucVuRepository chucVus { get; private set; }
       
        public IDomainRepository domains { get; private set; }
        public ILoaiThietBiRepository loaiThietBis { get; private set; }
        public IHeThongRepository heThongs { get; private set; }
        public IHangThietBiRepository hangThietBis { get; private set; }
   

        public IDanhMucThietBiRepository danhMucThietBis { get; private set; }
        public IThongTinThietBiRepository thongTinThietBis { get; private set; }

        public IDanhMucKhoRepository danhMucKhos { get; private set; }
        public IKhoRepository khos { get; private set; }
        public IKhoThongTinThietBiRepository khoThongTinThietBis { get; private set; }
        public IKhoLoaiThietBiRepository khoLoaiThietBis { get; private set; }
        public IBanGiaoTBRepository banGiaoTBs { get; private set; }
        public IBanGiaoThongTinThietBiRepository banGiaoThongTinThietBis { get; private set; }
    
        public IDieuChuyenThietBiRepository dieuChuyenThietBis { get; private set; }
        public IDieuChuyenThietBiKhoRepository dieuChuyenThietBiKhos { get; private set; }
        public IThanhLyThietBiRepository thanhLyThietBis { get; private set; }
        public IThanhLyKhoRepository thanhLyKhos { get; private set; }
        public IDieuChuyenNhanVienRepository dieuChuyenNhanViens { get; private set; }
        public ILichSuThietBiRepository lichSuThietBis { get; private set; }
        public ICBNV_DieuChuyenRepository cBNV_DieuChuyens { get; private set; }
        public ITieuChuanBaoTriRepository tieuChuanBaoTris { get; private set; }
        public IHinhThucCapPhatRepository hinhThucCapPhats { get; private set; }
        public IDanhMucLoiRepository danhMucLois { get; private set; }
        public ITinhTrangThietBiRepository tinhTrangThietBis { get; private set; }

        private MyDbContext db;
    public UnitofWork(MyDbContext _db)
    {
            db = _db;
            Menus = new MenuRepository(db);

            Nhoms = new NhomRepository(db);

            PhanHois = new PhanHoiRepository(db);

            DonViTinhs = new DonViTinhRepository(db);

            DonVis = new DonViRepository(db);
            NhaCungCaps = new NhaCungCapRepository(db);
            PhuongThucDangNhaps = new PhuongThucDangNhapRepository(db);
            Menu_Roles = new Menu_RoleRepository(db);
            Logs = new LogRepository(db);
            BoPhans = new BoPhanRepository(db);
            tapDoans = new TapDoanRepository(db);
            phongbans = new PhongbanRepository(db);
            chucVus = new ChucVuRepository(db);
            
            domains = new DomainRepository(db);
            loaiThietBis = new LoaiThietBiRepository(db);
            heThongs = new HeThongRepository(db);
            hangThietBis = new HangThietBiRepository(db);
            danhMucThietBis = new DanhMucThietBiRepository(db);
            thongTinThietBis = new ThongTinThietBiRepository(db);


            danhMucKhos = new DanhMucKhoRepository(db);
            khos = new KhoRepository(db);
            khoThongTinThietBis = new KhoThongTinThietBiRepository(db);
            khoLoaiThietBis = new KhoLoaiThietBiRepository(db);
            banGiaoTBs = new BanGiaoTBRepository(db);
            banGiaoThongTinThietBis = new BanGiaoThongTinThietBiRepository(db);
    
            dieuChuyenThietBis = new DieuChuyenThietBiRepository(db);
            thanhLyThietBis = new ThanhLyThietBiRepository(db);
            thanhLyKhos = new ThanhLyKhoRepository(db);
            dieuChuyenNhanViens = new DieuChuyenNhanVienRepository(db);
            lichSuThietBis = new LichSuThietBiRepository(db);
            dieuChuyenThietBiKhos = new DieuChuyenThietBiKhoRepository(db);
            cBNV_DieuChuyens = new CBNV_DieuChuyenRepository(db);
            tieuChuanBaoTris = new TieuChuanBaoTriRepository(db);
            hinhThucCapPhats = new HinhThucCapPhatRepository(db);
            danhMucLois = new DanhMucLoiRepository(db);
            tinhTrangThietBis = new TinhTrangThietBiRepository(db);
        }
    public void Dispose()
    {
      db.Dispose();
    }
    public int Complete()
    {
      return db.SaveChanges();
    }
  }
}