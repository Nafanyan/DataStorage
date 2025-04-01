using Application.Dataset.Create;
using Application.Dataset.Delete;
using Application.Dataset.Get;
using Application.Dataset.GetNames;
using Microsoft.AspNetCore.Mvc;

namespace DataStorage.Controllers;

[ApiController]
[Route( "[controller]" )]
public class DatasetController : ControllerBase
{
    private readonly ILogger<DatasetController> _logger;
    private readonly ICreateDatasetHandler _createDatasetHandler;
    private readonly IGetDatasetsNamesByUsernameHandler _getDatasetsNamesByUsernameHandler;
    private readonly IGetDatasetHandler _getDatasetHandler;
    private readonly IDeleteDatasetHandler _deleteDatasetHandler;

    public DatasetController(
        ICreateDatasetHandler createDatasetHandler,
        IGetDatasetsNamesByUsernameHandler getDatasetsNamesByUsernameHandler,
        IGetDatasetHandler getDatasetHandler,
        IDeleteDatasetHandler deleteDatasetHandler,
        ILogger<DatasetController> logger )
    {
        _createDatasetHandler = createDatasetHandler;
        _getDatasetsNamesByUsernameHandler = getDatasetsNamesByUsernameHandler;
        _getDatasetHandler = getDatasetHandler;
        _deleteDatasetHandler = deleteDatasetHandler;
        _logger = logger;
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

        var command = new CreateDatasetCommand
        {
            Username = username,
            DatasetZip = zipBytes
        };
        var result = _createDatasetHandler.Handle( command );

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

        var query = new GetDatasetsNamesByUsernameQuery
        {
            Username = username
        };

        var result = _getDatasetsNamesByUsernameHandler.Handle( query );

        if ( result.IsSuccess )
        {
            return Ok( result.Value );
        }

        return BadRequest( result.Errors );
    }

    [HttpGet( "{username}/datasetName" )]
    public IActionResult Get( string username, string datasetName )
    {
        if ( username is null || datasetName is null )
        {
            return BadRequest();
        }

        var query = new GetDatasetQuery
        {
            Username = username,
            DatasetName = datasetName
        };
        var result = _getDatasetHandler.Handle( query );

        if ( result.IsSuccess )
        {
            return File( result.Value, "application/zip", datasetName );
        }

        return BadRequest( result.Errors );
    }

    [HttpDelete( "{username}/datasetName" )]
    public IActionResult DeleteDataset( string username, string datasetName )
    {
        if ( username is null || datasetName is null )
        {
            return BadRequest();
        }

        var command = new DeleteDatasetCommand
        {
            Username = username,
            DatasetName = datasetName
        };
        var result = _deleteDatasetHandler.Handle( command );

        if ( result.IsSuccess )
        {
            return Ok();
        }

        return BadRequest( result.Errors );
    }
}

