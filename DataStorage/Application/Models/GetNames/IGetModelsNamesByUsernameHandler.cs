using Application.Results;

namespace Application.Models.GetNames
{
    public interface IGetModelsNamesByUsernameHandler
    {
        ResultT<List<string>> Handle( GetModelsNamesByUsernameQuery query );
    }
}
