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
    
    <v-main> 
      <!--
        Phần Header (không đổi theo router)
        CreatedBy MTDUONG(13/06/2021)
      -->
      <div class="header-wrapper">
        <Header/>
      </div>


      <!--
        Phần router-view, nội dung sẽ được thanh đổi khi ấn vào thanh sidebar
        CreatedBy MTDUONG(13/06/2021)
      --> 
        <router-view></router-view>
    </v-main>
    <Form-Details v-if="$store.state.isOpen"/>
  </v-app>
</template>

<script>
import Sidebar from './components/Sidebar'
import Header from './components/Header'
import FormDetails from './components/FormDetails.vue'
export default {
  data() { 
    return{
      drawer: null
    }
  },
  components:{
    Sidebar,
    Header,
    FormDetails
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
.v-main___wrap{
  display:flex;
}

.sidebar .v-list-item--link:hover{
  cursor: pointer;
  background-color: #273557;
}
::-webkit-scrollbar {
    width: 5px !important;
    height: 5px !important;
    z-index: 1231232123421
}

::-webkit-scrollbar-track {
    width:6px;
    background-color: #bbb;
}
      

</style>