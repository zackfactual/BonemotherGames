<template>
    <div class="mount-card">
        <h2>{{ mountData.MountType }}</h2>
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