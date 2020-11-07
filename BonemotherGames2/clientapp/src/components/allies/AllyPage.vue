<template>
    <div class="ally-page">
        <ally-card v-if="randomAlly" :ally-data="randomAlly" />
    </div>
</template>

<script>
import AllyCard from '../allies/AllyCard.vue'

import axios from 'axios'

export default {
    components: {
        AllyCard
    },
    data () {
        return {
            randomAlly: null
        }
    },
    beforeCreate () {
        axios.get('Ally')
            .then(result => {
                this.randomAlly = result.data
            })
    }
}
</script>

<style lang="scss">
    .ally-page {
        width: 100%;
        display: grid;
        grid-template-columns: repeat(12, 1fr);
    }
</style>