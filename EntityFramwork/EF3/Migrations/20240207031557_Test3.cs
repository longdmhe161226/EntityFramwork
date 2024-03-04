using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF3.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_PersonID",
                table: "Marks",
                column: "PersonID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Marks_PersonID",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Marks");
        }
    }
}
