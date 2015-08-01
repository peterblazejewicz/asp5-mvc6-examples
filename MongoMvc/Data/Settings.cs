using System;
using MongoDB.Driver;

namespace MongoMvc.Data
{
    public class Settings
    {
        public string Collection { get; set; }
        public string Database { get; set; }
        public string MongoConnection { get; set; }
    }
}
