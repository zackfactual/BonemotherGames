<template>
    <div class="follower-chart-page">
        <select class="leader-class-select" v-model="selectedLeaderClassId" @change="selectLeaderClass">
            <option disabled :value="null">Leader Class</option>
            <option v-for="leaderClass in leaderClasses" :value="leaderClass.LeaderClassId">{{ leaderClass.LeaderClassName }}</option>
        </select>
        <follower-chart v-if="selectedLeaderClassId" v-bind="{ chartData }" />
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
            selectedLeaderClassId: null,
            leaderClasses: [],
            chartData: []
        }
    },
    beforeCreate () {
        axios.get('follower')
            .then(result => {
                this.leaderClasses = result.data    
            })
    },
    methods: {
        selectLeaderClass () {
            console.log(this.selectedLeaderClassId)
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
