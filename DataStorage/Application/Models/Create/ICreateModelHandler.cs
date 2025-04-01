using Application.Results;

namespace Application.Models.Create
{
    public interface ICreateModelHandler
    {
        Result Handle( CreateModelCommand command );
    }
}
