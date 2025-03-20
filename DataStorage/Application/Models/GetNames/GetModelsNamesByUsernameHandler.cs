using Application.Common;
using Application.Results;

namespace Application.Models.GetNames
{
    public class GetModelsNamesByUsernameHandler : IGetModelsNamesByUsernameHandler
    {
        private readonly IModelService _modelsService;

        public GetModelsNamesByUsernameHandler( IModelService modelsService )
        {
            _modelsService = modelsService;
        }

        public ResultT<List<string>> Handle( GetModelsNamesByUsernameQuery query )
        {
            try
            {
                List<string> datasetNames = _modelsService.GetNamesByUsername( query.Username );

                return ResultT<List<string>>.Success( datasetNames );
            }
            catch ( Exception e )
            {
                return ResultT<List<string>>.Error( new List<Error>
                {
                    new Error(e.Message)
                } );
            }
        }
    }
}
