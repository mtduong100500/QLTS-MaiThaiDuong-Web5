<template>
  <div class="main-content">
    <div class="toolbar">
      <div>
        <!--
          Ô input tìm kiếm
          CreatedBy MTDUONG (14/06/2021)
        -->
        <input
          type="text"
          v-model="search"
          placeholder="Tìm kiếm"
          class="search-bar search-icon"
        />
      </div>

      <!--
        3 nút bấm: Thêm, load lại bảng và xóa
        CreatedBy MTDUONG (14/06/2021)
      -->
      <div class="btn-group d-flex align-center">
        <v-btn
          color="#00abfe"
          small
          class="white--text px-7 py-4 elevation-0"
          @click="$store.commit('changeFormState')"
          >Thêm</v-btn
        >

        <v-tooltip bottom>
          <template #activator="{ on, attrs }">
            <div class="btn-reload btn-hover" v-bind="attrs" v-on="on">
              <v-img
                max-height="15"
                max-width="15"
                src="../assets/icon/refresh.svg"
              ></v-img>
            </div>
          </template>
          <span>Tải lại bảng</span>
        </v-tooltip>
        <v-tooltip bottom>
          <template #activator="{ on, attrs }">
            <div class="btn-delete btn-hover" v-on="on" v-bind="attrs" @click="deleteDialog = true">
              <v-img
                height="15"
                width="15"
                src="../assets/icon/trash.svg"
              ></v-img>
            </div>
          </template>
          <span>Xóa dữ liệu</span>
        </v-tooltip>
      </div>
    </div>

    <!--
      Bảng dữ liệu
      CreatedBy MTDUONG (14/06/2021)
    -->
    <v-menu
      v-model="showMenu"
      :position-x="x"
      :position-y="y"
      absolute
      offset-y
    >
      <v-list>
        <v-list-item
          v-for="(item, index) in items"
          :key="index"
          @click="handleClick(index)"
        >
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
    <div class="table">
      <v-data-table
        :items="assets"
        :headers="headers"
        fixed-header
        hide-default-footer
        disable-pagination
        v-model="selectedRows"
        no-data-text="Không có dữ liệu"
      >
        <template #item="{ item, index }" > 
          <tr 
          @contextmenu.prevent="show" 
          :class="[selectedRows.indexOf(item.assetCode)>-1?'cyan':'' ]" 
          @click.ctrl.prevent="rowClicked(item)" >
            <td>{{ index }}</td>
            <td class="text-center">{{ formatDate(item.increaseDate)}}</td>
            <td>{{ item.assetCode }}</td>
            <td>{{ item.assetName }}</td>
            <td>{{ item.assetTypeId }}</td>
            <td>{{ item.departmentId }}</td>
            <td class="text-right">{{ formatMoney(item.originalPrice) }}</td>

            <!-- 
              3 nút sửa xóa nhân bản trong mỗi dòng của table
              CreatedBy MTDUONG (14/06/2021)
            -->
            <td>
              <div class="d-flex align-center">
                <v-tooltip bottom>
                  <template #activator="{ on, attrs }">
                    <v-icon
                      small
                      class="mr-2 btn-hover"
                      v-bind="attrs"
                      v-on="on"
                      @click="editItem(item), $store.commit('changeFormState')"
                    >
                      mdi-pencil
                    </v-icon>
                  </template>
                  <span>Sửa</span>
                </v-tooltip>
                <v-tooltip bottom>
                  <template #activator="{ on, attrs }">
                    <v-img
                      small
                      src="../assets/icon/trash.svg"
                      max-height="15"
                      max-width="15"
                      class="btn-hover"
                      v-bind="attrs"
                      v-on="on"
                      @click="deleteDialog = true"
                    ></v-img>
                  </template>
                  <span>Xóa</span>
                </v-tooltip>
                <v-tooltip bottom>
                  <template #activator="{ on, attrs }">
                    <v-icon
                      small
                      class="ml-2 btn-hover"
                      v-bind="attrs"
                      v-on="on"
                    >
                      mdi-history
                    </v-icon>
                  </template>
                  <span>Nhân bản dữ liệu</span>
                </v-tooltip>
              </div>
            </td>
          </tr>
        </template>
      </v-data-table>
    </div>

    <!--
      Thông tin về tổng số tài sản và tổng nguyên giá
      CreatedBy MTDUONg (14/06/2021)
    -->
    <div class="d-flex table-footer py-7 justify-space-between align-center">
      <div class="px-6 font-weight-bold">
        Tổng số tài sản: {{ assetCount() }}
      </div>
      <div class="px-x font-weight-bold tonggia">
        Tổng nguyên giá: {{ priceSumFunc() }}
      </div>
    </div>
    <v-dialog
      v-model="deleteDialog"
      max-width="350"
    >
      <v-card>
        <v-card-title class="text-h5">
         Thông báo
        </v-card-title>
        <v-card-text class="red--text text-h6">Bạn có chắc muốn xóa dữ liệu</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="green darken-1"
            text
            @click="deleteDialog = false"
          >
            Hủy
          </v-btn>
          <v-btn
            color="green darken-1"
            text
            @click="deleteDialog = false"
          >
            Đồng ý
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <FormDetails v-if="$store.state.isOpen" />
  </div>
</template>

<script>
import "../assets/css/ghitang.css";
import moment from "moment";
import FormDetails from "../components/FormDetails.vue";
import headers from '../common/header-table'
const axios = require('axios');
export default {
  name: "taisan",
  components: {
    FormDetails,
  },
  data() {
    return {
      deleteDialog: false,
      // Chứa các thông tin của table headers
      // CreatedBy MTDUONG (14/06/2021)
      headers: headers,

      // Dùng để lưu trữ dữ liệu để truyền lên table
      // CreatedBy MTDUONG (14/06/2021)
      assets: [],
      index: 0,
      // model dùng cho chức năng tìm kiếm
      search: "",

      // Tính tổng số tài sản
      // CreatedBy MTDUONG (14/06/2021)
      propertySum: "",

      // Tính tổng nguyên giá
      // CreatedBy MTDUONG (14/06/2021)
      priceSum: 0,

      // đổ dữ liệu lên form khi sửa
      // CreatedBy MTDUONG (15/06/2021)
      

      // Context Menu
      // CreatedBy MTDUONG (15/06/2021)
      items: [
        {
          title: "Sửa",
          click() {
            this.$store.commit("changeFormState");
          },
        },
        { title: "Xóa" },
        {
          title: "Nhân bản",
          click() {
            this.$store.commit("changeFormState");
          },
        },
      ],

      // Tọa độ chuột và trajgn thái của context menu
      showMenu: false,
      x: 0,
      y: 0,

      // Di chuyển bằng phím mũi tên
      selectedRows: [],

      // Dòng hiện tại
      
    };
  },
  // Di chuyển bằng phím mũi tên

  async created(){
    var res = await axios.get("https://localhost:44331/api/assets")
    this.assets = res.data
  },
  methods: {
    // Filter theo tên và mã nhân viên (Chưa hoạt động)
    // CreatedBy MTDUONG(13/06/2021)


    // Tính tổng tài sản
    // CreatdBy MTDUONG (15/06/2021)
    assetCount(){
      return this.assets.length
    },


    // Tính tổng nguyên giá (chưa hoạt động)
    // CreatedBY MTDUONG (14/06/2021)
    priceSumFunc(data) {
      for (item in data) {
        this.priceSum += parseInt(item.Price);
      }
      return this.priceSum;
    },

    // Đổ data lên form khi sửa (Chưa xong )
    // CreatedBy MTDUONG (15/06/2021)
    editItem(item) {
      this.editedIndex = data.indexOf(item);
      this.editedItem = Object.assign({}, item);
    },

    // Chuột phải sẽ hiện context menu
    // CreatedBy MTDUONG (15/06/2021)
    show(e) {
      e.preventDefault();
      this.showMenu = false;
      this.x = e.clientX;
      this.y = e.clientY;
      this.$nextTick(() => {
        this.showMenu = true;
      });
    },

    // Sự kiện khi click vào dòng trong context menu
    // CreatedBy MTDUONG (15/06/2021)
    handleClick(index) {
      this.items[index].click.call(this);
    },

    //Format data
    // CreatedBy MTDUONG (15/06/2021)
     formatMoney(money) {
      return money === null
        ? "0"
        : !isNaN(money)
        ? money.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.")
        : money;
    },
    formatDate(date) {
      return moment(String(date)).format("DD/MM/YYYY");
    },

    // Chọn nhiều dòng
    // CreatedBy MTDUONG (15/06/2021)
    rowClicked(row) {
      console.log(row)
      this.toggleSelection(row.id);
    },
    toggleSelection(keyID) {
      if (this.selectedRows.includes(keyID)) {
        this.selectedRows = this.selectedRows.filter(
          selectedKeyID => selectedKeyID !== keyID
        );
      } else {
        this.selectedRows.push(keyID);
      }
    },

    // Di chuyển lên xuống bằng phím mũi tên
   
  },
};
</script>

<style scoped>
.active-item {
  background-color: red;
}
.portrait.v-card {
  margin: 0 auto;
  max-width: 300px;
  width: 100%;
}

.v-menu__content > .v-list > .v-list-item {
  min-height: 30px !important;
}
.v-menu__content > .v-list > .v-list-item:hover {
  background-color: #dddddd;
}
.v-data-table__wrapper::-webkit-scrollbar {
  display: block;
    width: 5px !important;
    height: 5px !important;
    z-index: 1231232123421
}

</style>