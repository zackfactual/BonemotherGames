<template>
    <div class="ambassador-page">
        <ambassador-card v-if="randomAmbassador" :ambassador-data="randomAmbassador" />
    </div>
</template>

<script>
import AmbassadorCard from '../ambassadors/AmbassadorCard.vue'

import axios from 'axios'

export default {
    components: {
        AmbassadorCard
    },
    data () {
        return {
            randomAmbassador: null
        }
    },
    beforeCreate() {
        let ambassadorRoute = '/Ambassador'
        if (this.$route.params.ambassador_id) {
            ambassadorRoute = ambassadorRoute.concat(`/${this.$route.params.ambassador_id}`)
        }
        axios.get(ambassadorRoute)
            .then(result => {
                this.randomAmbassador = result.data
                if (this.$route.query.followerName != null) {
                    this.randomAmbassador.Name = this.$route.query.followerName
                }
            })
    }
}
</script>

<style lang="scss">
    .ambassador-page {
        width: 100%;
        display: grid;
        grid-template-columns: repeat(12, 1fr);
    }
</style>