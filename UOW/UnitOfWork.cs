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
    public IPhongBanRepository phongBans { get; private set; }
    public IChucVuRepository chucVus { get; private set; }
    public IDonViTraLuongRepository donViTraLuongs { get; private set; }
    public IDomainRepository domains { get; private set; }
    public ILoaiThietBiRepository loaiThietBis { get; private set; }
        public IHeThongRepository heThongs { get; private set; }
        public IHangThietBiRepository hangThietBis { get; private set; }
        public ILoaiHangThietBiRepository loaiHangThietBis { get; private set; }

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
      phongBans = new PhongBanRepository(db);
      chucVus = new ChucVuRepository(db);
      donViTraLuongs = new DonViTraLuongRepository(db);
            domains = new DomainRepository(db);
            loaiThietBis=new LoaiThietBiRepository(db);
            heThongs=new HeThongRepository(db);
            hangThietBis = new HangThietBiRepository(db);
            loaiHangThietBis = new LoaiHangThietBiRepository(db);
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