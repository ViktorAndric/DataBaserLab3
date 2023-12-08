using DatabaserLab3.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DatabaserLab3.Data
{
    public static class MongoCrud
    {
        private static IMongoDatabase db;


        public static void Initialize(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            db = client.GetDatabase("UsersDB");
        }

        public static IMongoCollection<UserModel> QuizCollection => db.GetCollection<UserModel>("Questions");

        public static void AddUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.InsertOne(user);
        }
        public static List<UserModel> GetAllUsers(string table)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.Find(_ => true).ToList();
        }
        public static UserModel GetUserById(string table, Guid Id)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.AsQueryable().ToList().Find(x => x.Id == Id);
        }
        public static void UpdateUser(string table, UserModel question)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.ReplaceOne(x => x.Id == question.Id, question, new ReplaceOptions { IsUpsert = false });
        }
        public static void DeleteUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.DeleteOne(x => x.Id == user.Id);
        }

    }
}
