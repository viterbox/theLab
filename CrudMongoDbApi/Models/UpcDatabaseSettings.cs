namespace CrudMongoDbApi.Models
{
    public class UpcDatabaseSettings : IUpcDatabaseSettings
    {
        public string UpcCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUpcDatabaseSettings
    {
        string UpcCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}