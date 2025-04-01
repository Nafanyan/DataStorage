using Application.Models.Create;
using Application.Models.Delete;
using Application.Models.Get;
using Application.Models.GetNames;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Models
{
    public static class ModelBindings
    {
        public static void AddModelsBindins( this IServiceCollection services )
        {
            services.AddScoped<ICreateModelHandler, CreateModelHandler>();
            services.AddScoped<IDeleteModelHandler, DeleteModelHandler>();
            services.AddScoped<IGetModelHandler, GetModelHandler>();
            services.AddScoped<IGetModelsNamesByUsernameHandler, GetModelsNamesByUsernameHandler>();
        }
    }
}
