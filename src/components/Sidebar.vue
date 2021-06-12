<template>
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="mini"
      permanent
      app
      width="200"
    >
      <v-list>
        <v-list-item>
          <v-list-item-icon @click.stop="mini = !mini">
                <v-img 
                src="../assets/icon/logo-qlts.svg" 
                width="24"
                height="24"
                />
            </v-list-item-icon>
            <v-list-item-content>
                <v-list-item-title>
                  QLTS.VN
                </v-list-item-title>
            </v-list-item-content>
            <v-list-item-icon @click.stop="mini = !mini">
                <v-img 
                src="../assets/icon/hamburger-menu.svg" 
                width="20"
                height="20"
                />
            </v-list-item-icon>
        </v-list-item>
        <v-list-item
          v-for="item in items"
          :key="item.title"
          :to="item.view"
          link
        >
            <v-list-item-icon>
                <v-img 
                :src="item.src"
                width="20"
                height="20"
                />
            </v-list-item-icon>
            <v-list-item-content>
                <v-list-item-title class="text-subtitle-2 font-weight-bold" >{{ item.title }}</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
</template>

<script>
  export default {
    data () {
      return {
        drawer: true,
        items: [
          { title: 'Tổng quan', src: require('../assets/icon/computer-line.svg'), view:'/tongquan'},
          { title: 'Tài sản', src: require('../assets/icon/community-line.svg'), view:'/taisan' },
          { title: 'Công cụ dụng cụ', src: require('../assets/icon/paint-brush-line.svg'), view:'/congcu' },
          { title: 'Danh mục', src: require('../assets/icon/common.svg'), view:'/danhmuc'},
          { title: 'Tra cứu', src: require('../assets/icon/search-eye-line.svg'), view:'/tracuu' },
          { title: 'Hệ thống', src: require('../assets/icon/settings.svg'), view:'/hethong' },
          { title: 'Báo cáo', src: require('../assets/icon/pie-chart-line.svg'), view:'/baocao' },
        ],
        mini: true,
      }
    },
  }
</script>

<style lang="scss">
.v-list-item--active{
  background-color: #d6d2d2
}
.v-navigation-drawer__content{
  background-color: #011239;
}
.v-list-item:hover{
  cursor: pointer;
}

.v-list-item__title{
  color: #ffffff;
}

</style>