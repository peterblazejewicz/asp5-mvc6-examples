using MongoDB.Bson;
using System;

namespace MongoMvc.Models
{
    public class Speaker
    {
        public ObjectId Id { get; set; }
        public string Blog { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Title { get; set; }
        public string Twitter { get; set; }
    }
}
