using BonemotherGames.Services;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace BonemotherGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetainerController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var retainerClasses = ctx.RetainerClass.ToList();
                var json = JsonConvert.SerializeObject(retainerClasses, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
        }

        [HttpGet("{retainerClassId}")]
        public string Get(int retainerClassId)
        {
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRetainerClass(retainerClassId);
            retainer.ConstructRetainer(retainer, null, null);

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
            retainer.ConstructRetainer(retainer, ancestryId, null);

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
            retainer.ConstructRetainer(retainer, null, null);

            var json = JsonConvert.SerializeObject(retainer, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}