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
            List<Follower> followers = new List<Follower>();
            using (var ctx = new BonemotherGamesContext())
            {
                var followerCharts = ctx.FollowerChart.ToList();
                foreach (var followerChart in followerCharts)
                {
                    var follower = new Follower();
                    follower.ConstructFollowerFromFollowerChart(follower, followerChart);
                    followers.Add(follower);
                }
            }
            return JsonSerializer.Serialize(followers);
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