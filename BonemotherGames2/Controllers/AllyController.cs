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