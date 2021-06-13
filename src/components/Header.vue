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
      <v-tooltip bottom>
          <template v-slot:activator="{on , attrs}">
      <div class="help-ico icon-hover" v-bind="attrs" v-on="on">
        <v-img src="../assets/icon/help.svg"> </v-img>
      </div>
      </template>
      <span>Trợ giúp</span>
      </v-tooltip>

      <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
          <div class="badge icon-hover" v-bind="attrs" v-on="on">
            <v-badge
              bordered
              bottom
              color="#00abfe"
              dot
              offset-x="8"
              offset-y="20"
            >
              <v-img src="../assets/icon/bell.svg"></v-img>
            </v-badge>
          </div>
        </template>
        <span>Thông báo</span>
      </v-tooltip>
      <v-img
        src="../assets/icon/Divider.svg"
        max-height="20"
        class="divider"
      ></v-img>
      <div class="avatar icon-hover">
        <v-avatar size="30">
          <v-img src="https://cdn.vuetifyjs.com/images/lists/2.jpg"></v-img>
        </v-avatar>
      </div>
      <v-img
        width="6"
        src="../assets/icon/i_arrow_up_small.svg"
        class="icon-hover down-icon"
      ></v-img>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
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
.down-icon{
  margin-right: 12px;
}
.avatar {
  margin-right: 8px;
}
.icon-hover:hover {
  cursor: pointer;
}
.divider {
  margin-right: 18px;
}
.help-ico {
  margin: 0 25px;
}
.badge {
  margin-right: 28px;
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
.v-responsive__content:hover {
  background-color: #ffffff;
}
.header {
  height: 50px;
}
.v-input__slot {
  min-height: 10px;
}

.select-year {
  width: 100px;
}

.select-year .v-input {
  font-size: 13px;
}
.v-application .primary--text {
  color: #e4e4e4 !important;
  caret-color: #e4e4e4 !important;
}
.v-input__slot {
  margin-bottom: 0;
}
</style>