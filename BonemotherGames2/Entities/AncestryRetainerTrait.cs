using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class AncestryRetainerTrait
    {
        public int AncestryId { get; set; }
        public int TraitId { get; set; }

        public virtual Ancestry Ancestry { get; set; }
        public virtual RetainerTrait Trait { get; set; }
    }
}
