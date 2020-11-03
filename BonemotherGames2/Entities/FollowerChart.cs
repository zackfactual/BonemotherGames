using System;
using System.Collections.Generic;

namespace BonemotherGames2.Models
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

        public virtual Ancestry Ancestry { get; set; }
        public virtual FollowerType FollowerType { get; set; }
        public virtual RetainerClass RetainerClass { get; set; }
        public virtual RollableUnit RollableUnit { get; set; }
    }
}
