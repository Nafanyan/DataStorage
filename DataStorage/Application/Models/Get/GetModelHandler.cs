using Application.Common;
using Application.Results;

namespace Application.Models.Get
{
    public class GetModelHandler : IGetModelHandler
    {
        private readonly IModelService _modelsService;

        public GetModelHandler( IModelService modelsService )
        {
            _modelsService = modelsService;
        }

        public ResultT<byte[]> Handle( GetModelQuery query )
        {
            try
            {
                byte[] dataset = _modelsService.Get( query.Username, query.ModelName );

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
