using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class RetainerClassSave
    {
        public int RetainerClassId { get; set; }
        public int AbilityId { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual RetainerClass RetainerClass { get; set; }
    }
}
