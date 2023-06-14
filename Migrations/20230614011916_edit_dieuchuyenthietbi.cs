using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class edit_dieuchuyenthietbi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_DonViTinhs_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_User_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropTable(
                name: "NguoiNhan_DieuChuyens");

            migrationBuilder.DropIndex(
                name: "IX_DieuChuyenThietBis_User_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DieuChuyenThietBi_Khos_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropColumn(
                name: "DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropColumn(
                name: "NgayNhan",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "DieuChuyenThietBis",
                newName: "UserNhan_Id");

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserLap_Id",
                table: "DieuChuyenThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBis_UserLap_Id",
                table: "DieuChuyenThietBis",
                column: "UserLap_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_UserLap_Id",
                table: "DieuChuyenThietBis",
                column: "UserLap_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_UserLap_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DieuChuyenThietBis_UserLap_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.DropColumn(
                name: "UserLap_Id",
                table: "DieuChuyenThietBis");

            migrationBuilder.RenameColumn(
                name: "UserNhan_Id",
                table: "DieuChuyenThietBis",
                newName: "User_Id");

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "NhaCungCaps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayNhan",
                table: "DieuChuyenThietBi_Khos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "NguoiNhan_DieuChuyens",
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

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBis_User_Id",
                table: "DieuChuyenThietBis",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DieuChuyenThietBi_Khos_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "DonViTinh_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_DonViTinhs_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBis_AspNetUsers_User_Id",
                table: "DieuChuyenThietBis",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
