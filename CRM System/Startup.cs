using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(o => o.AddPolicy("CorsApi", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc();
            services.AddControllers();
            services.AddControllersWithViews();

            // services.AddDbContext<DevoxTestTaskDbContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("DevoxTestTaskDatabase")));

            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc(Configuration.GetSection("SwaggerOptions:Version").Value, new OpenApiInfo
                 {
                     Version = Configuration.GetSection("SwaggerOptions:Version").Value,
                     Title = Configuration.GetSection("SwaggerOptions:Title").Value,
                     Description = Configuration.GetSection("SwaggerOptions:Description").Value
                 });
             });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(Configuration.GetSection("SwaggerOptions:UIEndpoint").Value, Configuration.GetSection("SwaggerOptions:Description").Value);
                option.RoutePrefix = string.Empty;
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
