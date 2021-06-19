<template>
  <!--
      Thanh sidebar có thể phóng to thu nhỏ
      CreatedBy MTDUONG (13/06/2021)
    -->
  <v-navigation-drawer
    v-model="drawer"
    :mini-variant="mini"
    permanent
    app
    width="200"
  >
    <v-list>
      <!--Mỗi 1 list item là một dòng trong thanh sidebar
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-list-item style="padding-left: 17px">
        <v-img
          @click.stop="mini = !mini"
          src="../assets/icon/logo-qlts.svg"
          max-height="25"
          max-width="25"
        />
        <v-list-item-title
          style="color: #ffffff; font-size: 20px; padding-left: 4px"
          >QLTS.VN</v-list-item-title
        >
        <v-list-item-icon @click.stop="mini = !mini" style="padding-left: 10px">
          <v-img
            src="../assets/icon/hamburger-menu.svg"
            max-height="16"
            max-width="16"
          />
        </v-list-item-icon>
      </v-list-item>


      <!--
        Tông Quan
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-list-item
        class="main-navbar"
        @click="$store.commit('changeDevelopingState')"
      >
        <v-img
          src="../assets/icon/computer-line.svg"
          max-height="18"
          max-width="18"
          style="margin: 0 4px"
        />
        <v-list-item-title style="padding-left: 8px; color: #ffffff"
          >Tổng quan</v-list-item-title
        >
      </v-list-item>

      <!--
        Tài chính
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-menu
        open-on-hover
        right
        offset-x
        max-width="120"
        
        transition="slide-x-transition"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-list-item
            to="/"
            class="multilevel-menu main-navbar"
            v-on="on"
            v-bind="attrs"
          >
            <v-img
              src="../assets/icon/community-line.svg"
              max-height="18"
              max-width="18"
              style="margin: 0 4px"
            />
            <v-list-item-title style="padding-left: 8px; color: #ffffff">Tài sản</v-list-item-title>
            <svg
              id="i_arrow_up_small"
              xmlns="http://www.w3.org/2000/svg"
              width="8"
              height="4"
              viewBox="0 0 8 4"
              class="open-menu-arrow"
              transparent
            >
              <defs></defs>
              <path id="Rectangle_54_copy_4" class="cls-1" d="M8,0H0L4,4Z" />
            </svg>
          </v-list-item>
        </template>
        <!--
        Menu con của tài chính
        CreatedBy MTDUONG (13/06/2021)
        -->
        <v-list>
          <v-list-item v-for="link in links" :key="link.text">
            <v-list-item-title>{{ link.text }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <!--
        Công cụ dụng cụ
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-list-item
        class="main-navbar"
        @click="$store.commit('changeDevelopingState')"
      >
        <v-img
          src="../assets/icon/paint-brush-line.svg"
          max-height="18"
          max-width="18"
          style="margin: 0 4px"
        />
        <v-list-item-title style="padding-left: 8px; color: #ffffff"
          >Công cụ dụng cụ</v-list-item-title
        >
        <svg
          id="i_arrow_up_small"
          xmlns="http://www.w3.org/2000/svg"
          width="8"
          height="4"
          viewBox="0 0 8 4"
          class="open-menu-arrow"
          transparent
        >
          <defs></defs>
          <path id="Rectangle_54_copy_4" class="cls-1" d="M8,0H0L4,4Z" />
        </svg>
      </v-list-item>

      <!--
        Danh mục
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-list-item
        class="main-navbar"
        @click="$store.commit('changeDevelopingState')"
      >
        <v-img
          src="../assets/icon/common.svg"
          max-height="18"
          max-width="18"
          style="margin: 0 4px"
        />
        <v-list-item-title style="padding-left: 8px; color: #ffffff"
          >Danh mục</v-list-item-title
        >
        <svg
          id="i_arrow_up_small"
          xmlns="http://www.w3.org/2000/svg"
          width="8"
          height="4"
          viewBox="0 0 8 4"
          class="open-menu-arrow"
          transparent
        >
          <defs></defs>
          <path id="Rectangle_54_copy_4" class="cls-1" d="M8,0H0L4,4Z" />
        </svg>
      </v-list-item>

      <!--
        Tra cứu
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-list-item class="main-navbar">
        <v-img
          src="../assets/icon/search-eye-line.svg"
          max-height="18"
          max-width="18"
          style="margin: 0 4px"
        />
        <v-list-item-title style="padding-left: 8px; color: #ffffff"
          >Tra cứu</v-list-item-title
        >
      </v-list-item>

      <!--
        Hệ thống
        CreatedBy MTDUONG (13/06/2021)
        -->
      <v-list-item
        class="main-navbar"
        @click="$store.commit('changeDevelopingState')"
      >
        <v-img
          src="../assets/icon/settings.svg"
          max-height="18"
          max-width="18"
          style="margin: 0 4px"
        />
        <v-list-item-title style="padding-left: 8px; color: #ffffff"
          >Hệ thống</v-list-item-title
        >
      </v-list-item>

      <!--
        Báo cáo
        CreatedBy MTDUONG (13/06/2021)
        -->
        
      <v-list-item
        class="main-navbar"
        @click="$store.commit('changeDevelopingState')"
      >
        <v-img
          src="../assets/icon/pie-chart-line.svg"
          max-height="18"
          max-width="18"
          style="margin: 0 4px"
        />
        <v-list-item-title style="padding-left: 8px; color: #ffffff"
          >Báo cáo</v-list-item-title
        >
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import "../assets/css/sidebar.css";
export default {
  data() {
    return {
      // Dùng để phóng to thu nhỏ thanh sidebar
      // CreatedBy MTDUONG(13/06/2021)
      drawer: true,
      mini: true,
      // Sub menu
      links: [
        { text: "Ghi tăng" },
        { text: "Điều chuyển" },
        { text: "Tính hao mòn" },
        { text: "Ghi giảm" },
      ],
    };
  },
  methods:{
    
  }
};
</script>

<style>
.v-menu__content > .v-list >.v-list-item:hover{
  background-color: #dddddd;
}

.v-menu__content > .v-list >.v-list-item{
  min-height: 35px !important;
}
</style>