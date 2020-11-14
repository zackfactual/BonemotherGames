<template>
    <div class="retainer-card">
        <h2>
            <span>{{ retainer.Name }}</span>
        </h2>
        <h3><span v-if="retainer.Subancestry != null">{{ retainer.Subancestry.SubancestryName }} </span><span v-if="retainer.Ancestry.AncestryName.toLowerCase() != 'gith'">{{ retainer.Ancestry.AncestryName }}</span> | {{ retainer.RetainerClass.ClassName }}</h3>
        <div>
            <span class="detail-label">Primary Ability: </span>
            <span>{{ retainer.primaryAbilities }}</span>
        </div>
        <div>
            <span class="detail-label">Saves: </span>
            <span>{{ retainer.saves }}</span>
        </div>
        <div>
            <span class="detail-label">Skills: </span>
            <span>{{ retainer.currentSkills }}</span>
        </div>
        <div>
            <span class="detail-label">Signature Attack: </span>
            <span>
                <span class="action-name">{{ retainer.signatureName }}</span><span v-if="retainer.Actions[0].ActionDescription != null">: {{ retainer.signatureDescription }}</span>
            </span>
        </div>
        <h4>Special Actions</h4>
        <div v-for="ability in retainer.otherAbilities">
            <span class="detail-label">
                {{ displayAbilityLevel(ability.LevelAttained) }} ({{ ability.UsesPerDay }}/day<span v-if="retainer.Actions[1].ActionTypeName.toLowerCase() != 'action'">, {{ ability.ActionTypeName }}</span>):
            </span>
            <span>
                <span class="action-name">{{ ability.ActionName }}</span><span v-if="retainer.Actions[1].ActionDescription != null">. {{ ability.ActionDescription }}</span>
            </span>
        </div>
        <h4 v-if="retainer.AncestryTraits && retainer.AncestryTraits.length > 0">{{ retainer.ancestryName }} Traits</h4>
        <div v-for="trait in retainer.AncestryTraits" :key="`trait-${trait.TraitId}`">
            <span class="detail-label">{{ trait.TraitName }}: </span>
            <span>{{ trait.TraitDescription }}</span>
        </div>
        <h4 v-if="retainer.SubancestryTraits && retainer.SubancestryTraits.length > 0">{{ retainer.Subancestry.SubancestryName }} {{ retainer.Ancestry.AncestryName }} Traits</h4>
        <div v-for="trait in retainer.SubancestryTraits" :key="`trait-${trait.TraitId}`">
            <span class="detail-label">{{ trait.TraitName }}: </span>
            <span>{{ trait.TraitDescription }}</span>
        </div>
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
    methods: {
        displayAbilityLevel (level) {
            return level === 3 ? '3rd' : `${level}th`
        }  
    }
}
</script>

<style lang="scss" scoped>
.retainer-card {
    border: 2px green solid;
    padding: 16px;
    background-color: white;
    grid-column: 1 / span 6;
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