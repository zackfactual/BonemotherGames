using BonemotherGames.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetainerController : ControllerBase
    {
        [HttpGet("{retainerClassId}")]
        public string Get(int retainerClassId)
        {
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRetainerClass(retainerClassId);
            retainer.ConstructRetainer(retainer);

            var json = JsonConvert.SerializeObject(retainer, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{retainerClassId}/{ancestryId}")]
        public string Get(int retainerClassId, int ancestryId)
        {
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRetainerClass(retainerClassId);
            retainer.ConstructRetainerWithAncestry(retainer, ancestryId);

            var json = JsonConvert.SerializeObject(retainer, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{retainerClassId}/{ancestryId}/{subancestryId}")]
        public string Get(int retainerClassId, int ancestryId, int subancestryId)
        { 
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRetainerClass(retainerClassId);
            retainer.ConstructRetainerWithSubancestry(retainer, ancestryId, subancestryId);

            var json = JsonConvert.SerializeObject(retainer, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}