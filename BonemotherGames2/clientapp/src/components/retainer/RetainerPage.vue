<template>
    <retainer-card />
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
                temp: null
            }
        },
    created () {
        axios.get('FollowerChart')
            .then(result => {
                this.temp = result
            })
    }
}
</script>

<style lang="scss">
</style>