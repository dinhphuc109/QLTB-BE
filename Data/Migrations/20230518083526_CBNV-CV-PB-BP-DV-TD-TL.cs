using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class CBNVCVPBBPDVTDTL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoPhans_DonVis_DonVi_Id",
                table: "BoPhans");

            migrationBuilder.DropTable(
                name: "ChiTietHangs");

            migrationBuilder.DropTable(
                name: "ChiTietNhomLoais");

            migrationBuilder.DropTable(
                name: "ChiTietNhoms");

            migrationBuilder.DropTable(
                name: "LoaiVatTus");

            migrationBuilder.DropTable(
                name: "Loais");

            migrationBuilder.DropTable(
                name: "VatTus");

            migrationBuilder.DropTable(
                name: "Hangs");

            migrationBuilder.RenameColumn(
                name: "DonVi_Id",
                table: "BoPhans",
                newName: "PhongbanId");

            migrationBuilder.RenameIndex(
                name: "IX_BoPhans_DonVi_Id",
                table: "BoPhans",
                newName: "IX_BoPhans_PhongbanId");

            migrationBuilder.AddColumn<Guid>(
                name: "TapDoanId",
                table: "DonVis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TapDoan_Id",
                table: "DonVis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongBan_Id",
                table: "BoPhans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChucVu_Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DonViTraLuong_Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongBan_Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "chucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_chucVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chucVus_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chucVus_BoPhans_BoPhanId",
                        column: x => x.BoPhanId,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "donViTraLuongs",
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
                    table.PrimaryKey("PK_donViTraLuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donViTraLuongs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
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
                        name: "FK_phongbans_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phongbans_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tapDoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaTapDoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTapDoan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_tapDoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tapDoans_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_TapDoanId",
                table: "DonVis",
                column: "TapDoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhongBan_Id",
                table: "AspNetUsers",
                column: "PhongBan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_BoPhanId",
                table: "chucVus",
                column: "BoPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_CreatedBy",
                table: "chucVus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_donViTraLuongs_CreatedBy",
                table: "donViTraLuongs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_phongbans_CreatedBy",
                table: "phongbans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_phongbans_DonVi_Id",
                table: "phongbans",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tapDoans_CreatedBy",
                table: "tapDoans",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_chucVus_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id",
                principalTable: "chucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_donViTraLuongs_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id",
                principalTable: "donViTraLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_phongbans_PhongBan_Id",
                table: "AspNetUsers",
                column: "PhongBan_Id",
                principalTable: "phongbans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoPhans_phongbans_PhongbanId",
                table: "BoPhans",
                column: "PhongbanId",
                principalTable: "phongbans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonVis_tapDoans_TapDoanId",
                table: "DonVis",
                column: "TapDoanId",
                principalTable: "tapDoans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_chucVus_ChucVu_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_donViTraLuongs_DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_phongbans_PhongBan_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BoPhans_phongbans_PhongbanId",
                table: "BoPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_DonVis_tapDoans_TapDoanId",
                table: "DonVis");

            migrationBuilder.DropTable(
                name: "chucVus");

            migrationBuilder.DropTable(
                name: "donViTraLuongs");

            migrationBuilder.DropTable(
                name: "phongbans");

            migrationBuilder.DropTable(
                name: "tapDoans");

            migrationBuilder.DropIndex(
                name: "IX_DonVis_TapDoanId",
                table: "DonVis");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhongBan_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TapDoanId",
                table: "DonVis");

            migrationBuilder.DropColumn(
                name: "TapDoan_Id",
                table: "DonVis");

            migrationBuilder.DropColumn(
                name: "PhongBan_Id",
                table: "BoPhans");

            migrationBuilder.DropColumn(
                name: "ChucVu_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhongBan_Id",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PhongbanId",
                table: "BoPhans",
                newName: "DonVi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BoPhans_PhongbanId",
                table: "BoPhans",
                newName: "IX_BoPhans_DonVi_Id");

            migrationBuilder.CreateTable(
                name: "Hangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hangs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loais_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hang_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nhom_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietNhoms_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietNhoms_Hangs_Hang_Id",
                        column: x => x.Hang_Id,
                        principalTable: "Hangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietNhoms_Nhoms_Nhom_Id",
                        column: x => x.Nhom_Id,
                        principalTable: "Nhoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VatTus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DVT_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Hang_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nhom_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaVatTu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenVatTu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TenVatTuKhongDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSoKyThuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VatTus_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VatTus_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VatTus_DonViTinhs_DVT_Id",
                        column: x => x.DVT_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VatTus_Hangs_Hang_Id",
                        column: x => x.Hang_Id,
                        principalTable: "Hangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VatTus_Nhoms_Nhom_Id",
                        column: x => x.Nhom_Id,
                        principalTable: "Nhoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hang_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Loai_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHangs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangs_Hangs_Hang_Id",
                        column: x => x.Hang_Id,
                        principalTable: "Hangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHangs_Loais_Loai_Id",
                        column: x => x.Loai_Id,
                        principalTable: "Loais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhomLoais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Loai_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nhom_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhomLoais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietNhomLoais_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietNhomLoais_Loais_Loai_Id",
                        column: x => x.Loai_Id,
                        principalTable: "Loais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietNhomLoais_Nhoms_Nhom_Id",
                        column: x => x.Nhom_Id,
                        principalTable: "Nhoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiVatTus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Loai_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VatTu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiVatTus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiVatTus_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaiVatTus_Loais_Loai_Id",
                        column: x => x.Loai_Id,
                        principalTable: "Loais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaiVatTus_VatTus_VatTu_Id",
                        column: x => x.VatTu_Id,
                        principalTable: "VatTus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangs_CreatedBy",
                table: "ChiTietHangs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangs_Hang_Id",
                table: "ChiTietHangs",
                column: "Hang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHangs_Loai_Id",
                table: "ChiTietHangs",
                column: "Loai_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhomLoais_CreatedBy",
                table: "ChiTietNhomLoais",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhomLoais_Loai_Id",
                table: "ChiTietNhomLoais",
                column: "Loai_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhomLoais_Nhom_Id",
                table: "ChiTietNhomLoais",
                column: "Nhom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhoms_CreatedBy",
                table: "ChiTietNhoms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhoms_Hang_Id",
                table: "ChiTietNhoms",
                column: "Hang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhoms_Nhom_Id",
                table: "ChiTietNhoms",
                column: "Nhom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hangs_CreatedBy",
                table: "Hangs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Loais_CreatedBy",
                table: "Loais",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiVatTus_CreatedBy",
                table: "LoaiVatTus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiVatTus_Loai_Id",
                table: "LoaiVatTus",
                column: "Loai_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiVatTus_VatTu_Id",
                table: "LoaiVatTus",
                column: "VatTu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_CreatedBy",
                table: "VatTus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_DVT_Id",
                table: "VatTus",
                column: "DVT_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_Hang_Id",
                table: "VatTus",
                column: "Hang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_Nhom_Id",
                table: "VatTus",
                column: "Nhom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_User_Id",
                table: "VatTus",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoPhans_DonVis_DonVi_Id",
                table: "BoPhans",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
