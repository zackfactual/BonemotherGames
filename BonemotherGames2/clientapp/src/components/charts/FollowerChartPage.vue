<template>
    <div class="follower-chart-page">
        <select class="leader-class-select" v-model="selectedLeaderClassId" @change="selectLeaderClass">
            <option disabled :value="null">Leader Class</option>
            <option v-for="leaderClass in leaderClasses" :value="leaderClass.LeaderClassId">{{ leaderClass.LeaderClassName }}</option>
        </select>
        <follower-chart v-if="selectedLeaderClassId" v-bind="{ chartData }" @open-modal="openRedirectModal" />
        <b-modal id="redirect-modal" title="Special Allies!" @ok="confirmRedirectModal">
            <select class="alignment-select" v-model="selectedAlignmentId">
                <option disabled :value="null">Leader Alignment</option>
                <option v-for="alignment in availableAlignments" :value="alignment.AlignmentId">{{ alignment.AlignmentName }}</option>
            </select>
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
            selectedAlignmentId: null,
            selectedLeaderClassId: null,
            leaderClasses: [],
            loadingModal: false,
            chartData: []
        }
    },
    created() {
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
        openRedirectModal() {
            this.loadingModal = true
            if (!this.availableAlignments) {
                axios.get('/alignment')
                    .then(result => {
                        this.availableAlignments = result.data
                        this.loadingModal = false
                    })
            }
            this.$bvModal.show('redirect-modal')
        },
        selectLeaderClass () {
            axios.get(`/follower/${this.selectedLeaderClassId}`)
                .then(result => {
                    this.chartData = result.data
                })
        },
        rollFollower() {
            console.log(Math.floor(Math.random() * (this.chartData[this.chartData.length - 1].HighRoll) + 1))   
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
