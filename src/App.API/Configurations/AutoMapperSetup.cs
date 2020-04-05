using App.Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;
using System;

namespace App.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
