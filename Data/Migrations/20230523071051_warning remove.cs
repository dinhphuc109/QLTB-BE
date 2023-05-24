using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Data.Migrations
{
    /// <inheritdoc />
    public partial class warningremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_CreatedBy",
                table: "banGiaoTBs");

            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoThongTinThietBis_AspNetUsers_CreatedBy",
                table: "banGiaoThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_BoPhans_AspNetUsers_CreatedBy",
                table: "BoPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_chiTietLoaiThongTinThietBis_AspNetUsers_CreatedBy",
                table: "chiTietLoaiThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_chucVus_AspNetUsers_CreatedBy",
                table: "chucVus");

            migrationBuilder.DropForeignKey(
                name: "FK_danhMucKhos_AspNetUsers_CreatedBy",
                table: "danhMucKhos");

            migrationBuilder.DropForeignKey(
                name: "FK_domains_AspNetUsers_CreatedBy",
                table: "domains");

            migrationBuilder.DropForeignKey(
                name: "FK_DonVis_AspNetUsers_CreatedBy",
                table: "DonVis");

            migrationBuilder.DropForeignKey(
                name: "FK_DonViTinhs_AspNetUsers_CreatedBy",
                table: "DonViTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_donViTraLuongs_AspNetUsers_CreatedBy",
                table: "donViTraLuongs");

            migrationBuilder.DropForeignKey(
                name: "FK_hangThietBis_AspNetUsers_CreatedBy",
                table: "hangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_heThongs_AspNetUsers_CreatedBy",
                table: "heThongs");

            migrationBuilder.DropForeignKey(
                name: "FK_khoLoaiThietBis_AspNetUsers_CreatedBy",
                table: "khoLoaiThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_khos_AspNetUsers_CreatedBy",
                table: "khos");

            migrationBuilder.DropForeignKey(
                name: "FK_khoThongTinThietBis_AspNetUsers_CreatedBy",
                table: "khoThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_loaiHangThietBis_AspNetUsers_CreatedBy",
                table: "loaiHangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_loaiThietBis_AspNetUsers_CreatedBy",
                table: "loaiThietBis");

      

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Roles_AspNetUsers_CreatedBy",
                table: "Menu_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_AspNetUsers_CreatedBy",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_NhaCungCaps_AspNetUsers_CreatedBy",
                table: "NhaCungCaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Nhoms_AspNetUsers_CreatedBy",
                table: "Nhoms");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanHois_AspNetUsers_CreatedBy",
                table: "PhanHois");

            migrationBuilder.DropForeignKey(
                name: "FK_phongbans_AspNetUsers_CreatedBy",
                table: "phongbans");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuongThucDangNhaps_AspNetUsers_CreatedBy",
                table: "PhuongThucDangNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_tapDoans_AspNetUsers_CreatedBy",
                table: "tapDoans");

            migrationBuilder.DropForeignKey(
                name: "FK_thongTinHangThietBis_AspNetUsers_CreatedBy",
                table: "thongTinHangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_thongTinThietBis_AspNetUsers_CreatedBy",
                table: "thongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_thongTinThietBis_CreatedBy",
                table: "thongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_thongTinHangThietBis_CreatedBy",
                table: "thongTinHangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_tapDoans_CreatedBy",
                table: "tapDoans");

            migrationBuilder.DropIndex(
                name: "IX_PhuongThucDangNhaps_CreatedBy",
                table: "PhuongThucDangNhaps");

  

            migrationBuilder.DropIndex(
                name: "IX_PhanHois_CreatedBy",
                table: "PhanHois");

            migrationBuilder.DropIndex(
                name: "IX_Nhoms_CreatedBy",
                table: "Nhoms");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCaps_CreatedBy",
                table: "NhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_Menus_CreatedBy",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menu_Roles_CreatedBy",
                table: "Menu_Roles");



            migrationBuilder.DropIndex(
                name: "IX_loaiThietBis_CreatedBy",
                table: "loaiThietBis");

            migrationBuilder.DropIndex(
                name: "IX_loaiHangThietBis_CreatedBy",
                table: "loaiHangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_khoThongTinThietBis_CreatedBy",
                table: "khoThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_khos_CreatedBy",
                table: "khos");

            migrationBuilder.DropIndex(
                name: "IX_khoLoaiThietBis_CreatedBy",
                table: "khoLoaiThietBis");

            migrationBuilder.DropIndex(
                name: "IX_heThongs_CreatedBy",
                table: "heThongs");

            migrationBuilder.DropIndex(
                name: "IX_hangThietBis_CreatedBy",
                table: "hangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_donViTraLuongs_CreatedBy",
                table: "donViTraLuongs");

            migrationBuilder.DropIndex(
                name: "IX_DonViTinhs_CreatedBy",
                table: "DonViTinhs");

            migrationBuilder.DropIndex(
                name: "IX_DonVis_CreatedBy",
                table: "DonVis");

            migrationBuilder.DropIndex(
                name: "IX_domains_CreatedBy",
                table: "domains");

            migrationBuilder.DropIndex(
                name: "IX_danhMucKhos_CreatedBy",
                table: "danhMucKhos");

            migrationBuilder.DropIndex(
                name: "IX_chucVus_CreatedBy",
                table: "chucVus");

            migrationBuilder.DropIndex(
                name: "IX_chiTietLoaiThongTinThietBis_CreatedBy",
                table: "chiTietLoaiThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_BoPhans_CreatedBy",
                table: "BoPhans");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoThongTinThietBis_CreatedBy",
                table: "banGiaoThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoTBs_CreatedBy",
                table: "banGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BoPhan_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonVi_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "thongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "thongTinHangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "tapDoans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "PhuongThucDangNhaps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "PhanHois",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "Nhoms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "NhaCungCaps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "Menu_Roles",
                type: "uniqueidentifier",
                nullable: true);

   

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "loaiThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "loaiHangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "khoThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "khos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "khoLoaiThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "heThongs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "hangThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "DonViTinhs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "domains",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "danhMucKhos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "chiTietLoaiThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "banGiaoThongTinThietBis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User_CreatedId",
                table: "banGiaoTBs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_thongTinThietBis_User_CreatedId",
                table: "thongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinHangThietBis_User_CreatedId",
                table: "thongTinHangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_tapDoans_User_CreatedId",
                table: "tapDoans",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucDangNhaps_User_CreatedId",
                table: "PhuongThucDangNhaps",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_User_CreatedId",
                table: "PhanHois",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhoms_User_CreatedId",
                table: "Nhoms",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_User_CreatedId",
                table: "NhaCungCaps",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_User_CreatedId",
                table: "Menus",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Roles_User_CreatedId",
                table: "Menu_Roles",
                column: "User_CreatedId");

         
      

            migrationBuilder.CreateIndex(
                name: "IX_loaiThietBis_User_CreatedId",
                table: "loaiThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_User_CreatedId",
                table: "loaiHangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_User_CreatedId",
                table: "khoThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_khos_User_CreatedId",
                table: "khos",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_User_CreatedId",
                table: "khoLoaiThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_heThongs_User_CreatedId",
                table: "heThongs",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_hangThietBis_User_CreatedId",
                table: "hangThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_User_CreatedId",
                table: "DonViTinhs",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_domains_User_CreatedId",
                table: "domains",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_danhMucKhos_User_CreatedId",
                table: "danhMucKhos",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLoaiThongTinThietBis_User_CreatedId",
                table: "chiTietLoaiThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoThongTinThietBis_User_CreatedId",
                table: "banGiaoThongTinThietBis",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_User_CreatedId",
                table: "banGiaoTBs",
                column: "User_CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BoPhan_Id",
                table: "AspNetUsers",
                column: "BoPhan_Id",
                unique: true,
                filter: "[BoPhan_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id",
                unique: true,
                filter: "[ChucVu_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonVi_Id",
                table: "AspNetUsers",
                column: "DonVi_Id",
                unique: true,
                filter: "[DonVi_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id",
                unique: true,
                filter: "[DonViTraLuong_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhongBan_Id",
                table: "AspNetUsers",
                column: "PhongBan_Id",
                unique: true,
                filter: "[PhongBan_Id] IS NOT NULL");



            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_User_CreatedId",
                table: "banGiaoTBs",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoThongTinThietBis_AspNetUsers_User_CreatedId",
                table: "banGiaoThongTinThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chiTietLoaiThongTinThietBis_AspNetUsers_User_CreatedId",
                table: "chiTietLoaiThongTinThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_danhMucKhos_AspNetUsers_User_CreatedId",
                table: "danhMucKhos",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_domains_AspNetUsers_User_CreatedId",
                table: "domains",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonViTinhs_AspNetUsers_User_CreatedId",
                table: "DonViTinhs",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hangThietBis_AspNetUsers_User_CreatedId",
                table: "hangThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_heThongs_AspNetUsers_User_CreatedId",
                table: "heThongs",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_khoLoaiThietBis_AspNetUsers_User_CreatedId",
                table: "khoLoaiThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_khos_AspNetUsers_User_CreatedId",
                table: "khos",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_khoThongTinThietBis_AspNetUsers_User_CreatedId",
                table: "khoThongTinThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loaiHangThietBis_AspNetUsers_User_CreatedId",
                table: "loaiHangThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loaiThietBis_AspNetUsers_User_CreatedId",
                table: "loaiThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Roles_AspNetUsers_User_CreatedId",
                table: "Menu_Roles",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_AspNetUsers_User_CreatedId",
                table: "Menus",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhaCungCaps_AspNetUsers_User_CreatedId",
                table: "NhaCungCaps",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nhoms_AspNetUsers_User_CreatedId",
                table: "Nhoms",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanHois_AspNetUsers_User_CreatedId",
                table: "PhanHois",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuongThucDangNhaps_AspNetUsers_User_CreatedId",
                table: "PhuongThucDangNhaps",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tapDoans_AspNetUsers_User_CreatedId",
                table: "tapDoans",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_thongTinHangThietBis_AspNetUsers_User_CreatedId",
                table: "thongTinHangThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_thongTinThietBis_AspNetUsers_User_CreatedId",
                table: "thongTinThietBis",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_phongbans_PhongBan_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_User_CreatedId",
                table: "banGiaoTBs");

            migrationBuilder.DropForeignKey(
                name: "FK_banGiaoThongTinThietBis_AspNetUsers_User_CreatedId",
                table: "banGiaoThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_chiTietLoaiThongTinThietBis_AspNetUsers_User_CreatedId",
                table: "chiTietLoaiThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_danhMucKhos_AspNetUsers_User_CreatedId",
                table: "danhMucKhos");

            migrationBuilder.DropForeignKey(
                name: "FK_domains_AspNetUsers_User_CreatedId",
                table: "domains");

            migrationBuilder.DropForeignKey(
                name: "FK_DonViTinhs_AspNetUsers_User_CreatedId",
                table: "DonViTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_hangThietBis_AspNetUsers_User_CreatedId",
                table: "hangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_heThongs_AspNetUsers_User_CreatedId",
                table: "heThongs");

            migrationBuilder.DropForeignKey(
                name: "FK_khoLoaiThietBis_AspNetUsers_User_CreatedId",
                table: "khoLoaiThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_khos_AspNetUsers_User_CreatedId",
                table: "khos");

            migrationBuilder.DropForeignKey(
                name: "FK_khoThongTinThietBis_AspNetUsers_User_CreatedId",
                table: "khoThongTinThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_loaiHangThietBis_AspNetUsers_User_CreatedId",
                table: "loaiHangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_loaiThietBis_AspNetUsers_User_CreatedId",
                table: "loaiThietBis");



            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Roles_AspNetUsers_User_CreatedId",
                table: "Menu_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_AspNetUsers_User_CreatedId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_NhaCungCaps_AspNetUsers_User_CreatedId",
                table: "NhaCungCaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Nhoms_AspNetUsers_User_CreatedId",
                table: "Nhoms");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanHois_AspNetUsers_User_CreatedId",
                table: "PhanHois");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuongThucDangNhaps_AspNetUsers_User_CreatedId",
                table: "PhuongThucDangNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_tapDoans_AspNetUsers_User_CreatedId",
                table: "tapDoans");

            migrationBuilder.DropForeignKey(
                name: "FK_thongTinHangThietBis_AspNetUsers_User_CreatedId",
                table: "thongTinHangThietBis");

            migrationBuilder.DropForeignKey(
                name: "FK_thongTinThietBis_AspNetUsers_User_CreatedId",
                table: "thongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_thongTinThietBis_User_CreatedId",
                table: "thongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_thongTinHangThietBis_User_CreatedId",
                table: "thongTinHangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_tapDoans_User_CreatedId",
                table: "tapDoans");

            migrationBuilder.DropIndex(
                name: "IX_PhuongThucDangNhaps_User_CreatedId",
                table: "PhuongThucDangNhaps");

            migrationBuilder.DropIndex(
                name: "IX_PhanHois_User_CreatedId",
                table: "PhanHois");

            migrationBuilder.DropIndex(
                name: "IX_Nhoms_User_CreatedId",
                table: "Nhoms");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCaps_User_CreatedId",
                table: "NhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_Menus_User_CreatedId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menu_Roles_User_CreatedId",
                table: "Menu_Roles");



            migrationBuilder.DropIndex(
                name: "IX_loaiThietBis_User_CreatedId",
                table: "loaiThietBis");

            migrationBuilder.DropIndex(
                name: "IX_loaiHangThietBis_User_CreatedId",
                table: "loaiHangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_khoThongTinThietBis_User_CreatedId",
                table: "khoThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_khos_User_CreatedId",
                table: "khos");

            migrationBuilder.DropIndex(
                name: "IX_khoLoaiThietBis_User_CreatedId",
                table: "khoLoaiThietBis");

            migrationBuilder.DropIndex(
                name: "IX_heThongs_User_CreatedId",
                table: "heThongs");

            migrationBuilder.DropIndex(
                name: "IX_hangThietBis_User_CreatedId",
                table: "hangThietBis");

            migrationBuilder.DropIndex(
                name: "IX_DonViTinhs_User_CreatedId",
                table: "DonViTinhs");

            migrationBuilder.DropIndex(
                name: "IX_domains_User_CreatedId",
                table: "domains");

            migrationBuilder.DropIndex(
                name: "IX_danhMucKhos_User_CreatedId",
                table: "danhMucKhos");

            migrationBuilder.DropIndex(
                name: "IX_chiTietLoaiThongTinThietBis_User_CreatedId",
                table: "chiTietLoaiThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoThongTinThietBis_User_CreatedId",
                table: "banGiaoThongTinThietBis");

            migrationBuilder.DropIndex(
                name: "IX_banGiaoTBs_User_CreatedId",
                table: "banGiaoTBs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BoPhan_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonVi_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhongBan_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "thongTinThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "thongTinHangThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "tapDoans");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "PhuongThucDangNhaps");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "PhanHois");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "Nhoms");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "NhaCungCaps");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "Menu_Roles");



            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "loaiThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "loaiHangThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "khoThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "khos");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "khoLoaiThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "heThongs");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "hangThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "DonViTinhs");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "domains");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "danhMucKhos");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "chiTietLoaiThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "banGiaoThongTinThietBis");

            migrationBuilder.DropColumn(
                name: "User_CreatedId",
                table: "banGiaoTBs");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinThietBis_CreatedBy",
                table: "thongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinHangThietBis_CreatedBy",
                table: "thongTinHangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tapDoans_CreatedBy",
                table: "tapDoans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucDangNhaps_CreatedBy",
                table: "PhuongThucDangNhaps",
                column: "CreatedBy");


            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_CreatedBy",
                table: "PhanHois",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Nhoms_CreatedBy",
                table: "Nhoms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_CreatedBy",
                table: "NhaCungCaps",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CreatedBy",
                table: "Menus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Roles_CreatedBy",
                table: "Menu_Roles",
                column: "CreatedBy");



            migrationBuilder.CreateIndex(
                name: "IX_loaiThietBis_CreatedBy",
                table: "loaiThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_CreatedBy",
                table: "loaiHangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_CreatedBy",
                table: "khoThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khos_CreatedBy",
                table: "khos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_CreatedBy",
                table: "khoLoaiThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_heThongs_CreatedBy",
                table: "heThongs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_hangThietBis_CreatedBy",
                table: "hangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_donViTraLuongs_CreatedBy",
                table: "donViTraLuongs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_CreatedBy",
                table: "DonViTinhs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_CreatedBy",
                table: "DonVis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_domains_CreatedBy",
                table: "domains",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_danhMucKhos_CreatedBy",
                table: "danhMucKhos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_CreatedBy",
                table: "chucVus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLoaiThongTinThietBis_CreatedBy",
                table: "chiTietLoaiThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhans_CreatedBy",
                table: "BoPhans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoThongTinThietBis_CreatedBy",
                table: "banGiaoThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_banGiaoTBs_CreatedBy",
                table: "banGiaoTBs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BoPhan_Id",
                table: "AspNetUsers",
                column: "BoPhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonVi_Id",
                table: "AspNetUsers",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoTBs_AspNetUsers_CreatedBy",
                table: "banGiaoTBs",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_banGiaoThongTinThietBis_AspNetUsers_CreatedBy",
                table: "banGiaoThongTinThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoPhans_AspNetUsers_CreatedBy",
                table: "BoPhans",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chiTietLoaiThongTinThietBis_AspNetUsers_CreatedBy",
                table: "chiTietLoaiThongTinThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chucVus_AspNetUsers_CreatedBy",
                table: "chucVus",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_danhMucKhos_AspNetUsers_CreatedBy",
                table: "danhMucKhos",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_domains_AspNetUsers_CreatedBy",
                table: "domains",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonVis_AspNetUsers_CreatedBy",
                table: "DonVis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonViTinhs_AspNetUsers_CreatedBy",
                table: "DonViTinhs",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_donViTraLuongs_AspNetUsers_CreatedBy",
                table: "donViTraLuongs",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hangThietBis_AspNetUsers_CreatedBy",
                table: "hangThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_heThongs_AspNetUsers_CreatedBy",
                table: "heThongs",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_khoLoaiThietBis_AspNetUsers_CreatedBy",
                table: "khoLoaiThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_khos_AspNetUsers_CreatedBy",
                table: "khos",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_khoThongTinThietBis_AspNetUsers_CreatedBy",
                table: "khoThongTinThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loaiHangThietBis_AspNetUsers_CreatedBy",
                table: "loaiHangThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loaiThietBis_AspNetUsers_CreatedBy",
                table: "loaiThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Roles_AspNetUsers_CreatedBy",
                table: "Menu_Roles",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_AspNetUsers_CreatedBy",
                table: "Menus",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhaCungCaps_AspNetUsers_CreatedBy",
                table: "NhaCungCaps",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nhoms_AspNetUsers_CreatedBy",
                table: "Nhoms",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanHois_AspNetUsers_CreatedBy",
                table: "PhanHois",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_phongbans_AspNetUsers_CreatedBy",
                table: "phongbans",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuongThucDangNhaps_AspNetUsers_CreatedBy",
                table: "PhuongThucDangNhaps",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tapDoans_AspNetUsers_CreatedBy",
                table: "tapDoans",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_thongTinHangThietBis_AspNetUsers_CreatedBy",
                table: "thongTinHangThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_thongTinThietBis_AspNetUsers_CreatedBy",
                table: "thongTinThietBis",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
