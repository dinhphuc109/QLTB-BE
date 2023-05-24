using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NETCORE3.Repositories;

namespace NETCORE3.Infrastructure
{
    public interface IUnitofWork : IDisposable
    {
        IMenuRepository Menus { get; }
        INhomRepository Nhoms { get; }

        IDonViTinhRepository DonViTinhs { get; }
        IPhongbanRepository phongbans { get; }
        IDonViRepository DonVis { get; }
        INhaCungCapRepository NhaCungCaps { get; }

        IPhanHoiRepository PhanHois { get; }
        IPhuongThucDangNhapRepository PhuongThucDangNhaps { get; }

        IMenu_RoleRepository Menu_Roles { get; }
        ILogRepository Logs { get; }
        IBoPhanRepository BoPhans { get; }
        ITapDoanRepository tapDoans { get; }
        IChucVuRepository chucVus { get; }
        IDonViTraLuongRepository donViTraLuongs { get; }
        IDomainRepository domains { get; }
        ILoaiThietBiRepository loaiThietBis { get; }
        IHeThongRepository heThongs { get; }
        IHangThietBiRepository hangThietBis { get; }
        ILoaiHangThietBiRepository loaiHangThietBis { get; }
       
        IThongTinThietBiRepository thongTinThietBis { get; }
        IThongTinHangThietBiRepository thongTinHangThietBis { get; }
        IChiTietLoaiThongTinThietBiRepository chiTietLoaiThongTinThietBis { get; }
        IKhoRepository khos { get; }
        IDanhMucKhoRepository danhMucKhos {get;}
        IKhoLoaiThietBiRepository khoLoaiThietBis { get; }
        IKhoThongTinThietBiRepository khoThongTinThietBis { get; }
        IBanGiaoThongTinThietBiRepository banGiaoThongTinThietBis { get; }
        IBanGiaoTBRepository banGiaoTBs { get; }
        IBanGiaoNguoiNhanRepository banGiaoNguoiNhans { get; }

        int Complete();
  }
}
