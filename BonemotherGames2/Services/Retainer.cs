using BonemotherGames2.Entities;
using System;
using System.Linq;

namespace BonemotherGames.Services
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
        public Name GetRandomName()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var names = ctx.Name.ToList();
                var name = names[rand.Next(names.Count)];
                return name;
            }
        }


    }
}
