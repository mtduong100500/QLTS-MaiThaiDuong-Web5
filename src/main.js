import Vue from 'vue'
import App from './App.vue'
import router from './router'

import store from './store'
import vuetify from './plugins/vuetify'

Vue.config.productionTip = false
Vue.config.keyCodes = {
  v: 86,
  f1: 112,
}

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')

export const bus = new Vue();
