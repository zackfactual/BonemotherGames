using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        [HttpGet("{ancestryId}")]
        public string Get(int ancestryId) 
        {
            var json = JsonConvert.SerializeObject(CharacterNameGenerator.GetRandomAncestralName(ancestryId, null), new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{ancestryId}/{subancestryId}")]
        public string Get(int ancestryId, int subancestryId)
        {
            var json = JsonConvert.SerializeObject(CharacterNameGenerator.GetRandomAncestralName(ancestryId, subancestryId), new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}