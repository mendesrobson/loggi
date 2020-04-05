using App.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace App.API.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
