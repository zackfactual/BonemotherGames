using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class UnitEquipment
    {
        public UnitEquipment()
        {
            RollableUnit = new HashSet<RollableUnit>();
        }

        public int UnitEquipmentId { get; set; }
        public string UnitEquipmentName { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }

        public virtual ICollection<RollableUnit> RollableUnit { get; set; }
    }
}
