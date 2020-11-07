<template>
    <div class="ambassador-card">
        <h2>{{ ambassadorData.Name }}</h2>
        <h3>{{ ambassadorData.AncestryName }} Ambassador</h3>
    </div>
</template>

<script>
export default {
    props: {
        ambassadorData: {
            type: Object,
            default: () => { }
        }
    },
}
</script>

<style lang="scss">
</style>