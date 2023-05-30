using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETCORE3.Models;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>,
      ApplicationUserRole, IdentityUserLogin<Guid>,
      IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
      
    {
        public class ApplicationUser : IdentityUser<Guid>
        {
            public string FullName { get; set; }
            public string MaNhanVien { get; set; }
            //public string SoDienThoai { get; set; }
            public string? ChucDanh { get; set; }
            public bool IsActive { get; set; }
            public bool MustChangePass { get; set; }
            public bool IsDeleted { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public DateTime? DeletedDate { get; set; }
            public ICollection<ApplicationUserRole> UserRoles { get; set; }
            [ForeignKey("DonVi")]

            public Guid? DonVi_Id { get; set; }
            public DonVi DonVi  { get; set; }
            [ForeignKey("BoPhan")]
            public Guid? BoPhan_Id { get; set; }
            public BoPhan BoPhan  { get; set; }
            [ForeignKey("ChucVu")]

            public Guid? ChucVu_Id { get; set; }
            public ChucVu ChucVu { get; set; }
            [ForeignKey("Phongban")]
            public Guid? PhongBan_Id { get; set; }
            public Phongban Phongban { get; set; }
            [ForeignKey("DonViTraLuong")]
            public Guid? DonViTraLuong_Id { get; set; }
            public DonViTraLuong DonViTraLuong { get; set; }

        }
        public class ApplicationRole : IdentityRole<Guid>
        {
            public string Description { get; set; }
            public bool IsDeleted { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public DateTime? DeletedDate { get; set; }
            public ICollection<ApplicationUserRole> UserRoles { get; set; }
            public ICollection<Menu_Role> Menu_Roles { get; set; }
        }
        public class ApplicationUserRole : IdentityUserRole<Guid>
        {
            public virtual ApplicationUser User { get; set; }
            public virtual ApplicationRole Role { get; set; }
        }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Loại bỏ quan hệ vòng
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<ApplicationUserRole>(userRole =>
              {
                  userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                  userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                  userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
              });
            builder.Entity<Menu_Role>(pq =>
            {
                pq.HasKey(ur => new { ur.Menu_Id, ur.Role_Id });

                pq.HasOne(ur => ur.Menu)
              .WithMany(r => r.Menu_Roles)
              .HasForeignKey(ur => ur.Menu_Id)
              .IsRequired();

                pq.HasOne(ur => ur.Role)
              .WithMany(r => r.Menu_Roles)
              .HasForeignKey(ur => ur.Role_Id)
              .IsRequired();
            });
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<Nhom> Nhoms { get; set; }
        public DbSet<Phongban> phongbans { get; set; }

        public DbSet<PhanHoi> PhanHois { get; set; }
        public DbSet<PhuongThucDangNhap> PhuongThucDangNhaps { get; set; }
        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public DbSet<DonVi> DonVis { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<Menu_Role> Menu_Roles { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<TapDoan> TapDoans { get; set; }
        public DbSet<DonViTraLuong> DonViTraLuongs { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<HangThietBi> HangThietBis { get; set; }
        public DbSet<LoaiThietBi> LoaiThietBis{ get; set; }
        public DbSet<Loai_HangThietBi> Loai_HangThietBis { get; set; }
        public DbSet<HeThong> HeThongs { get; set; }
        public DbSet<ThongTinThietBi> ThongTinThietBis { get; set; }
      
        /*public DbSet<ThongTinHangThietBi> ThongTinHangThietBis { get; set; }*/
        /*public DbSet<ChiTietLoaiThongTinThietBi> chiTietLoaiThongTinThietBis { get; set; }*/
        public DbSet<DanhMucKho> DanhMucKhos { get; set; }
        public DbSet<Kho> Khos { get; set; }
        /*public DbSet<KhoLoaiThietBi> khoLoaiThietBis { get; set; }*/
        public DbSet<BanGiao_NguoiNhan> BanGiao_NguoiNhans { get; set; }
        public DbSet<Kho_ThongTinThietBi> Kho_ThongTinThietBis { get; set; }
        public DbSet<BanGiaoTB> BanGiaoTBs { get; set; }
        public DbSet<BanGiao_ThongTinThietBi> BanGiao_ThongTinThietBis { get; set; }

        public DbSet<DieuChuyenThietBi> DieuChuyenThietBis { get; set; }
        public DbSet<NguoiNhan_DieuChuyen> NguoiNhan_DieuChuyens { get; set; }
        public DbSet<ThanhLyThietBi> ThanhLyThietBis { get; set; }
        public DbSet<ThanhLy_Kho> ThanhLy_Khos { get; set; }


    }
}