using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class add_dieuchuyennhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DieuChuyenNhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViNew_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhanNew_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVuNew_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanNew_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuongNew_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongbanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViNewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhanNewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVuNewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongbanNewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuongNewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DieuChuyenNhanViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_BoPhans_BoPhanId",
                        column: x => x.BoPhanId,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_BoPhans_BoPhanNewId",
                        column: x => x.BoPhanNewId,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_ChucVus_ChucVuNewId",
                        column: x => x.ChucVuNewId,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_DonViTraLuongs_DonViTraLuongId",
                        column: x => x.DonViTraLuongId,
                        principalTable: "DonViTraLuongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_DonViTraLuongs_DonViTraLuongNewId",
                        column: x => x.DonViTraLuongNewId,
                        principalTable: "DonViTraLuongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_DonVis_DonViId",
                        column: x => x.DonViId,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_DonVis_DonViNewId",
                        column: x => x.DonViNewId,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_phongbans_PhongbanId",
                        column: x => x.PhongbanId,
                        principalTable: "phongbans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieuChuyenNhanViens_phongbans_PhongbanNewId",
                        column: x => x.PhongbanNewId,
                        principalTable: "phongbans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_BoPhanId",
                table: "DieuChuyenNhanViens",
                column: "BoPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_BoPhanNewId",
                table: "DieuChuyenNhanViens",
                column: "BoPhanNewId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_ChucVuId",
                table: "DieuChuyenNhanViens",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_ChucVuNewId",
                table: "DieuChuyenNhanViens",
                column: "ChucVuNewId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_DonViId",
                table: "DieuChuyenNhanViens",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_DonViNewId",
                table: "DieuChuyenNhanViens",
                column: "DonViNewId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_DonViTraLuongId",
                table: "DieuChuyenNhanViens",
                column: "DonViTraLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_DonViTraLuongNewId",
                table: "DieuChuyenNhanViens",
                column: "DonViTraLuongNewId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_PhongbanId",
                table: "DieuChuyenNhanViens",
                column: "PhongbanId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_PhongbanNewId",
                table: "DieuChuyenNhanViens",
                column: "PhongbanNewId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_User_CreatedId",
                table: "DieuChuyenNhanViens",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenNhanViens_User_Id",
                table: "DieuChuyenNhanViens",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DieuChuyenNhanViens");
        }
    }
}
