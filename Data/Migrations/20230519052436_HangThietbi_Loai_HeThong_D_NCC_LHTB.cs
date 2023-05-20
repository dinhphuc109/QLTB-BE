using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class HangThietbi_Loai_HeThong_D_NCC_LHTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiLienHe",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "domains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDomain = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_domains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_domains_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "heThongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHeThong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHeThong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_heThongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heThongs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loaiThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoaiThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_loaiThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loaiThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHangThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HeThong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_hangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hangThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hangThietBis_heThongs_HeThong_Id",
                        column: x => x.HeThong_Id,
                        principalTable: "heThongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loaiHangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_loaiHangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loaiHangThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loaiHangThietBis_hangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "hangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loaiHangThietBis_loaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "loaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_domains_CreatedBy",
                table: "domains",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_hangThietBis_CreatedBy",
                table: "hangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_hangThietBis_HeThong_Id",
                table: "hangThietBis",
                column: "HeThong_Id");

            migrationBuilder.CreateIndex(
                name: "IX_heThongs_CreatedBy",
                table: "heThongs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_CreatedBy",
                table: "loaiHangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_HangThietBi_Id",
                table: "loaiHangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_LoaiThietBi_Id",
                table: "loaiHangThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loaiThietBis_CreatedBy",
                table: "loaiThietBis",
                column: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "domains");

            migrationBuilder.DropTable(
                name: "loaiHangThietBis");

            migrationBuilder.DropTable(
                name: "hangThietBis");

            migrationBuilder.DropTable(
                name: "loaiThietBis");

            migrationBuilder.DropTable(
                name: "heThongs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "NhaCungCaps");

            migrationBuilder.DropColumn(
                name: "NguoiLienHe",
                table: "NhaCungCaps");
        }
    }
}
