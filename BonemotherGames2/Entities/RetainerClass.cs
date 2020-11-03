using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class RetainerClass
    {
        public RetainerClass()
        {
            FollowerChart = new HashSet<FollowerChart>();
        }

        public int RetainerClassId { get; set; }
        public string ClassName { get; set; }
        public int ArmorId { get; set; }

        public virtual Armor Armor { get; set; }
        public virtual ICollection<FollowerChart> FollowerChart { get; set; }
    }
}
