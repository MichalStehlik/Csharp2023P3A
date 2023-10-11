using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS03Mongo.Models
{
    [BsonIgnoreExtraElements]
    internal class Address
    {
        public ObjectId Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public int? ZipCode { get; set; }
    }
}
