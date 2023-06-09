using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationchinhsuadieuchuyenthietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_DonVis_DonVi_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DieuChuyenThietBis_DonVi_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropColumn(
                name: "DonVi_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.CreateTable(
                name: "DieuChuyenThietBi_Kho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DieuChuyenThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_DieuChuyenThietBi_Kho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DieuChuyenThietBi_Kho_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenThietBi_Kho_DieuChuyenThietBis_DieuChuyenThietBi_Id",
                        column: x => x.DieuChuyenThietBi_Id,
                        principalTable: "DieuChuyenThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenThietBi_Kho_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenThietBi_Kho_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBi_Kho_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Kho",
                column: "DieuChuyenThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBi_Kho_DonViTinh_Id",
                table: "DieuChuyenThietBi_Kho",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBi_Kho_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Kho",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBi_Kho_User_CreatedId",
                table: "DieuChuyenThietBi_Kho",
                column: "User_CreatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DieuChuyenThietBi_Kho");

            migrationBuilder.AddColumn<Guid>(
                name: "DonVi_Id",
                table: "DieuChuyenThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBis_DonVi_Id",
                table: "DieuChuyenThietBis",
                column: "DonVi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_DonVis_DonVi_Id",
                table: "DieuChuyenThietBis",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
