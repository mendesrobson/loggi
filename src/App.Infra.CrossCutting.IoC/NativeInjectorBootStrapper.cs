using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Interfaces;
using App.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using GFT.Fleury.Pepilines.Interfaces;
using Fleury.Core.ElasticLog.Interfaces;
using Fleury.Core.ElasticLog;
using Microsoft.Extensions.Caching.Memory;
using Dapper;
using GraphQL;
using App.Domain.Queries;
using App.Domain.Models;

namespace App.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //#############################################################
            //====================  Application service ===================
            //#############################################################
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<ILogginLoggiAppService, LogginLoggiAppService>();
            services.AddScoped<ICriarPedidoLoggiAppService, CriarPedidoLoggiAppService>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            //#############################################################
            //=================  Repository mongodb ========================
            //#############################################################

            //#############################################################
            //========================  Repository ========================
            //#############################################################
            services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();


            //#############################################################
            //==================   Context  ===================
            //#############################################################
            services.AddTransient<DynamicParameters>();

            //#############################################################
            //=====================  Unit Of Work ========================
            //#############################################################
            services.AddScoped<IWorkingContext, WorkingContext>();


            //#############################################################
            //=====================  LOG Elastic  ========================
            //#############################################################
            services.AddSingleton<ILogFunctions, LogFunctions>();
            services.AddSingleton<ITokenFunctions, TokenFunctions>();

        }
    }
}
