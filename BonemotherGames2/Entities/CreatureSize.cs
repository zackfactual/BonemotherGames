using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
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
