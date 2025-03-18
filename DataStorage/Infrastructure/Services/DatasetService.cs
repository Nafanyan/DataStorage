using System.IO.Compression;
using Application.Common;

namespace Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        public DatasetService()
        {
        }

        public void CreateDataset( string username, byte[] dataset )
        {
            using var ms = new MemoryStream( dataset );
            using var archive = new ZipArchive( ms, ZipArchiveMode.Read );

            foreach ( var entry in archive.Entries )
            {
                if ( entry.FullName.EndsWith( "/" ) ) continue; // Пропускаем директории

                var fullPath = Path.Combine( username, entry.FullName );
                Directory.CreateDirectory( Path.GetDirectoryName( fullPath ) ); // Создаем нужные директории

                using var stream = entry.Open();
                using var fileStream = new FileStream( fullPath, FileMode.Create );
                stream.CopyTo( fileStream );
            }
        }

        public byte[] Get( string username, string datasetName )
        {
            throw new NotImplementedException();
        }

        public List<string> GetNamesByUser( string username )
        {
            throw new NotImplementedException();
        }
    }
}

