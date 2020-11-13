<template>
    <div class="retainer-card">
        <h2>
            <input v-if="editable" v-model="retainer.Name" />
            <span>{{ retainer.Name }}</span>
        </h2>
        <h3><span v-if="retainer.Subancestry != null">{{ retainer.Subancestry.SubancestryName }} </span><span v-if="retainer.Ancestry.AncestryName.toLowerCase() != 'gith'">{{ retainer.Ancestry.AncestryName }}</span> | {{ retainer.RetainerClass.ClassName }}</h3>
        <div>
            <span class="detail-label">Primary Ability: </span>
            <span>{{ formatAbilities(retainer.PrimaryAbilities) }}</span>
        </div>
        <div>
            <span class="detail-label">Saves: </span>
            <span>{{ formatAbilities(retainer.Saves) }}</span>
        </div>
        <div>
            <span class="detail-label">Skills: </span>
            <span>{{ formattedSkills }}</span>
        </div>
        <div>
            <span class="detail-label">Signature Attack: </span>
            <span>
                <span class="action-name">{{ retainer.Actions[0].ActionName }}</span><span v-if="retainer.Actions[0].ActionDescription != null">: {{ retainer.Actions[0].ActionDescription }}</span>
            </span>
        </div>
        <h4>Special Actions</h4>
        <div>
            <span class="detail-label">
                3rd-Level ({{ retainer.Actions[1].UsesPerDay }}/day<span v-if="retainer.Actions[1].ActionTypeName.toLowerCase() != 'action'">, {{ retainer.Actions[1].ActionTypeName }}</span>):
            </span>
            <span>
                <span class="action-name">{{ retainer.Actions[1].ActionName }}</span><span v-if="retainer.Actions[1].ActionDescription != null">. {{ retainer.Actions[1].ActionDescription }}</span>
            </span>
        </div>
        <div>
            <span class="detail-label">5th-Level ({{ retainer.Actions[2].UsesPerDay }}/day<span v-if="retainer.Actions[2].ActionTypeName.toLowerCase() != 'action'">, {{ retainer.Actions[2].ActionTypeName }}</span>): </span>
            <span>
                <span class="action-name">{{ retainer.Actions[2].ActionName }}</span><span v-if="retainer.Actions[2].ActionDescription != null">. {{ retainer.Actions[2].ActionDescription }}</span>
            </span>
        </div>
        <div>
            <span class="detail-label">7th-Level ({{ retainer.Actions[3].UsesPerDay }}/day<span v-if="retainer.Actions[3].ActionTypeName.toLowerCase() != 'action'">, {{ retainer.Actions[3].ActionTypeName }}</span>): </span>
            <span>
                <span class="action-name">{{ retainer.Actions[3].ActionName }}</span><span v-if="retainer.Actions[3].ActionDescription != null">. {{ retainer.Actions[3].ActionDescription }}</span>
            </span>
        </div>
        <h4 v-if="retainer.AncestryTraits && retainer.AncestryTraits.length > 0">{{ retainer.Ancestry.AncestryName }} Traits</h4>
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

import axios from 'axios'

export default {
    mixins: [
        CardMixin
    ],
    data () {
        return {
            editable: true,
            retainer: null
        }
    },
    computed: {
        formattedDefaultSkills () {
            let skillString = ""
            this.retainer.Skills.forEach((skill, index) => {
                skillString = skillString.concat(skill.SkillName)
                if (index + 1 !== this.retainer.Skills.length) {
                    skillString = skillString.concat(", ")
                }
            })
            return skillString
        }
    },
    created () {
        const retainerRoute = this.buildDataRetrievalUrl('/Retainer')
        axios.get(retainerRoute)
            .then(result => {
                this.retainer = result.data
                if (this.$route.query.followerName != null) {
                    this.retainer.Name = this.$route.query.followerName
                    this.retainer.currentSkills = this.formattedDefaultSkills
                    this.retainer.signature = this.formatAbilities[retainer.Actions[0]]
                }
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
.retainer-card {
    border: 2px green solid;
    padding: 16px;
    background-color: white;
    grid-column: 2 / span 5;
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