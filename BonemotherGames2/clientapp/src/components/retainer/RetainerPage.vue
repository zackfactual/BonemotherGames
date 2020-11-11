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
        if (this.$route.params.retainer_class_id != null) {
            retainerRoute = retainerRoute.concat(`/${this.$route.params.retainer_class_id}`)
            if (this.$route.query.ancestry != null) {
                retainerRoute = retainerRoute.concat(`/${this.$route.query.ancestry}`)
                if (this.$route.query.subancestry != null) {
                    retainerRoute = retainerRoute.concat(`/${this.$route.query.subancestry}`)
                }
            }
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