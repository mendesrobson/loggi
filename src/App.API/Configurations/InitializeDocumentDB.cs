using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace App.API.Configurations
{
    public static class InitializeDocumentDB
    {
        private static string _DATABASE => Environment.GetEnvironmentVariable("MONOGODB_DATABASE");
        private static string _COLLECTION_FILE => Environment.GetEnvironmentVariable("MONOGODB_COLLECTION_FILE");

        public static void InitializeMongoDB(this IServiceCollection services)
        {
            var connectionFormat = Environment.GetEnvironmentVariable("MONGODB_FORMAT_CONNECT");
            var user = Environment.GetEnvironmentVariable("MONGODB_USER");
            var pass = Environment.GetEnvironmentVariable("MONGODB_PASS");
            var host = Environment.GetEnvironmentVariable("MONGODB_HOST");

            Console.WriteLine("Open Connection MongoDB Start");

            var connectionString = $"{connectionFormat}://{user}:{pass}@{host}";
            var client = new MongoClient(connectionString);


            CreateDatabaseIfNotExists(client);
            CreateCollectionIfNotExists(client);

            var db = client.GetDatabase(_DATABASE);

            services.AddSingleton<IMongoClient>(client);
            services.AddSingleton<IMongoDatabase>(db);
        }

        private static void CreateDatabaseIfNotExists(MongoClient client)
        {
            try
            {
                if (!DatabaseExists(client))
                {
                    client.GetDatabase(_DATABASE);
                }
            }
            catch (MongoClientException)
            {
                client.GetDatabase(_DATABASE);
            }
        }
        private static bool DatabaseExists(MongoClient client)
        {
            var dbList = client.ListDatabases()
                            .ToList()
                            .Select(db => db.GetValue("name").AsString);

            return dbList.Contains(_DATABASE);
        }

        private static void CreateCollectionIfNotExists(MongoClient Client)
        {
            IMongoDatabase db = Client.GetDatabase(_DATABASE);

            try
            {

                bool exist = CollectionExists(_COLLECTION_FILE, db);

                if (!exist)
                {
                    db.CreateCollection(_COLLECTION_FILE);
                }
            }
            catch (MongoClientException)
            {
                db.CreateCollection(_COLLECTION_FILE);
            }
        }

        private static bool CollectionExists(string collectionName, IMongoDatabase db)
        {
            var filter = new BsonDocument("name", collectionName);
            //filter by collection name
            var collections = db.ListCollections(new ListCollectionsOptions { Filter = filter });
            //check for existence
            return collections.Any();
        }
    }
}
