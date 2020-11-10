using System.Linq;
using System.Text.Json;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;

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
                return JsonSerializer.Serialize(subancestries);
            }
        }
    }
}