using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class suakho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_khos_AspNetUsers_User_Id",
                table: "khos");

            migrationBuilder.DropColumn(
                name: "MaKho",
                table: "khos");

            migrationBuilder.DropColumn(
                name: "TenKho",
                table: "khos");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "khos",
                newName: "DanhMucKho_Id");

            migrationBuilder.RenameIndex(
                name: "IX_khos_User_Id",
                table: "khos",
                newName: "IX_khos_DanhMucKho_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_khos_danhMucKhos_DanhMucKho_Id",
                table: "khos",
                column: "DanhMucKho_Id",
                principalTable: "danhMucKhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_khos_danhMucKhos_DanhMucKho_Id",
                table: "khos");

            migrationBuilder.RenameColumn(
                name: "DanhMucKho_Id",
                table: "khos",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_khos_DanhMucKho_Id",
                table: "khos",
                newName: "IX_khos_User_Id");

            migrationBuilder.AddColumn<string>(
                name: "MaKho",
                table: "khos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenKho",
                table: "khos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_khos_AspNetUsers_User_Id",
                table: "khos",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
