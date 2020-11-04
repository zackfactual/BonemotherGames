<template>
    <div class="retainer-card">
        <h2>{{ retainerData.Name.NameText }}</h2>
        <h3>{{ retainerData.Ancestry.AncestryName }} {{ retainerData.RetainerClass.ClassName }}</h3>
        <div>
            <span class="detail-label">Primary Ability: </span>
            <span>{{ formatAbilities(retainerData.PrimaryAbilities) }}</span>
        </div>
        <div>
            <span class="detail-label">Saves: </span>
            <span>{{ formatAbilities(retainerData.Saves) }}</span>
        </div>
        <div>
            <span class="detail-label">Skills: </span>
            <span>{{ formattedSkills }}</span>
        </div>
        <div>
            <span class="detail-label">Signature Attack: </span>
            <span>
                <span class="action-name">{{ retainerData.Actions[0].ActionName }}</span><span v-if="retainerData.Actions[0].ActionDescription != null">: {{ retainerData.Actions[0].ActionDescription }}</span>
            </span>
        </div>
        <h4>Special Actions</h4>
        <div>
            <span class="detail-label">
                3rd-Level ({{ retainerData.Actions[1].UsesPerDay }}/day<span v-if="retainerData.Actions[1].ActionTypeName.toLowerCase() != 'action'">, {{ retainerData.Actions[1].ActionTypeName }}</span>): </span>
            <span>
                <span class="action-name">{{ retainerData.Actions[1].ActionName }}</span><span v-if="retainerData.Actions[1].ActionDescription != null">. {{ retainerData.Actions[1].ActionDescription }}</span>
</span>
        </div>
        <div>
            <span class="detail-label">5th-Level ({{ retainerData.Actions[2].UsesPerDay }}/day<span v-if="retainerData.Actions[2].ActionTypeName.toLowerCase() != 'action'">, {{ retainerData.Actions[2].ActionTypeName }}</span>): </span>
            <span>
                <span class="action-name">{{ retainerData.Actions[2].ActionName }}</span><span v-if="retainerData.Actions[2].ActionDescription != null">. {{ retainerData.Actions[2].ActionDescription }}</span>
</span>
        </div>
        <div>
            <span class="detail-label">7th-Level ({{ retainerData.Actions[3].UsesPerDay }}/day<span v-if="retainerData.Actions[3].ActionTypeName.toLowerCase() != 'action'">, {{ retainerData.Actions[3].ActionTypeName }}</span>): </span>
            <span>
                <span class="action-name">{{ retainerData.Actions[3].ActionName }}</span><span v-if="retainerData.Actions[3].ActionDescription != null">. {{ retainerData.Actions[3].ActionDescription }}</span>
</span>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        retainerData: {
            type: Object,
            default: () => {}
        }
    },
    computed: {
        formattedSkills () {
            let skillString = ""
            this.retainerData.Skills.forEach((skill, index) => {
                skillString = skillString.concat(skill.SkillName)
                if (index + 1 !== this.retainerData.Skills.length) {
                    skillString = skillString.concat(", ")
                }
            })
            return skillString
        }
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