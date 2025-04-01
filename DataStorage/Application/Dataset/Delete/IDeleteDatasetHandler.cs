using Application.Results;

namespace Application.Dataset.Delete
{
    public interface IDeleteDatasetHandler
    {
        public Result Handle( DeleteDatasetCommand command ); 
    }
}
