using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsua_BanGiaoTB_addchuyennhapkho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanGiaoTBs_DonViTinhs_DonViTinh_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_BanGiaoTBs_DonViTinh_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropColumn(
                name: "DonViTinh_Id",
                table: "BanGiaoTBs");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "BanGiaoTBs");

            migrationBuilder.DropColumn(
                name: "NgayNhan",
                table: "BanGiaoTBs");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "BanGiaoTBs");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "BanGiaoTBs");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViTinh_Id",
                table: "BanGiao_ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "BanGiao_ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Kho_Id",
                table: "BanGiao_ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayNhan",
                table: "BanGiao_ThongTinThietBis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "BanGiao_ThongTinThietBis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "BanGiao_ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_ThongTinThietBis_DonViTinh_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_ThongTinThietBis_Kho_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "Kho_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BanGiao_ThongTinThietBis_DonViTinhs_DonViTinh_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BanGiao_ThongTinThietBis_Khos_Kho_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "Kho_Id",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanGiao_ThongTinThietBis_DonViTinhs_DonViTinh_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_BanGiao_ThongTinThietBis_Khos_Kho_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_BanGiao_ThongTinThietBis_DonViTinh_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_BanGiao_ThongTinThietBis_Kho_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "DonViTinh_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "Kho_Id",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "NgayNhan",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "BanGiao_ThongTinThietBis");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViTinh_Id",
                table: "BanGiaoTBs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "BanGiaoTBs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayNhan",
                table: "BanGiaoTBs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "BanGiaoTBs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "BanGiaoTBs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoTBs_DonViTinh_Id",
                table: "BanGiaoTBs",
                column: "DonViTinh_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BanGiaoTBs_DonViTinhs_DonViTinh_Id",
                table: "BanGiaoTBs",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
