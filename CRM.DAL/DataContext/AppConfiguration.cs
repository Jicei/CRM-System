using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CRM.DAL.DataContext
{
    class AppConfiguration
    {
        public string SqlConnection { get; set; }
        public AppConfiguration()
        {
            var builder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            builder.AddJsonFile(path, false);
            var Configuration = builder.Build();
            SqlConnection = Configuration.GetConnectionString("devConnection");
        }
    }
}
