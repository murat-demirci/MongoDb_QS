using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBex.Models
{
    public class Restaurants
    {
        public ObjectId Id { get; set; }
        public Address Address { get; set; }
        public string Borough { get; set; }
        public string Cuisine { get; set; }
        public Grades[] Grades { get; set; }
        public string Name { get; set; }
        [BsonElement("restaurant_id")]
        public string RestaurantId { get; set; }
    }
}
