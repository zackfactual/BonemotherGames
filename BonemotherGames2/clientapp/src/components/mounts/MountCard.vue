<template>
    <div class="mount-card">
        <h2>{{ mountData.Name }}</h2>
        <h3>{{ mountData.MountType }}</h3>
    </div>
</template>

<script>
export default {
    props: {
        mountData: {
            type: Object,
            default: () => { }
        }
    },
}
</script>

<style lang="scss">
</style>