<template>
    <div class="mount-page">
        <mount-card v-if="randomMount" :mount-data="randomMount" />
    </div>
</template>

<script>
import MountCard from '../mounts/MountCard.vue'

import axios from 'axios'

export default {
    components: {
        MountCard
    },
    data () {
        return {
            randomMount: null
        }
    },
    beforeCreate () {
        axios.get('PaladinMount')
            .then(result => {
                this.randomMount = result.data
            })
    }
}
</script>

<style lang="scss">
    .mount-page {
        width: 100%;
        display: grid;
        grid-template-columns: repeat(12, 1fr);
    }
</style>