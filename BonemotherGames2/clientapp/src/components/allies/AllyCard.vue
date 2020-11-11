<template>
    <div class="ally-card">
        <h2>{{ allyData.AllyName }}</h2>
        <h3>{{ allyData.AllyType }}</h3>
    </div>
</template>

<script>
export default {
    props: {
        allyData: {
            type: Object,
            default: () => { }
        }
    },
}
</script>

<style lang="scss">
   
</style>