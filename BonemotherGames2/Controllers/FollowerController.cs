using System.Collections.Generic;
using System.Linq;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var followerSources = ctx.FollowerSource.ToList();
                var json = JsonConvert.SerializeObject(followerSources, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
        }


        [HttpGet("{leaderClassId}")]
        public string Get(int leaderClassId)
        {
            List<Follower> followers = new List<Follower>();
            using (var ctx = new BonemotherGamesContext())
            {
                var followerSourceFollowerCharts = ctx.FollowerSourceFollowerChart.Where(x => x.LeaderClassId == leaderClassId).ToList();
                foreach (var followerSourceFollowerChart in followerSourceFollowerCharts)
                {
                    var follower = new Follower();
                    follower.ConstructFollowerFromLeaderClassId(follower, followerSourceFollowerChart);
                    followers.Add(follower);
                }
                var json = JsonConvert.SerializeObject(followers, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
        }
    }
}