using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class FollowerSourceFollowerChart
    {
        public int LeaderClassId { get; set; }
        public int FollowerChartId { get; set; }
        public int LowRoll { get; set; }
        public int HighRoll { get; set; }

        public virtual FollowerChart FollowerChart { get; set; }
        public virtual FollowerSource LeaderClass { get; set; }
    }
}
