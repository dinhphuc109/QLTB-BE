using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsuahangthietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loai_HangThietBis_AspNetUsers_User_CreatedId",
                table: "Loai_HangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_Loai_HangThietBis_User_CreatedId",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Loai_HangThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "Loai_HangThietBis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Loai_HangThietBis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Loai_HangThietBis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Loai_HangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Loai_HangThietBis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Loai_HangThietBis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Loai_HangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Loai_HangThietBis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "Loai_HangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loai_HangThietBis_User_CreatedId",
                table: "Loai_HangThietBis",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loai_HangThietBis_AspNetUsers_User_CreatedId",
                table: "Loai_HangThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
