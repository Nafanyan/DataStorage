using Infrastructure.Configurations;

namespace DataStorage.ConfigurationBindings
{
    public static class StorageConfigurationBindings
    {
        private const string DatasetsPathKey = "StorageConfiguration:DatasetsPath";
        private const string ModelssPathKey = "StorageConfiguration:ModelsPath";


        public static void AddStorageConfigurationBindings( this IServiceCollection services, IConfiguration configuration )
        {
            var storageConfiguration = new StorageConfiguration(
                configuration[ DatasetsPathKey ],
                configuration[ ModelssPathKey ] );

            services.AddSingleton<IStorageConfiguration>( storageConfiguration );
        }
    }
}

