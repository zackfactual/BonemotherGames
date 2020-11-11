using System.Linq;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlignmentController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var alignments = ctx.Alignment.ToList();
                var json = JsonConvert.SerializeObject(alignments, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
        }
    }
}