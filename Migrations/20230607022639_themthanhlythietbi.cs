using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class themthanhlythietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhLy_Khos_Khos_Kho_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "ThanhLyThietBis");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ThanhLyThietBis");

            migrationBuilder.RenameColumn(
                name: "Kho_Id",
                table: "ThanhLy_Khos",
                newName: "ThongTinThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThanhLy_Khos_Kho_Id",
                table: "ThanhLy_Khos",
                newName: "IX_ThanhLy_Khos_ThongTinThietBi_Id");

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "ThongTinThietBis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Kho_Id",
                table: "ThanhLyThietBis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DonViTinh_Id",
                table: "ThanhLy_Khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "ThanhLy_Khos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ThanhLy_Khos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "ThanhLy_Khos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyThietBis_Kho_Id",
                table: "ThanhLyThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLy_Khos_DonViTinh_Id",
                table: "ThanhLy_Khos",
                column: "DonViTinh_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhLy_Khos_DonViTinhs_DonViTinh_Id",
                table: "ThanhLy_Khos",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhLy_Khos_ThongTinThietBis_ThongTinThietBi_Id",
                table: "ThanhLy_Khos",
                column: "ThongTinThietBi_Id",
                principalTable: "ThongTinThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhLyThietBis_Khos_Kho_Id",
                table: "ThanhLyThietBis",
                column: "Kho_Id",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhLy_Khos_DonViTinhs_DonViTinh_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhLy_Khos_ThongTinThietBis_ThongTinThietBi_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhLyThietBis_Khos_Kho_Id",
                table: "ThanhLyThietBis");

            migrationBuilder.DropIndex(
                name: "IX_ThanhLyThietBis_Kho_Id",
                table: "ThanhLyThietBis");

            migrationBuilder.DropIndex(
                name: "IX_ThanhLy_Khos_DonViTinh_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "Kho_Id",
                table: "ThanhLyThietBis");

            migrationBuilder.DropColumn(
                name: "DonViTinh_Id",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "ThanhLy_Khos");

            migrationBuilder.RenameColumn(
                name: "ThongTinThietBi_Id",
                table: "ThanhLy_Khos",
                newName: "Kho_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThanhLy_Khos_ThongTinThietBi_Id",
                table: "ThanhLy_Khos",
                newName: "IX_ThanhLy_Khos_Kho_Id");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "ThanhLyThietBis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ThanhLyThietBis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhLy_Khos_Khos_Kho_Id",
                table: "ThanhLy_Khos",
                column: "Kho_Id",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
