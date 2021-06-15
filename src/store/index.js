import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isOpen: false,
    isDeveloping: false,
    isClose: false,
  },
  mutations: {
    changeFormState(state){
      state.isOpen = !state.isOpen
    },
    changeDevelopingState(state){
      state.isDeveloping = !state.isDeveloping
    },
    changeCloseConfirmState(state){
      state.isClose = !state.isClose
    }
  },
  actions: {
  },
  modules: {
  },
  getters:{
  }
})
