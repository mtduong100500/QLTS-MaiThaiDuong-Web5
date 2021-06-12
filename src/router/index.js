import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  // {
  //   path: '/danhmuckhachhang',
  //   name: 'danhmuckhachhang',
  //   component: () => import('../views/danh-muc-khach-hang')
  // },

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
