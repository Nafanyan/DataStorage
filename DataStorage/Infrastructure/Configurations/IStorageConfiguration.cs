namespace Infrastructure.Configurations
{
    public interface IStorageConfiguration
    {
        string DatasetsPath { get; set; }

        string ModelsPath { get; set; }
    }
}

