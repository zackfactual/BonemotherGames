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
        <h4>Special Actions</h4>
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

h4 {
    text-decoration: underline;
}
</style>