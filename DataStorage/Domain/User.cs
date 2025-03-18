namespace Domain
{
    public class User
    {
        public string Username { get; }

        public List<string> DatasetsNames { get; }

        public List<string> ModelsNames { get; }

        public User( string username, List<string> datasetsNames, List<string> modelsNames )
        {
            Username = username;
            DatasetsNames = datasetsNames;
            ModelsNames = modelsNames;
        }
    }
}

