using BonemotherGames2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BonemotherGames2.Services
{
    public static class CharacterNameGenerator
    {
        public static string GetRandomAncestralName(int ancestryId, int? subancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                List<NameAncestry> ancestralNames = new List<NameAncestry>();
                if (subancestryId != null && ctx.Subancestry.Where(x => x.SubancestryId == subancestryId).Select(x => x.NameRequired).Any() == true)
                {
                    ancestralNames = ctx.NameAncestry.Where(x => x.SubancestryId == subancestryId).ToList();
                }
                else
                {
                    ancestralNames = ctx.NameAncestry.Where(x => x.AncestryId == ancestryId).ToList();
                }
                if (ancestralNames.Count == 0)
                {
                    ancestralNames = ctx.NameAncestry.Where(x => x.AncestryId == ancestryId).ToList();
                }

                List<string> ancestralFirstNames = new List<string>();
                List<string> ancestralNicknames = new List<string>();
                List<string> ancestralSurnames = new List<string>();

                // todo: replace this mess with a sql join when you don't have election brain
                foreach (var ancestralName in ancestralNames)
                {
                    var currentName = ctx.Name.Where(x => x.NameId == ancestralName.NameId).First();
                    switch (currentName.NameType)
                    {
                        case 0:
                        case 1:
                            ancestralFirstNames.Add(currentName.NameText);
                            break;
                        case 4:
                            ancestralNicknames.Add(currentName.NameText);
                            break;
                        case 2:
                            ancestralSurnames.Add(currentName.NameText);
                            break;
                        default:
                            break;
                    }
                }

                var firstName = ancestralFirstNames.Count > 0 ? ancestralFirstNames[rand.Next(ancestralFirstNames.Count)] : null;
                var nickname = ancestralNicknames.Count > 0 ? ancestralNicknames[rand.Next(ancestralNicknames.Count)] : null;
                var surname = ancestralSurnames.Count > 0 ? ancestralSurnames[rand.Next(ancestralSurnames.Count)] : null;

                StringBuilder sb = new StringBuilder();
                if (firstName != null)
                {
                    sb.Append(firstName + ' ');
                }
                    
                if (nickname != null)
                {
                    if (ancestryId == 7 || ancestryId == 42)
                    {
                        sb.Append('"');
                        sb.Append(nickname);
                        sb.Append('"');
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append(nickname + ' ');
                    }   
                }
                    
                if (surname != null)
                {
                    sb.Append(surname);
                }
                var name = sb.ToString().Trim();
                return name;
            }
        }
    }
}
