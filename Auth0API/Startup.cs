using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Auth0API.Application.Interfaces;
using Auth0API.Application.Services;
using Auth0API.Domain;
using Auth0API.Domain.Repositories;
using Auth0API.Domain.Seedwork;
using Auth0API.Helper;
using Auth0API.Infrastructure;
using Auth0API.Infrastructure.Adapter;
using Auth0API.Infrastructure.Initializer;
using Auth0API.Infrastructure.Repositories;
using Auth0API.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Auth0API
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddSingleton<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
            services.AddScoped<IInitializer, Initializer>();

            var domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = Configuration["Auth0:Audience"];
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:employees", policy => policy.Requirements.Add(new HasScopeRequirement("read:employees", domain)));
            });
        
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Auth0 API with NetCore", 
                    Version = "v1" ,
                    Description="This API demostrate the use of DDD, Repository Pattern , Specification Patterns and all related to Enterprise Design",
                    Contact = new OpenApiContact
                    {
                        Name = "Olonyl Landeros",
                        Email = "jose87.landeros@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/olonyl-horacio-rocha-landeros-3b3760a9"),
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
           

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IInitializer initializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwagger(option => option.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(option => option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            var typeAdapterFactory = app.ApplicationServices.GetService<ITypeAdapterFactory>();
            if (typeAdapterFactory == null) throw new Exception("No se ha agregado el servicio de FabricaAdaptadorTipo");
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            initializer.Initialize();
        }
    }
}
