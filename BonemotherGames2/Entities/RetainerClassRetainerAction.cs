using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class RetainerClassRetainerAction
    {
        public int RetainerClassId { get; set; }
        public int ActionId { get; set; }
        public int? UsesPerDay { get; set; }
        public int LevelAttained { get; set; }

        public virtual RetainerAction Action { get; set; }
        public virtual RetainerClass RetainerClass { get; set; }
    }
}
