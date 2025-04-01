namespace Infrastructure.Configurations
{
    public class StorageConfiguration : IStorageConfiguration
    {
        public string DatasetsPath { get; set; }
        public string ModelsPath { get; set; }

        public StorageConfiguration( string datasetsPath, string modelsPath )
        {
            DatasetsPath = datasetsPath;
            ModelsPath = modelsPath;
        }
    }
}

