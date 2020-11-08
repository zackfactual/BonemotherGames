using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return JsonSerializer.Serialize(paladinMount);
        }
    }
}