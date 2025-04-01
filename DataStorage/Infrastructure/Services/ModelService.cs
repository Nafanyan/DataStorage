using Application.Common;
using Infrastructure.Configurations;

namespace Infrastructure.Services
{
    public class ModelService : IModelService
    {
        private readonly string _modelsPath;
        private readonly FileService _fileService;

        public ModelService( IStorageConfiguration configuration )
        {
            _modelsPath = configuration.ModelsPath;
            _fileService = new FileService();
        }

        public void Create( string username, byte[] model )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_modelsPath}/{username}" );

            _fileService.Create( fullPath, model );
        }

        public List<string> GetNamesByUsername( string username )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_modelsPath}/{username}" );

            return _fileService.GetNamesByUsername( fullPath );
        }

        public byte[] Get( string username, string modelName )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_modelsPath}/{username}/{modelName}" );

            return _fileService.Get( fullPath );
        }

        public void Delete( string username, string modelName )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{_modelsPath}/{username}/{modelName}" );

            _fileService.Delete( fullPath );
        }
    }
}
