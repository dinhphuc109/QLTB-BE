using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatebangiaotb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserGiaoId",
                table: "banGiaoTBs");

            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserNhanId",
                table: "banGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoTBs_UserGiaoId",
                table: "banGiaoTBs");

            migrationBuilder.DropColumn(
                name: "UserGiaoId",
                table: "banGiaoTBs");

            migrationBuilder.DropColumn(
                name: "UserGiao_Id",
                table: "banGiaoTBs");

            migrationBuilder.RenameColumn(
                name: "UserNhan_Id",
                table: "banGiaoTBs",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "UserNhanId",
                table: "banGiaoTBs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_banGiaoTBs_UserNhanId",
                table: "banGiaoTBs",
                newName: "IX_banGiaoTBs_UserId");

            migrationBuilder.CreateTable(
                name: "banGiaoNguoiNhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanGiaoTB_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserInfoModel_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NVNguoiNhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_banGiaoNguoiNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_banGiaoNguoiNhans_AspNetUsers_NVNguoiNhanId",
                        column: x => x.NVNguoiNhanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoNguoiNhans_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_banGiaoNguoiNhans_banGiaoTBs_BanGiaoTB_Id",
                        column: x => x.BanGiaoTB_Id,
                        principalTable: "banGiaoTBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoNguoiNhans_BanGiaoTB_Id",
                table: "banGiaoNguoiNhans",
                column: "BanGiaoTB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoNguoiNhans_NVNguoiNhanId",
                table: "banGiaoNguoiNhans",
                column: "NVNguoiNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoNguoiNhans_User_CreatedId",
                table: "banGiaoNguoiNhans",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserId",
                table: "banGiaoTBs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserId",
                table: "banGiaoTBs");

            migrationBuilder.DropTable(
                name: "banGiaoNguoiNhans");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "banGiaoTBs",
                newName: "UserNhan_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "banGiaoTBs",
                newName: "UserNhanId");

            migrationBuilder.RenameIndex(
                name: "IX_banGiaoTBs_UserId",
                table: "banGiaoTBs",
                newName: "IX_banGiaoTBs_UserNhanId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserGiaoId",
                table: "banGiaoTBs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGiao_Id",
                table: "banGiaoTBs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_UserGiaoId",
                table: "banGiaoTBs",
                column: "UserGiaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserGiaoId",
                table: "banGiaoTBs",
                column: "UserGiaoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_UserNhanId",
                table: "banGiaoTBs",
                column: "UserNhanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
