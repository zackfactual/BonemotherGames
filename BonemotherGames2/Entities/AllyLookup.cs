using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class AllyLookup
    {
        public int AllyLookupId { get; set; }
        public string AllyLookupName { get; set; }
        public string OutsideLink { get; set; }
        public bool IsUnit { get; set; }
    }
}
