using BonemotherGames2.Entities;
using System.Linq;

namespace BonemotherGames2.Services
{
    public class Follower
    {
        public FollowerChart FollowerChart { get; set; }
        public int LeaderClassId { get; set; }
        public int LowRoll { get; set; }
        public int HighRoll { get; set; }

        public Follower()
        {

        }

        public Follower ConstructFollowerFromFollowerChart(Follower follower, FollowerChart followerChart)
        {
            follower.FollowerChart = followerChart;
            using (var ctx = new BonemotherGamesContext())
            {
                var followerSourceFollowerChart = ctx.FollowerSourceFollowerChart.Where(x => x.FollowerChartId == follower.FollowerChart.FollowerChartId).First();
                follower.LeaderClassId = followerSourceFollowerChart.LeaderClassId;
                follower.LowRoll = followerSourceFollowerChart.LowRoll;
                follower.HighRoll = followerSourceFollowerChart.HighRoll;
            }
            return follower;
        }

        public Follower ConstructFollowerFromLeaderClassId(Follower follower, FollowerSourceFollowerChart followerSourceFollowerChart)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                follower.FollowerChart = ctx.FollowerChart.Where(x => x.FollowerChartId == followerSourceFollowerChart.FollowerChartId).First();
                follower.LeaderClassId = followerSourceFollowerChart.LeaderClassId;
                follower.LowRoll = followerSourceFollowerChart.LowRoll;
                follower.HighRoll = followerSourceFollowerChart.HighRoll;
            }
            return follower;
        }
    }
}
