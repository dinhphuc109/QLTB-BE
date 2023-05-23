using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class smallupdatekho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_Id",
                table: "khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_khos_UserId",
                table: "khos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_khos_AspNetUsers_UserId",
                table: "khos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_khos_AspNetUsers_UserId",
                table: "khos");

            migrationBuilder.DropIndex(
                name: "IX_khos_UserId",
                table: "khos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "khos");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "khos");
        }
    }
}
