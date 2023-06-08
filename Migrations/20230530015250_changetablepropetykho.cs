using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class changetablepropetykho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoThongTinThietBis");

            migrationBuilder.CreateTable(
                name: "Kho_ThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Kho_ThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kho_ThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kho_ThongTinThietBis_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kho_ThongTinThietBis_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kho_ThongTinThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kho_ThongTinThietBis_DonViTinh_Id",
                table: "Kho_ThongTinThietBis",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_ThongTinThietBis_Kho_Id",
                table: "Kho_ThongTinThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_ThongTinThietBis_ThongTinThietBi_Id",
                table: "Kho_ThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kho_ThongTinThietBis_User_CreatedId",
                table: "Kho_ThongTinThietBis",
                column: "User_CreatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kho_ThongTinThietBis");

            migrationBuilder.CreateTable(
                name: "KhoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoThongTinThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_DonViTinh_Id",
                table: "KhoThongTinThietBis",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_Kho_Id",
                table: "KhoThongTinThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_ThongTinThietBi_Id",
                table: "KhoThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhoThongTinThietBis_User_CreatedId",
                table: "KhoThongTinThietBis",
                column: "User_CreatedId");
        }
    }
}
