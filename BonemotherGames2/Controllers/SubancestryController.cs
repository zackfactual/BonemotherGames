using System.Linq;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubancestryController : ControllerBase
    {
        [HttpGet("{ancestryId}")]
        public string Get(int ancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var subancestries = ctx.Subancestry.Where(x => x.AncestryId == ancestryId).ToList();
                var json = JsonConvert.SerializeObject(subancestries, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
        }
    }
}