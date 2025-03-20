using Application.Dataset;
using Application.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Bindings
    {
        public static void AddApplicationBindings( this IServiceCollection services )
        {
            services.AddDatasetsBindings();
            services.AddModelsBindins();
        }
    }
}
