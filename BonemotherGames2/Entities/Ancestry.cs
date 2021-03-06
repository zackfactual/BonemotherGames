using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class Ancestry
    {
        public Ancestry()
        {
            FollowerChart = new HashSet<FollowerChart>();
            Subancestry = new HashSet<Subancestry>();
        }

        public int AncestryId { get; set; }
        public string AncestryName { get; set; }
        public int CreatureSizeId { get; set; }
        public int Speed { get; set; }
        public int? Darkvision { get; set; }
        public int Attack { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }
        public int Toughness { get; set; }
        public int Morale { get; set; }
        public bool PlayableRace { get; set; }
        public bool AllowRetainer { get; set; }
        public bool AllowUnit { get; set; }
        public bool SubancestryRequired { get; set; }
        public bool SubancestryOptional { get; set; }
        public string UnitPrefix { get; set; }

        public virtual CreatureSize CreatureSize { get; set; }
        public virtual ICollection<FollowerChart> FollowerChart { get; set; }
        public virtual ICollection<Subancestry> Subancestry { get; set; }
    }
}
