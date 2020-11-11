using System.Linq;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AmbassadorController : ControllerBase
    {
        [HttpGet("{ambassadorLookupId}")]
        public string Get(int ambassadorLookupId)
        {
            Ambassador ambassador = new Ambassador();
            using (var ctx = new BonemotherGamesContext())
            {
                var ambassadorLookup = ctx.AmbassadorLookup.Where(x => x.AmbassadorLookupId == ambassadorLookupId).First();
                ambassador.AncestryName = ctx.Ancestry.Where(x => x.AncestryId == ambassadorLookup.AncestryId).Select(x => x.AncestryName).First();
                ambassador.Name = CharacterNameGenerator.GetRandomAncestralName(ambassadorLookup.AncestryId, null);
            }
            var json = JsonConvert.SerializeObject(ambassador, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}