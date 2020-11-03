using System;
using System.Collections.Generic;

namespace BonemotherGames2.Models
{
    public partial class Armor
    {
        public Armor()
        {
            RetainerClass = new HashSet<RetainerClass>();
        }

        public int ArmorId { get; set; }
        public string ArmorWeight { get; set; }
        public int ArmorClass { get; set; }

        public virtual ICollection<RetainerClass> RetainerClass { get; set; }
    }
}
