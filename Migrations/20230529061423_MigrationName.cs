using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonViTraLuongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonViTraLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonViTraLuong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTraLuongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MustChangePass = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_DonViTraLuongs_DonViTraLuong_Id",
                        column: x => x.DonViTraLuong_Id,
                        principalTable: "DonViTraLuongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKho = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKhos_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhMucKhos_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDomain = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domains_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonViTinhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonViTinh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonViTinhs_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeThongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHeThong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHeThong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeThongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeThongs_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoaiThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AccessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_AspNetUsers_AccessdBy",
                        column: x => x.AccessdBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMenu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Parent_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNhaCungCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhaCungCaps_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nhoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNhom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenNhom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nhoms_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanHois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDung_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDungPhanHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GopY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuLy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanHois_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucDangNhaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhuongThucDangNhap = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LinkCheckLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucDangNhaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhuongThucDangNhaps_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TapDoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaTapDoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTapDoan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TapDoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TapDoans_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThanhLyThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaThanhLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThanhLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhLyThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhLyThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLyThietBis_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BanGiaoTBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaBanGIao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGiaoTBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiaoTBs_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoTBs_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoTBs_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHangThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HeThong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HangThietBis_HeThongs_HeThong_Id",
                        column: x => x.HeThong_Id,
                        principalTable: "HeThongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Roles",
                columns: table => new
                {
                    Menu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false),
                    Cof = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Roles", x => new { x.Menu_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_Menu_Roles_AspNetRoles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Roles_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Roles_Menus_Menu_Id",
                        column: x => x.Menu_Id,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonVis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonVi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TapDoan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonVis_TapDoans_TapDoan_Id",
                        column: x => x.TapDoan_Id,
                        principalTable: "TapDoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BanGiaoNguoiNhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGiaoNguoiNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiaoNguoiNhans_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoNguoiNhans_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoNguoiNhans_BanGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "BanGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiHangThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaiHangThietBis_HangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaiHangThietBis_LoaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "LoaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaThongTinThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CauHinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NhaCungCap_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoSeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBaoHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongTinThietBis_Domains_Domain_Id",
                        column: x => x.Domain_Id,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongTinThietBis_HangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongTinThietBis_LoaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "LoaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongTinThietBis_NhaCungCaps_NhaCungCap_Id",
                        column: x => x.NhaCungCap_Id,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Khos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanhMucKho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Khos_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Khos_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Khos_DanhMucKhos_DanhMucKho_Id",
                        column: x => x.DanhMucKho_Id,
                        principalTable: "DanhMucKhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Khos_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phongbans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaPhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phongbans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phongbans_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BanGiaoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGiaoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiaoThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoThongTinThietBis_BanGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "BanGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoThongTinThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BieuChuyenThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDieuChuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayDieuChuyen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BieuChuyenThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BieuChuyenThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BieuChuyenThietBis_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BieuChuyenThietBis_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BieuChuyenThietBis_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThanhLyKhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThanhLyThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhLyKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhLyKhos_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLyKhos_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLyKhos_ThanhLyThietBis_ThanhLyThietBi_Id",
                        column: x => x.ThanhLyThietBi_Id,
                        principalTable: "ThanhLyThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoPhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaBoPhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenBoPhan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhongBan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoPhans_phongbans_PhongBan_Id",
                        column: x => x.PhongBan_Id,
                        principalTable: "phongbans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiNhanDieuChuyens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DieuChuyenThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiNhanDieuChuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiNhanDieuChuyens_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiNhanDieuChuyens_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiNhanDieuChuyens_BieuChuyenThietBis_DieuChuyenThietBi_Id",
                        column: x => x.DieuChuyenThietBi_Id,
                        principalTable: "BieuChuyenThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChucVus_BoPhans_BoPhan_Id",
                        column: x => x.BoPhan_Id,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BoPhan_Id",
                table: "AspNetUsers",
                column: "BoPhan_Id",
                unique: true,
                filter: "[BoPhan_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id",
                unique: true,
                filter: "[ChucVu_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonVi_Id",
                table: "AspNetUsers",
                column: "DonVi_Id",
                unique: true,
                filter: "[DonVi_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id",
                unique: true,
                filter: "[DonViTraLuong_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhongBan_Id",
                table: "AspNetUsers",
                column: "PhongBan_Id",
                unique: true,
                filter: "[PhongBan_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoNguoiNhans_BanGiaoTB_Id",
                table: "BanGiaoNguoiNhans",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoNguoiNhans_User_CreatedId",
                table: "BanGiaoNguoiNhans",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoNguoiNhans_User_Id",
                table: "BanGiaoNguoiNhans",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoTBs_DonViTinh_Id",
                table: "BanGiaoTBs",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoTBs_User_CreatedId",
                table: "BanGiaoTBs",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoTBs_User_Id",
                table: "BanGiaoTBs",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoThongTinThietBis_BanGiaoTB_Id",
                table: "BanGiaoThongTinThietBis",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoThongTinThietBis_ThongTinThietBi_Id",
                table: "BanGiaoThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoThongTinThietBis_User_CreatedId",
                table: "BanGiaoThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BieuChuyenThietBis_DonVi_Id",
                table: "BieuChuyenThietBis",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BieuChuyenThietBis_Kho_Id",
                table: "BieuChuyenThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BieuChuyenThietBis_User_CreatedId",
                table: "BieuChuyenThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BieuChuyenThietBis_User_Id",
                table: "BieuChuyenThietBis",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhans_PhongBan_Id",
                table: "BoPhans",
                column: "PhongBan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChucVus_BoPhan_Id",
                table: "ChucVus",
                column: "BoPhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhos_User_CreatedId",
                table: "DanhMucKhos",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhos_User_Id",
                table: "DanhMucKhos",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_User_CreatedId",
                table: "Domains",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_TapDoan_Id",
                table: "DonVis",
                column: "TapDoan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_User_CreatedId",
                table: "DonViTinhs",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_HangThietBis_HeThong_Id",
                table: "HangThietBis",
                column: "HeThong_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HangThietBis_User_CreatedId",
                table: "HangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_HeThongs_User_CreatedId",
                table: "HeThongs",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Khos_DanhMucKho_Id",
                table: "Khos",
                column: "DanhMucKho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Khos_DonVi_Id",
                table: "Khos",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Khos_User_CreatedId",
                table: "Khos",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Khos_User_Id",
                table: "Khos",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_DonViTinh_Id",
                table: "KhoThongTinThietBis",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_Kho_Id",
                table: "KhoThongTinThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_ThongTinThietBi_Id",
                table: "KhoThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_User_CreatedId",
                table: "KhoThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangThietBis_HangThietBi_Id",
                table: "LoaiHangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangThietBis_LoaiThietBi_Id",
                table: "LoaiHangThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangThietBis_User_CreatedId",
                table: "LoaiHangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBis_User_CreatedId",
                table: "LoaiThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_AccessdBy",
                table: "Logs",
                column: "AccessdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Roles_Role_Id",
                table: "Menu_Roles",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Roles_User_CreatedId",
                table: "Menu_Roles",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_User_CreatedId",
                table: "Menus",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanDieuChuyens_DieuChuyenThietBi_Id",
                table: "NguoiNhanDieuChuyens",
                column: "DieuChuyenThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanDieuChuyens_User_CreatedId",
                table: "NguoiNhanDieuChuyens",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanDieuChuyens_User_Id",
                table: "NguoiNhanDieuChuyens",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_User_CreatedId",
                table: "NhaCungCaps",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhoms_User_CreatedId",
                table: "Nhoms",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_User_CreatedId",
                table: "PhanHois",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_phongbans_DonVi_Id",
                table: "phongbans",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucDangNhaps_User_CreatedId",
                table: "PhuongThucDangNhaps",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_TapDoans_User_CreatedId",
                table: "TapDoans",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyKhos_Kho_Id",
                table: "ThanhLyKhos",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyKhos_ThanhLyThietBi_Id",
                table: "ThanhLyKhos",
                column: "ThanhLyThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyKhos_User_CreatedId",
                table: "ThanhLyKhos",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyThietBis_User_CreatedId",
                table: "ThanhLyThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyThietBis_User_Id",
                table: "ThanhLyThietBis",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinThietBis_Domain_Id",
                table: "ThongTinThietBis",
                column: "Domain_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinThietBis_HangThietBi_Id",
                table: "ThongTinThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinThietBis_LoaiThietBi_Id",
                table: "ThongTinThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinThietBis_NhaCungCap_Id",
                table: "ThongTinThietBis",
                column: "NhaCungCap_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinThietBis_User_CreatedId",
                table: "ThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BoPhans_BoPhan_Id",
                table: "AspNetUsers",
                column: "BoPhan_Id",
                principalTable: "BoPhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ChucVus_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id",
                principalTable: "ChucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DonVis_DonVi_Id",
                table: "AspNetUsers",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_phongbans_PhongBan_Id",
                table: "AspNetUsers",
                column: "PhongBan_Id",
                principalTable: "phongbans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TapDoans_AspNetUsers_User_CreatedId",
                table: "TapDoans");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BanGiaoNguoiNhans");

            migrationBuilder.DropTable(
                name: "BanGiaoThongTinThietBis");

            migrationBuilder.DropTable(
                name: "KhoThongTinThietBis");

            migrationBuilder.DropTable(
                name: "LoaiHangThietBis");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Menu_Roles");

            migrationBuilder.DropTable(
                name: "NguoiNhanDieuChuyens");

            migrationBuilder.DropTable(
                name: "Nhoms");

            migrationBuilder.DropTable(
                name: "PhanHois");

            migrationBuilder.DropTable(
                name: "PhuongThucDangNhaps");

            migrationBuilder.DropTable(
                name: "ThanhLyKhos");

            migrationBuilder.DropTable(
                name: "BanGiaoTBs");

            migrationBuilder.DropTable(
                name: "ThongTinThietBis");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "BieuChuyenThietBis");

            migrationBuilder.DropTable(
                name: "ThanhLyThietBis");

            migrationBuilder.DropTable(
                name: "DonViTinhs");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "HangThietBis");

            migrationBuilder.DropTable(
                name: "LoaiThietBis");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "Khos");

            migrationBuilder.DropTable(
                name: "HeThongs");

            migrationBuilder.DropTable(
                name: "DanhMucKhos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "DonViTraLuongs");

            migrationBuilder.DropTable(
                name: "BoPhans");

            migrationBuilder.DropTable(
                name: "phongbans");

            migrationBuilder.DropTable(
                name: "DonVis");

            migrationBuilder.DropTable(
                name: "TapDoans");
        }
    }
}
