<template>
    <div class="artisan-page">
        <artisan-card v-if="randomArtisan" :artisan-data="randomArtisan" />
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
            randomArtisan: null
        }
    },
    beforeCreate() {
        let artisanRoute = '/Artisan'
        if (this.$route.params.artisan_id) {
            artisanRoute = artisanRoute.concat(`/${this.$route.params.artisan_id}`)
        }
        axios.get(artisanRoute)
            .then(result => {
                this.randomArtisan = result.data
                if (this.$route.query.followerName != null) {
                    this.randomArtisan.Name = this.$route.query.followerName
                }
                if (this.$route.query.ancestry != null) {
                    console.log(this.$route.query.ancestry)
                    // todo: get this.randomArtisan.Ancestry.AncestryName from ancestryId 
                    if (this.$route.query.subancestry != null) {
                        console.log(this.$route.query.subancestry)
                        // todo: get this.randomArtisan.Subancestry.SubancestryName from subancestryId 
                    }
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