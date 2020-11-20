<template>
    <div class="retainer-page">
        <retainer-card v-if="retainer" :retainer="retainer" />
        <retainer-card-editor v-if="retainer"
                              :retainer="retainer"
                              v-bind="{ availableAncestries, availableSubancestries, availableRetainerClasses }"
                              @select-ancestry="selectAncestry($event)"
                              @select-subancestry="selectSubancestry($event)"
                              @select-retainer-classs="selectRetainerClass($event)" />
    </div>
</template>

<script>
import CardMixin from '../mixins/CardMixin.js'
import RetainerCard from '../retainer/RetainerCard.vue'
import RetainerCardEditor from '../retainer/RetainerCardEditor.vue'

import axios from 'axios'

export default {
    components: {
        RetainerCard,
        RetainerCardEditor
    },
    mixins: [
        CardMixin
    ],
    data () {
        return {
            availableAncestries: {},
            availableRetainerClasses: null,
            availableSubancestries: {},
            retainer: null
        }
    },
    computed: {
        selectedAncestryId () {
            return this.retainer.Ancestry.AncestryId
        }
    },
    created () {
        this.getRetainer()
        this.getAvailableAncestries()
        this.getAvailableRetainerClasses()
    },
    methods: {
        formatAbilities (abilityArray) {
            let abilityString = ""
            abilityArray.forEach((ability, index) => {
                abilityString = abilityString.concat(ability.AbilityName)
                if (index + 1 !== abilityArray.length) {
                    abilityString = abilityString.concat(", ")
                }
            })
            return abilityString
        },
        getRetainer () {
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
                    // Wait until we have retainer data to grab available subancestries so we know which ancestry to start with
                    this.getAvailableSubancestries(false, false)
                })
        },
        getAvailableAncestries () {
            axios.get('/ancestry')
                .then(result => {
                    this.availableAncestries = result.data.reduce((ancestries, ancestry) => {
                        ancestries[ancestry.AncestryId] = ancestry
                        return ancestries
                    }, {})
                })
        },
        getAvailableSubancestries (resetSubancestry, getName) {
            if (!this.availableSubancestries[this.selectedAncestryId]) {
                axios.get(`/subancestry/${this.selectedAncestryId}`)
                    .then(result => {
                        const subancestries = result.data.reduce((subancestries, subancestry) => {
                            subancestries[subancestry.SubancestryId] = subancestry
                            return subancestries
                        }, {})
                        this.$set(this.availableSubancestries, this.selectedAncestryId, subancestries)
                        if (resetSubancestry) {
                            this.resetSubancestry()
                        } else if (getName) {
                            this.getRetainerName()
                        }
                    })
            } else {
                if (resetSubancestry) {
                    this.resetSubancestry()
                }
            }
        },
        getAvailableRetainerClasses () {
            axios.get('/retainer')
                .then(result => {
                    this.availableRetainerClasses = result.data.reduce((retainerClasses, retainerClass) => {
                        retainerClasses[retainerClass.RetainerClassId] = retainerClass
                        return retainerClasses
                    }, {})
                })
        },
        getRetainerName () {
            let nameQueryPath = `/name/${this.selectedAncestryId}`
            if (this.retainer.Subancestry) {
                nameQueryPath = nameQueryPath.concat(`/${this.retainer.Subancestry.SubancestryId}`)
            }
            axios.get(nameQueryPath)
                .then(result => {
                    this.$set(this.retainer, 'Name', result.data)
                    this.updatePath()
                })
        },
        resetSubancestry () {
            if (this.retainer.Ancestry.SubancestryRequired) {
                const subancestryKeys = Object.keys(this.availableSubancestries[this.selectedAncestryId])
                this.$set(this.retainer, 'Subancestry', this.availableSubancestries[this.selectedAncestryId][subancestryKeys[0]])
            } else {
                this.$set(this.retainer, 'Subancestry', null)
            }
            this.getRetainerName()
        },
        selectAncestry (ancestryId) {
            this.$set(this.retainer, 'Ancestry', this.availableAncestries[ancestryId])
            this.getAvailableSubancestries(true, true)
        },
        selectRetainerClass (classId) {
            this.$set(this.retainer, 'RetainerClass', this.availableRetainerClasses[classId])
            this.updatePath()
        },
        selectSubancestry (subancestryId) {
            const newSubancestry = this.availableSubancestries[this.selectedAncestryId][subancestryId]
            this.$set(this.retainer, 'Subancestry', newSubancestry)
            if (newSubancestry.NameRequired) {
                this.getRetainerName()
            }
            this.updatePath()
        },
        updatePath () {
            let redirectQuery = { followerName: this.retainer.Name, ancestry: this.selectedAncestryId }
            if (this.retainer.Subancestry) {
                redirectQuery['subancestry'] = this.retainer.Subancestry.SubancestryId
            }
            this.$router.push({ path: `/retainer_card/${this.retainer.RetainerClass.RetainerClassId}`, query: redirectQuery })
        } 
    }
}
</script>

<style lang="scss">
.retainer-page {
    width: 100%;
    display: grid;
    grid-template-columns: repeat(12, 1fr);
    column-gap: 8px;
}
</style>