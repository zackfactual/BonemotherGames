using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class UnitSize
    {
        public UnitSize()
        {
            RollableUnit = new HashSet<RollableUnit>();
            UnitName = new HashSet<UnitName>();
        }

        public int UnitSizeId { get; set; }
        public string UnitSizeName { get; set; }
        public double CostModifier { get; set; }

        public virtual ICollection<RollableUnit> RollableUnit { get; set; }
        public virtual ICollection<UnitName> UnitName { get; set; }
    }
}
