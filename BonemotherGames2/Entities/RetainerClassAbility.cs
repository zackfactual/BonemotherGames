using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class RetainerClassAbility
    {
        public int RetainerClassId { get; set; }
        public int AbilityId { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual RetainerClass RetainerClass { get; set; }
    }
}
