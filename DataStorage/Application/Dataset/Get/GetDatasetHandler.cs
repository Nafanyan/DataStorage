using Application.Common;
using Application.Results;

namespace Application.Dataset.Get
{
    public class GetDatasetHandler : IGetDatasetHandler
    {
        private readonly IDatasetService _datasetService;

        public GetDatasetHandler( IDatasetService datasetService )
        {
            _datasetService = datasetService;
        }

        public ResultT<byte[]> Handle( GetDatasetQuery query )
        {
            try
            {
                byte[] dataset = _datasetService.Get( query.Username, query.DatasetName );

                return ResultT<byte[]>.Success( dataset );
            }
            catch ( Exception e )
            {
                return ResultT<byte[]>.Error( new List<Error>
                {
                    new Error(e.Message)
                } );
            }
        }
    }
}
