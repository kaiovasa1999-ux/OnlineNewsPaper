using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineNewsPaper.Data.Migrations
{
    public partial class MyNewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ApplicationUsers_ApplicationUserID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_NewsAd_NewsAdId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ApplicationUserID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_NewsAd_NewsAdId",
                table: "Images",
                column: "NewsAdId",
                principalTable: "NewsAd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_NewsAd_NewsAdId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ApplicationUserID",
                table: "Images",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ApplicationUsers_ApplicationUserID",
                table: "Images",
                column: "ApplicationUserID",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_NewsAd_NewsAdId",
                table: "Images",
                column: "NewsAdId",
                principalTable: "NewsAd",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
