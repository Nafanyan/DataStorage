using Application.Common;
using Application.Results;

namespace Application.Dataset.Delete
{
    public class DeleteDatasetHandler : IDeleteDatasetHandler
    {
        private readonly IDatasetService _datasetService;

        public DeleteDatasetHandler( IDatasetService datasetService )
        {
            _datasetService = datasetService;
        }

        public Result Handle( DeleteDatasetCommand command )
        {
            try
            {
                _datasetService.Delete( command.Username, command.DatasetName );

                return Result.Success();
            }
            catch ( Exception e )
            {
                return Result.Error( new List<Error>
                {
                    new Error(e.Message)
                } );
            }
        }
    }
}
