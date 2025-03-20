using Application.Results;

namespace Application.Models.Get
{
    public interface IGetModeltHandler
    {
        ResultT<byte[]> Handle( GetModelQuery query );
    }
}
