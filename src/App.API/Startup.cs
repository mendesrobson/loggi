using App.API.Configurations;
using App.API.Middleware;
using App.Domain.Enum;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using Fleury.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL;
using GraphQL.Types;
using App.Infra.Data.Schema;
using GraphiQl;

namespace App.API
{
    public class Startup
    {
        private const string version = "2.0.0";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigins"));
            });

            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.BDCORP, Configuration["BDCORP"] },
                { DatabaseConnectionName.CAC_PROD,Configuration["CAC_PROD"]}
            };

            services.AddFleuryJwtDefault(Environment.GetEnvironmentVariable("JWT_SECRET"));


            services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();

            services.AddSwaggerDefault(s =>
            {
                s.Version = version;
                s.Title = "Api Integração Loggi";
                s.Description = "Api Integração Loggi";
                s.TermsOfService = "";
                s.Contact.Name = "";
                s.Contact.Email = "";
                s.Contact.Url = "";
                s.License.Name = "";
                s.License.Url = "";
            });

            services.AddAutoMapperSetup();

            services.AddMemoryCache();

            services.AddDependencyInjection();
            services.AddSingleton(Configuration);

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(
                new SchemaManager(
                    new FuncDependencyResolver(type => sp.GetService(type))));

            //services.AddScoped<IDependencyResolver>(x =>
            //                                        new FuncDependencyResolver(x.GetRequiredService));


            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });

            services.AddTransient<ErrorHandlerMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerfactory,
            IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFleurySwaggerDefault(s =>
            {
                s.Name = "API - Loggi";
                s.Version = version;
            });

            app.UseGraphiQl();
           // app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}