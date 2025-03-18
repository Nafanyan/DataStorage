namespace Application.Common
{
    public interface IDatasetService
    {
        void CreateDataset( string username, byte[] dataset );

        List<string> GetNamesByUser( string username );

        byte[] Get( string username, string datasetName );
    }
}

