using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class CreatureSize
    {
        public CreatureSize()
        {
            Ancestry = new HashSet<Ancestry>();
        }

        public int CreatureSizeId { get; set; }
        public string CreatureSizeName { get; set; }

        public virtual ICollection<Ancestry> Ancestry { get; set; }
    }
}
