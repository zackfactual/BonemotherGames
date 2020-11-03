using System;
using System.Collections.Generic;

namespace BonemotherGames2.Models
{
    public partial class FollowerSourcePaladinMountLookup
    {
        public int LeaderClassId { get; set; }
        public int PaladinMountLookupId { get; set; }
        public int LowRoll { get; set; }
        public int HighRoll { get; set; }

        public virtual FollowerSource LeaderClass { get; set; }
        public virtual PaladinMountLookup PaladinMountLookup { get; set; }
    }
}
