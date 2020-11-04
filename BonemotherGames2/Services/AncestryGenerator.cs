using BonemotherGames2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonemotherGames2.Services
{
    public static class AncestryGenerator
    {
        public static Ancestry GetRandomAncestry()
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var playableAncestries = ctx.Ancestry.Where(x => x.PlayableRace == true).ToList();
                var randomAncestry = playableAncestries[rand.Next(playableAncestries.Count)];
                return randomAncestry;
            }
        }

        public static Subancestry GetRandomSubancestry(int ancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var subancestries = ctx.Subancestry.Where(x => x.AncestryId == ancestryId).ToList();
                var randomSubancestry = subancestries[rand.Next(subancestries.Count)];
                return randomSubancestry;
            }
        }
    }
}
