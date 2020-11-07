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
    beforeCreate () {
        axios.get('Ambassador')
            .then(result => {
                this.randomAmbassador = result.data
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