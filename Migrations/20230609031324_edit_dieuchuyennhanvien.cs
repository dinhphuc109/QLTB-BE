using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class edit_dieuchuyennhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaNhanVien",
                table: "DieuChuyenNhanViens");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "DieuChuyenNhanViens",
                newName: "TrangThai");

            migrationBuilder.AlterColumn<string>(
                name: "SoSeri",
                table: "ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Kho_Id",
                table: "ThanhLyThietBis",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "MaDieuChuyen",
                table: "DieuChuyenNhanViens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "XacNhan",
                table: "DieuChuyenNhanViens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CBNV_DieuChuyen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DieuChuyenNhanVien_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CBNV_DieuChuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CBNV_DieuChuyen_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CBNV_DieuChuyen_DieuChuyenNhanViens_DieuChuyenNhanVien_Id",
                        column: x => x.DieuChuyenNhanVien_Id,
                        principalTable: "DieuChuyenNhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CBNV_DieuChuyen_DieuChuyenNhanVien_Id",
                table: "CBNV_DieuChuyen",
                column: "DieuChuyenNhanVien_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CBNV_DieuChuyen_User_Id",
                table: "CBNV_DieuChuyen",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CBNV_DieuChuyen");

            migrationBuilder.DropColumn(
                name: "MaDieuChuyen",
                table: "DieuChuyenNhanViens");

            migrationBuilder.DropColumn(
                name: "XacNhan",
                table: "DieuChuyenNhanViens");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "DieuChuyenNhanViens",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "SoSeri",
                table: "ThongTinThietBis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Kho_Id",
                table: "ThanhLyThietBis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNhanVien",
                table: "DieuChuyenNhanViens",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
