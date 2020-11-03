using System;
using System.Collections.Generic;

namespace BonemotherGames2.Models
{
    public partial class FollowerSource
    {
        public int LeaderClassId { get; set; }
        public string LeaderClassName { get; set; }
        public bool? PlayableClass { get; set; }
    }
}
