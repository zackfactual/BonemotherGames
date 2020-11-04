using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class AllyLookup
    {
        public AllyLookup()
        {
            FollowerChart = new HashSet<FollowerChart>();
        }

        public int AllyLookupId { get; set; }
        public string AllyLookupName { get; set; }
        public string OutsideLink { get; set; }
        public bool IsUnit { get; set; }

        public virtual ICollection<FollowerChart> FollowerChart { get; set; }
    }
}
