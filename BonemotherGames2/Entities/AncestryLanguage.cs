using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class AncestryLanguage
    {
        public int AncestryId { get; set; }
        public int LanguageId { get; set; }

        public virtual Ancestry Ancestry { get; set; }
        public virtual Language Language { get; set; }
    }
}
