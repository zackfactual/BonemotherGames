using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class RetainerClassSkill
    {
        public int RetainerClassId { get; set; }
        public int SkillId { get; set; }

        public virtual RetainerClass RetainerClass { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
