using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBex.Models
{
    public class Address
    {
        public string Building { get; set; }
        public double[] Coord { get; set; }
        public string Street { get; set; }
        [BsonElement("zipcode")]
        public string ZipCode { get; set; }
    }
}
