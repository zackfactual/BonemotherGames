using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class FollowerChart
    {
        public int FollowerChartId { get; set; }
        public int FollowerTypeId { get; set; }
        public string FollowerName { get; set; }
        public int? RollableUnitId { get; set; }
        public int? RetainerClassId { get; set; }
        public int? RetainerLevel { get; set; }
        public int? ArtisanId { get; set; }
        public int? AncestryId { get; set; }
        public int? AllyLookupId { get; set; }
        public int? PaladinMountLookupId { get; set; }
        public int? AmbassadorLookupId { get; set; }

        public virtual AllyLookup AllyLookup { get; set; }
        public virtual Ancestry Ancestry { get; set; }
        public virtual FollowerType FollowerType { get; set; }
        public virtual PaladinMountLookup PaladinMountLookup { get; set; }
        public virtual RetainerClass RetainerClass { get; set; }
        public virtual RollableUnit RollableUnit { get; set; }
    }
}
