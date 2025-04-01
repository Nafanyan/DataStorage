using Application.Common;
using Application.Results;

namespace Application.Models.Delete
{
    public class DeleteModelHandler : IDeleteModelHandler
    {
        private readonly IModelService _modelsService;

        public DeleteModelHandler( IModelService modelsService )
        {
            _modelsService = modelsService;
        }

        public Result Handle( DeleteModelCommand command )
        {
            try
            {
                _modelsService.Delete( command.Username, command.ModelName );

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
