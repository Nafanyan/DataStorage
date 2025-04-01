using Application.Results;

namespace Application.Models.Delete
{
    public interface IDeleteModelHandler
    {
        public Result Handle( DeleteModelCommand command );
    }
}
