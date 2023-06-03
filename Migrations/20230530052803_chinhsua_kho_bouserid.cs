using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsua_kho_bouserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Khos_AspNetUsers_User_Id",
                table: "Khos");

            migrationBuilder.DropIndex(
                name: "IX_Khos_User_Id",
                table: "Khos");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Khos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "User_Id",
                table: "Khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khos_User_Id",
                table: "Khos",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Khos_AspNetUsers_User_Id",
                table: "Khos",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
