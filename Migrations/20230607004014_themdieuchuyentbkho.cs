using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class themdieuchuyentbkho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_AspNetUsers_User_CreatedId",
                table: "DieuChuyenThietBi_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_DieuChuyenThietBis_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_DonViTinhs_DonViTinh_Id",
                table: "DieuChuyenThietBi_Kho");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_ThongTinThietBis_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Kho");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DieuChuyenThietBi_Kho",
                table: "DieuChuyenThietBi_Kho");

            migrationBuilder.RenameTable(
                name: "DieuChuyenThietBi_Kho",
                newName: "DieuChuyenThietBi_Khos");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Kho_User_CreatedId",
                table: "DieuChuyenThietBi_Khos",
                newName: "IX_DieuChuyenThietBi_Khos_User_CreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Kho_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                newName: "IX_DieuChuyenThietBi_Khos_ThongTinThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Kho_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos",
                newName: "IX_DieuChuyenThietBi_Khos_DonViTinh_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Kho_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                newName: "IX_DieuChuyenThietBi_Khos_DieuChuyenThietBi_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DieuChuyenThietBi_Khos",
                table: "DieuChuyenThietBi_Khos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_AspNetUsers_User_CreatedId",
                table: "DieuChuyenThietBi_Khos",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_DieuChuyenThietBis_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "DieuChuyenThietBi_Id",
                principalTable: "DieuChuyenThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_DonViTinhs_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_ThongTinThietBis_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Khos",
                column: "ThongTinThietBi_Id",
                principalTable: "ThongTinThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_AspNetUsers_User_CreatedId",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_DieuChuyenThietBis_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_DonViTinhs_DonViTinh_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropForeignKey(
                name: "FK_DieuChuyenThietBi_Khos_ThongTinThietBis_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DieuChuyenThietBi_Khos",
                table: "DieuChuyenThietBi_Khos");

            migrationBuilder.RenameTable(
                name: "DieuChuyenThietBi_Khos",
                newName: "DieuChuyenThietBi_Kho");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Khos_User_CreatedId",
                table: "DieuChuyenThietBi_Kho",
                newName: "IX_DieuChuyenThietBi_Kho_User_CreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Khos_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Kho",
                newName: "IX_DieuChuyenThietBi_Kho_ThongTinThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Khos_DonViTinh_Id",
                table: "DieuChuyenThietBi_Kho",
                newName: "IX_DieuChuyenThietBi_Kho_DonViTinh_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DieuChuyenThietBi_Khos_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Kho",
                newName: "IX_DieuChuyenThietBi_Kho_DieuChuyenThietBi_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DieuChuyenThietBi_Kho",
                table: "DieuChuyenThietBi_Kho",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_AspNetUsers_User_CreatedId",
                table: "DieuChuyenThietBi_Kho",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_DieuChuyenThietBis_DieuChuyenThietBi_Id",
                table: "DieuChuyenThietBi_Kho",
                column: "DieuChuyenThietBi_Id",
                principalTable: "DieuChuyenThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_DonViTinhs_DonViTinh_Id",
                table: "DieuChuyenThietBi_Kho",
                column: "DonViTinh_Id",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieuChuyenThietBi_Kho_ThongTinThietBis_ThongTinThietBi_Id",
                table: "DieuChuyenThietBi_Kho",
                column: "ThongTinThietBi_Id",
                principalTable: "ThongTinThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
