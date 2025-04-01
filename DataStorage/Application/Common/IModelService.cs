namespace Application.Common
{
    public interface IModelService
    {
        void Create( string username, byte[] model );

        List<string> GetNamesByUsername( string username );

        byte[] Get( string username, string modelName );

        void Delete( string username, string modelName );
    }
}
