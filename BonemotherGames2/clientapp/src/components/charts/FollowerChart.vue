<template>
    <table class="follower-chart">
        <tr>
            <th>d100</th>
            <th>Follower</th>
        </tr>
        <tr v-for="chartRow in chartData">
            <td>{{ chartRow.LowRoll }}<span v-if="chartRow.LowRoll != chartRow.HighRoll">-{{ chartRow.HighRoll }}</span></td>
            <td><button @click="getFollower(chartRow)">{{ chartRow.FollowerChart.FollowerName }}</button></td>
        </tr>
    </table>
</template>

<script>
    export default {
        props: {
            chartData: {
                type: Array,
                required: true
            }
        },
        methods: {
            getFollower(row) {
                switch (row.FollowerChart.FollowerTypeId) {
                    case 1:
                        window.location.href = `/unit_card/${row.FollowerChart.RollableUnitId}`
                        break
                    case 2:
                        window.location.href = `/retainer_card/${row.FollowerChart.RetainerClassId}`
                        break
                    case 3:
                        window.location.href = `/artisan_card/${row.FollowerChart.ArtisanId}`
                        break
                    case 4:
                        window.location.href = `/ambassador_card/${row.FollowerChart.AmbassadorLookupId}`
                        break
                    case 5:
                        this.$emit('open-modal')
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
                        window.location.href = `/mount_card/${row.FollowerChart.PaladinMountLookupId}`
                        break
                    // 10, 11, 13, 14
                    default:
                        window.location.href = `/ally_card/${row.FollowerChart.AllyLookupId}`
                }
            }
        }
    }
</script>

<style lang="scss">
.follower-chart {
    background-color: white;
    border: 2px solid #2D2F39;
}

th {
    background-color: #FFF8EB;
}

td:not(:last-child), th:not(:last-child) {
    border-right: 1px solid #2D2F39;
    padding: 4px;
}

tr:not(:last-child) {
    border-bottom: 1px solid #2D2F39;
}
</style>
