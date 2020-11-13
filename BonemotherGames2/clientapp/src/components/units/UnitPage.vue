<template>
    <div class="unit-page">
        <unit-card v-if="randomUnit" :unit-data="randomUnit" />
    </div>
</template>

<script>
import CardMixin from '../mixins/CardMixin.js'
import UnitCard from '../units/UnitCard.vue'

import axios from 'axios'

export default {
    components: {
        UnitCard
    },
    mixins: [
        CardMixin
    ],
    data () {
        return {
            randomUnit: null
        }
    },
    created () {
        const unitRoute = this.buildDataRetrievalUrl('/MilitaryUnit')
        axios.get(unitRoute)
            .then(result => {
                this.randomUnit = result.data
                if (this.$route.query.followerName != null) {
                    this.randomUnit.Name = this.$route.query.followerName
                }
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