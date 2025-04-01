using Application.Models.Create;
using Application.Models.Delete;
using Application.Models.Get;
using Application.Models.GetNames;
using Microsoft.AspNetCore.Mvc;

namespace DataStorage.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class ModelController : ControllerBase
    {
        private readonly ICreateModelHandler _createModelHandler;
        private readonly IDeleteModelHandler _deleteModelHandler;
        private readonly IGetModelHandler _getModelHandler;
        private readonly IGetModelsNamesByUsernameHandler _getModelsNamesByUsernameHandler;

        public ModelController(
            ICreateModelHandler createModelHandler,
            IDeleteModelHandler deleteModelHandler,
            IGetModelHandler getModelHandler,
            IGetModelsNamesByUsernameHandler getModelsNamesByUsernameHandler )
        {
            _createModelHandler = createModelHandler;
            _deleteModelHandler = deleteModelHandler;
            _getModelHandler = getModelHandler;
            _getModelsNamesByUsernameHandler = getModelsNamesByUsernameHandler;
        }

        [HttpPost( "create-zip" )]
        public IActionResult UploadDatasetZip( string username, IFormFile file )
        {
            if ( file == null || file.Length == 0 )
                return BadRequest( "Файл не был предоставлен." );

            if ( !file.FileName.EndsWith( ".zip" ) )
                return BadRequest( "Файл должен быть в формате .zip." );

            using var memoryStream = new MemoryStream();
            file.CopyTo( memoryStream );
            byte[] zipBytes = memoryStream.ToArray(); // Преобразование файла в массив байтов

            var command = new CreateModelCommand
            {
                Username = username,
                ModelZip = zipBytes
            };
            var result = _createModelHandler.Handle( command );

            if ( result.IsSuccess )
            {
                return Ok( "Архив успешно принят и разобран." );
            }

            return BadRequest( result.Errors );
        }

        [HttpGet( "{username}/names" )]
        public IActionResult GetDatasetNames( string username )
        {
            if ( username is null )
            {
                return BadRequest();
            }

            var query = new GetModelsNamesByUsernameQuery
            {
                Username = username
            };
            var result = _getModelsNamesByUsernameHandler.Handle( query );

            if ( result.IsSuccess )
            {
                return Ok( result.Value );
            }

            return BadRequest( result.Errors );
        }

        [HttpGet( "{username}/modelName" )]
        public IActionResult Get( string username, string modelName )
        {
            if ( username is null || modelName is null )
            {
                return BadRequest();
            }

            var query = new GetModelQuery
            {
                Username = username,
                ModelName = modelName
            };
            var result = _getModelHandler.Handle( query );

            if ( result.IsSuccess )
            {
                return File( result.Value, "application/zip", modelName );
            }

            return BadRequest( result.Errors );
        }

        [HttpDelete( "{username}/modelName" )]
        public IActionResult DeleteDataset( string username, string modelName )
        {
            if ( username is null || modelName is null )
            {
                return BadRequest();
            }

            var command = new DeleteModelCommand
            {
                Username = username,
                ModelName = modelName
            };
            var result = _deleteModelHandler.Handle( command );

            if ( result.IsSuccess )
            {
                return Ok();
            }

            return BadRequest( result.Errors );
        }
    }
}
