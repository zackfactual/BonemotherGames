using BonemotherGames2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace BonemotherGames2.Services
{
    public class Retainer : IRetainer
    {
        public RetainerClass RetainerClass { get; set; }
        public Ancestry Ancestry { get; set; }
        public Name Name { get; set; }
        public Retainer()
        {

        }
        public Retainer(RetainerClass retainerClass, Ancestry ancestry, Name name)
        {
            RetainerClass = retainerClass;
            Ancestry = ancestry;
            Name = name;
        }

        public RetainerClass GetRandomRetainerClass()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var retainerClasses = ctx.RetainerClass.ToList();
                var randomRetainerClass = retainerClasses[rand.Next(retainerClasses.Count)];
                return randomRetainerClass;
            }
        }

        public Ancestry GetRandomAncestry()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var ancestries = ctx.Ancestry.ToList();
                var randomAncestry = ancestries[rand.Next(ancestries.Count)];
                return randomAncestry;
            }
        }
        public Name GetRandomName(Ancestry ancestry)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var ancestralNames = ctx.NameAncestry.Where(x => x.AncestryId == ancestry.AncestryId).ToList();
                var ancestralName = ancestralNames[rand.Next(ancestralNames.Count)];
                var name = ctx.Name.First(x => x.NameId == ancestralName.NameId);
                return name;
            }
        }

   
    }
}
