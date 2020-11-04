using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace BonemotherGames.Services
{
    public class Retainer
    {
        public RetainerClass RetainerClass { get; set; }
        public Ancestry Ancestry { get; set; }
        public Subancestry Subancestry { get; set; }
        public string Name { get; set; }
        public List<Ability> PrimaryAbilities { get; set; }
        public List<Ability> Saves { get; set; }
        public List<Skill> Skills { get; set; }
        public List<SpecialAction> Actions { get; set; }

        public Retainer()
        {

        }
        public Retainer(RetainerClass retainerClass,
            Ancestry ancestry,
            Subancestry subancestry,
            string name,
            List<Ability> primaryAbilities,
            List<Ability> saves,
            List<Skill> skills,
            List<SpecialAction> actions)
        {
            RetainerClass = retainerClass;
            Ancestry = ancestry;
            Subancestry = subancestry;
            Name = name;
            PrimaryAbilities = primaryAbilities;
            Saves = saves;
            Skills = skills;
            Actions = actions;
        }

        public Retainer ConstructRetainer(Retainer retainer)
        {
            retainer.Ancestry = retainer.GetRandomAncestry();
            retainer.Subancestry = retainer.Ancestry.SubancestryRequired ? GetRandomSubancestry(retainer.Ancestry.AncestryId) : null;
            retainer.Name = retainer.Subancestry == null ? CharacterName.GetRandomAncestralName(retainer.Ancestry.AncestryId) : CharacterName.GetRandomAncestralName(retainer.Ancestry.AncestryId);
            retainer.PrimaryAbilities = retainer.GetPrimaryAbilities(retainer.RetainerClass.RetainerClassId);
            retainer.Saves = retainer.GetSaves(retainer.RetainerClass.RetainerClassId);
            retainer.Skills = retainer.GetSkills(retainer.RetainerClass.RetainerClassId);
            retainer.Actions = retainer.GetActions(retainer.RetainerClass.RetainerClassId);

            return retainer;
        }
        public RetainerClass GetRetainerClass(int retainerClassId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var retainerClass = ctx.RetainerClass.Where(x => x.RetainerClassId == retainerClassId).First();
                return retainerClass;
            }
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
                var playableAncestries = ctx.Ancestry.Where(x => x.PlayableRace == true).ToList();
                var randomAncestry = playableAncestries[rand.Next(playableAncestries.Count)];
                return randomAncestry;
            }
        }

        public Subancestry GetRandomSubancestry(int ancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var rand = new Random();
                var subancestries = ctx.Subancestry.Where(x => x.AncestryId == ancestryId).ToList();
                var randomSubancestry = subancestries[rand.Next(subancestries.Count)];
                return randomSubancestry;
            }
        }

        public List<Ability> GetPrimaryAbilities(int retainerClassId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var primaryAbilities = new List<Ability>();
                var retainerClassAbilities = ctx.RetainerClassAbility.Where(x => x.RetainerClassId == retainerClassId).ToList();
                foreach (var retainerClassAbility in retainerClassAbilities)
                {
                    var primaryAbility = ctx.Ability.Where(x => x.AbilityId == retainerClassAbility.AbilityId).First();
                    primaryAbilities.Add(primaryAbility);
                }
                return primaryAbilities;
            }
        }

        public List<Ability> GetSaves(int retainerClassId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var saves = new List<Ability>();
                var retainerClassSaves = ctx.RetainerClassSave.Where(x => x.RetainerClassId == retainerClassId).ToList();
                foreach (var retainerClassSave in retainerClassSaves)
                {
                    var save = ctx.Ability.Where(x => x.AbilityId == retainerClassSave.AbilityId).First();
                    saves.Add(save);
                }
                return saves;
            }
        }

        public List<Skill> GetSkills(int retainerClassId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var skills = new List<Skill>();
                var retainerClassSkills = ctx.RetainerClassSkill.Where(x => x.RetainerClassId == retainerClassId).ToList();
                foreach (var retainerClassSkill in retainerClassSkills)
                {
                    var skill = ctx.Skill.Where(x => x.SkillId == retainerClassSkill.SkillId).First();
                    skills.Add(skill);
                }
                return skills;
            }
        }

        public List<SpecialAction> GetActions(int retainerClassId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var actions = new List<SpecialAction>();
                var retainerActions = new List<RetainerAction>();
                var retainerClassActions = ctx.RetainerClassRetainerAction.Where(x => x.RetainerClassId == retainerClassId).ToList();
                foreach (var rca in retainerClassActions)
                {
                    var actionId = rca.ActionId;
                    var levelAttained = rca.LevelAttained;
                    var usesPerDay = rca.UsesPerDay;
                    var retainerAction = ctx.RetainerAction.Where(x => x.ActionId == rca.ActionId).First();
                    var actionName = retainerAction.ActionName;
                    var actionTypeName = ctx.ActionType.Where(x => x.ActionTypeId == retainerAction.ActionTypeId).Select(x => x.ActionTypeName).First();
                    var actionDescription = retainerAction.ActionDescription;
                    actions.Add(new SpecialAction(actionId, levelAttained, usesPerDay, actionName, actionTypeName, actionDescription));
                }
                return actions;
            }
        }
    }
}
