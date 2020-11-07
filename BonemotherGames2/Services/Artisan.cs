using BonemotherGames2.Entities;
using System;
using System.Linq;

namespace BonemotherGames2.Services
{
    public class Artisan
    {
        public string Name { get; set; }
        public Ancestry Ancestry { get; set; }
        public ArtisanLookup ArtisanLookup { get; set; }
        public int ShopLevel { get; set; }

        internal Artisan ConstructRandomArtisan(Artisan artisan)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var artisanLookups = ctx.ArtisanLookup.ToList();
                var randomArtisanLookup = artisanLookups[rand.Next(artisanLookups.Count)];
                artisan.ArtisanLookup = randomArtisanLookup;
            }
            artisan.Ancestry = AncestryGenerator.GetRandomAncestry(true, false);
            artisan.Name = CharacterNameGenerator.GetRandomAncestralName(artisan.Ancestry.AncestryId, null);
            artisan.ShopLevel = 1;
            return artisan;
        }
    }
}
