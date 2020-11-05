using BonemotherGames2.Entities;
using System;
using System.Linq;

namespace BonemotherGames2.Services
{
    public static class AncestryGenerator
    {
        public static Ancestry GetRandomAncestry(bool isRetainerOrArtisan, bool isUnit)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var randomAncestry = new Ancestry();
                if (isRetainerOrArtisan)
                {
                    var playableAncestries = ctx.Ancestry.Where(x => x.PlayableRace == true).ToList();
                    randomAncestry = playableAncestries[rand.Next(playableAncestries.Count)];
                }
                if (isUnit)
                {
                    var unitAncestries = ctx.Ancestry.Where(x => x.AllowUnit == true).ToList();
                    randomAncestry = unitAncestries[rand.Next(unitAncestries.Count)];
                }
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
