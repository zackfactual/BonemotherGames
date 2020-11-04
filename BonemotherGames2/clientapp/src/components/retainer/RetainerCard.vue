<template>
    <div class="retainer-card">
        <h2>{{ retainerData.Name.NameText }}</h2>
        <h3>{{ retainerData.Ancestry.AncestryName }} {{ retainerData.RetainerClass.ClassName }}</h3>
    </div>
</template>

<script>
export default {
    props: {
        retainerData: {
            type: Object,
            default: () => {}
        }
    }
}
</script>

<style lang="scss">
.retainer-card {
    border: 2px green solid;
    padding: 16px;
    background-color: white;
    grid-column: 2 / span 5;
}
</style>