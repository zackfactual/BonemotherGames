using BonemotherGames2.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace BonemotherGames2.Services
{
    public class Artisan
    {
        public string Name { get; set; }
        public Ancestry Ancestry { get; set; }
        public Subancestry Subancestry { get; set; }
        public ArtisanLookup ArtisanLookup { get; set; }
        public int ShopLevel { get; set; }

        internal Artisan ConstructArtisan(int artisanLookupId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var artisan = new Artisan();
                artisan.ArtisanLookup = ctx.ArtisanLookup.Where(x => x.ArtisanLookupId == artisanLookupId).First();
                artisan.Ancestry = AncestryGenerator.GetRandomAncestry(true, false);
                artisan.Subancestry = AncestryGenerator.GetRandomSubancestry(artisan.Ancestry.AncestryId);
                artisan.Name = CharacterNameGenerator.GetRandomAncestralName(artisan.Ancestry.AncestryId, null);
                artisan.ShopLevel = 1;
                return artisan;
            }
        }

        internal Artisan ConstructArtisanWithAncestry(int artisanLookupId, int ancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var artisan = new Artisan();
                artisan.ArtisanLookup = ctx.ArtisanLookup.Where(x => x.ArtisanLookupId == artisanLookupId).First();
                artisan.Ancestry = ctx.Ancestry.Where(x => x.AncestryId == ancestryId).First();
                artisan.Subancestry = AncestryGenerator.GetRandomSubancestry(artisan.Ancestry.AncestryId);
                artisan.Name = CharacterNameGenerator.GetRandomAncestralName(artisan.Ancestry.AncestryId, null);
                artisan.ShopLevel = 1;
                return artisan;
            }
        }

        internal Artisan ConstructArtisanWithSubancestry(int artisanLookupId, int ancestryId, int subancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var artisan = new Artisan();
                artisan.ArtisanLookup = ctx.ArtisanLookup.Where(x => x.ArtisanLookupId == artisanLookupId).First();
                artisan.Ancestry = ctx.Ancestry.Where(x => x.AncestryId == ancestryId).First();
                artisan.Subancestry = ctx.Subancestry.Where(x => x.SubancestryId == subancestryId).First();
                artisan.Name = CharacterNameGenerator.GetRandomAncestralName(artisan.Ancestry.AncestryId, null);
                artisan.ShopLevel = 1;
                return artisan;
            }
        }
    }
}
