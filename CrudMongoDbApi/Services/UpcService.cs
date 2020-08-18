using CrudMongoDbApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CrudMongoDbApi.Services
{
    public class UpcService
    {
        private readonly IMongoCollection<Upc> _upcs;

        public UpcService(IUpcDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _upcs = database.GetCollection<Upc>(settings.UpcCollectionName);
        }
        public List<Upc> Get() =>
            _upcs.Find(upc => true).ToList();
        public Upc Get(string id) =>
            _upcs.Find<Upc>(upc => upc.Id == id).FirstOrDefault();

        public Upc Create(Upc upc)
        {
            _upcs.InsertOne(upc);
            return upc;
        }

        public void Update(string id, Upc upcIn) =>
            _upcs.ReplaceOne(upc => upc.Id == id, upcIn);

        public void Remove(Upc upcIn) =>
            _upcs.DeleteOne(upc => upc.Id == upcIn.Id);

        public void Remove(string id) => 
            _upcs.DeleteOne(upc => upc.Id == id);
    }
    

}