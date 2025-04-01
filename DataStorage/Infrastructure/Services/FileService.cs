using System.IO.Compression;

namespace Infrastructure.Services
{
	public class FileService
	{
        public void Create( string fullPath, byte[] file )
        {
            using ( var memoryStream = new MemoryStream( file ) )
            {
                using ( var archive = new ZipArchive( memoryStream ) )
                {
                    archive.ExtractToDirectory( fullPath );
                }
            }
        }

        public List<string> GetNamesByUsername( string fullPath )
        {
            if ( !Directory.Exists( fullPath ) )
            {
                return new List<string>();
            }

            string[] directories = Directory.GetDirectories( fullPath );

            return directories.Select( d => Path.GetFileName( d ) ).ToList();
        }

        public byte[] Get( string fullPath )
        {
            byte[] byteArray;

            if ( !Directory.Exists( fullPath ) )
            {
                throw new Exception( "Такого файла не существует" );
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

        public void Delete( string fullPath )
        {
            if ( Directory.Exists( fullPath ) )
            {
                Directory.Delete( fullPath, true );
            }
            else
            {
                throw new Exception( "Такого файла не существует" );
            }
        }
    }
}

