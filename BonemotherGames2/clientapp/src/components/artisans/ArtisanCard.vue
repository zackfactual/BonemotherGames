<template>
    <div class="artisan-card">
        <h2>{{ artisanData.Name }}</h2>
        <h3>{{ artisanData.Ancestry.AncestryName }} {{ artisanData.ArtisanLookup.Title }}</h3>
        <h4>Level {{ artisanData.ShopLevel }} {{ artisanData.ArtisanLookup.Shop }}</h4>
        <p>{{ artisanData.ArtisanLookup.Benefit }}</p>
        <p>{{ artisanData.ArtisanLookup.RecipeCsv }}</p>
    </div>
</template>

<script>
export default {
    props: {
        artisanData: {
            type: Object,
            default: () => { }
        }
    }
}
</script>

<style lang="scss">
</style>