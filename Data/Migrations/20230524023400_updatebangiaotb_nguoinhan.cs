using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatebangiaotb_nguoinhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoNguoiNhans_AspNetUsers_NVNguoiNhanId",
                table: "banGiaoNguoiNhans");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoNguoiNhans_NVNguoiNhanId",
                table: "banGiaoNguoiNhans");

            migrationBuilder.DropColumn(
                name: "NVNguoiNhanId",
                table: "banGiaoNguoiNhans");

            migrationBuilder.RenameColumn(
                name: "UserInfoModel_Id",
                table: "banGiaoNguoiNhans",
                newName: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoNguoiNhans_User_Id",
                table: "banGiaoNguoiNhans",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoNguoiNhans_AspNetUsers_User_Id",
                table: "banGiaoNguoiNhans",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoNguoiNhans_AspNetUsers_User_Id",
                table: "banGiaoNguoiNhans");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoNguoiNhans_User_Id",
                table: "banGiaoNguoiNhans");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "banGiaoNguoiNhans",
                newName: "UserInfoModel_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "NVNguoiNhanId",
                table: "banGiaoNguoiNhans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoNguoiNhans_NVNguoiNhanId",
                table: "banGiaoNguoiNhans",
                column: "NVNguoiNhanId");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoNguoiNhans_AspNetUsers_NVNguoiNhanId",
                table: "banGiaoNguoiNhans",
                column: "NVNguoiNhanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
