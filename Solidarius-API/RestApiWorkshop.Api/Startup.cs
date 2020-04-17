using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SolidariusAPI.Api.Data;
using System;
using System.IO;
using System.Reflection;

namespace SolidariusAPI.Api
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
            services.AddControllers()
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            // Mysql Connection Packages Mysql.Data; NHibernate
            var connStr = Configuration.GetConnectionString("DefaultConnection");
            var _sessionFactory = Fluently.Configure()
                                      .Database(MySQLConfiguration.Standard.ConnectionString(connStr))
                                      .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                                      .BuildSessionFactory();
            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });


            services.AddAutoMapper(GetType().Assembly);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API Documentation",
                    Version = "1.0",
                    Description = "Come and learn how to use my cool API"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            //services.AddDbContext<MyDatabase>(options =>
            //{
            //    options.UseInMemoryDatabase("Workshop");
            //});

            // REST
            //services.AddMvc(options => options.EnableEndpointRouting = false)
            //    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddScoped<IMyDatabase, MyDatabase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMyDatabase myDatabase)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Documentation V1"));

            // REST
            // app.UseMvc();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            MyDatabaseSeeder.Seed(myDatabase);
        }
    }
}