using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class UnitType
    {
        public UnitType()
        {
            RollableUnit = new HashSet<RollableUnit>();
        }

        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public int Attack { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }
        public int Toughness { get; set; }
        public int Morale { get; set; }
        public double CostModifier { get; set; }

        public virtual ICollection<RollableUnit> RollableUnit { get; set; }
    }
}
