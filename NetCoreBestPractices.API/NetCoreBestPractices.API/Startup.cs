using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCoreBestPractices.Core;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using NetCoreBestPractices.Core.UnitOfWork;
using NetCoreBestPractices.Data;
using NetCoreBestPractices.Data.Repositories;
using NetCoreBestPractices.Data.UnitOfWorks;
using NetCoreBestPractices.Service.Services;
namespace NetCoreBestPractices.API
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DevelopmentConnection"].ToString(), o =>
                {
                    o.MigrationsAssembly("NetCoreBestPractices.Data");//Migrationı hangi katmanda oluşturacağını bildirdim.
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Requestte IUnitOfWork gördüğünde bir UnitOfWork objesi oluşturacak. Transient yazarsak her IUnitOfWork için bir obje yaratır.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
