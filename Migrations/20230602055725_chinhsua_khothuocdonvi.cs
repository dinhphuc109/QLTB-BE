using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsua_khothuocdonvi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThietBis_Loai_HangThietBis_LoaiThietBiId",
                table: "DanhMucThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_HangThietBis_HeThongs_HeThong_Id",
                table: "HangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_Khos_DonVis_DonVi_Id",
                table: "Khos");

            migrationBuilder.DropIndex(
                name: "IX_Khos_DonVi_Id",
                table: "Khos");

            migrationBuilder.DropIndex(
                name: "IX_HangThietBis_HeThong_Id",
                table: "HangThietBis");

            migrationBuilder.DropColumn(
                name: "DonVi_Id",
                table: "Khos");

            migrationBuilder.DropColumn(
                name: "HeThong_Id",
                table: "HangThietBis");

            migrationBuilder.AddColumn<Guid>(
                name: "HeThong_Id",
                table: "LoaiThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DonVi_Id",
                table: "DanhMucKhos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBis_HeThong_Id",
                table: "LoaiThietBis",
                column: "HeThong_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKhos_DonVi_Id",
                table: "DanhMucKhos",
                column: "DonVi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKhos_DonVis_DonVi_Id",
                table: "DanhMucKhos",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThietBis_LoaiThietBis_LoaiThietBiId",
                table: "DanhMucThietBis",
                column: "LoaiThietBiId",
                principalTable: "LoaiThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiThietBis_HeThongs_HeThong_Id",
                table: "LoaiThietBis",
                column: "HeThong_Id",
                principalTable: "HeThongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKhos_DonVis_DonVi_Id",
                table: "DanhMucKhos");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThietBis_LoaiThietBis_LoaiThietBiId",
                table: "DanhMucThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiThietBis_HeThongs_HeThong_Id",
                table: "LoaiThietBis");

            migrationBuilder.DropIndex(
                name: "IX_LoaiThietBis_HeThong_Id",
                table: "LoaiThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucKhos_DonVi_Id",
                table: "DanhMucKhos");

            migrationBuilder.DropColumn(
                name: "HeThong_Id",
                table: "LoaiThietBis");

            migrationBuilder.DropColumn(
                name: "DonVi_Id",
                table: "DanhMucKhos");

            migrationBuilder.AddColumn<Guid>(
                name: "DonVi_Id",
                table: "Khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HeThong_Id",
                table: "HangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khos_DonVi_Id",
                table: "Khos",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HangThietBis_HeThong_Id",
                table: "HangThietBis",
                column: "HeThong_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThietBis_Loai_HangThietBis_LoaiThietBiId",
                table: "DanhMucThietBis",
                column: "LoaiThietBiId",
                principalTable: "Loai_HangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HangThietBis_HeThongs_HeThong_Id",
                table: "HangThietBis",
                column: "HeThong_Id",
                principalTable: "HeThongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Khos_DonVis_DonVi_Id",
                table: "Khos",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
