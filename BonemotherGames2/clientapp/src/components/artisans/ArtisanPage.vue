<template>
    <div class="artisan-page">
        <artisan-card v-if="artisan" :artisan-data="artisan" />
    </div>
</template>

<script>
import ArtisanCard from '../artisans/ArtisanCard.vue'

import axios from 'axios'

export default {
    components: {
        ArtisanCard
    },
    data () {
        return {
            artisan: null
        }
    },
    beforeCreate() {
        let artisanRoute = '/Artisan'
        if (this.$route.params.artisan_id) {
            artisanRoute = artisanRoute.concat(`/${this.$route.params.artisan_id}`)
            if (this.$route.query.ancestry != null) {
                artisanRoute = artisanRoute.concat(`/${this.$route.query.ancestry}`)
                if (this.$route.query.subancestry != null) {
                    artisanRoute = artisanRoute.concat(`/${this.$route.query.subancestry}`)
                }
            }
        }
        axios.get(artisanRoute)
            .then(result => {
                this.artisan = result.data
                if (this.$route.query.followerName != null) {
                    this.artisan.Name = this.$route.query.followerName
                }
            })
    }
}
</script>

<style lang="scss">
    .artisan-page {
        width: 100%;
        display: grid;
        grid-template-columns: repeat(12, 1fr);
    }
</style>