using CRM.DAL;
using CRM.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRM.DAL
{
    public class CrmDbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
    {
        public CrmDbContext CreateDbContext(string[] args)
        {

            //var appConfiguration = new AppConfiguration();
            var optionBuilder = new DbContextOptionsBuilder<CrmDbContext>();
            optionBuilder.UseSqlServer("Server=PC\\SQLEXPRESS;Database=CRM;Trusted_Connection=True;");

            return new CrmDbContext(optionBuilder.Options);
        }
    }
}
