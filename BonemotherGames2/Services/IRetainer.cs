using BonemotherGames2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonemotherGames2.Services
{
    public interface IRetainer
    {
        public RetainerClass GetRandomRetainerClass();
        public Ancestry GetRandomAncestry();
        public Name GetRandomName();
    }
}
