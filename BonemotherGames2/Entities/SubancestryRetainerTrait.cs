using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class SubancestryRetainerTrait
    {
        public int SubancestryId { get; set; }
        public int TraitId { get; set; }
        public int? TraitIdToReplace { get; set; }

        public virtual Subancestry Subancestry { get; set; }
        public virtual RetainerTrait Trait { get; set; }
    }
}
