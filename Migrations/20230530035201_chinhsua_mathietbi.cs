using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsua_mathietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaThongTinThietBi",
                table: "ThongTinThietBis",
                newName: "MaThietBi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaThietBi",
                table: "ThongTinThietBis",
                newName: "MaThongTinThietBi");
        }
    }
}
