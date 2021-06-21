import Vue from 'vue'
import Vuex from 'vuex'
import api from '../service/api'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    // Đóng mỏ form
    isOpen: false,
    // Form sửa
    isEdited: false,
    // Form nhân bản
    isDuplicated: false,
    // Lỗi từ server
    error: false,
    // data lấy từ api
    assets: [],
    // Loading screen
    overlay: false,
    // 
    isSuccess: false,
    // THêm thành công
    successAdd: false,
    // Sửa thành công
    successEdit: false,
    // Xóa thành công
    successDelete: false,
    // Lỗi khi xóa nhiều nhưng chưa chọn dòng nào
    multipleError: false,
  },
  mutations: {
    changeAddNoti(state){
      state.successAdd = !state.successAdd
    },
    changeEditNoti(state){
      state.successEdit = !state.successEdit
    },
    changeDeleteNoti(state){
      state.successDelete = !state.successDelete
    },
    // Đóng mở form thêm
    changeFormState(state) {
      state.isOpen = !state.isOpen
    },
    // Đóng mở form sửa
    changeEditFormState(state) {
      state.isEdited = !state.isEdited
    },
    // Đóng mở form nhân bản
    changeDuplicateState(state) {
      state.isDuplicated = !state.isDuplicated
    },
    // truyền dữ liệu lấy từ api để đổ sang biến global
    GET_ASSETS(state, assets) {
      state.assets = assets
    },
    // Trạng thái của icon xoay loading
    changeLoadingState(state) {
      state.overlay = !state.overlay
    },
    // Trạng thái khi gửi request có lỗi
    changeErrorState(state) {
      state.error = !state.error
    },
    // Trạng thái khi thêm thành công
    changeSuccessState(state) {
      state.isSuccess = !state.isSuccess
    },
    deleteMultipleError(state){
      state.multipleError = !state.multipleError
    }
    
  },
  actions: {
    // Lấy dữ liệu từ API
    async loadData({ commit }, state) {
      await api().get("/assets").then(res => {
        commit('GET_ASSETS', res.data)
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
