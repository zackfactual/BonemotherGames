﻿using System;
using System.Collections.Generic;

namespace BonemotherGames.Models
{
    public partial class ActionType
    {
        public ActionType()
        {
            RetainerAction = new HashSet<RetainerAction>();
        }

        public int ActionTypeId { get; set; }
        public string ActionTypeName { get; set; }

        public virtual ICollection<RetainerAction> RetainerAction { get; set; }
    }
}