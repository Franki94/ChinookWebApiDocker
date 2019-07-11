using Chinook.WebApi;
using Chinook.WebApi.Repository;
using Chinook.WebApi.Repository.MySql;
using Chinook.WebApi.Repository.SqlServer;
using Chinook.WebApi.Strategy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook
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
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ChinookSqlContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("sqlserver"))).BuildServiceProvider();

            services
                .AddDbContext<ChinookMySqlContext>().BuildServiceProvider();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsAccess", builder => 
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            }); 

            services.AddTransient<IUnitOfWork, SqlServerUnitOfWork>();
            services.AddTransient<IUnitOfWork, MySqlUnitOfWork>();
            services.AddTransient<IUnitOfWorkEngine, UnitOfWorkEngine>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //SeedData.InitialData
            //    (
            //    app
            //    .ApplicationServices
            //    .GetRequiredService<IServiceScopeFactory>()
            //    .CreateScope()
            //    .ServiceProvider
            //    );

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
