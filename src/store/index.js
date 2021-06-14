import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isOpen: false
  },
  mutations: {
    changeFormState(state){
      state.isOpen = !state.isOpen
    }
  },
  actions: {
  },
  modules: {
  }
})
