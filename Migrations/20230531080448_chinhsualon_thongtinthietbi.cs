using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class chinhsualon_thongtinthietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_HangThietBis_HangThietBi_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_LoaiThietBis_LoaiThietBi_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "CauHinh",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "MaThietBi",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "TenThietBi",
                table: "ThongTinThietBis");

            migrationBuilder.RenameColumn(
                name: "LoaiThietBi_Id",
                table: "ThongTinThietBis",
                newName: "DonViTinh_Id");

            migrationBuilder.RenameColumn(
                name: "HangThietBi_Id",
                table: "ThongTinThietBis",
                newName: "DanhMucThietBI_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinThietBis_LoaiThietBi_Id",
                table: "ThongTinThietBis",
                newName: "IX_ThongTinThietBis_DonViTinh_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinThietBis_HangThietBi_Id",
                table: "ThongTinThietBis",
                newName: "IX_ThongTinThietBis_DanhMucThietBI_Id");

            migrationBuilder.RenameColumn(
                name: "MaHangThietBi",
                table: "HangThietBis",
                newName: "MaHang");

            migrationBuilder.AddColumn<string>(
                name: "TinhTrangThietBi",
                table: "ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiThietBi_Id",
                table: "LoaiThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentLoaiThietBiId",
                table: "LoaiThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Kho_Id",
                table: "Kho_ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "User_Id",
                table: "BanGiao_NguoiNhans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BanGiaoTB_Id",
                table: "BanGiao_NguoiNhans",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "DanhMucThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CauHinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoaiThietbi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoaiThietBiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucThietBis_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhMucThietBis_HangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhMucThietBis_Loai_HangThietBis_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "Loai_HangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiThietBis_ParentLoaiThietBiId",
                table: "LoaiThietBis",
                column: "ParentLoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThietBis_HangThietBi_Id",
                table: "DanhMucThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThietBis_LoaiThietBiId",
                table: "DanhMucThietBis",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThietBis_User_CreatedId",
                table: "DanhMucThietBis",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiThietBis_LoaiThietBis_ParentLoaiThietBiId",
                table: "LoaiThietBis",
                column: "ParentLoaiThietBiId",
                principalTable: "LoaiThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_DanhMucThietBis_DanhMucThietBI_Id",
                table: "ThongTinThietBis",
                column: "DanhMucThietBI_Id",
                principalTable: "DanhMucThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_DonViTinhs_DonViTinh_Id",
                table: "ThongTinThietBis",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoaiThietBis_LoaiThietBis_ParentLoaiThietBiId",
                table: "LoaiThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_DanhMucThietBis_DanhMucThietBI_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinThietBis_DonViTinhs_DonViTinh_Id",
                table: "ThongTinThietBis");

            migrationBuilder.DropTable(
                name: "DanhMucThietBis");

            migrationBuilder.DropIndex(
                name: "IX_LoaiThietBis_ParentLoaiThietBiId",
                table: "LoaiThietBis");

            migrationBuilder.DropColumn(
                name: "TinhTrangThietBi",
                table: "ThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "LoaiThietBi_Id",
                table: "LoaiThietBis");

            migrationBuilder.DropColumn(
                name: "ParentLoaiThietBiId",
                table: "LoaiThietBis");

            migrationBuilder.RenameColumn(
                name: "DonViTinh_Id",
                table: "ThongTinThietBis",
                newName: "LoaiThietBi_Id");

            migrationBuilder.RenameColumn(
                name: "DanhMucThietBI_Id",
                table: "ThongTinThietBis",
                newName: "HangThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinThietBis_DonViTinh_Id",
                table: "ThongTinThietBis",
                newName: "IX_ThongTinThietBis_LoaiThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ThongTinThietBis_DanhMucThietBI_Id",
                table: "ThongTinThietBis",
                newName: "IX_ThongTinThietBis_HangThietBi_Id");

            migrationBuilder.RenameColumn(
                name: "MaHang",
                table: "HangThietBis",
                newName: "MaHangThietBi");

            migrationBuilder.AddColumn<string>(
                name: "CauHinh",
                table: "ThongTinThietBis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaThietBi",
                table: "ThongTinThietBis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenThietBi",
                table: "ThongTinThietBis",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "Kho_Id",
                table: "Kho_ThongTinThietBis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "User_Id",
                table: "BanGiao_NguoiNhans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BanGiaoTB_Id",
                table: "BanGiao_NguoiNhans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_HangThietBis_HangThietBi_Id",
                table: "ThongTinThietBis",
                column: "HangThietBi_Id",
                principalTable: "HangThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinThietBis_LoaiThietBis_LoaiThietBi_Id",
                table: "ThongTinThietBis",
                column: "LoaiThietBi_Id",
                principalTable: "LoaiThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
