using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineNewsPaper.Data.Migrations
{
    public partial class MappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsAdViaCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsAdID = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsAdViaCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsAdViaCategories_NewsAd_NewsAdID",
                        column: x => x.NewsAdID,
                        principalTable: "NewsAd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsAdViaCategories_NewsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsAdViaCategories_CategoryId",
                table: "NewsAdViaCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsAdViaCategories_NewsAdID",
                table: "NewsAdViaCategories",
                column: "NewsAdID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsAdViaCategories");
        }
    }
}
