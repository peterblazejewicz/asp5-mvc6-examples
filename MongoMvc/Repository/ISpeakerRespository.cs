using MongoDB.Bson;
using MongoMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoMvc.Repository
{
    public interface ISpeakerRespository
    {
        Task<IEnumerable<Speaker>> AllSpeakers();

        Task<Speaker> GetById(ObjectId id);

        Task Add(Speaker speaker);

        Task Update(Speaker speaker);

        Task<bool> Remove(ObjectId id);
    }
}
