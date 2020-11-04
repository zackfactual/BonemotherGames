using System;
using System.Collections.Generic;

namespace BonemotherGames2.Entities
{
    public partial class RetainerAction
    {
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionDescription { get; set; }
        public string OutsideLink { get; set; }

        public virtual ActionType ActionType { get; set; }
    }
}
