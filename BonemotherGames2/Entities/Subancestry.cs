using System;
using System.Collections.Generic;

namespace BonemotherGames2.Models
{
    public partial class Subancestry
    {
        public int SubancestryId { get; set; }
        public int AncestryId { get; set; }
        public string SubancestryName { get; set; }
        public int? Darkvision { get; set; }
        public int? Speed { get; set; }
        public bool AllowRetainer { get; set; }

        public virtual Ancestry Ancestry { get; set; }
    }
}
