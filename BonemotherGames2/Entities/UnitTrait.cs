using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class UnitTrait
    {
        public int UnitTraitId { get; set; }
        public string TraitName { get; set; }
        public string TraitDescription { get; set; }
        public int? Cost { get; set; }
    }
}
