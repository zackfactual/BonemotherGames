using System;
using System.Collections.Generic;

namespace BonemotherGames2.Models
{
    public partial class NameAncestry
    {
        public int NameId { get; set; }
        public int AncestryId { get; set; }
        public int? SubancestryId { get; set; }

        public virtual Ancestry Ancestry { get; set; }
        public virtual Name Name { get; set; }
        public virtual Subancestry Subancestry { get; set; }
    }
}
