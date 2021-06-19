import Vue from 'vue'
import Vuex from 'vuex'
import api from '../service/api'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isOpen: false,
    isEdited: false,
    isDuplicated: false,
    error: false,
    assets: [],
    overlay: false,
    isSuccess: false,

  },
  mutations: {
    changeFormState(state) {
      state.isOpen = !state.isOpen
    },
    changeEditFormState(state) {
      state.isEdited = !state.isEdited
    },
    changeDuplicateState(state) {
      state.isDuplicated = !state.isDuplicated
    },
    GET_ASSETS(state, assets) {
      state.assets = assets
    },
    changeLoadingState(state) {
      state.overlay = !state.overlay
    },
    changeErrorState(state) {
      state.error = !state.error
    },
    changeSuccessState(state) {
      state.isSuccess = !state.isSuccess
    },

    
  },
  actions: {
    async loadData({ commit }, state) {
      await api().get("/assets").then(res => {
        commit('GET_ASSETS', res.data)
        commit('changeLoadingState')
      }).catch((error) => {
        commit('changeErrorState')
      });
    },

  },
  modules: {
  },
  getters: {
    hasError: state => state.hasError,
    error: state => state.error,
    usernameAlredyExists: state => state.usernameAlredyExists
  }
})
