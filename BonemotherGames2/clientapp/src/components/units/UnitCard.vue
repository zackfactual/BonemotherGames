<template>
    <div class="unit-card">
        <h2>{{ unitData.AncestryName }} Squad</h2>
        <p>{{ unitData.AncestryName }} {{ unitData.UnitExperienceName }} {{ unitData.UnitEquipmentName }} {{ unitData.UnitTypeName }}</p>

        <p>Cost: {{ unitData.Cost}}</p>
        <table>
            <tr>
                <td>Attack: </td>
                <td>{{ unitData.Attack }}</td>
                <td>Defense: </td>
                <td>{{ unitData.Defense }}</td>
            </tr>
            <tr>
                <td>Power: </td>
                <td>{{ unitData.Power }}</td>
                <td>Toughness: </td>
                <td>{{ unitData.Toughness }}</td>
            </tr>
            <tr>
                <td>Morale: </td>
                <td>{{ unitData.Morale }}</td>
                <td>Size: </td>
                <td>{{ unitData.UnitSizeName }}</td>
            </tr>
        </table>

        <h3 v-if="unitData.Traits.length > 0">Traits</h3>
        <p v-for="trait in unitData.Traits"><b>{{ trait.TraitName }}</b>: {{ trait.TraitDescription }}</p>
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