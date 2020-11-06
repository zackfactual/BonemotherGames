<template>
    <follower-chart v-bind="{ chartData }" />
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
            chartData: []
        }
    },
    beforeCreate () {
        axios.get('follower/3')
            .then(result => {
                this.chartData = result.data
            })
    }
}
</script>
