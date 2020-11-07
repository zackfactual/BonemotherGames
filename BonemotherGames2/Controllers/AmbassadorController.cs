using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AmbassadorController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var ambassador = new Ambassador();
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var ambassadors = ctx.AmbassadorLookup.ToList();
                var randomAmbassador = ambassadors[rand.Next(ambassadors.Count)];
                ambassador.AncestryName = ctx.Ancestry.Where(x => x.AncestryId == randomAmbassador.AncestryId).Select(x => x.AncestryName).First();
                ambassador.Name = CharacterNameGenerator.GetRandomAncestralName(randomAmbassador.AncestryId, null);
            }
            return JsonSerializer.Serialize(ambassador);
        }
        
        //[HttpGet]
        //public string Get()
        //{
        //    List<Ambassador> ambassadors = new List<Ambassador>();
        //    using (var ctx = new BonemotherGamesContext())
        //    {
        //        var ambassadorFollowers = ctx.AmbassadorLookup.ToList();
        //        foreach (var ambassadorFollower in ambassadorFollowers)
        //        {
        //            var ambassador = new Ambassador()
        //            {
        //                AncestryName = ctx.Ancestry.Where(x => x.AncestryId == ambassadorFollower.AncestryId).Select(x => x.AncestryName).First(),
        //                Name = CharacterNameGenerator.GetRandomAncestralName(ambassadorFollower.AncestryId, null)
        //            };
        //            ambassadors.Add(ambassador);
        //        }
        //    }
        //    return JsonSerializer.Serialize(ambassadors);
        //}

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
            return JsonSerializer.Serialize(ambassador);
        }
    }
}