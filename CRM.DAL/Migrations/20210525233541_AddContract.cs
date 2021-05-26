using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DAL.Migrations
{
    public partial class AddContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Opportunities_OpportunityId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Employees_ResponsibleId",
                table: "Contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_ResponsibleId",
                table: "Contracts",
                newName: "IX_Contracts_ResponsibleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_OpportunityId",
                table: "Contracts",
                newName: "IX_Contracts_OpportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Opportunities_OpportunityId",
                table: "Contracts",
                column: "OpportunityId",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_ResponsibleId",
                table: "Contracts",
                column: "ResponsibleId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Opportunities_OpportunityId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_ResponsibleId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ResponsibleId",
                table: "Contract",
                newName: "IX_Contract_ResponsibleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_OpportunityId",
                table: "Contract",
                newName: "IX_Contract_OpportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Opportunities_OpportunityId",
                table: "Contract",
                column: "OpportunityId",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Employees_ResponsibleId",
                table: "Contract",
                column: "ResponsibleId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
