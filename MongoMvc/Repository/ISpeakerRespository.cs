using System.Collections.Generic;
using System.Threading.Tasks;
using MongoMvc.Models;
using MongoDB.Bson;

namespace MongoMvc.Repository
{
    interface ISpeakerRespository
    {
        Task<IEnumerable<Speaker>> AllSpeakers();

        Task<Speaker> GetById(ObjectId id);

        void Add(Speaker speaker);

        void Update(Speaker speaker);

        Task<bool> Remove(ObjectId id);
    }
}
