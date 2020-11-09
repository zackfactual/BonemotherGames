<template>
    <div class="follower-chart-page">
        <select class="leader-class-select" v-model="selectedLeaderClassId" @change="selectLeaderClass">
            <option disabled :value="null">Leader Class</option>
            <option v-for="leaderClass in leaderClasses" :value="leaderClass.LeaderClassId">{{ leaderClass.LeaderClassName }}</option>
        </select>
        <follower-chart v-if="selectedLeaderClassId" v-bind="{ chartData }" @open-modal="openRedirectModal" />
        <b-modal id="redirect-modal" title="BootstrapVue">
            <p class="my-4">Hello from modal!</p>
        </b-modal>
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
        openRedirectModal() {
            this.$bvModal.show('redirect-modal')
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
