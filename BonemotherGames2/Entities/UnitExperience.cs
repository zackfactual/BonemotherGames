using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class UnitExperience
    {
        public UnitExperience()
        {
            RollableUnit = new HashSet<RollableUnit>();
        }

        public int UnitExperienceId { get; set; }
        public string UnitExperienceName { get; set; }
        public int Attack { get; set; }
        public int Toughness { get; set; }
        public int Morale { get; set; }

        public virtual ICollection<RollableUnit> RollableUnit { get; set; }
    }
}
