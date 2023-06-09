﻿using System;
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
      
        IDomainRepository domains { get; }
        ILoaiThietBiRepository loaiThietBis { get; }
        IHeThongRepository heThongs { get; }
        IHangThietBiRepository hangThietBis { get; }

        IDanhMucThietBiRepository danhMucThietBis { get; }

        IThongTinThietBiRepository thongTinThietBis { get; }
     
    
        IKhoRepository khos { get; }
        IDanhMucKhoRepository danhMucKhos {get;}
        IKhoLoaiThietBiRepository khoLoaiThietBis { get; }
        IKhoThongTinThietBiRepository khoThongTinThietBis { get; }
        IBanGiaoThongTinThietBiRepository banGiaoThongTinThietBis { get; }
        IBanGiaoTBRepository banGiaoTBs { get; }
     
        IDieuChuyenThietBiRepository dieuChuyenThietBis { get; }
        IDieuChuyenThietBiKhoRepository dieuChuyenThietBiKhos { get; }
        IThanhLyThietBiRepository thanhLyThietBis { get; }
        IThanhLyKhoRepository thanhLyKhos { get; }
        IDieuChuyenNhanVienRepository dieuChuyenNhanViens { get; }
        ILichSuThietBiRepository lichSuThietBis { get; }
        ICBNV_DieuChuyenRepository cBNV_DieuChuyens { get; }
        ITieuChuanBaoTriRepository tieuChuanBaoTris { get; }
        IHinhThucCapPhatRepository hinhThucCapPhats { get; }
        IDanhMucLoiRepository danhMucLois { get; }
        ITinhTrangThietBiRepository tinhTrangThietBis { get; }
        int Complete();
  }
}
