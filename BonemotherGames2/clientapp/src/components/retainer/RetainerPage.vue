<template>
    <div class="retainer-page">
        <retainer-card v-if="randomRetainer" :retainer-data="randomRetainer" />
    </div>
</template>

<script>
import RetainerCard from '../retainer/RetainerCard.vue'

import axios from 'axios'

export default {
    components: {
        RetainerCard
    },
    data () {
        return {
            randomRetainer: null
        }
    },
    beforeCreate () {
        axios.get('Retainer')
            .then(result => {
                this.randomRetainer = result.data
            })
    }
}
</script>

<style lang="scss">
.retainer-page {
    margin: 0 64px;
    padding: 32px;
    background-color: #C1CCD7;
    display: grid;
    grid-template-columns: repeat(12, 1fr);
}
</style>