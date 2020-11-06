import Vue from 'vue'
import VueRouter from 'vue-router'

import App from './App.vue'
import RetainerPage from './components/retainer/RetainerPage.vue'
import HelloWorld from './components/HelloWorld.vue'

Vue.config.productionTip = false

// Routing
Vue.use(VueRouter);
const routes = [
    { path: '/test', component: RetainerPage },
    { path: '/hello', component: HelloWorld }
]

const router = new VueRouter({ mode: 'history', routes: routes })

new Vue({
    render: h => h(App),
    router: router
}).$mount('#app')
