namespace Application.Dataset.Create
{
    public class CreateDatasetCommand
    {
        public string Username { get; init; }

        public byte[] DatasetZip { get; init; }
    }
}

