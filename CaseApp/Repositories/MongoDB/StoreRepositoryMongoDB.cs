using CaseApp.Klasser;
using MongoDB.Driver;
using CaseApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseApp.Repositories.MongoDB
{
    public class StoreRepositoryMongoDB : IStoreRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoCollection<Store> storeCollection;

        public StoreRepositoryMongoDB()
        {
            var mongoUri = "mongodb+srv://Bromus:Bromus12344321@cluster0.k4kon.mongodb.net/";
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
            var collectionName = "store"; // <- MongoDB collection name

            storeCollection = client.GetDatabase(dbName)
                .GetCollection<Store>(collectionName);
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await storeCollection.Find(Builders<Store>.Filter.Empty).ToListAsync();
        }

        public async Task<Store> GetById(int id)
        {
            var filter = Builders<Store>.Filter.Eq(s => s.Id, id);
            return await storeCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddStore(Store store)
        {
            int maxId = 0;
            var existingStores = await GetStores();
            if (existingStores.Any())
            {
                maxId = existingStores.Max(s => s.Id);
            }

            store.Id = maxId + 1;
            await storeCollection.InsertOneAsync(store);
        }

        public async Task UpdateStore(Store store)
        {
            var filter = Builders<Store>.Filter.Eq(s => s.Id, store.Id);
            await storeCollection.ReplaceOneAsync(filter, store);
        }

        public async Task DeleteStore(int id)
        {
            var filter = Builders<Store>.Filter.Eq(s => s.Id, id);
            await storeCollection.DeleteOneAsync(filter);
        }
    }
}
