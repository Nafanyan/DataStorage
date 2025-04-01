using Application.Common;
using Infrastructure.Configurations;

namespace Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        private readonly string _datasetsPath;
        private readonly FileService _fileService;

        public DatasetService( IStorageConfiguration configuration )
        {
            _datasetsPath = configuration.DatasetsPath;
            _fileService = new FileService();
        }

        public void Create( string username, byte[] dataset )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_datasetsPath}/{username}" );

            _fileService.Create( fullPath, dataset );
        }

        public List<string> GetNamesByUsername( string username )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_datasetsPath}/{username}" );

            return _fileService.GetNamesByUsername( fullPath );
        }

        public byte[] Get( string username, string datasetName )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_datasetsPath}/{username}/{datasetName}" );

            return _fileService.Get( fullPath );
        }

        public void Delete( string username, string datasetName )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_datasetsPath}/{username}/{datasetName}" );

            _fileService.Delete( fullPath );
        }
    }
}

