import Vue from 'vue'
import VueRouter from 'vue-router'

import App from './App.vue'

import FollowerChartPage from './components/charts/FollowerChartPage.vue'
import RetainerPage from './components/retainer/RetainerPage.vue'

Vue.config.productionTip = false

// Routing
Vue.use(VueRouter);
const routes = [
    { path: '/test', component: RetainerPage },
    { path: '/follower_chart', component: FollowerChartPage }
]

const router = new VueRouter({ mode: 'history', routes: routes })

new Vue({
    render: h => h(App),
    router: router
}).$mount('#app')
