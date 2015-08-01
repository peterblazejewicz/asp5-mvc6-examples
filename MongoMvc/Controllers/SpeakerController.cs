using Microsoft.AspNet.Mvc;
using MongoDB.Bson;
using MongoMvc.Models;
using MongoMvc.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoMvc.Controllers
{
    [Route("api/[controller]")]
    public class SpeakerController : Controller
    {

        readonly ISpeakerRespository _speakerRepository;

        public SpeakerController(ISpeakerRespository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Speaker>> GetAll()
        {
            var speakers = await _speakerRepository.AllSpeakers();
            return speakers;
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdRoute")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _speakerRepository.GetById(new ObjectId(id));
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public async Task CreateSpeaker([FromBody] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                await _speakerRepository.Add(speaker);
                string url = Url.RouteUrl("GetByIdRoute", new { id = speaker.Id.ToString() }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteSpeaker(string id)
        {
            var removed = await _speakerRepository.Remove(new ObjectId(id));
            if (removed)
            {
                return new HttpStatusCodeResult(204);// 204 No Content
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
