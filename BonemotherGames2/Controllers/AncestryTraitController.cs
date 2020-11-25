using System.Collections.Generic;
using System.Linq;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AncestryTraitController : ControllerBase
    {
        [HttpGet("{ancestryId}")]
        public string Get(int ancestryId)
        {
            List<RetainerTrait> retainerTraits = new List<RetainerTrait>();
            using (var ctx = new BonemotherGamesContext())
            {
                var ancestralRetainerTraits = ctx.AncestryRetainerTrait.Where(x => x.AncestryId == ancestryId);
                foreach (var ancestralRetainerTrait in ancestralRetainerTraits)
                {
                    var trait = ctx.RetainerTrait.Where(x => x.TraitId == ancestralRetainerTrait.TraitId).First();
                    retainerTraits.Add(trait);
                }
            }
            var json = JsonConvert.SerializeObject(retainerTraits, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}