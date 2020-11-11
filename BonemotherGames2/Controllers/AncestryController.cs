using System.Linq;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AncestryController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var ancestries = ctx.Ancestry.ToList();
                var json = JsonConvert.SerializeObject(ancestries, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
        }
    }
}