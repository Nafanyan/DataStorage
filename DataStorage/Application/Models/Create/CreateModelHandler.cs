using Application.Common;
using Application.Results;

namespace Application.Models.Create
{
    internal class CreateModelHandler : ICreateModelHandler
    {
        private readonly IModelService _modelsService;

        public CreateModelHandler( IModelService modelsService )
        {
            _modelsService = modelsService;
        }

        public Result Handle( CreateModelCommand command )
        {
            try
            {
                _modelsService.Create( command.Username, command.ModelZip );

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
