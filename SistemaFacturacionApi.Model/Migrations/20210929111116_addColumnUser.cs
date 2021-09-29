using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaFacturacionApi.Model.Migrations
{
    public partial class addColumnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Users");
        }
    }
}
