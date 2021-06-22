<template>
  <div class="d-flex header">
    <!--
      Phần Header của trang, sẽ không thay đổi theo router-view
      CreatedBy MTDUONG (13/06/2021)    
    -->

    <!--Đường dẫn -->
    <v-breadcrumbs :items="links"></v-breadcrumbs>
    <v-spacer></v-spacer>
    <!--Thông tin -->
    <div class="d-flex align-center px-3">
      <p class="sotaichinh">Sở tài chính</p>
      <!-- Trợ giúp -->
      <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
          <div class="help-ico icon-hover" v-bind="attrs" v-on="on" @click="developingDialog = true">
            <v-img src="../../assets/icon/help.svg"> </v-img>
          </div>
        </template>
        <span>Trợ giúp</span>
      </v-tooltip>
      <!-- Thông báo -->
      <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
          <div class="badge icon-hover" v-bind="attrs" v-on="on" @click="developingDialog = true">
            <v-badge
              bordered
              bottom
              color="#00abfe"
              dot
              offset-x="8"
              offset-y="20"
            >
              <v-img src="../../assets/icon/bell.svg"></v-img>
            </v-badge>
          </div>
        </template>
        <span>Thông báo</span>
      </v-tooltip>
      <v-img
        src="../../assets/icon/Divider.svg"
        max-height="20"
        class="divider"

      ></v-img>

      <!-- Avatar -->
      <div class="avatar icon-hover" @click="developingDialog = true">
        <v-avatar size="30">
          <v-img src="https://cdn.vuetifyjs.com/images/lists/2.jpg"></v-img>
        </v-avatar>
      </div>
      <v-img
        width="6"
        src="../../assets/icon/i_arrow_up_small.svg"
        class="icon-hover down-icon"
      ></v-img>
    </div>
     <v-dialog
      v-model="developingDialog"
      max-width="350"
      
    >
      <v-card>
        <v-card-title class="text-h5">
         Thông báo
        </v-card-title>
        <v-card-text class="text-h6">Tính năng này hiện đang được phát triển</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="green darken-1"
            text
            @click="developingDialog = false"
          >
            Quay lại
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    
  </div>
</template>

<script>
import '../../assets/css/header.css'
export default {
  
  name: "Header",
  data() {
    return {
      developingDialog: false,
      // Breadcrums link
      links: [
        {
          text: "Tài sản",
          disabled: false,
          href: "/taisan",
        },
        {
          text: "Danh sách tài sản",
          disabled: true,
          href: "/taisan/danhsachtaisan",
        },
      ],
      years: ["2019", "2020", "2021"],
    };
  },
};
</script>
<style scoped>
.v-responsive__content:hover {
    background-color: #ffffff;
  }

  .sotaichinh {
    align-items: center;
    display: flex;
    flex-wrap: wrap;
    flex: 0 1 auto;
    list-style-type: none;
    margin: 0;
    padding: 18px 12px;
    font-weight: 500;
  }
</style>