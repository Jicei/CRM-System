using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DAL.Migrations
{
    public partial class IsFisicalClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFisicalClient",
                table: "Opportunities",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFisicalClient",
                table: "Opportunities");
        }
    }
}
