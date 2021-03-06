using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class FollowerType
    {
        public FollowerType()
        {
            FollowerChart = new HashSet<FollowerChart>();
        }

        public int FollowerTypeId { get; set; }
        public string FollowerTypeName { get; set; }

        public virtual ICollection<FollowerChart> FollowerChart { get; set; }
    }
}
