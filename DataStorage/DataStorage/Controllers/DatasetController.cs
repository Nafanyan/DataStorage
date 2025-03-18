using Application.Dataset.Create;
using Microsoft.AspNetCore.Mvc;

namespace DataStorage.Controllers;

[ApiController]
[Route( "[controller]" )]
public class DatasetController : ControllerBase
{
    private readonly ILogger<DatasetController> _logger;

    public DatasetController( ILogger<DatasetController> logger )
    {
        _logger = logger;
    }

    [HttpPost( "upload-zip" )]
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

            var s = new CreateDatasetHandler();

            Unzip( zipBytes ); // Разархивируем и сохраняем файлы

            return Ok( "Архив успешно принят и разобран." );
        }
        catch ( Exception ex )
        {
            return StatusCode( StatusCodes.Status500InternalServerError, $"Ошибка обработки файла: {ex.Message}" );
        }
    }
}

