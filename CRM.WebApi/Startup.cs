using CRM.BLL.MapperProfiles;
using CRM.BLL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CRM.BLL.Services;
using Microsoft.EntityFrameworkCore;
using CRM.DAL;
using Microsoft.EntityFrameworkCore.Design;

namespace CRM.WebAPi
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
            services.AddDbContext<CrmDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("devConnection")));
            //services.AddMvc();
            services.AddControllers();
            //services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                 c.SwaggerDoc(Configuration.GetSection("SwaggerOptions:Version").Value, new OpenApiInfo
                 {
                     Version = Configuration.GetSection("SwaggerOptions:Version").Value,
                     Title = Configuration.GetSection("SwaggerOptions:Title").Value,
                     Description = Configuration.GetSection("SwaggerOptions:Description").Value
                 });
            });

            services.AddAutoMapper(typeof(MapperConfig));

            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IActivityService, ActivityService>();
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

            app.UseCors("CorsApi");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
