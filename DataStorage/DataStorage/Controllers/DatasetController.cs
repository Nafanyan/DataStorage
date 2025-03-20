using Application.Dataset.Create;
using Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace DataStorage.Controllers;

[ApiController]
[Route( "[controller]" )]
public class DatasetController : ControllerBase
{
    private readonly ILogger<DatasetController> _logger;
    private readonly ICreateDatasetHandler _createDatasetHandler;

    public DatasetController(
        ICreateDatasetHandler createDatasetHandler,
        ILogger<DatasetController> logger )
    {
        _createDatasetHandler = createDatasetHandler;
        _logger = logger;
    }

    [HttpPost( "create-zip" )]
    public IActionResult UploadDatasetZip( string username, IFormFile file )
    {
        if ( file == null || file.Length == 0 )
            return BadRequest( "Файл не был предоставлен." );

        if ( !file.FileName.EndsWith( ".zip" ) )
            return BadRequest( "Файл должен быть в формате .zip." );

        try
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo( memoryStream );
            byte[] zipBytes = memoryStream.ToArray(); // Преобразование файла в массив байтов

            CreateDatasetCommand command = new CreateDatasetCommand
            {
                Username = username,
                DatasetZip = zipBytes
            };
            Result result = _createDatasetHandler.Handle( command );

            if ( result.IsSuccess )
            {
                return Ok( "Архив успешно принят и разобран." );
            }

            return BadRequest();
        }
        catch ( Exception ex )
        {
            return StatusCode( StatusCodes.Status500InternalServerError, $"Ошибка обработки файла: {ex.Message}" );
        }
    }
}

