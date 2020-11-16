<template>
    <div class="retainer-card-editor">
        <input type="text" name="retainerName" v-model="editedRetainer.Name">
        <select name="retainerSubancestry" v-model="selectedSubancestryId">
            <option value="null">Subancestry</option>
            <option v-for="subancestry in availableSubancestries"
                    :key="`subancestry-${subancestry.SubancestryId}`"
                    :value="subancestry.SubancestryId">{{ subancestry.SubancestryName }}</option>
        </select>
        <select name="retainerAncestry" v-model="editedRetainer.Ancestry.AncestryId">
            <option value="null">Ancestry</option>
            <option v-for="ancestry in availableAncestries"
                    :key="`ancestry-${ancestry.AncestryId}`"
                    :value="ancestry.AncestryId">{{ ancestry.AncestryName }}</option>
        </select>
        <h3 v-if="editedRetainer">
            | {{ editedRetainer.RetainerClass.ClassName }}
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
            availableSubancestries: null,
            editedRetainer: null,
            selectedSubancestryId: null
        }
    },
    beforeMount () {
        this.editedRetainer = this.retainer
        if (this.editedRetainer.Subancestry) {
            this.selectedSubancestryId = this.editedRetainer.Subancestry.SubancestryId
        }
        this.getAvailableAncestries()
        this.getAvailableSubancestries()
    },
    methods: {
        displayAbilityLevel (level) {
            return level === 3 ? '3rd' : `${level}th`
        },
        getAvailableAncestries() {
            axios.get('/ancestry')
                .then(result => {
                    this.availableAncestries = result.data.reduce((ancestries, ancestry) => {
                        ancestries[ancestry.AncestryId] = ancestry
                        return ancestries
                    }, {})
                })
        },
        getAvailableSubancestries () {
            axios.get(`/subancestry/${this.editedRetainer.Ancestry.AncestryId}`)
                .then(result => {
                    this.availableSubancestries = result.data.reduce((subancestries, subancestry) => {
                        subancestries[subancestry.SubancestryId] = subancestry
                        return subancestries
                    }, {})
                })
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