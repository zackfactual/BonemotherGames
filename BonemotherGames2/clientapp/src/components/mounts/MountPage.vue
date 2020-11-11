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
    beforeCreate() {
        let mountRoute = '/PaladinMount'
        if (this.$route.params.mount_id) {
            mountRoute = mountRoute.concat(`/${this.$route.params.mount_id}`)
        }
        axios.get(mountRoute)
            .then(result => {
                this.randomMount = result.data
                if (this.$route.query.followerName != null) {
                    this.randomMount.Name = this.$route.query.followerName
                }
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