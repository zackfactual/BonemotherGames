using BonemotherGames2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BonemotherGames2.Services
{
    public class MilitaryUnit
    {
        public string Name { get; set; }
        public string AncestryName { get; set; }
        public string UnitExperienceName { get; set; }
        public string UnitEquipmentName { get; set; }
        public string UnitSizeName { get; set; }
        public List<UnitTrait> Traits { get; set; }
        public string UnitTypeName { get; set; }
        public int Attack { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }
        public int Toughness { get; set; }
        public int Morale { get; set; }
        public int Cost { get; set; }

        public MilitaryUnit()
        {

        }

        internal MilitaryUnit BuildUnit(int rollableUnitId, int? ancestryId, int? subancestryId)
        {
            using (var ctx = new BonemotherGamesContext())
            {
                var militaryUnit = new MilitaryUnit();
                var ancestry = ancestryId == null ? AncestryGenerator.GetRandomAncestry(false, true) : ctx.Ancestry.Where(x => x.AncestryId == ancestryId).First();
                if (subancestryId != null)
                {
                    var subancestry = ctx.Subancestry.Where(x => x.SubancestryId == subancestryId).First();
                    militaryUnit.AncestryName = ancestry.AncestryId == 46 ? subancestry.SubancestryName : subancestry.SubancestryName + ancestry.AncestryName;
                }
                else
                {
                    militaryUnit.AncestryName = ancestry.AncestryName;
                }
                militaryUnit.Traits = GetAncestralUnitTraits(ancestry.AncestryId);

                var rollableUnit = ctx.RollableUnit.Where(x => x.RollableUnitId == rollableUnitId).First();
                var experience = ctx.UnitExperience.Where(x => x.UnitExperienceId == rollableUnit.UnitExperienceId).First();
                var equipment = ctx.UnitEquipment.Where(x => x.UnitEquipmentId == rollableUnit.UnitEquipmentId).First();
                var size = ctx.UnitSize.Where(x => x.UnitSizeId == rollableUnit.UnitSizeId).First();
                var unitType = ctx.UnitType.Where(x => x.UnitTypeId == rollableUnit.UnitTypeId).First();

                militaryUnit.UnitExperienceName = experience.UnitExperienceName;
                militaryUnit.UnitEquipmentName = equipment.UnitEquipmentName;
                militaryUnit.UnitSizeName = size.UnitSizeName;
                militaryUnit.UnitTypeName = unitType.UnitTypeName;

                militaryUnit.Attack = ancestry.Attack + experience.Attack + unitType.Attack;
                militaryUnit.Power = ancestry.Power + equipment.Power + unitType.Power;
                militaryUnit.Defense = ancestry.Defense + equipment.Defense + unitType.Defense;
                militaryUnit.Toughness = ancestry.Toughness + experience.Toughness + unitType.Toughness;
                militaryUnit.Morale = ancestry.Morale + experience.Morale + unitType.Morale;
                militaryUnit.Cost = CalculateUnitCost(militaryUnit, unitType.CostModifier, size.CostModifier);
                return militaryUnit;
            }
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

        private int CalculateUnitCost(MilitaryUnit unit, double unitTypeCostModifier, double unitSizeCostModifier)
        {
            var traitCost = 0;
            foreach (var trait in unit.Traits)
            {
                traitCost += trait.Cost;
            }
            double cost = (unitTypeCostModifier * (unit.Attack + unit.Power + unit.Defense + unit.Toughness + (unit.Morale * 2)) * unitSizeCostModifier * 10) + traitCost + 30;
            return Convert.ToInt32(Math.Round(cost));
        }
    }
}
