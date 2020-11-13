<template>
    <div class="retainer-page">
        <retainer-card v-if="retainer" :retainer="retainer" />
    </div>
</template>

<script>
import CardMixin from '../mixins/CardMixin.js'
import RetainerCard from '../retainer/RetainerCard.vue'

import axios from 'axios'

export default {
    components: {
        RetainerCard
    },
    mixins: [
        CardMixin
    ],
    data () {
        return {
            retainer: null
        }
    },
    created () {
        const retainerRoute = this.buildDataRetrievalUrl('/Retainer')
        axios.get(retainerRoute)
            .then(result => {
                this.retainer = result.data
                this.retainer.Name = this.$route.query.followerName || this.retainer.Name
                // Abilities
                this.retainer.primaryAbilities = this.formatAbilities(this.retainer.PrimaryAbilities)
                this.retainer.saves = this.formatAbilities(this.retainer.Saves)
                this.retainer.currentSkills = this.formatAbilities(this.retainer.Skills)
                this.retainer.signatureDescription = this.retainer.Actions[0].ActionDescription
                this.retainer.signatureName = this.retainer.Actions[0].ActionName
                this.retainer.otherAbilities = this.retainer.Actions.slice(1).map((ability, index) => {
                    ability.level = index ? `${3 + (index * 2)}th` : '3rd'
                    return ability
                })
            })
    },
    methods: {
        formatAbilities(abilityArray) {
            let abilityString = ""
            abilityArray.forEach((ability, index) => {
                abilityString = abilityString.concat(ability.AbilityName)
                if (index + 1 !== abilityArray.length) {
                    abilityString = abilityString.concat(", ")
                }
            })
            return abilityString
        } 
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