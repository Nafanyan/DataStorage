using System.IO.Compression;
using Application.Common;

namespace Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        public void Create( string username, byte[] dataset )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{Constants.StoragePath}/{username}" );

            using ( var memoryStream = new MemoryStream( dataset ) )
            {
                using ( var archive = new ZipArchive( memoryStream ) )
                {
                    archive.ExtractToDirectory( fullPath );
                }
            }
        }

        public byte[] Get( string username, string datasetName )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{Constants.StoragePath}/{username}" );
            byte[] byteArray;

            if ( !Directory.Exists( fullPath ) )
            {
                throw new Exception( "Такого датасета не существует" );
            }

            using ( var memoryStream = new MemoryStream() )
            {
                using ( var archive = new ZipArchive( memoryStream, ZipArchiveMode.Create, true ) )
                {
                    foreach ( string filePath in Directory.GetFiles( fullPath, "*", SearchOption.AllDirectories ) )
                    {
                        string entryName = Path.GetRelativePath( fullPath, filePath );
                        archive.CreateEntryFromFile( filePath, entryName );
                    }
                }
                byteArray = memoryStream.ToArray();
            }

            return byteArray;
        }

        public List<string> GetNamesByUsername( string username )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{Constants.StoragePath}/{username}" );

            if ( !Directory.Exists( fullPath ) )
            {
                return new List<string>();
            }

            string[] directories = Directory.GetDirectories( fullPath );

            return directories.Select(d => Path.GetFileName( d ) ).ToList();
        }

        public void Delete( string username, string datasetName )
        {
            string fullPath = Path.Combine( Directory.GetCurrentDirectory(), $"{Constants.StoragePath}/{username}/{datasetName}");

            if ( Directory.Exists( fullPath ) )
            {
                Directory.Delete( fullPath, true );
            }
            else
            {
                throw new Exception("Такого датасета не существует");
            }
        }
    }
}

