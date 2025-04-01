using Application.Results;

namespace Application.Dataset.Get
{
    public interface IGetDatasetHandler
    {
        ResultT<byte[]> Handle( GetDatasetQuery query );
    }
}
