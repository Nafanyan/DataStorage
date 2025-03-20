namespace Application.Common
{
    public interface IDatasetService
    {
        void Create( string username, byte[] dataset );

        List<string> GetNamesByUsername( string username );

        byte[] Get( string username, string datasetName );

        void Delete( string username, string datasetName );
    }
}

