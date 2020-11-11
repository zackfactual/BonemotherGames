using System.Linq;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllyController : ControllerBase
    {
        [HttpGet("{allyLookupId}")]
        public string Get(int allyLookupId)
        {
            Ally ally = new Ally();
            using (var ctx = new BonemotherGamesContext())
            {
                var allyLookup = ctx.AllyLookup.Where(x => x.AllyLookupId == allyLookupId).First();
                ally.Name = allyLookup.AllyLookupName;
                ally.IsUnit = allyLookup.IsUnit;
            }
            var json = JsonConvert.SerializeObject(ally, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}