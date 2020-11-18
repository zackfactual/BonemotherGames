<template>
    <div class="retainer-card-editor">
        <input type="text" name="retainerName" v-model="editedRetainer.Name">
        <generic-select v-if="Object.keys(availableSubancestries[selectedAncestryId]).length"
                        :default-value="defaultSubancestry"
                        :default-enabled="!editedRetainer.Ancestry.SubancestryRequired"
                        :option-object="availableSubancestries[selectedAncestryId]"
                        option-key-selector="SubancestryId"
                        option-text-selector="SubancestryName"
                        option-value-selector="SubancestryId"
                        name="retainerSubancestry"
                        @selected="selectSubancestry($event)">
            Subancestry
        </generic-select>
        <generic-select name="retainerAncestry"
                        :default-value="defaultAncestry"
                        :option-object="availableAncestries"
                        option-key-selector="AncestryId"
                        option-text-selector="AncestryName"
                        option-value-selector="AncestryId"
                        @selected="selectAncestry($event)">Ancestry</generic-select>
        <h3 v-if="editedRetainer">
            {{ editedRetainer.RetainerClass.ClassName }}
        </h3>
    </div>
</template>

<script>
import CardMixin from '../mixins/CardMixin.js'
import GenericSelect from '../shared/GenericSelect.vue'

import axios from 'axios'

export default {
    components: {
        GenericSelect
    },
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
            availableAncestries: {},
            ancestryOptions: [],
            availableSubancestries: {},
            editedRetainer: null,
            loading: false,
            selectedClassId: null
        }
    },
    computed: {
        defaultAncestry () {
            return this.editedRetainer.Ancestry.AncestryId
        },
        defaultSubancestry () {
            return this.editedRetainer.Subancestry ? this.editedRetainer.Subancestry.SubancestryId : -1
        },
        selectedAncestryId () {
            return this.editedRetainer.Ancestry.AncestryId
        }
    },
    beforeMount () {
        this.editedRetainer = this.retainer
        this.getAvailableAncestries()
        this.getAvailableSubancestries(false)
    },
    methods: {
        getAvailableAncestries() {
            this.loading = true
            axios.get('/ancestry')
                .then(result => {
                    this.availableAncestries = result.data.reduce((ancestries, ancestry) => {
                        ancestries[ancestry.AncestryId] = ancestry
                        return ancestries
                    }, {})
                    this.loading = false
                })
        },
        getAvailableSubancestries (resetSubancestry) {
            this.loading = true
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
                        this.loading = false
                    })
            } else {
                this.loading = false
                if (resetSubancestry) {
                    this.resetSubancestry()
                }
            }
        },
        resetSubancestry () {
            if (this.editedRetainer.Ancestry.SubancestryRequired) {
                const subancestryKeys = Object.keys(this.availableSubancestries[this.selectedAncestryId])
                this.$set(this.editedRetainer, 'Subancestry', this.availableSubancestries[this.selectedAncestryId][subancestryKeys[0]])
            } else {
                this.$set(this.editedRetainer, 'Subancestry', null)
            }
        },
        selectAncestry (ancestryId) {
            const redirectQuery = { followerName: this.editedRetainer.Name, ancestry: ancestryId }
            this.$router.push({ path: `/retainer_card/${this.editedRetainer.RetainerClass.RetainerClassId}`, query: redirectQuery })
            this.$set(this.editedRetainer, 'Ancestry', this.availableAncestries[ancestryId])
            this.getAvailableSubancestries(true)
        },
        selectSubancestry(subancestryId) {
            const selectedSubancestry = this.availableSubancestries[this.selectedAncestryId][subancestryId]
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