using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class dieuchuyenthietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dieuChuyenThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDieuChuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayDieuChuyen = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_dieuChuyenThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dieuChuyenThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dieuChuyenThietBis_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dieuChuyenThietBis_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dieuChuyenThietBis_khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nguoiNhanDieuChuyens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DieuChuyenThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_nguoiNhanDieuChuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguoiNhanDieuChuyens_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiNhanDieuChuyens_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nguoiNhanDieuChuyens_dieuChuyenThietBis_DieuChuyenThietBi_Id",
                        column: x => x.DieuChuyenThietBi_Id,
                        principalTable: "dieuChuyenThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dieuChuyenThietBis_DonVi_Id",
                table: "dieuChuyenThietBis",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dieuChuyenThietBis_Kho_Id",
                table: "dieuChuyenThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dieuChuyenThietBis_User_CreatedId",
                table: "dieuChuyenThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_dieuChuyenThietBis_User_Id",
                table: "dieuChuyenThietBis",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiNhanDieuChuyens_DieuChuyenThietBi_Id",
                table: "nguoiNhanDieuChuyens",
                column: "DieuChuyenThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiNhanDieuChuyens_User_CreatedId",
                table: "nguoiNhanDieuChuyens",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_nguoiNhanDieuChuyens_User_Id",
                table: "nguoiNhanDieuChuyens",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nguoiNhanDieuChuyens");

            migrationBuilder.DropTable(
                name: "dieuChuyenThietBis");
        }
    }
}
