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
    public class AllyController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var ally = new Ally();
                var rand = new Random();
                var allies = ctx.AllyLookup.ToList();
                var randomAlly = allies[rand.Next(allies.Count)];
                ally.Name = randomAlly.AllyLookupName;
                ally.IsUnit = randomAlly.IsUnit;
                return JsonSerializer.Serialize(ally);
            }
        }

        //[HttpGet]
        //public string Get()
        //{
        //    List<Ally> allies = new List<Ally>();
        //    using (var ctx = new BonemotherGamesContext())
        //    {
        //        var allyLookups = ctx.AllyLookup.ToList();
        //        foreach (var allyLookup in allyLookups)
        //        {
        //            var ally = new Ally()
        //            {
        //                Name = allyLookup.AllyLookupName,
        //                IsUnit = allyLookup.IsUnit
        //            };
        //            allies.Add(ally);
        //        }
        //    }
        //    return JsonSerializer.Serialize(allies);
        //}

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
            return JsonSerializer.Serialize(ally);
        }
    }
}