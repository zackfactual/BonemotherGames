using BonemotherGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonemotherGames.Services
{
    public interface IRetainer
    {
        public RetainerClass GetRandomRetainerClass();
        public Ancestry GetRandomAncestry();
        public Name GetRandomName();
    }
}
