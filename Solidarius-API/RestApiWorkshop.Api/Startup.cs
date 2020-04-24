using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NHibernate;
using SolidariusAPI.Api.Data;
using System;
using System.IO;
using System.Reflection;

namespace SolidariusAPI.Api
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";
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
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            // Mysql Connection Packages Mysql.Data; NHibernate
            //var database = MySQLConfiguration.Standard.ConnectionString(Configuration.GetConnectionString("DefaultConnection"));
            var database = MsSqliteConfiguration.Standard.UsingFile("../../DB/database.db");
            var _sessionFactory = Fluently.Configure()
                                      .Database(database)
                                      .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                                      .BuildConfiguration();
            _sessionFactory.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName)
                      .SetProperty(NHibernate.Cfg.Environment.PrepareSql, true.ToString())
                      .SetProperty(NHibernate.Cfg.Environment.ShowSql, true.ToString())
                      .SetProperty(NHibernate.Cfg.Environment.MaxFetchDepth, 2.ToString());
            services.AddScoped(factory =>
            {
                return _sessionFactory.BuildSessionFactory().OpenSession();
            });

            // Add Session
            //services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvcCore(option => option.EnableEndpointRouting = false);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true; // consent required
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddSession(opts =>
            //{
            //    opts.Cookie.IsEssential = true; // make the session cookie Essential
            //});
            //services.AddScoped(svc =>
            //{
            //    var sessionFactory = svc.GetRequiredService<ISessionFactory>();
            //    var session = sessionFactory.OpenSession();
            //    return session;
            //});
            //services.AddDistributedMySqlCache(o =>
            //{
            //    o.ConnectionString = connStr;
            //    o.SchemaName = "TCCSolidario";
            //    o.TableName = "Sessions";
            //});

            // Add CORS policy
            services.AddCors(o => o.AddPolicy(AllowSpecificOrigins, builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
            }));

            // Mapper
            services.AddAutoMapper(GetType().Assembly);

            // Swagger
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

            // DI
            services.AddScoped<IDatabase, MyDatabase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabase myDatabase)
        {
            app.UseStaticFiles();
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // Use Cors
            app.UseCors(AllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Documentation V1"));

            // app.UseAuthorization();



            // Use session
            //app.UseMvc();
        }
    }
}