<template>
    <div class="retainer-card-editor">
        <input type="text" name="retainerName" v-model="editedRetainer.Name">
        <select v-if="availableSubancestries[selectedAncestryId]" name="retainerSubancestry" v-model="selectedSubancestryId" @change="selectSubancestry">
            <option value="null">Subancestry</option>
            <option v-for="subancestry in availableSubancestries[selectedAncestryId]"
                    :key="`subancestry-${subancestry.SubancestryId}`"
                    :value="subancestry.SubancestryId">{{ subancestry.SubancestryName }}</option>
        </select>
        <select name="retainerAncestry" v-model="selectedAncestryId" @change="selectAncestry($event)">
            <option value="null">Ancestry</option>
            <option v-for="ancestry in availableAncestries"
                    :key="`ancestry-${ancestry.AncestryId}`"
                    :value="ancestry.AncestryId">{{ ancestry.AncestryName }}</option>
        </select>
        <h3 v-if="editedRetainer">
            {{ editedRetainer.RetainerClass.ClassName }}
        </h3>
    </div>
</template>

<script>
import CardMixin from '../mixins/CardMixin.js'

import axios from 'axios'

export default {
    mixins: [
        CardMixin
    ],
    props: {
        availableClasses: {
            type: Array,
            default: () => []
        },
        retainer: {
            type: Object,
            required: true
        }
    },
    data () {
        return {
            availableAncestries: null,
            availableSubancestries: {},
            editedRetainer: null,
            selectedAncestryId: null,
            selectedSubancestryId: null
        }
    },
    beforeMount () {
        this.editedRetainer = this.retainer
        if (this.editedRetainer.Subancestry) {
            this.selectedSubancestryId = this.editedRetainer.Subancestry.SubancestryId
        }
        this.selectedAncestryId = this.editedRetainer.Ancestry.AncestryId
        this.getAvailableAncestries()
        this.getAvailableSubancestries(false)
    },
    methods: {
        getAvailableAncestries() {
            axios.get('/ancestry')
                .then(result => {
                    this.availableAncestries = result.data.reduce((ancestries, ancestry) => {
                        ancestries[ancestry.AncestryId] = ancestry
                        return ancestries
                    }, {})
                })
        },
        getAvailableSubancestries (resetSubancestry) {
            const ancestryId = this.editedRetainer.Ancestry.AncestryId
            if (!this.availableSubancestries[ancestryId]) {
                axios.get(`/subancestry/${ancestryId}`)
                    .then(result => {
                        const subancestries = result.data.reduce((subancestries, subancestry) => {
                            subancestries[subancestry.SubancestryId] = subancestry
                            return subancestries
                        }, {})
                        this.$set(this.availableSubancestries, ancestryId, subancestries)
                        if (resetSubancestry) {
                            this.resetSubancestry()
                        }
                    })
            } else {
                if (resetSubancestry) {
                    this.resetSubancestry()
                }
            }
        },
        resetSubancestry () {
            if (this.editedRetainer.Ancestry.SubancestryRequired) {
                const subancestryKeys = Object.keys(this.availableSubancestries[this.selectedAncestryId])
                this.selectedSubancestryId = subancestryKeys[0]
                this.$set(this.editedRetainer, 'Subancestry', this.availableSubancestries[this.selectedAncestryId][this.selectedSubancestryId])
            } else {
                this.selectedSubancestryId = null
                this.$set(this.editedRetainer, 'Subancestry', null)
            }
        },
        selectAncestry () {
            const redirectQuery = { followerName: this.editedRetainer.Name, ancestry: this.selectedAncestryId }
            this.$router.push({ path: `/retainer_card/${this.editedRetainer.RetainerClass.RetainerClassId}`, query: redirectQuery })
            this.$set(this.editedRetainer, 'Ancestry', this.availableAncestries[this.selectedAncestryId])
            this.selectedSubancestryId = null
            this.$set(this.editedRetainer, 'Subancestry', null)
            this.getAvailableSubancestries(true)
        },
        selectSubancestry () {
            const selectedSubancestry = this.availableSubancestries[this.selectedAncestryId][this.selectedSubancestryId]
            this.$set(this.editedRetainer, 'Subancestry', selectedSubancestry)
        }
    }
}
</script>

<style lang="scss" scoped>
.retainer-card-editor {
    border: 2px gray solid;
    padding: 16px;
    background-color: white;
    grid-column: 7 / span 6;
}

.detail-label, h4 {
    font-weight: 600;
    text-transform: uppercase;
    color: #2B2E50;
}

.action-name {
    font-style: italic;
}

h4 {
    text-decoration: underline;
}
</style>