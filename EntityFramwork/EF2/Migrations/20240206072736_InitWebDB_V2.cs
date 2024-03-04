using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF2.Migrations
{
    public partial class InitWebDB_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articletag",
                columns: table => new
                {
                    ArticleTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articletag", x => x.ArticleTagId);
                    table.ForeignKey(
                        name: "FK_articletag_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articletag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articletag_ArticleId_TagId",
                table: "articletag",
                columns: new[] { "ArticleId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_articletag_TagId",
                table: "articletag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articletag");
        }
    }
}
