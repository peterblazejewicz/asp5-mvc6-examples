using Microsoft.Framework.OptionsModel;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoMvc.Data;
using MongoMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoMvc.Repository
{
    public class SpeakerRepository : ISpeakerRespository
    {
        private Settings _settings;
        private IMongoDatabase _database;

        public SpeakerRepository(IOptions<Settings> settings)
        {
            _settings = settings.Options;
            this._database = Connect();
        }

        public async Task Add(Speaker speaker)
        {
            await _database.GetCollection<Speaker>(_settings.Collection)
                .InsertOneAsync(speaker);
        }

        public async Task<IEnumerable<Speaker>> AllSpeakers()
        {
            var list = await _database.GetCollection<Speaker>(_settings.Collection)
                .Find(x => true)
                .ToListAsync();
            return list;
        }

        public async Task<Speaker> GetById(ObjectId id)
        {
            var filter = Builders<Speaker>.Filter;
            var query = filter.Where(x => x.Id == id);
            var speaker = await _database.GetCollection<Speaker>(_settings.Collection)
                .Find(query)
                .SingleOrDefaultAsync();
            return speaker;
        }

        public async Task<bool> Remove(ObjectId id)
        {
            var filter = Builders<Speaker>.Filter;
            var query = filter.Where(x => x.Id == id);
            var result = await _database.GetCollection<Speaker>(_settings.Collection)
                .DeleteOneAsync(query);
            return (result.DeletedCount == 1);
        }

        public async Task Update(Speaker speaker)
        {
            var filter = Builders<Speaker>.Filter;
            var query = filter.Where(x => x.Id == speaker.Id);
            var results = await _database.GetCollection<Speaker>(_settings.Collection)
                .ReplaceOneAsync(query, speaker);
        }

        private IMongoDatabase Connect()
        {
            var client = new MongoClient(_settings.MongoConnection);
            var database = client.GetDatabase(_settings.Database);
            return database;
        }
    }
}
