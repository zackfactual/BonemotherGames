<template>
    <div class="retainer-page">
        <retainer-card :retainer-data="randomRetainers ? randomRetainers[0] : {}" />
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
            randomRetainers: null
        }
    },
    beforeCreate () {
        axios.get('Retainer')
            .then(result => {
                this.randomRetainers = result.data
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