﻿using BonemotherGames2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonemotherGames2.Services
{
    public static class CharacterName
    {
        // todo: pass potentially null subancestryId
        public static string GetRandomAncestralName(int ancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var ancestralNames = ctx.NameAncestry.Where(x => x.AncestryId == ancestryId).ToList();

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
                    sb.Append(firstName + ' ');
                if (nickname != null)
                    sb.Append(nickname + ' ');
                if (surname != null)
                    sb.Append(surname);
                var name = sb.ToString().Trim();
                return name;
            }
        }
    }
}
