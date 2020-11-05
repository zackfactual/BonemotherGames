using BonemotherGames2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BonemotherGames2.Services
{
    public class MilitaryUnit
    {
        public Ancestry Ancestry { get; set; }
        public UnitExperience Experience { get; set; }
        public UnitEquipment Equipment { get; set; }
        public UnitSize Size { get; set; }
        public List<UnitTrait> Traits { get; set; }
        public UnitType UnitType { get; set; }
        public int Attack { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }
        public int Toughness { get; set; }
        public int Morale { get; set; }
        public double Cost { get; set; }

        public MilitaryUnit()
        {

        }

        internal MilitaryUnit ConstructRandomUnit(MilitaryUnit unit)
        {
            unit.Ancestry = AncestryGenerator.GetRandomAncestry(false, true);
            unit.Traits = GetAncestralUnitTraits(unit.Ancestry.AncestryId);
            unit.Experience = GetRandomExperience();
            unit.Equipment = GetRandomEquipment();
            unit.Size = GetRandomSize();
            unit.UnitType = GetRandomUnitType();
            unit.Attack = unit.Ancestry.Attack + unit.Experience.Attack + unit.UnitType.Attack;
            unit.Power = unit.Ancestry.Power + unit.Equipment.Power + unit.UnitType.Power;
            unit.Defense = unit.Ancestry.Defense + unit.Equipment.Defense + unit.UnitType.Defense;
            unit.Toughness = unit.Ancestry.Toughness + unit.Experience.Toughness + unit.UnitType.Toughness;
            unit.Morale = unit.Ancestry.Morale + unit.Experience.Morale + unit.UnitType.Morale;
            unit.Cost = CalculateUnitCost(unit);
            return unit;
        }

        private List<UnitTrait> GetAncestralUnitTraits(int ancestryId)
        {
            List<UnitTrait> unitTraits = new List<UnitTrait>();
            using (var ctx = new BonemotherGamesContext())
            {
                var ancestralUnitTraits = ctx.AncestryUnitTrait.Where(x => x.AncestryId == ancestryId);
                foreach (var ancestralUnitTrait in ancestralUnitTraits)
                {
                    var unitTrait = ctx.UnitTrait.Where(x => x.UnitTraitId == ancestralUnitTrait.UnitTraitId).First();
                    unitTraits.Add(unitTrait);
                }
                return unitTraits;
            }
        }

        private UnitType GetRandomUnitType()
        {
            var rand = new Random();
            using (var ctx = new BonemotherGamesContext())
            {
                var unitTypes = ctx.UnitType.ToList();
                var randomUnitType = unitTypes[rand.Next(unitTypes.Count)];
                return randomUnitType;
            }
        }

        private UnitSize GetRandomSize()
        {
            var rand = new Random();
            using (var ctx = new BonemotherGamesContext())
            {
                var unitSizes = ctx.UnitSize.ToList();
                var randomUnitSize = unitSizes[rand.Next(unitSizes.Count)];
                return randomUnitSize;
            }
        }

        private UnitEquipment GetRandomEquipment()
        {
            var rand = new Random();
            using (var ctx = new BonemotherGamesContext())
            {
                var unitEquipments = ctx.UnitEquipment.ToList();
                var randomUnitEquipment = unitEquipments[rand.Next(unitEquipments.Count)];
                return randomUnitEquipment;
            }
        }

        private UnitExperience GetRandomExperience()
        {
            var rand = new Random();
            using (var ctx = new BonemotherGamesContext())
            {
                var unitExperiences = ctx.UnitExperience.ToList();
                var randomUnitExperience = unitExperiences[rand.Next(unitExperiences.Count)];
                return randomUnitExperience;
            }
        }

        private double CalculateUnitCost(MilitaryUnit unit)
        {
            var traitCost = 0;
            foreach (var trait in unit.Traits)
            {
                traitCost += trait.Cost;
            }
            double cost = (unit.UnitType.CostModifier * (unit.Attack + unit.Power + unit.Defense + unit.Toughness + (unit.Morale * 2)) * unit.Size.CostModifier * 10) + traitCost + 30;
            return cost;
        }
    }
}
