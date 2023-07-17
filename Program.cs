using MongoDBex;

var restaurantDB = new RestaurantDb();

//*Get By Score
var restaurantByScore = restaurantDB.GetByScore(30, mode: Mode.Gt);
foreach (var aboveScore in restaurantByScore)
{
    Console.Write(aboveScore.Name + " => ");
    foreach (var score in aboveScore.Grades)
    {
        Console.Write(score.Score + " | ");
    }
    Console.WriteLine();
}

////*Get By Name*
//var restaurantByName = restaurantDB.GetByName("Updated Restaurant");
//Console.WriteLine(restaurantByName.ToJson());


////*Insert Restaurant
//Restaurants restaurant = new Restaurants
//{
//    Address = new Address
//    {
//        Building = "building",
//        Coord = new double[] { 1, 2 },
//        Street = "street",
//        ZipCode = "zipcode"
//    },
//    Borough = "borough",
//    Cuisine = "cuisine",
//    Grades = new Grades[]
//    {
//        new Grades
//        {
//            Date = new DateTime().ToLocalTime(),
//            Grade="S",
//            Score = 10
//        },
//        new Grades
//        {
//            Date = new DateTime().ToLocalTime(),
//            Grade="SS",
//            Score = 30
//        }
//    },
//    Id = ObjectId.GenerateNewId(),
//    Name = "New Restaurant",
//    RestaurantId = Guid.NewGuid().ToString(),
//};
//restaurantDB.InsertRestaurant(restaurant);
//Console.WriteLine("Added");

//*Update Restaurant
//var updatedRestaurant = restaurantDB.UpdateRestaurant("New Restaurant", "Updated Restaurant");
//Console.WriteLine(updatedRestaurant.IsAcknowledged);
//Console.WriteLine(updatedRestaurant.MatchedCount);
//Console.WriteLine(updatedRestaurant.ModifiedCount);

//*Delete Restaurant
//var result = restaurantDB.DeleteRestaurant("Updated Restaurant");
//Console.WriteLine(result.IsAcknowledged);
//Console.WriteLine(result.DeletedCount);
