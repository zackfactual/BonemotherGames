using System.Linq;
using System.Text.Json;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;

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
                return JsonSerializer.Serialize(ancestries);
            }
        }
    }
}