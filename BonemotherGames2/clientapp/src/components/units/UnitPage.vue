<template>
    <div class="unit-page">
        <unit-card v-if="randomUnit" :unit-data="randomUnit" />
    </div>
</template>

<script>
import UnitCard from '../units/UnitCard.vue'

import axios from 'axios'

export default {
    components: {
        UnitCard
    },
    data () {
        return {
            randomUnit: null
        }
    },
    beforeCreate () {
        let unitRoute = '/MilitaryUnit'
        if (this.$route.params.unit_id) {
            unitRoute = unitRoute.concat(`/${this.$route.params.unit_id}`)
        }
        axios.get(unitRoute)
            .then(result => {
                this.randomUnit = result.data
            })
    }
}
</script>

<style lang="scss">
    .unit-page {
        width: 100%;
        display: grid;
        grid-template-columns: repeat(12, 1fr);
    }
</style>