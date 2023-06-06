using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class addlichsuthietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LichSuThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LichSuThietBis_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LichSuThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LichSuThietBis_ThongTinThietBi_Id",
                table: "LichSuThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuThietBis_User_CreatedId",
                table: "LichSuThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuThietBis_User_Id",
                table: "LichSuThietBis",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LichSuThietBis");
        }
    }
}
