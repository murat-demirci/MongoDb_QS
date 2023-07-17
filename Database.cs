using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDBex.Models;

namespace MongoDBex
{
    public class Database
    {
        //private static IMongoCollection<Restaurants> _restaurantsCollection;
        private static readonly string mongodDbConnectionString = Environment.GetEnvironmentVariable("MONGODB", EnvironmentVariableTarget.Machine);

        public static IMongoCollection<Restaurants> RestaurantsSetup()
        {
            var camelCaseConvension = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvension, type => true);

            var client = new MongoClient(connectionString: mongodDbConnectionString);

            var restaurantsDatabase = client.GetDatabase("sample_restaurants");
            //_restaurantsCollection = restaurantsDatabase.GetCollection<Restaurants>("restaurants");
            return restaurantsDatabase.GetCollection<Restaurants>("restaurants");
        }
    }
}
