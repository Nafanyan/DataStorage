using Application.Common;
using Application.Results;

namespace Application.Dataset.GetNames
{
    public class GetDatasetsNamesByUsernameHandler : IGetDatasetsNamesByUsernameHandler
    {
        private readonly IDatasetService _datasetService;

        public GetDatasetsNamesByUsernameHandler( IDatasetService datasetService )
        {
            _datasetService = datasetService;
        }

        public ResultT<List<string>> Handle( GetDatasetsNamesByUsernameQuery query )
        {
            try
            {
                List<string> datasetNames = _datasetService.GetNamesByUsername( query.Username );

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
