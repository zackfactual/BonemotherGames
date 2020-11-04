using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BonemotherGames2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FollowerChartController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var followerChart = ctx.FollowerChart.ToList();
                return JsonSerializer.Serialize(followerChart);
            }
        }

        [HttpGet("{leaderClassId}")]
        public IEnumerable<FollowerChart> Get(int leaderClassId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var followerMaps = ctx.FollowerSourceFollowerChart.Where(x => x.LeaderClassId == leaderClassId).ToList();
                var followerCharts = new List<FollowerChart>();
                foreach (var followerMap in followerMaps)
                {
                    var follower = ctx.FollowerChart.Where(x => x.FollowerChartId == followerMap.FollowerChartId).First();
                    followerCharts.Add(follower);
                }
                return followerCharts;
            }
        }
    }
}