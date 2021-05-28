﻿// <auto-generated />
using System;
using CRM.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.DAL.Migrations
{
    [DbContext(typeof(CrmDbContext))]
    [Migration("20210528172901_IsFisicalClient")]
    partial class IsFisicalClient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM.DAL.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.HasIndex("TypeActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("CRM.DAL.Entities.ActivityManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActivityManagerTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LeadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResposibleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActivityManagerTypeId");

                    b.HasIndex("ContactId");

                    b.HasIndex("LeadId");

                    b.HasIndex("ResposibleId");

                    b.ToTable("ActivityManagers");
                });

            modelBuilder.Entity("CRM.DAL.Entities.ActivityManagerType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityManagerTypes");
                });

            modelBuilder.Entity("CRM.DAL.Entities.ActivityType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("CRM.DAL.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LeadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("LeadId");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Desctiption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CountryId");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OpportunityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CRM.DAL.Entities.EmployeeInRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoleId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeInRoles");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Lead", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("TypeId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("CRM.DAL.Entities.LeadType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LeadTypes");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Opportunity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<bool>("IsFisicalClient")
                        .HasColumnType("bit");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("TimeWait")
                        .HasColumnType("time");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ContactId");

                    b.HasIndex("ResponsibleId");

                    b.HasIndex("TypeId");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("CRM.DAL.Entities.OpportunityType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OpportunityTypes");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Remains")
                        .HasColumnType("real");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CRM.DAL.Entities.ProductInOpportunity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OpportunityId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInOpportunities");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Queue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEndAnswer")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStartAnswer")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeStartCall")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("TimeWait")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentRoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Activity", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId");

                    b.HasOne("CRM.DAL.Entities.ActivityType", "TypeActivity")
                        .WithMany("Activities")
                        .HasForeignKey("TypeActivityId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.ActivityManager", b =>
                {
                    b.HasOne("CRM.DAL.Entities.ActivityManagerType", "ActivityManagerType")
                        .WithMany("ActivitiyManagers")
                        .HasForeignKey("ActivityManagerTypeId");

                    b.HasOne("CRM.DAL.Entities.Contact", "Contact")
                        .WithMany("ActivityManagers")
                        .HasForeignKey("ContactId");

                    b.HasOne("CRM.DAL.Entities.Lead", "Lead")
                        .WithMany("ActivityManagers")
                        .HasForeignKey("LeadId");

                    b.HasOne("CRM.DAL.Entities.Employee", "Resposible")
                        .WithMany("ActivityManagers")
                        .HasForeignKey("ResposibleId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.City", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Company", b =>
                {
                    b.HasOne("CRM.DAL.Entities.City", "City")
                        .WithMany("Companies")
                        .HasForeignKey("CityId");

                    b.HasOne("CRM.DAL.Entities.Country", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("CountryId");

                    b.HasOne("CRM.DAL.Entities.Lead", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId");

                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany("Companies")
                        .HasForeignKey("ResponsibleId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Contact", b =>
                {
                    b.HasOne("CRM.DAL.Entities.City", "City")
                        .WithMany("Contact")
                        .HasForeignKey("CityId");

                    b.HasOne("CRM.DAL.Entities.Company", "Company")
                        .WithMany("Conatact")
                        .HasForeignKey("CompanyId");

                    b.HasOne("CRM.DAL.Entities.Country", "Country")
                        .WithMany("Contact")
                        .HasForeignKey("CountryId");

                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany("Contacts")
                        .HasForeignKey("ResponsibleId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Contract", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Opportunity", "Opportunity")
                        .WithMany("Contracts")
                        .HasForeignKey("OpportunityId");

                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany("Contracts")
                        .HasForeignKey("ResponsibleId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.EmployeeInRole", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Employee", "Employee")
                        .WithMany("EmployeeInRole")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.DAL.Entities.Role", "Role")
                        .WithMany("EmployeeInRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.DAL.Entities.Lead", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Activity", "Activity")
                        .WithMany("Leads")
                        .HasForeignKey("ActivityId");

                    b.HasOne("CRM.DAL.Entities.LeadType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Opportunity", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Company", "Company")
                        .WithMany("Opportunities")
                        .HasForeignKey("CompanyId");

                    b.HasOne("CRM.DAL.Entities.Contact", "Contact")
                        .WithMany("Opportunities")
                        .HasForeignKey("ContactId");

                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany("Opportunities")
                        .HasForeignKey("ResponsibleId");

                    b.HasOne("CRM.DAL.Entities.OpportunityType", "Type")
                        .WithMany("Opportunities")
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Product", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.ProductInOpportunity", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Opportunity", "Opportunity")
                        .WithMany("ProductInOpportunity")
                        .HasForeignKey("OpportunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.DAL.Entities.Product", "Product")
                        .WithMany("ProductInOpportunity")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.DAL.Entities.Queue", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Employee", "Responsible")
                        .WithMany("Queue")
                        .HasForeignKey("ResponsibleId");
                });

            modelBuilder.Entity("CRM.DAL.Entities.Role", b =>
                {
                    b.HasOne("CRM.DAL.Entities.Role", "ParentRole")
                        .WithMany()
                        .HasForeignKey("ParentRoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
