<template>
    <table class="follower-chart">
        <tr>
            <th>d100</th>
            <th>Follower</th>
        </tr>
        <tr v-for="chartRow in chartData">
            <td>{{ chartRow.LowRoll }}<span v-if="chartRow.LowRoll != chartRow.HighRoll">-{{ chartRow.HighRoll }}</span></td>
            <td>{{ chartRow.FollowerChart.FollowerName }}</td>
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
    }
}
</script>
