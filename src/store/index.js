import Vue from 'vue'
import Vuex from 'vuex'
import api from '../service/api'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isOpen: false,
    isEdit: false,
    error: false,
    assets: [],
    overlay: true,
  },
  mutations: {
    changeFormState(state) {
      state.isOpen = !state.isOpen
    },
    changeEditFormState(state) {
      state.isEdit = !state.isEdit
    },
    GET_ASSETS(state, assets) {
      state.assets = assets
    },
    changeLoadingState(state){
      state.overlay = !state.overlay
    },
    changeErrorState(state){
      state.error = !state.error
    }

  },
  actions: {
    async loadData({ commit }, state) {
      await api().get("/assets").then(res => {
        commit('GET_ASSETS', res.data),
        commit('changeLoadingState')
      }).catch((error) => {
        commit('changeErrorState')
      });
    },

  },
  modules: {
  },
  getters: {
  }
})
