<template>
    <select v-bind="{ name }" v-model="selectedOption" @change="selectOption">
        <option v-if="defaultEnabled" value="-1"><slot /></option>
        <option v-else value="-1"><slot /></option>
        <option v-for="option in options"
                :key="`option-${option[optionValueSelector]}`"
                :value="option[optionValueSelector]">
            {{ option[optionTextSelector] }}
        </option>
    </select>
</template>

<script>
export default {
    props: {
        defaultEnabled: {
            type: Boolean,
            default: false
        },
        defaultValue: {
            type: Number,
            default: -1
        },
        name: {
            type: String,
            required: true
        },
        optionArray: {
            type: Array,
            default: () => []
        },
        optionObject: {
            type: Object,
            default: () => {}
        },
        optionTextSelector: {
            type: String,
            default: 'text'
        },
        optionValueSelector: {
            type: String,
            default: 'value'
        }
    },
    computed: {
        options () {
            return this.optionArray.length ? this.optionArray : this.optionObject
        }
    },
    data () {
        return {
            selectedOption: this.defaultValue
        }
    },
    watch: {
        defaultValue () {
            this.selectedOption = this.defaultValue
        }
    },
    methods: {
        selectOption () {
            this.$emit('selected', this.selectedOption)
        }
    }
}
</script>
