using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<RetainerTrait> AncestryTraits { get; set; }
        public List<RetainerTrait> SubancestryTraits { get; set; }

        public Retainer()
        {

        }

        public Retainer ConstructRetainer(Retainer retainer)
        {
            retainer.Ancestry = AncestryGenerator.GetRandomAncestry(true, false);
            if (retainer.Ancestry.SubancestryRequired)
            {
                retainer.Subancestry = AncestryGenerator.GetRandomSubancestry(retainer.Ancestry.AncestryId);
            }
            if (retainer.Ancestry.SubancestryOptional)
            {
                using (var ctx = new BonemotherGamesContext())
                {
                    var rand = new Random();
                    var subancestries = ctx.Subancestry.Where(x => x.AncestryId == retainer.Ancestry.AncestryId).ToList();
                    var subancestryIndex = rand.Next(subancestries.Count + 1);
                    retainer.Subancestry = subancestryIndex == subancestries.Count ? retainer.Subancestry = null : subancestries[subancestryIndex];
                }
                
            }
            retainer.AncestryTraits = GetAncestryTraits(retainer.Ancestry.AncestryId);
            retainer.SubancestryTraits = retainer.Subancestry != null ? GetSubancestryTraits(retainer.Subancestry.SubancestryId) : null;
            retainer.Name = retainer.Subancestry == null ? CharacterNameGenerator.GetRandomAncestralName(retainer.Ancestry.AncestryId, null) : 
                CharacterNameGenerator.GetRandomAncestralName(retainer.Ancestry.AncestryId, retainer.Subancestry.SubancestryId);
            retainer.PrimaryAbilities = retainer.GetPrimaryAbilities(retainer.RetainerClass.RetainerClassId);
            retainer.Saves = retainer.GetSaves(retainer.RetainerClass.RetainerClassId);
            retainer.Skills = retainer.GetSkills(retainer.RetainerClass.RetainerClassId);
            retainer.Actions = retainer.GetActions(retainer.RetainerClass.RetainerClassId);

            return retainer;
        }

        private List<RetainerTrait> GetAncestryTraits(int ancestryId)
        {
            List<RetainerTrait> retainerTraits = new List<RetainerTrait>();
            using (var ctx = new BonemotherGamesContext())
            {
                var ancestralRetainerTraits = ctx.AncestryRetainerTrait.Where(x => x.AncestryId == ancestryId);
                foreach (var ancestralRetainerTrait in ancestralRetainerTraits)
                {
                    var retainerTrait = ctx.RetainerTrait.Where(x => x.TraitId == ancestralRetainerTrait.TraitId).First();
                    retainerTraits.Add(retainerTrait);
                }
            }
            return retainerTraits;
        }

        private List<RetainerTrait> GetSubancestryTraits(int subancestryId)
        {
            List<RetainerTrait> retainerTraits = new List<RetainerTrait>();
            using (var ctx = new BonemotherGamesContext())
            {
                var subancestralRetainerTraits = ctx.SubancestryRetainerTrait.Where(x => x.SubancestryId == subancestryId);
                foreach (var subancestralRetainerTrait in subancestralRetainerTraits)
                {
                    var retainerTrait = ctx.RetainerTrait.Where(x => x.TraitId == subancestralRetainerTrait.TraitId).First();
                    retainerTraits.Add(retainerTrait);
                }
            }
            return retainerTraits;
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
