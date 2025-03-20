using Application.Results;

namespace Application.Dataset.GetNames
{
    public interface IGetDatasetsNamesByUsernameHandler
    {
        ResultT<List<string>> Handle( GetDatasetsNamesByUsernameQuery query );
    }
}
 