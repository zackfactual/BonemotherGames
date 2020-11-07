import Vue from 'vue'
import VueRouter from 'vue-router'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

import App from './App.vue'

import FollowerChartPage from './components/charts/FollowerChartPage.vue'
import RetainerPage from './components/retainer/RetainerPage.vue'
import AllyPage from './components/allies/AllyPage.vue'
import AmbassadorPage from './components/ambassadors/AmbassadorPage.vue'
import ArtisanPage from './components/artisans/ArtisanPage.vue'
import MountPage from './components/mounts/MountPage.vue'
import UnitPage from './components/units/UnitPage.vue'

Vue.config.productionTip = false

// Routing
Vue.use(VueRouter);
const routes = [
    { path: '/ally_card', component: AllyPage },
    { path: '/ambassador_card', component: AmbassadorPage },
    { path: '/artisan_card', component: ArtisanPage },
    { path: '/mount_card', component: MountPage },
    { path: '/retainer_card', component: RetainerPage },
    { path: '/unit_card', component: UnitPage },
    { path: '/follower_chart', component: FollowerChartPage }
]

const router = new VueRouter({ mode: 'history', routes: routes })

new Vue({
    render: h => h(App),
    router: router
}).$mount('#app')
