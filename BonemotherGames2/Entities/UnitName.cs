using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class UnitName
    {
        public int UnitNameId { get; set; }
        public int UnitTypeId { get; set; }
        public int UnitSizeId { get; set; }
        public string UnitNameText { get; set; }

        public virtual UnitSize UnitSize { get; set; }
        public virtual UnitType UnitType { get; set; }
    }
}
