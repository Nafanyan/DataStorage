using Application.Common;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Bindings
    {
        public static void AddInfrastructureBindings( this IServiceCollection services )
        {
            services.AddScoped<IDatasetService, DatasetService>();
            services.AddScoped<IModelService, ModelService>();
        }
    }
}
