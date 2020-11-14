<template>
    <div class="retainer-card-editor">
        <h3><span v-if="editedRetainer && editedRetainer.Subancestry != null">{{ editedRetainer.Subancestry.SubancestryName }} </span><span v-if="editedRetainer && editedRetainer.Ancestry.AncestryName.toLowerCase() != 'gith'">{{ editedRetainer.Ancestry.AncestryName }}</span> | {{ retainer.editedRetainerClass.ClassName }}</h3>
    </div>
</template>

<script>
import CardMixin from '../mixins/CardMixin.js'

export default {
    mixins: [
        CardMixin
    ],
    props: {
        retainer: {
            type: Object,
            required: true
        }
    },
    data () {
        return {
            editedRetainer: null
        }
    },
    beforeMounted () {
        this.editedRetainer = this.retainer
    },
    methods: {
        displayAbilityLevel(level) {
            return level === 3 ? '3rd' : `${level}th`
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