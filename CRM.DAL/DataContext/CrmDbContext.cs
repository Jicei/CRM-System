using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DAL
{
    public class CrmDbContext: DbContext
    {
        //public DbSet<Lead> Leads { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LeadType> LeadTypes { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<OpportunityType> OpportunityTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInOpportunity> ProductInOpportunities { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<ActivityManagerType> ActivityManagerTypes { get; set; }
        public DbSet<ActivityManager> ActivityManagers { get; set; }
        public DbSet<EmployeeInRole> EmployeeInRoles { get; set; }
        public CrmDbContext(DbContextOptions<CrmDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
