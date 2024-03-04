using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF2.Migrations
{
    public partial class InitWebDB_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "article",
                type: "ntext",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "article");
        }
    }
}
