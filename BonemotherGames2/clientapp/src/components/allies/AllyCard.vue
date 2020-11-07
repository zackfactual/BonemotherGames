<template>
        <div class="ally-card">
            <h2>{{ allyData.Name }}</h2>
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