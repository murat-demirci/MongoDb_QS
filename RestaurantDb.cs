using MongoDB.Driver;
using MongoDBex.Models;

namespace MongoDBex
{
    public class RestaurantDb
    {
        private IMongoCollection<Restaurants> restaurantsCollection = Database.RestaurantsSetup();
        public IList<Restaurants> GetByScore(int param, Mode mode)
        {
            if (param <= 0) return null;
            switch (mode)
            {
                case Mode.Ls:
                    return restaurantsCollection.AsQueryable()
                    .Where(restaurants => restaurants.Grades.Length > 0 && restaurants.Grades.All(s => s.Score < param)).ToList();
                case Mode.Gt:
                    return restaurantsCollection.AsQueryable()
                    .Where(restaurants => restaurants.Grades.Length > 0 && restaurants.Grades.All(s => s.Score > param)).ToList();
                case Mode.Lseq:
                    return restaurantsCollection.AsQueryable()
                    .Where(restaurants => restaurants.Grades.Length > 0 && restaurants.Grades.All(s => s.Score <= param)).ToList();
                case Mode.Gteq:
                    return restaurantsCollection.AsQueryable()
                    .Where(restaurants => restaurants.Grades.Length > 0 && restaurants.Grades.All(s => s.Score >= param)).ToList(); ;
                default:
                    return null;
            }
        }

        public Restaurants GetByName(string name)
        {
            if (name == null || name.Length <= 0) return null;
            return restaurantsCollection.AsQueryable()
                .Where(restaurant => restaurant.Name.ToUpper() == name.ToUpper()).First();
        }

        public void InsertRestaurant(Restaurants restaurant)
        {
            if (restaurant == null) return;
            restaurantsCollection.InsertOne(restaurant);
        }

        public UpdateResult UpdateRestaurant(string oldValue, string newValue)
        {
            if (oldValue == null || oldValue.Length <= 0 || newValue == null || newValue.Length <= 0) return null;
            var filter = Builders<Restaurants>.Filter.Eq(r => r.Name.ToUpper(), oldValue.ToUpper());
            var update = Builders<Restaurants>.Update.Set(r => r.Name.ToUpper(), newValue.ToUpper());

            return restaurantsCollection.UpdateOne(filter, update);
        }

        public DeleteResult DeleteRestaurant(string name)
        {
            var filter = Builders<Restaurants>.Filter
                .Eq(r => r.Name, name);
            return restaurantsCollection.DeleteOne(filter);
        }
    }

    public enum Mode
    {
        Ls = 11,
        Gt = 21,
        Lseq = 12,
        Gteq = 22
    }
}
