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
        [HttpGet]
        public string Get()
        {
            List<PaladinMount> paladinMounts = new List<PaladinMount>();
            using (var ctx = new BonemotherGamesContext())
            {
                var paladinMountLookups = ctx.PaladinMountLookup.ToList();
                foreach (var paladinMountLookup in paladinMountLookups)
                {
                    var paladinMount = new PaladinMount()
                    {
                        MountType = paladinMountLookup.PaladinMountName
                    };
                    paladinMounts.Add(paladinMount);
                }
            }
            return JsonSerializer.Serialize(paladinMounts);
        }

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