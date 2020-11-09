using System.Linq;
using System.Text.Json;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlignmentController : ControllerBase
    {
        [HttpGet()]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var alignments = ctx.Alignment.ToList();
                return JsonSerializer.Serialize(alignments);
            }
        }
    }
}