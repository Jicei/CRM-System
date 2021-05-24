using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityManagerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityManagerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    Patronymic = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_ParentRoleId",
                        column: x => x.ParentRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    TypeActivityId = table.Column<Guid>(nullable: true),
                    ResponsibleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_TypeActivityId",
                        column: x => x.TypeActivityId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Remains = table.Column<float>(nullable: false),
                    ResponsibleId1 = table.Column<Guid>(nullable: true),
                    ResponsibleIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Employees_ResponsibleId1",
                        column: x => x.ResponsibleId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Employees_ResponsibleIdId",
                        column: x => x.ResponsibleIdId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    DateTimeStartCall = table.Column<DateTime>(nullable: false),
                    TimeWait = table.Column<TimeSpan>(nullable: false),
                    DateStartAnswer = table.Column<DateTime>(nullable: false),
                    DateEndAnswer = table.Column<DateTime>(nullable: false),
                    ResponsibleId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queues_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ActivityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lead_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_LeadTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "LeadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ResponsibleId = table.Column<Guid>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    CityId = table.Column<Guid>(nullable: true),
                    LeadId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Desctiption = table.Column<string>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    ResponsibleId = table.Column<Guid>(nullable: true),
                    CityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ActivityManagerTypeId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: true),
                    LeadId = table.Column<Guid>(nullable: true),
                    ResposibleId = table.Column<Guid>(nullable: true),
                    ResponsibleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityManagers_ActivityManagerTypes_ActivityManagerTypeId",
                        column: x => x.ActivityManagerTypeId,
                        principalTable: "ActivityManagerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityManagers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityManagers_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityManagers_Employees_ResposibleId",
                        column: x => x.ResposibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    TimeWait = table.Column<TimeSpan>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Discount = table.Column<float>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true),
                    ResponsibleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunities_OpportunityTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OpportunityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInOpportunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OpportunityId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInOpportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInOpportunities_Opportunities_OpportunityId",
                        column: x => x.OpportunityId,
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInOpportunities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ResponsibleId",
                table: "Activities",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TypeActivityId",
                table: "Activities",
                column: "TypeActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityManagers_ActivityManagerTypeId",
                table: "ActivityManagers",
                column: "ActivityManagerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityManagers_ContactId",
                table: "ActivityManagers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityManagers_LeadId",
                table: "ActivityManagers",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityManagers_ResposibleId",
                table: "ActivityManagers",
                column: "ResposibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LeadId",
                table: "Companies",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ResponsibleId",
                table: "Companies",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CityId",
                table: "Contacts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CountryId",
                table: "Contacts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ResponsibleId",
                table: "Contacts",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInRoles_EmployeeId",
                table: "EmployeeInRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInRoles_RoleId",
                table: "EmployeeInRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_ActivityId",
                table: "Lead",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_TypeId",
                table: "Lead",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_CompanyId",
                table: "Opportunities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_ContactId",
                table: "Opportunities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_ResponsibleId",
                table: "Opportunities",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_TypeId",
                table: "Opportunities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInOpportunities_OpportunityId",
                table: "ProductInOpportunities",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInOpportunities_ProductId",
                table: "ProductInOpportunities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ResponsibleId1",
                table: "Products",
                column: "ResponsibleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ResponsibleIdId",
                table: "Products",
                column: "ResponsibleIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_ResponsibleId",
                table: "Queues",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ParentRoleId",
                table: "Roles",
                column: "ParentRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityManagers");

            migrationBuilder.DropTable(
                name: "EmployeeInRoles");

            migrationBuilder.DropTable(
                name: "ProductInOpportunities");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "ActivityManagerTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OpportunityTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "LeadTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ActivityTypes");
        }
    }
}
