using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class bangiaotb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "banGiaoTBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaBanGIao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserNhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserNhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserGiao_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserGiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banGiaoTBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_banGiaoTBs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoTBs_AspNetUsers_UserGiaoId",
                        column: x => x.UserGiaoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoTBs_AspNetUsers_UserNhanId",
                        column: x => x.UserNhanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoTBs_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "banGiaoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banGiaoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_banGiaoThongTinThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoThongTinThietBis_banGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "banGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoThongTinThietBis_thongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "thongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phongbans_CreatedBy",
                table: "phongbans",
                column: "CreatedBy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_TapDoan_Id",
                table: "DonVis",
                column: "TapDoan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_BoPhan_Id",
                table: "chucVus",
                column: "BoPhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhans_PhongBan_Id",
                table: "BoPhans",
                column: "PhongBan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_CreatedBy",
                table: "banGiaoTBs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_DonViTinh_Id",
                table: "banGiaoTBs",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_UserGiaoId",
                table: "banGiaoTBs",
                column: "UserGiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_UserNhanId",
                table: "banGiaoTBs",
                column: "UserNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoThongTinThietBis_BanGiaoTB_Id",
                table: "banGiaoThongTinThietBis",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoThongTinThietBis_CreatedBy",
                table: "banGiaoThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoThongTinThietBis_ThongTinThietBi_Id",
                table: "banGiaoThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoPhans_phongbans_PhongBan_Id",
                table: "BoPhans",
                column: "PhongBan_Id",
                principalTable: "phongbans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chucVus_BoPhans_BoPhan_Id",
                table: "chucVus",
                column: "BoPhan_Id",
                principalTable: "BoPhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonVis_tapDoans_TapDoan_Id",
                table: "DonVis",
                column: "TapDoan_Id",
                principalTable: "tapDoans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
