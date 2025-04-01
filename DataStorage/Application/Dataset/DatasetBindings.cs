using Application.Dataset.Create;
using Application.Dataset.Delete;
using Application.Dataset.Get;
using Application.Dataset.GetNames;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Dataset
{
    public static class DatasetBindings
    {
        public static void AddDatasetsBindings( this IServiceCollection services )
        {
            services.AddScoped<ICreateDatasetHandler, CreateDatasetHandler>();
            services.AddScoped<IDeleteDatasetHandler, DeleteDatasetHandler>();
            services.AddScoped<IGetDatasetHandler, GetDatasetHandler>();
            services.AddScoped<IGetDatasetsNamesByUsernameHandler, GetDatasetsNamesByUsernameHandler>();
        }
    }
}
