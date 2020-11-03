using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class AncestryUnitTrait
    {
        public int AncestryId { get; set; }
        public int UnitTraitId { get; set; }

        public virtual Ancestry Ancestry { get; set; }
        public virtual UnitTrait UnitTrait { get; set; }
    }
}
