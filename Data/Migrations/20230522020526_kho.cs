using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class kho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "danhMucKhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKho = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_danhMucKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_danhMucKhos_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_danhMucKhos_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKho = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_khos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khos_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoLoaiThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_khoLoaiThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoLoaiThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoLoaiThietBis_khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoLoaiThietBis_loaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "loaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_khoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoThongTinThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoThongTinThietBis_khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoThongTinThietBis_thongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "thongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_danhMucKhos_CreatedBy",
                table: "danhMucKhos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_danhMucKhos_User_Id",
                table: "danhMucKhos",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_CreatedBy",
                table: "khoLoaiThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_Kho_Id",
                table: "khoLoaiThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_LoaiThietBi_Id",
                table: "khoLoaiThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_CreatedBy",
                table: "khos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khos_DonVi_Id",
                table: "khos",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_DonViTinh_Id",
                table: "khos",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_User_Id",
                table: "khos",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_CreatedBy",
                table: "khoThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_Kho_Id",
                table: "khoThongTinThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_ThongTinThietBi_Id",
                table: "khoThongTinThietBis",
                column: "ThongTinThietBi_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "danhMucKhos");

            migrationBuilder.DropTable(
                name: "khoLoaiThietBis");

            migrationBuilder.DropTable(
                name: "khoThongTinThietBis");

            migrationBuilder.DropTable(
                name: "khos");
        }
    }
}
