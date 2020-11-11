<template>
    <div class="follower-chart-page">
        <select class="leader-class-select" v-model="selectedLeaderClassId" @change="selectLeaderClass">
            <option disabled :value="null">Leader Class</option>
            <option v-for="leaderClass in leaderClasses" :value="leaderClass.LeaderClassId">{{ leaderClass.LeaderClassName }}</option>
        </select>
        <follower-chart v-if="selectedLeaderClassId" v-bind="{ chartData }" @row-selected="redirectToFollower($event)" />
        <b-modal id="redirect-modal" title="Your Roll" @ok="confirmRedirectModal">
            <h3>{{ followerRoll }}: {{ followerRolled ? followerRolled.FollowerName : '' }}</h3>

            <label for="name">Name: </label>
            <input type="text" id="nameInput" name="name"><br><br>

            <select v-if="followerRolled && (followerRolled.FollowerTypeId === 1 || followerRolled.FollowerTypeId === 2 || followerRolled.FollowerTypeId === 3)"
                    v-model="selectedAncestryId"
                    @change="selectAncestry" >
                <option disabled :value="null">Ancestry</option>
                <option v-for="ancestry in availableAncestries" :value="ancestry.AncestryId">{{ ancestry.AncestryName }}</option>
            </select>

            <select v-if="hasSubancestryOptions" v-model="selectedSubancestryId">
                <option v-if="subancestryRequired" disabled :value="null">Subancestry</option>
                <option v-else :value="null">None</option>
                <option v-for="subancestry in availableSubancestries[selectedAncestryId]" :value="subancestry.SubancestryId">{{ subancestry.SubancestryName }}</option>
            </select>

            <select v-if="followerRolled && followerRolled.FollowerTypeId === 5" class="alignment-select" v-model="selectedAlignmentId">
                <option disabled :value="null">Leader Alignment</option>
                <option v-for="alignment in availableAlignments" :value="alignment.AlignmentId">{{ alignment.AlignmentName }}</option>
            </select>
        </b-modal>
        <button @click="openRedirectModal" v-if="chartData.length > 0">Roll 1d{{ chartData[chartData.length - 1].HighRoll }}</button>
    </div>
</template>

<script>
import axios from 'axios'

import FollowerChart from './FollowerChart.vue'

export default {
    components: {
        FollowerChart
    },
    data () {
        return {
            availableAlignments: null,
            availableAncestries: null,
            availableSubancestries: {},
            chartData: [],
            followerRoll: null,
            followerRolled: null,
            leaderClasses: [],
            randomAncestralName: null,
            selectedAlignmentId: null,
            selectedAncestryId: null,
            selectedLeaderClassId: null,
            selectedSubancestryId: null,
            subancestryRequired: false
        }
    },
    computed: {
        hasSubancestryOptions() {
            return this.selectedAncestryId != null && this.availableSubancestries[this.selectedAncestryId] != null && this.followerRolled && (this.followerRolled.FollowerTypeId === 2 || this.followerRolled.FollowerTypeId === 3)
        },
        loadingModal () {
            return !(this.availableAlignments && this.availableAncestries)
        }
    },
    created () {
        axios.get('/follower')
            .then(result => {
                this.leaderClasses = result.data
            })
        if (this.$route.params.leader_class_id) {
            this.selectedLeaderClassId = this.$route.params.leader_class_id
            this.selectLeaderClass()
        }
    },
    methods: {
        confirmRedirectModal () {
            this.redirectToFollower(this.followerRolled)  
        },
        redirectToAllyChart () {
            switch (this.selectedAlignmentId) {
                case 1:
                    window.location.href = '/follower_chart/19'
                    break
                case 2:
                    window.location.href = '/follower_chart/22'
                    break
                case 3:
                    window.location.href = '/follower_chart/25'
                    break
                case 4:
                    window.location.href = '/follower_chart/20'
                    break
                case 5:
                    window.location.href = '/follower_chart/23'
                    break
                case 6:
                    window.location.href = '/follower_chart/26'
                    break
                case 7:
                    window.location.href = '/follower_chart/21'
                    break
                case 8:
                    window.location.href = '/follower_chart/24'
                    break
                case 9:
                    window.location.href = '/follower_chart/27'
                    break
            }
        },
        openRedirectModal () {
            this.followerRoll = Math.floor(Math.random() * (this.chartData[this.chartData.length - 1].HighRoll) + 1)
            this.followerRolled = this.chartData.find(follower => {
                return this.followerRoll >= follower.LowRoll && this.followerRoll <= follower.HighRoll
            }).FollowerChart
            if (!this.availableAlignments) {
                axios.get('/alignment')
                    .then(result => {
                        this.availableAlignments = result.data
                    })
            }
            if (!this.availableAncestries) {
                axios.get('/ancestry')
                    .then(result => {
                        this.availableAncestries = result.data
                    })
            }
            this.$bvModal.show('redirect-modal')
        },
        redirectToFollower (followerChart) {
            switch (followerChart.FollowerTypeId) {
                case 1:
                    window.location.href = `/unit_card/${followerChart.RollableUnitId}`
                    break
                case 2:
                    window.location.href = `/retainer_card/${followerChart.RetainerClassId}`
                    break
                case 3:
                    window.location.href = `/artisan_card/${followerChart.ArtisanId}`
                    break
                case 4:
                    window.location.href = `/ambassador_card/${followerChart.AmbassadorLookupId}`
                    break
                case 5:
                    if (this.selectedAlignmentId != null) {
                        this.redirectToAllyChart()
                    } else {
                        this.openRedirectModal()
                    }
                    break
                case 6:
                    window.location.href = '/follower_chart/15'
                    break
                case 7:
                    window.location.href = '/follower_chart/16'
                    break
                case 8:
                    window.location.href = '/follower_chart/17'
                    break
                case 9:
                    window.location.href = '/follower_chart/18'
                    break
                case 12:
                    window.location.href = `/mount_card/${followerChart.PaladinMountLookupId}`
                    break
                // 10, 11, 13, 14
                default:
                    window.location.href = `/ally_card/${followerChart.AllyLookupId}`
            }
        },
        selectAncestry () {
            this.selectedSubancestryId = null
            this.subancestryRequired = this.availableAncestries.find(ancestry => ancestry.AncestryId === this.selectedAncestryId).SubancestryRequired
            if (!this.availableSubancestries[this.selectedAncestryId]) {
                axios.get(`/subancestry/${this.selectedAncestryId}`)
                    .then(result => {
                        this.$set(this.availableSubancestries, this.selectedAncestryId, result.data)
                        if (this.subancestryRequired) {
                            this.selectedSubancestryId = result.data[0].SubancestryId
                        }
                    })
            }
        },
        selectLeaderClass () {
            axios.get(`/follower/${this.selectedLeaderClassId}`)
                .then(result => {
                    this.chartData = result.data
                })
        }
    }
}
</script>

<style lang="scss">
    .follower-chart-page {
        grid-template-columns: repeat(12, 1fr);
    }

    .leader-class-select {
        display: block;
        grid-column: 1 / span 2;
    }
</style>
