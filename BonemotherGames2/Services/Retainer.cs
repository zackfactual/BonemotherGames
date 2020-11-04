﻿using BonemotherGames2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BonemotherGames.Services
{
    public class Retainer : IRetainer
    {
        public RetainerClass RetainerClass { get; set; }
        public Ancestry Ancestry { get; set; }
        public Name Name { get; set; }
        public List<Ability> PrimaryAbilities { get; set; }
        public List<Ability> Saves { get; set; }
        public List<Skill> Skills { get; set; }
        public List<RetainerAction> Actions { get; set; }
        public Retainer()
        {

        }
        public Retainer(RetainerClass retainerClass,
            Ancestry ancestry,
            Name name,
            List<Ability> primaryAbilities,
            List<Ability> saves,
            List<Skill> skills,
            List<RetainerAction> actions) 
        {
            RetainerClass = retainerClass;
            Ancestry = ancestry;
            Name = name;
            PrimaryAbilities = primaryAbilities;
            Saves = saves;
            Skills = skills;
            Actions = actions;
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

        public List<Ability> GetPrimaryAbilities(RetainerClass retainerClass)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var primaryAbilities = new List<Ability>();
                var retainerClassAbilities = ctx.RetainerClassAbility.Where(x => x.RetainerClassId == retainerClass.RetainerClassId).ToList();
                foreach (var retainerClassAbility in retainerClassAbilities)
                {
                    var primaryAbility = ctx.Ability.Where(x => x.AbilityId == retainerClassAbility.AbilityId).First();
                    primaryAbilities.Add(primaryAbility);
                }
                return primaryAbilities;
            }
        }

        public List<Ability> GetSaves(RetainerClass retainerClass)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var saves = new List<Ability>();
                var retainerClassSaves = ctx.RetainerClassSave.Where(x => x.RetainerClassId == retainerClass.RetainerClassId).ToList();
                foreach (var retainerClassSave in retainerClassSaves)
                {
                    var save = ctx.Ability.Where(x => x.AbilityId == retainerClassSave.AbilityId).First();
                    saves.Add(save);
                }
                return saves;
            }
        }

        public List<Skill> GetSkills(RetainerClass retainerClass)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var skills = new List<Skill>();
                var retainerClassSkills = ctx.RetainerClassSkill.Where(x => x.RetainerClassId == retainerClass.RetainerClassId).ToList();
                foreach (var retainerClassSkill in retainerClassSkills)
                {
                    var skill = ctx.Skill.Where(x => x.SkillId == retainerClassSkill.SkillId).First();
                    skills.Add(skill);
                }
                return skills;
            }
        }

        public List<RetainerAction> GetRetainerActions(RetainerClass retainerClass)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var actions = new List<RetainerAction>();
                var retainerClassActions = ctx.RetainerClassRetainerAction.Where(x => x.RetainerClassId == retainerClass.RetainerClassId).ToList();
                foreach (var retainerClassAction in retainerClassActions)
                {
                    var action = ctx.RetainerAction.Where(x => x.ActionId == retainerClassAction.ActionId).First();
                    actions.Add(action);
                }
                return actions;
            }
        }
    }
}
