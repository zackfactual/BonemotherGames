<template>
    <div class="follower-chart-page">
        <select class="leader-class-select" v-model="selectedLeaderClassId" @change="selectLeaderClass">
            <option disabled :value="null">Leader Class</option>
            <option v-for="leaderClass in leaderClasses" :value="leaderClass.LeaderClassId">{{ leaderClass.LeaderClassName }}</option>
        </select>
        <follower-chart v-if="selectedLeaderClassId" v-bind="{ chartData }" @open-modal="openModalForRow($event)" @redirect-to-follower="redirectToFollower($event)" />
        <b-modal id="redirect-modal" title="Your Roll" @ok="confirmRedirectModal">
            <h3><span v-if="followerRoll != null">{{ followerRoll }}: </span>{{ selectedFollower ? selectedFollower.FollowerName : '' }}</h3>

            <div v-if="selectedFollower && selectedFollower.FollowerTypeId != 1
                 && selectedFollower.FollowerTypeId != 5
                 && selectedFollower.FollowerTypeId != 6
                 && selectedFollower.FollowerTypeId != 7
                 && selectedFollower.FollowerTypeId != 8
                 && selectedFollower.FollowerTypeId != 9">
                <label for="name">Optional Name: </label>
                <input type="text" id="nameInput" name="name" v-model="followerName"><br><br>
            </div>

            <div v-if="selectedFollower && selectedFollower.FollowerTypeId == 1">
                <label for="unitName">Optional Name: </label>
                <input type="text" id="unitNameInput" name="unitName" v-model="unitName" />
            </div>
           
            <div v-if="selectedFollower && (selectedFollower.FollowerTypeId === 1 ||
                    selectedFollower.FollowerTypeId === 2 ||
                    selectedFollower.FollowerTypeId === 3)">
                <label for="ancestry">Optional Ancestry: </label>
                <select v-if="selectedFollower && (selectedFollower.FollowerTypeId === 1 ||
                    selectedFollower.FollowerTypeId === 2 ||
                    selectedFollower.FollowerTypeId === 3)"
                        v-model="selectedAncestryId"
                        @change="selectAncestry">
                    <option disabled :value="null">Ancestry</option>
                    <option v-for="ancestry in availableAncestries" :value="ancestry.AncestryId">{{ ancestry.AncestryName }}</option>
                </select>
            </div>
            
            <select v-if="hasSubancestryOptions"
                    v-model="selectedSubancestryId"
                    @change="getRandomName" >
                <option v-if="subancestryRequired" disabled :value="null">Subancestry</option>
                <option v-else :value="null">None</option>
                <option v-for="subancestry in availableSubancestries[selectedAncestryId]" :value="subancestry.SubancestryId">{{ subancestry.SubancestryName }}</option>
            </select>

            <div v-if="selectedFollower && selectedFollower.FollowerTypeId === 5">
                <label for="ancestry">Required Leader Alignment: </label>
                <select class="alignment-select" v-model="selectedAlignmentId">
                    <option disabled :value="null">Leader Alignment</option>
                    <option v-for="alignment in availableAlignments" :value="alignment.AlignmentId">{{ alignment.AlignmentName }}</option>
                </select>
            </div>
            
        </b-modal>
        <button @click="rollFollower" v-if="chartData.length > 0">Roll 1d{{ chartData[chartData.length - 1].HighRoll }}</button>
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
            followerName: null,
            unitName: null,
            followerRoll: null,
            selectedFollower: null,
            leaderClasses: [],
            selectedAlignmentId: null,
            selectedAncestryId: null,
            selectedLeaderClassId: null,
            selectedSubancestryId: null,
            subancestryRequired: false
        }
    },
    computed: {
        hasSubancestryOptions() {
            return this.selectedAncestryId != null && this.availableSubancestries[this.selectedAncestryId] && this.selectedFollower && (this.selectedFollower.FollowerTypeId === 2 || this.selectedFollower.FollowerTypeId === 3)
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
            this.getChartData()
        }
    },
    methods: {
        confirmRedirectModal () {
            this.redirectToFollower(this.selectedFollower)
        },
        getChartData () {
            axios.get(`/follower/${this.selectedLeaderClassId}`)
                .then(result => {
                    this.chartData = result.data
                })
        },
        getRandomName() {
            let nameUrl = `/name/${this.selectedAncestryId}`
            if (this.selectedSubancestryId) {
                nameUrl.concat(`/${this.selectedSubancestryId}`)
            }
            axios.get(nameUrl)
                .then(result => {
                    this.followerName = result.data
                })
        },
        getUnitName() {
            let unitUrl = `/militaryunit/${this.selectedAncestryId}`
            axios.get(unitUrl)
                .then(result => {
                    this.unitName = result.data.Name
                })
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
        openModalForRow (followerChart) {
            this.selectedFollower = followerChart
            this.followerRoll = null
            this.openRedirectModal()
        },
        openRedirectModal () {
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
        rollFollower () {
            this.followerRoll = Math.floor(Math.random() * (this.chartData[this.chartData.length - 1].HighRoll) + 1)
            this.selectedFollower = this.chartData.find(follower => {
                return this.followerRoll >= follower.LowRoll && this.followerRoll <= follower.HighRoll
            }).FollowerChart
            this.openRedirectModal()
        },
        redirectToFollower (followerChart) {
            let redirectUrl = null
            let newLeaderId = null
            switch (followerChart.FollowerTypeId) {
                case 1:
                    redirectUrl = `/unit_card/${followerChart.RollableUnitId}`
                    break
                case 2:
                    redirectUrl = `/retainer_card/${followerChart.RetainerClassId}`
                    break
                case 3:
                    redirectUrl = `/artisan_card/${followerChart.ArtisanId}`
                    break
                case 4:
                    redirectUrl = `/ambassador_card/${followerChart.AmbassadorLookupId}`
                    break
                case 5:
                    if (this.selectedAlignmentId != null) {
                        this.redirectToAllyChart()
                    } else {
                        this.openRedirectModal()
                    }
                    break
                case 6:
                    newLeaderId = 15
                    break
                case 7:
                    newLeaderId = 16
                    break
                case 8:
                    newLeaderId = 17
                    break
                case 9:
                    newLeaderId = 18
                    break
                case 12:
                    redirectUrl = `/mount_card/${followerChart.PaladinMountLookupId}`
                    break
                // 10, 11, 13, 14
                default:
                    redirectUrl = `/ally_card/${followerChart.AllyLookupId}`
            }
            if (redirectUrl) {
                const redirectQuery = { followerName: this.followerName, ancestry: this.selectedAncestryId, subancestry: this.selectedSubancestryId }
                this.$router.push({ path: redirectUrl, query: redirectQuery })
            } else if (newLeaderId != null) {
                this.selectedLeaderClassId = newLeaderId
                this.selectLeaderClass()
            }
        },
        selectAncestry () {
            this.selectedSubancestryId = null
            this.subancestryRequired = this.availableAncestries.find(ancestry => ancestry.AncestryId === this.selectedAncestryId).SubancestryRequired
            if (!this.availableSubancestries[this.selectedAncestryId]) {
                axios.get(`/subancestry/${this.selectedAncestryId}`)
                    .then(result => {
                        if (result.data.length) {
                            this.$set(this.availableSubancestries, this.selectedAncestryId, result.data)
                        }
                        this.setDefaultSubancestry()
                        this.getRandomName()
                        this.getUnitName()
                    })
            } else {
                this.setDefaultSubancestry()
                this.getRandomName()
                this.getUnitName()
            }
        },
        selectLeaderClass () {
            this.$router.push(`/follower_chart/${this.selectedLeaderClassId}`)
            this.getChartData()
        },
        setDefaultSubancestry() {
            if (this.subancestryRequired) {
                this.selectedSubancestryId = this.availableSubancestries[this.selectedAncestryId][0].SubancestryId
            }
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
