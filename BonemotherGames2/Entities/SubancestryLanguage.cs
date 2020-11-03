using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class SubancestryLanguage
    {
        public int SubancestryId { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Subancestry Subancestry { get; set; }
    }
}
