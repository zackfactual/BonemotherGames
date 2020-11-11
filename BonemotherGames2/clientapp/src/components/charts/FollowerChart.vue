<template>
    <table class="follower-chart">
        <tr>
            <th>d100</th>
            <th>Follower</th>
        </tr>
        <tr v-for="chartRow in chartData">
            <td>{{ chartRow.LowRoll }}<span v-if="chartRow.LowRoll != chartRow.HighRoll">-{{ chartRow.HighRoll }}</span></td>
            <td><button @click="$emit('row-selected', chartRow.FollowerChart)">{{ chartRow.FollowerChart.FollowerName }}</button><button>Customize</button><button>Randomize</button></td>
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
