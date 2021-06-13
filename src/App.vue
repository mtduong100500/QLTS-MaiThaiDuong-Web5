<template>
  <v-app id="inspire">
    <!--
      Phần thanh siderbar bên trái (không đổi theo router)
      CreatedBy MTDUONG(13/06/2021)
    -->
    <div class="sidebar">
      <Sidebar />
    </div>

    <!--
      Phần nội dung chính
      CreatedBy MTDUONG(13/06/2021)
    -->
    <v-main class="d-flex">

      <!--
        Phần Header (không đổi theo router)
        CreatedBy MTDUONG(13/06/2021)
      -->
      <div class="header-wrapper" style="">
        <Header />
      </div>

      <!--
        Phần router-view, nội dung sẽ được thanh đổi khi ấn vào thanh sidebar
        CreatedBy MTDUONG(13/06/2021)
      -->
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
import Sidebar from './components/Sidebar'
import Header from './components/Header'
export default {
  data() { 
    return{
      
    }
  },
  components:{
    Sidebar,
    Header,
  }
}
</script>

<style>
  @import './styles/fonts.css';
  .v-application {
    font-family: "GoogleSans-Regular", sans-serif;
    line-height: 0;
}
.v-list{
  padding: 0
}
.header-wrapper{
  border-bottom: 1px solid #e1e1e1;
}

.sidebar .v-list-item--link:hover{
  cursor: pointer;
  background-color: #273557;
}
</style>