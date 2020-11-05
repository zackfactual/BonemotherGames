using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class RollableUnit
    {
        public RollableUnit()
        {
            FollowerChart = new HashSet<FollowerChart>();
        }

        public int RollableUnitId { get; set; }
        public int? UnitExperienceId { get; set; }
        public int? UnitEquipmentId { get; set; }
        public int UnitTypeId { get; set; }
        public int UnitSizeId { get; set; }

        public virtual UnitEquipment UnitEquipment { get; set; }
        public virtual UnitExperience UnitExperience { get; set; }
        public virtual UnitSize UnitSize { get; set; }
        public virtual UnitType UnitType { get; set; }
        public virtual ICollection<FollowerChart> FollowerChart { get; set; }
    }
}
