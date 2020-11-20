<template>
    <div class="retainer-card-editor">
        <input type="text" name="retainerName" v-model="editedRetainer.Name">
        <generic-select v-if="availableSubancestries[selectedAncestryId] && Object.keys(availableSubancestries[selectedAncestryId]).length"
                        :default-value="defaultSubancestry"
                        :default-enabled="!editedRetainer.Ancestry.SubancestryRequired"
                        :option-object="availableSubancestries[selectedAncestryId]"
                        option-text-selector="SubancestryName"
                        option-value-selector="SubancestryId"
                        name="retainerSubancestry"
                        @selected="$emit('select-subancestry', $event)">
            Subancestry
        </generic-select>
        <generic-select name="retainerAncestry"
                        :default-value="defaultAncestry"
                        :option-object="availableAncestries"
                        option-text-selector="AncestryName"
                        option-value-selector="AncestryId"
                        @selected="$emit('select-ancestry', $event)">Ancestry</generic-select>
        <h3 v-if="editedRetainer">
            {{ editedRetainer.RetainerClass.ClassName }}
        </h3>
        <generic-select name="retainerClass"
                        :default-value="retainer.RetainerClass.RetainerClassId"
                        :option-object="availableRetainerClasses"
                        option-text-selector="ClassName"
                        option-value-selector="RetainerClassId"
                        @selected="$emit('select-retainer-class', $event)">Class</generic-select>
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
        availableAncestries: {
            type: Object,
            default: () => {}
        },
        availableSubancestries: {
            type: Object,
            default: () => { }
        },
        availableRetainerClasses: {
            type: Object,
            default: () => { }
        },
        retainer: {
            type: Object,
            required: true
        }
    },
    data () {
        return {
            editedRetainer: null,
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