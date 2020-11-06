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
    public class FollowerController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var followerSources = ctx.FollowerSource.ToList();
                return JsonSerializer.Serialize(followerSources);
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
                return JsonSerializer.Serialize(followers);
            }
        }
    }
}