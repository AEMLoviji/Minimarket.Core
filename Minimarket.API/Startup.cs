using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minimarket.API.Domain.Db.Contexts;
using Minimarket.API.Domain.Repositories;
using Minimarket.API.Domain.Services;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Minimarket.API
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
            services.AddSwaggerGen(cfg =>
           {
               cfg.SwaggerDoc("v1", new Info
               {
                   Title = "Minimarket API",
                   Version = "v1.0",
                   Description = "RESTful API built with ASP.NET Core v2.2. The main purpose was to fix and share how to create RESTful service using maintainable architecture where modules decoupled and allows features to be added easily.",
                   Contact = new Contact
                   {
                       Name = "Elvin Asadov",
                       Url = "https://github.com/AEMLoviji",
                   },
                   License = new License
                   {
                       Name = "MIT",
                   },
               });

               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               cfg.IncludeXmlComments(xmlPath);
           });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("MinimarketDb");
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
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

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Supermarket API");
             });

            app.UseMvc();
        }
    }
}
