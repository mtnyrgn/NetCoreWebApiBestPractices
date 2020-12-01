using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetCoreBestPractices.API.Filters;
using NetCoreBestPractices.Core;
using NetCoreBestPractices.Core.Repositories;
using NetCoreBestPractices.Core.Services;
using NetCoreBestPractices.Core.UnitOfWork;
using NetCoreBestPractices.Data;
using NetCoreBestPractices.Data.Repositories;
using NetCoreBestPractices.Data.UnitOfWorks;
using NetCoreBestPractices.Service.Services;
using NetCoreBestPractices.API.Extensions;
using NetCoreBestPractices.API.Settings;
using NetCoreBestPractices.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

            //services.AddControllers(options =>
            //{
            //    options.Filters.Add(new ValidationFilter());
            //}); //Controller seviyesinde herhangi bir tanımlama yapmadan validation filterı merkezileştirdim. İSter endpointe,ister controllera, ister global olarak filter yazabiliriz.

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DevelopmentConnection"].ToString(), o =>
                {
                    o.MigrationsAssembly("NetCoreBestPractices.Data");//Migrationı hangi katmanda oluşturacağını bildirdim.
                });
            });

            services.AddScoped<NotFoundFilter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Requestte IUnitOfWork gördüğünde bir UnitOfWork objesi oluşturacak. Transient yazarsak her IUnitOfWork için bir obje yaratır.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped(typeof(IMongoService<>), typeof(MongoService<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            services.Configure<MongoDbSettings>(Configuration.GetSection("ConnectionStrings:MongoDbSettings"));
            services.AddSingleton<IMongoDbSettings>( serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value); //Bir üst satırda appsetingsten alınan ayarlar burada inject edildi.


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("TestApi", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "A best practices example of .NET Core API"
                });
            });

            services.Configure<ApiBehaviorOptions>(options =>
           {
               options.SuppressModelStateInvalidFilter = true; //ModelState filterımı kendim kontrol edeceğimi projeye söyledim.Net Core kendi kontrolünü bırakacak.
            });
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

            app.UseCustomExceptionHandler(); // Kendi yazddığımız CustomExceptionHandler içerisindeki UseExceptionHandler methodunu net core'a tanımladık.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/TestApi/swagger.json", "Test API"); //Swaggerın kullanacağı json dosyasının yerini belirledik.
            });

        }
    }
}
