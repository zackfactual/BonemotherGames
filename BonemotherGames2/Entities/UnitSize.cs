using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class UnitSize
    {
        public UnitSize()
        {
            RollableUnit = new HashSet<RollableUnit>();
        }

        public int UnitSizeId { get; set; }
        public string UnitSizeName { get; set; }
        public double CostModifier { get; set; }

        public virtual ICollection<RollableUnit> RollableUnit { get; set; }
    }
}
