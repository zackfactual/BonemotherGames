using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class FollowerSourceAllyLookup
    {
        public int LeaderClassId { get; set; }
        public int AllyLookupId { get; set; }
        public int LowRoll { get; set; }
        public int HighRoll { get; set; }

        public virtual AllyLookup AllyLookup { get; set; }
        public virtual FollowerSource LeaderClass { get; set; }
    }
}
