using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class addqrcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "ThanhLy_Khos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "Kho_ThongTinThietBis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "DieuChuyenThietBi_Khos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "qrCodeData",
                table: "BanGiao_ThongTinThietBis",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "ThanhLy_Khos");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "Kho_ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropColumn(
                name: "qrCodeData",
                table: "BanGiao_ThongTinThietBis");
        }
    }
}
