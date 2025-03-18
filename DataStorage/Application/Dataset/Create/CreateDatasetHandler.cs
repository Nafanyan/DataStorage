using Application.Common;
using Application.Results;

namespace Application.Dataset.Create
{
    public class CreateDatasetHandler : ICreateDatasetHandler
    {
        private readonly IDatasetService _datasetService;

        public CreateDatasetHandler( IDatasetService datasetService )
        {
            _datasetService = datasetService;
        }

        public Result Handle( CreateDatasetCommand command )
        {
            try
            {
                _datasetService.CreateDataset( command.Username, command.DatasetZip );

                return Result.Success();
            }
            catch ( Exception e )
            {
                return Result.Error( new List<Error>
                {
                    new Error(e.Message)
                } ); ;
            }
        }
    }
}

