using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyuserforbangiaotb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserId",
                table: "banGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoTBs_UserId",
                table: "banGiaoTBs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "banGiaoTBs");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_User_Id",
                table: "banGiaoTBs",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_User_Id",
                table: "banGiaoTBs",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_User_Id",
                table: "banGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoTBs_User_Id",
                table: "banGiaoTBs");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "banGiaoTBs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_UserId",
                table: "banGiaoTBs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserId",
                table: "banGiaoTBs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
