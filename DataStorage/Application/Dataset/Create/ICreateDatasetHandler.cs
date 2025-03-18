using Application.Results;

namespace Application.Dataset.Create
{
    public interface ICreateDatasetHandler
    {
        Result Handle( CreateDatasetCommand command );
    }
}

