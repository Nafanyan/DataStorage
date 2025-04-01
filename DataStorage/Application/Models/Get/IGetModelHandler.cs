using Application.Results;

namespace Application.Models.Get
{
    public interface IGetModelHandler
    {
        ResultT<byte[]> Handle( GetModelQuery query );
    }
}
