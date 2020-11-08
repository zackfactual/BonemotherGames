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
    { path: '/ally_card/:ally_id', component: AllyPage },
    { path: '/ambassador_card', component: AmbassadorPage },
    { path: '/ambassador_card/:ambassador_id', component: AmbassadorPage },
    { path: '/artisan_card', component: ArtisanPage },
    { path: '/artisan_card/:artisan_id', component: ArtisanPage },
    { path: '/mount_card', component: MountPage },
    { path: '/mount_card/:mount_id', component: MountPage },
    { path: '/retainer_card', component: RetainerPage },
    { path: '/retainer_card/:retainer_class_id', component: RetainerPage },
    { path: '/unit_card', component: UnitPage },
    { path: '/unit_card/:unit_id', component: UnitPage },
    { path: '/follower_chart', component: FollowerChartPage },
    { path: '/follower_chart/:leader_class_id', component: FollowerChartPage }
]

const router = new VueRouter({ mode: 'history', routes: routes })

new Vue({
    render: h => h(App),
    router: router
}).$mount('#app')
