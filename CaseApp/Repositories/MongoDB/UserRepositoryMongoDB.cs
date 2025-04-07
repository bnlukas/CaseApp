using CaseApp.Klasser;
using MongoDB.Driver;
using CaseApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseApp.Repositories.MongoDB
{
    public class UserRepositoryMongoDB : IUserRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoCollection<User> userCollection;

        public UserRepositoryMongoDB()
        {
            var mongoUri = $"mongodb+srv://Bromus:Bromus12344321@cluster0.k4kon.mongodb.net/";
            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to MongoDB.");
                throw;
            }

            var dbName = "myDatabase";
            var collectionName = "user"; // <- updated here

            userCollection = client.GetDatabase(dbName)
                .GetCollection<User>(collectionName);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await userCollection.Find(Builders<User>.Filter.Empty).ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            return await userCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddUser(User user)
        {
            int maxId = 0;
            var existingUsers = await GetAll();
            if (existingUsers.Any())
            {
                maxId = existingUsers.Max(u => u.Id);
            }

            user.Id = maxId + 1;
            await userCollection.InsertOneAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            await userCollection.DeleteOneAsync(filter);
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await userCollection.ReplaceOneAsync(filter, user);
        }
    }
}
