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
        let retainerRoute = '/Retainer'
        if (this.$route.params.retainer_class_id) {
            retainerRoute = retainerRoute.concat(`/${this.$route.params.retainer_class_id}`)
        }
        axios.get(retainerRoute)
            .then(result => {
                this.randomRetainer = result.data
            })
        console.log(this.$route.query.followerName)
        console.log(this.$route.query.ancestry)
        console.log(this.$route.query.subancestry)
    }
}
</script>

<style lang="scss">
.retainer-page {
    width: 100%;
    display: grid;
    grid-template-columns: repeat(12, 1fr);
}
</style>