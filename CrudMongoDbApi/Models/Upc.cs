using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMongoDbApi.Models
{
    public class Upc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UpcId {get; set; }
        public int StoreId {get; set; }
         public int Stock {get; set; }

    }
}