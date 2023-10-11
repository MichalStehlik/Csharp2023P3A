using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS03Mongo.Models
{
    internal class Person
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        [BsonElement("Home")]
        public Address HomeAddress { get; set; }
    }
}
