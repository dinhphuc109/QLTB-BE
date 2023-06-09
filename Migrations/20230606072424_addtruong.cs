using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class addtruong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThietBis_LoaiThietBis_LoaiThietBiId",
                table: "DanhMucThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_DanhMucThietBis_DanhMucThietBI_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThietBis_LoaiThietBiId",
                table: "DanhMucThietBis");

            migrationBuilder.DropColumn(
                name: "LoaiThietBiId",
                table: "DanhMucThietBis");

            migrationBuilder.RenameColumn(
                name: "DanhMucThietBI_Id",
                table: "ThongTinThietBis",
                newName: "DanhMucThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinThietBis_DanhMucThietBI_Id",
                table: "ThongTinThietBis",
                newName: "IX_ThongTinThietBis_DanhMucThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThietBis_LoaiThietbi_Id",
                table: "DanhMucThietBis",
                column: "LoaiThietbi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThietBis_LoaiThietBis_LoaiThietbi_Id",
                table: "DanhMucThietBis",
                column: "LoaiThietbi_Id",
                principalTable: "LoaiThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_DanhMucThietBis_DanhMucThietBi_Id",
                table: "ThongTinThietBis",
                column: "DanhMucThietBi_Id",
                principalTable: "DanhMucThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThietBis_LoaiThietBis_LoaiThietbi_Id",
                table: "DanhMucThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_DanhMucThietBis_DanhMucThietBi_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThietBis_LoaiThietbi_Id",
                table: "DanhMucThietBis");

            migrationBuilder.RenameColumn(
                name: "DanhMucThietBi_Id",
                table: "ThongTinThietBis",
                newName: "DanhMucThietBI_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinThietBis_DanhMucThietBi_Id",
                table: "ThongTinThietBis",
                newName: "IX_ThongTinThietBis_DanhMucThietBI_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiThietBiId",
                table: "DanhMucThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThietBis_LoaiThietBiId",
                table: "DanhMucThietBis",
                column: "LoaiThietBiId");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThietBis_LoaiThietBis_LoaiThietBiId",
                table: "DanhMucThietBis",
                column: "LoaiThietBiId",
                principalTable: "LoaiThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_DanhMucThietBis_DanhMucThietBI_Id",
                table: "ThongTinThietBis",
                column: "DanhMucThietBI_Id",
                principalTable: "DanhMucThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
