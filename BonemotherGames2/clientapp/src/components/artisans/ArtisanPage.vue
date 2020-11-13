<template>
    <div class="artisan-page">
        <artisan-card v-if="artisan" :artisan-data="artisan" />
    </div>
</template>

<script>
import ArtisanCard from '../artisans/ArtisanCard.vue'
import CardMixin from '../mixins/CardMixin.js'

import axios from 'axios'

export default {
    components: {
        ArtisanCard
    },
    mixins: [
        CardMixin
    ],
    data () {
        return {
            artisan: null
        }
    },
    created () {
        const artisanRoute = this.buildDataRetrievalUrl('/Artisan')
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