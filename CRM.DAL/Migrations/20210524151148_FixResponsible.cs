using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DAL.Migrations
{
    public partial class FixResponsible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_ResponsibleId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_ResponsibleIdId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ResponsibleId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ResponsibleIdId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ResponsibleId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ResponsibleIdId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ResponsibleId",
                table: "Products",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_ResponsibleId",
                table: "Products",
                column: "ResponsibleId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_ResponsibleId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ResponsibleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleIdId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ResponsibleId1",
                table: "Products",
                column: "ResponsibleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ResponsibleIdId",
                table: "Products",
                column: "ResponsibleIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_ResponsibleId1",
                table: "Products",
                column: "ResponsibleId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_ResponsibleIdId",
                table: "Products",
                column: "ResponsibleIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
