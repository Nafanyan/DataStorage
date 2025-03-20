using Application.Common;

namespace Infrastructure.Services
{
    public class ModelService : IModelService
    {
        public void Create( string username, byte[] model )
        {
            throw new NotImplementedException();
        }

        public List<string> GetNamesByUsername( string username )
        {
            throw new NotImplementedException();
        }

        public byte[] Get( string username, string modelName )
        {
            throw new NotImplementedException();
        }

        public void Delete( string username, string modelName )
        {
            throw new NotImplementedException();
        }
    }
}
