using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsuacacbangnguoidung_removedvtl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DonViTraLuongs_DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BanGiaoTBs_AspNetUsers_User_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucVus_BoPhans_BoPhan_Id",
                table: "ChucVus");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenNhanViens_DonViTraLuongs_DonViTraLuongId",
                table: "DieuChuyenNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenNhanViens_DonViTraLuongs_DonViTraLuongNewId",
                table: "DieuChuyenNhanViens");

            migrationBuilder.DropTable(
                name: "DonViTraLuongs");

            migrationBuilder.DropTable(
                name: "Loai_HangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_BanGiaoTBs_User_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "LichSuThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "Kho_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "Kho_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropColumn(
                name: "CauHinh",
                table: "DanhMucThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.RenameColumn(
                name: "BoPhan_Id",
                table: "ChucVus",
                newName: "BoPhanId");

            migrationBuilder.RenameIndex(
                name: "IX_ChucVus_BoPhan_Id",
                table: "ChucVus",
                newName: "IX_ChucVus_BoPhanId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "BanGiaoTBs",
                newName: "UserNhan_Id");

            migrationBuilder.AddColumn<string>(
                name: "CauHinh",
                table: "ThongTinThietBis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangThietBi_Id",
                table: "ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangThietBi_Id",
                table: "ThanhLy_Khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangThietBi_Id",
                table: "LichSuThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangThietBi_Id",
                table: "Kho_ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGiao_Id",
                table: "BanGiaoTBs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TinhTrangThietBi_Id",
                table: "BanGiao_ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DanhMucLois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_DanhMucLois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucLois_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucCapPhats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHinhThucCapPhat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHinhThucCapPhat = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_HinhThucCapPhats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhThucCapPhats_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TieuChuanBaoTris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaTieuChuanBaoTri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTieuChuanBaoTri = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ThoiGianTieuChuanBaoTri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuyDinh_TaiLieuHuongDan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_TieuChuanBaoTris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TieuChuanBaoTris_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaTinhTrangThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTinhTrangThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_TinhTrangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinhTrangThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinThietBis_TinhTrangThietBi_Id",
                table: "ThongTinThietBis",
                column: "TinhTrangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLy_Khos_TinhTrangThietBi_Id",
                table: "ThanhLy_Khos",
                column: "TinhTrangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuThietBis_TinhTrangThietBi_Id",
                table: "LichSuThietBis",
                column: "TinhTrangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_ThongTinThietBis_TinhTrangThietBi_Id",
                table: "Kho_ThongTinThietBis",
                column: "TinhTrangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBi_Khos_TinhTrangThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "TinhTrangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoTBs_UserGiao_Id",
                table: "BanGiaoTBs",
                column: "UserGiao_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_ThongTinThietBis_TinhTrangThietBi_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "TinhTrangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLois_User_CreatedId",
                table: "DanhMucLois",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucCapPhats_User_CreatedId",
                table: "HinhThucCapPhats",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChuanBaoTris_User_CreatedId",
                table: "TieuChuanBaoTris",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhTrangThietBis_User_CreatedId",
                table: "TinhTrangThietBis",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_BanGiao_ThongTinThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "TinhTrangThietBi_Id",
                principalTable: "TinhTrangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BanGiaoTBs_AspNetUsers_UserGiao_Id",
                table: "BanGiaoTBs",
                column: "UserGiao_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucVus_BoPhans_BoPhanId",
                table: "ChucVus",
                column: "BoPhanId",
                principalTable: "BoPhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenNhanViens_DonVis_DonViTraLuongId",
                table: "DieuChuyenNhanViens",
                column: "DonViTraLuongId",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenNhanViens_DonVis_DonViTraLuongNewId",
                table: "DieuChuyenNhanViens",
                column: "DonViTraLuongNewId",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "TinhTrangThietBi_Id",
                principalTable: "TinhTrangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kho_ThongTinThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "Kho_ThongTinThietBis",
                column: "TinhTrangThietBi_Id",
                principalTable: "TinhTrangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "LichSuThietBis",
                column: "TinhTrangThietBi_Id",
                principalTable: "TinhTrangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhLy_Khos_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "ThanhLy_Khos",
                column: "TinhTrangThietBi_Id",
                principalTable: "TinhTrangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "ThongTinThietBis",
                column: "TinhTrangThietBi_Id",
                principalTable: "TinhTrangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanGiao_ThongTinThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_BanGiaoTBs_AspNetUsers_UserGiao_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucVus_BoPhans_BoPhanId",
                table: "ChucVus");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenNhanViens_DonVis_DonViTraLuongId",
                table: "DieuChuyenNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenNhanViens_DonVis_DonViTraLuongNewId",
                table: "DieuChuyenNhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_Kho_ThongTinThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "Kho_ThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "LichSuThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhLy_Khos_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_TinhTrangThietBis_TinhTrangThietBi_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropTable(
                name: "DanhMucLois");

            migrationBuilder.DropTable(
                name: "HinhThucCapPhats");

            migrationBuilder.DropTable(
                name: "TieuChuanBaoTris");

            migrationBuilder.DropTable(
                name: "TinhTrangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinThietBis_TinhTrangThietBi_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_ThanhLy_Khos_TinhTrangThietBi_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropIndex(
                name: "IX_LichSuThietBis_TinhTrangThietBi_Id",
                table: "LichSuThietBis");

            migrationBuilder.DropIndex(
                name: "IX_Kho_ThongTinThietBis_TinhTrangThietBi_Id",
                table: "Kho_ThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DieuChuyenThietBi_Khos_TinhTrangThietBi_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropIndex(
                name: "IX_BanGiaoTBs_UserGiao_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_BanGiao_ThongTinThietBis_TinhTrangThietBi_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "CauHinh",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi_Id",
                table: "LichSuThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi_Id",
                table: "Kho_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropColumn(
                name: "UserGiao_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.RenameColumn(
                name: "BoPhanId",
                table: "ChucVus",
                newName: "BoPhan_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChucVus_BoPhanId",
                table: "ChucVus",
                newName: "IX_ChucVus_BoPhan_Id");

            migrationBuilder.RenameColumn(
                name: "UserNhan_Id",
                table: "BanGiaoTBs",
                newName: "User_Id");

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "ThongTinThietBis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "ThanhLy_Khos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "ThanhLy_Khos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "LichSuThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "Kho_ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "Kho_ThongTinThietBis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "DieuChuyenThietBi_Khos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "DieuChuyenThietBi_Khos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CauHinh",
                table: "DanhMucThietBis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "BanGiao_ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "BanGiao_ThongTinThietBis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DonViTraLuongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaDonViTraLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonViTraLuong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTraLuongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loai_HangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai_HangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loai_HangThietBis_HangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loai_HangThietBis_LoaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "LoaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoTBs_User_Id",
                table: "BanGiaoTBs",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id",
                unique: true,
                filter: "[DonViTraLuong_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_HangThietBis_HangThietBi_Id",
                table: "Loai_HangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_HangThietBis_LoaiThietBi_Id",
                table: "Loai_HangThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DonViTraLuongs_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id",
                principalTable: "DonViTraLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BanGiaoTBs_AspNetUsers_User_Id",
                table: "BanGiaoTBs",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucVus_BoPhans_BoPhan_Id",
                table: "ChucVus",
                column: "BoPhan_Id",
                principalTable: "BoPhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenNhanViens_DonViTraLuongs_DonViTraLuongId",
                table: "DieuChuyenNhanViens",
                column: "DonViTraLuongId",
                principalTable: "DonViTraLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenNhanViens_DonViTraLuongs_DonViTraLuongNewId",
                table: "DieuChuyenNhanViens",
                column: "DonViTraLuongNewId",
                principalTable: "DonViTraLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
