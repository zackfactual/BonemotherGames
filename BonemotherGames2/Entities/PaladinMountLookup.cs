using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class PaladinMountLookup
    {
        public PaladinMountLookup()
        {
            FollowerChart = new HashSet<FollowerChart>();
        }

        public int PaladinMountLookupId { get; set; }
        public string PaladinMountName { get; set; }
        public string OutsideLink { get; set; }

        public virtual ICollection<FollowerChart> FollowerChart { get; set; }
    }
}
