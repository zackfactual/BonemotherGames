<template>
    <div class="unit-card">
        <h2>Ancestry: {{ unitData.Ancestry.AncestryName }}</h2>
        <p>Experience: {{ unitData.Experience.UnitExperienceName }}</p>
        <p>Equipment: {{ unitData.Equipment.UnitEquipmentName }}</p>
        <p>Size: {{ unitData.Size.UnitSizeName }}</p>
        <p>Type: {{ unitData.UnitType.UnitTypeName }}</p>
        <h3>Traits</h3>
        <p v-for="trait in unitData.Traits"><b>{{ trait.TraitName}}</b>: {{ trait.TraitDescription }}</p>
        <p>Attack: {{ unitData.Attack}}</p>
        <p>Power: {{ unitData.Power}}</p>
        <p>Defense: {{ unitData.Defense}}</p>
        <p>Toughness: {{ unitData.Toughness}}</p>
        <p>Morale: {{ unitData.Morale}}</p>
        <p>Cost: {{ unitData.Cost}}</p>
    </div>
</template>

<script>
export default {
    props: {
        unitData: {
            type: Object,
            default: () => { }
        }
    },
}
</script>

<style lang="scss">
</style>