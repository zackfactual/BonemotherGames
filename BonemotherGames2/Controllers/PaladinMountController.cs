using System.Linq;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaladinMountController : ControllerBase
    {
        [HttpGet("{paladinMountLookupId}")]
        public string Get(int paladinMountLookupId)
        {
            PaladinMount paladinMount = new PaladinMount();
            using (var ctx = new BonemotherGamesContext())
            {
                var paladinMountLookup = ctx.PaladinMountLookup.Where(x => x.PaladinMountLookupId == paladinMountLookupId).First();
                paladinMount.MountType = paladinMountLookup.PaladinMountName;
            }
            var json = JsonConvert.SerializeObject(paladinMount, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}