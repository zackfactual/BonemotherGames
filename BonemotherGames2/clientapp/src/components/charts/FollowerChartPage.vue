<template>
    <div>
        <select class="form-control" v-model="selectedLeaderClassId">
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
    watch: {
        selectedLeaderClassId () {
            console.log(this.selectedLeaderClassId)
            axios.get(`follower/${this.selectedLeaderClassId}`)
                .then(result => {
                    this.chartData = result.data
                })
        }    
    }
}
</script>

<style lang="scss">
    .form-control {
        display: block;
        width: 100%;
    }
</style>
