<template>
    <table class="follower-chart">
        <tr>
            <th>d100</th>
            <th>Follower</th>
        </tr>
        <tr v-for="chartRow in chartData">
            <td>{{ chartRow.LowRoll }}<span v-if="chartRow.LowRoll != chartRow.HighRoll">-{{ chartRow.HighRoll }}</span></td>
            <td><a :href="chartLinkUrl(chartRow)">{{ chartRow.FollowerChart.FollowerName }}</a></td>
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
        chartLinkUrl (row) {
            if (row.FollowerChart.FollowerTypeId === 1) {
                return `/unit_card/${row.FollowerChart.RollableUnitId}`
            }
            if (row.FollowerChart.FollowerTypeId === 2) {
                return `/retainer_card/${row.FollowerChart.RetainerClassId}`
            }
            if (row.FollowerChart.FollowerTypeId === 3) {
                return `/artisan_card/${row.FollowerChart.ArtisanId}`
            }
            if (row.FollowerChart.FollowerTypeId === 4) {
                return `/ambassador_card/${row.FollowerChart.AmbassadorLookupId}`
            }
            if (row.FollowerChart.FollowerTypeId === 12) {
                return `/mount_card/${row.FollowerChart.PaladinMountLookupId}`
            }
            if (row.FollowerChart.FollowerTypeId === 10 ||
                row.FollowerChart.FollowerTypeId === 11 ||
                row.FollowerChart.FollowerTypeId === 13 ||
                row.FollowerChart.FollowerTypeId === 14) {
                return `/ally_card/${row.FollowerChart.AllyLookupId}`
            }
            return '/'
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
