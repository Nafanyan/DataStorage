namespace Application.Models.Create
{
    public class CreateModelCommand
    {
        public string Username { get; init; }

        public byte[] ModelZip { get; init; }
    }
}
