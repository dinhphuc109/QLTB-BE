using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class changetablepropety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BieuChuyenThietBis_AspNetUsers_User_CreatedId",
                table: "BieuChuyenThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_BieuChuyenThietBis_AspNetUsers_User_Id",
                table: "BieuChuyenThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_BieuChuyenThietBis_DonVis_DonVi_Id",
                table: "BieuChuyenThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_BieuChuyenThietBis_Khos_Kho_Id",
                table: "BieuChuyenThietBis");

            migrationBuilder.DropTable(
                name: "BanGiaoNguoiNhans");

            migrationBuilder.DropTable(
                name: "BanGiaoThongTinThietBis");

            migrationBuilder.DropTable(
                name: "LoaiHangThietBis");

            migrationBuilder.DropTable(
                name: "NguoiNhanDieuChuyens");

            migrationBuilder.DropTable(
                name: "ThanhLyKhos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BieuChuyenThietBis",
                table: "BieuChuyenThietBis");

            migrationBuilder.RenameTable(
                name: "BieuChuyenThietBis",
                newName: "DieuChuyenThietBis");

            migrationBuilder.RenameIndex(
                name: "IX_BieuChuyenThietBis_User_Id",
                table: "DieuChuyenThietBis",
                newName: "IX_DieuChuyenThietBis_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BieuChuyenThietBis_User_CreatedId",
                table: "DieuChuyenThietBis",
                newName: "IX_DieuChuyenThietBis_User_CreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_BieuChuyenThietBis_Kho_Id",
                table: "DieuChuyenThietBis",
                newName: "IX_DieuChuyenThietBis_Kho_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BieuChuyenThietBis_DonVi_Id",
                table: "DieuChuyenThietBis",
                newName: "IX_DieuChuyenThietBis_DonVi_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DieuChuyenThietBis",
                table: "DieuChuyenThietBis",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BanGiao_NguoiNhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_BanGiao_NguoiNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiao_NguoiNhans_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiao_NguoiNhans_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiao_NguoiNhans_BanGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "BanGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BanGiao_ThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_BanGiao_ThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiao_ThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiao_ThongTinThietBis_BanGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "BanGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiao_ThongTinThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loai_HangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Loai_HangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loai_HangThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loai_HangThietBis_HangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loai_HangThietBis_LoaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "LoaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiNhan_DieuChuyens",
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
                    table.PrimaryKey("PK_NguoiNhan_DieuChuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiNhan_DieuChuyens_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiNhan_DieuChuyens_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiNhan_DieuChuyens_DieuChuyenThietBis_DieuChuyenThietBi_Id",
                        column: x => x.DieuChuyenThietBi_Id,
                        principalTable: "DieuChuyenThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThanhLy_Khos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThanhLyThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ThanhLy_Khos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhLy_Khos_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLy_Khos_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLy_Khos_ThanhLyThietBis_ThanhLyThietBi_Id",
                        column: x => x.ThanhLyThietBi_Id,
                        principalTable: "ThanhLyThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_NguoiNhans_BanGiaoTB_Id",
                table: "BanGiao_NguoiNhans",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_NguoiNhans_User_CreatedId",
                table: "BanGiao_NguoiNhans",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_NguoiNhans_User_Id",
                table: "BanGiao_NguoiNhans",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_ThongTinThietBis_BanGiaoTB_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_ThongTinThietBis_ThongTinThietBi_Id",
                table: "BanGiao_ThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiao_ThongTinThietBis_User_CreatedId",
                table: "BanGiao_ThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_HangThietBis_HangThietBi_Id",
                table: "Loai_HangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_HangThietBis_LoaiThietBi_Id",
                table: "Loai_HangThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_HangThietBis_User_CreatedId",
                table: "Loai_HangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhan_DieuChuyens_DieuChuyenThietBi_Id",
                table: "NguoiNhan_DieuChuyens",
                column: "DieuChuyenThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhan_DieuChuyens_User_CreatedId",
                table: "NguoiNhan_DieuChuyens",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhan_DieuChuyens_User_Id",
                table: "NguoiNhan_DieuChuyens",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLy_Khos_Kho_Id",
                table: "ThanhLy_Khos",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLy_Khos_ThanhLyThietBi_Id",
                table: "ThanhLy_Khos",
                column: "ThanhLyThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLy_Khos_User_CreatedId",
                table: "ThanhLy_Khos",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_User_CreatedId",
                table: "DieuChuyenThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_User_Id",
                table: "DieuChuyenThietBis",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_DonVis_DonVi_Id",
                table: "DieuChuyenThietBis",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_Khos_Kho_Id",
                table: "DieuChuyenThietBis",
                column: "Kho_Id",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_User_CreatedId",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_User_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_DonVis_DonVi_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_Khos_Kho_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropTable(
                name: "BanGiao_NguoiNhans");

            migrationBuilder.DropTable(
                name: "BanGiao_ThongTinThietBis");

            migrationBuilder.DropTable(
                name: "Loai_HangThietBis");

            migrationBuilder.DropTable(
                name: "NguoiNhan_DieuChuyens");

            migrationBuilder.DropTable(
                name: "ThanhLy_Khos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DieuChuyenThietBis",
                table: "DieuChuyenThietBis");

            migrationBuilder.RenameTable(
                name: "DieuChuyenThietBis",
                newName: "BieuChuyenThietBis");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBis_User_Id",
                table: "BieuChuyenThietBis",
                newName: "IX_BieuChuyenThietBis_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBis_User_CreatedId",
                table: "BieuChuyenThietBis",
                newName: "IX_BieuChuyenThietBis_User_CreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBis_Kho_Id",
                table: "BieuChuyenThietBis",
                newName: "IX_BieuChuyenThietBis_Kho_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBis_DonVi_Id",
                table: "BieuChuyenThietBis",
                newName: "IX_BieuChuyenThietBis_DonVi_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BieuChuyenThietBis",
                table: "BieuChuyenThietBis",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BanGiaoNguoiNhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGiaoNguoiNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiaoNguoiNhans_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoNguoiNhans_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoNguoiNhans_BanGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "BanGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BanGiaoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGiaoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGiaoThongTinThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoThongTinThietBis_BanGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "BanGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BanGiaoThongTinThietBis_ThongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "ThongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiHangThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaiHangThietBis_HangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaiHangThietBis_LoaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "LoaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiNhanDieuChuyens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DieuChuyenThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiNhanDieuChuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiNhanDieuChuyens_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiNhanDieuChuyens_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiNhanDieuChuyens_BieuChuyenThietBis_DieuChuyenThietBi_Id",
                        column: x => x.DieuChuyenThietBi_Id,
                        principalTable: "BieuChuyenThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThanhLyKhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThanhLyThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhLyKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhLyKhos_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLyKhos_Khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhLyKhos_ThanhLyThietBis_ThanhLyThietBi_Id",
                        column: x => x.ThanhLyThietBi_Id,
                        principalTable: "ThanhLyThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoNguoiNhans_BanGiaoTB_Id",
                table: "BanGiaoNguoiNhans",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoNguoiNhans_User_CreatedId",
                table: "BanGiaoNguoiNhans",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoNguoiNhans_User_Id",
                table: "BanGiaoNguoiNhans",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoThongTinThietBis_BanGiaoTB_Id",
                table: "BanGiaoThongTinThietBis",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoThongTinThietBis_ThongTinThietBi_Id",
                table: "BanGiaoThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BanGiaoThongTinThietBis_User_CreatedId",
                table: "BanGiaoThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangThietBis_HangThietBi_Id",
                table: "LoaiHangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangThietBis_LoaiThietBi_Id",
                table: "LoaiHangThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangThietBis_User_CreatedId",
                table: "LoaiHangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanDieuChuyens_DieuChuyenThietBi_Id",
                table: "NguoiNhanDieuChuyens",
                column: "DieuChuyenThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanDieuChuyens_User_CreatedId",
                table: "NguoiNhanDieuChuyens",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiNhanDieuChuyens_User_Id",
                table: "NguoiNhanDieuChuyens",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyKhos_Kho_Id",
                table: "ThanhLyKhos",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyKhos_ThanhLyThietBi_Id",
                table: "ThanhLyKhos",
                column: "ThanhLyThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhLyKhos_User_CreatedId",
                table: "ThanhLyKhos",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_BieuChuyenThietBis_AspNetUsers_User_CreatedId",
                table: "BieuChuyenThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BieuChuyenThietBis_AspNetUsers_User_Id",
                table: "BieuChuyenThietBis",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BieuChuyenThietBis_DonVis_DonVi_Id",
                table: "BieuChuyenThietBis",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BieuChuyenThietBis_Khos_Kho_Id",
                table: "BieuChuyenThietBis",
                column: "Kho_Id",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
