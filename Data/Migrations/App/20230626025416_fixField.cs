using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationForTest.data.migrations.App
{
    public partial class fixField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AspNetUsers");
        }
    }
}
