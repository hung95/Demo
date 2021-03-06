using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Email { get; set; }

        [BsonElement("Name")]
        public string FullName { get; set; }
        public bool HasConfirmed { get; set; }
    }
}
