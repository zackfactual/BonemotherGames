using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class SpecialName
    {
        public int? AllyLookupId { get; set; }
        public int? PaladinMountLookupId { get; set; }
        public string SpecialNameText { get; set; }

        public virtual AllyLookup AllyLookup { get; set; }
        public virtual PaladinMountLookup PaladinMountLookup { get; set; }
    }
}
