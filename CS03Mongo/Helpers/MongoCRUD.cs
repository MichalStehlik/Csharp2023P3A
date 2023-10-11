using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS03Mongo.Helpers
{
    internal class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string name)
        {
            Name = name;
            var client = new MongoClient("mongodb://student:Educat1on@10.10.10.160:27017/?authSource=playground");
            _db = client.GetDatabase(name);
        }

        public string Name { get; private set; }

        public void Create<T> (string collectionName, T document)
        {
            var collection = _db.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        public T? Read<T>(string collectionName, string id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            return collection.Find(filter).FirstOrDefault();
        }

        public List<T> List<T>(string collectionName)
        {
            var collection = _db.GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        public void Delete<T> (string collectionName, string id) 
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            collection.DeleteOne(filter);
        }

        public void Upsert<T>(string collectionName, string id, T document)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            var result = collection.ReplaceOne(filter, document, new ReplaceOptions { IsUpsert = true});
        }
    }
}
