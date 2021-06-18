<template>
  <div class="main-content">
    <!--
      Loading trước khi data hiện lên
      CreatedBy MTDUONG (17/06/2021)
    -->
    <v-overlay :value="overlay">
      <v-progress-circular
        indeterminate
        color="primary"
        size="64"
      ></v-progress-circular>
    </v-overlay>
    <div class="toolbar">
      <div>
        <!--
          Ô input tìm kiếm
          CreatedBy MTDUONG (14/06/2021)
        -->
        <input
          type="text"
          ref="search"
          v-model="search"
          placeholder="Tìm kiếm"
          class="search-bar search-icon"
        />
      </div>

      <div class="btn-group d-flex align-center">
        <!--
          Nút thêm
          CreatedBy MTDUONG (14/06/2021)
        -->
        <v-btn
          color="#00abfe"
          small
          class="white--text px-7 py-4 elevation-0"
          @click="$store.commit('changeFormState')"
          >Thêm</v-btn
        >
        <!--
          Nút tải lại bảng
          CreatedBy MTDUONG (14/06/2021)
        -->
        <v-tooltip bottom>
          <template #activator="{ on, attrs }">
            <div
              class="btn-reload btn-hover"
              v-bind="attrs"
              v-on="on"
              @click="reloadTable"
            >
              <v-img
                max-height="15"
                max-width="15"
                src="../assets/icon/refresh.svg"
              ></v-img>
            </div>
          </template>
          <span>Tải lại bảng</span>
        </v-tooltip>

        <!--
          Nút xóa nhiều
          CreatedBy MTDUONG (14/06/2021)
        -->
        
        <v-tooltip bottom>
          <template #activator="{ on, attrs }">
            <div
              class="btn-delete btn-hover"
              v-on="on"
              v-bind="attrs"
              @click="deleteDialog = true"
            >
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
        :custom-filter="searchByNameAndCode"
        :search="search"
        fixed-header
        hide-default-footer
        disable-pagination
        no-data-text="Không có dữ liệu"
        
      >
        <template #item="{ item }">
          <tr @contextmenu.prevent="show">
            <td>{{ assets.indexOf(item) + 1 }}</td>
            <td class="text-center">{{ formatDate(item.increaseDate) }}</td>
            <td>{{ item.assetCode }}</td>
            <td>{{ item.assetName }}</td>
            <td>{{ item.assetTypeName }}</td>
            <td>{{ item.departmentName }}</td>
            <td class="text-right">{{ formatMoney(item.originalPrice) }}</td>
            <td>
              <div class="d-flex align-center">
                <!--
                  Nút chỉnh sửa trên dòng trong bảng
                  CreatedBy MTDUONG (14/06/2021)
                -->
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

                <!--
                  Nút xóa dòng trên bảng
                  CreatedBy MTDUONG (14/06/2021)
                -->
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

                <!--
                  Nút nhân bản trên dòng trong bảng
                  CreatedBy MTDUONG (14/06/2021)
                -->

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
      CreatedBy MTDUONG (14/06/2021)
    -->
    <div class="d-flex table-footer py-7 justify-space-between align-center">
      <div class="px-6 font-weight-bold">
        Tổng số tài sản: {{ assetCount() }}
      </div>
      <div class="px-x font-weight-bold tonggia">
        Tổng nguyên giá: {{ priceSumFunc() }}
      </div>
    </div>

    <!--
      Thông báo xóa 
      CreatedBy MTDUONG (17/06/2021)
    -->
    <v-dialog v-model="deleteDialog" max-width="350">
      <v-card>
        <v-card-title class="text-h5"> Thông báo </v-card-title>
        <v-card-text class="red--text text-h6"
          >Bạn có chắc muốn xóa dữ liệu</v-card-text
        >
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" text @click="deleteDialog = false">
            Hủy
          </v-btn>
          <v-btn color="green darken-1" text @click="deleteDialog = false">
            Đồng ý
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!--
      FORM
      CreatedBy MTDUONG (17/06/2021)
      -->
    <FormDetails v-if="$store.state.isOpen"/>
  </div>
</template>

<script>
import "../assets/css/ghitang.css";
import moment from "moment";
import FormDetails from "../components/FormDetails.vue";
import headers from "../common/header-table";
const axios = require("axios");
export default {
  name: "taisan",
  components: {
    FormDetails,
  },
  props:{
    editedItem: Object
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

      // Loading icon khi load data
      // CreatedBy MTDUONG (17/06/2021)
      overlay: true,

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

      // Tọa độ chuột và trạng thái của context menu
      showMenu: false,
      x: 0,
      y: 0,
    };
  },
  // Di chuyển bằng phím mũi tên

  created() {
    this.loadData();
    

  },

  mounted() {
    
    // Focus vào ô input tìm kiếm
    this.focusInput();

    this.priceSumFunc()
  },
  methods: {
    edit(){
    },
    // Load dữ liệu
    // CreadtedBy MTDUONG (17/06/2021)
    async loadData() {
      await axios.get("https://localhost:44331/api/assets/").then((res) => {
        this.assets = res.data;
        this.overlay = false;
      });
    },

     

    // Load lại dữ liệu
    // CreatedBy MTDUONG (17/06/2021)
    reloadTable() {
      this.overlay = true;
      this.loadData();
    },

    // CreatedBy MTDUONG (17/06/2021)
    // Filter theo tên và mã nhân viên
    // CreatedBy MTDUONG(13/06/2021)
    searchByNameAndCode(value, search, item) {
      let inName = RegExp(search, "i").test(item.assetName);
      let inCode = RegExp(search, "i").test(item.assetCode);
      return inName || inCode;
    },

    // Tính tổng tài sản
    // CreatdBy MTDUONG (15/06/2021)
    assetCount() {
      return this.assets.length;
    },

    // Tính tổng nguyên giá (chưa hoạt động)
    // CreatedBY MTDUONG (14/06/2021)
    priceSumFunc() {
      var sum = 0;
      this.assets.filter((data)=>{
        sum += data.originalPrice;
      })

      return sum = this.formatMoney(sum);
    },

    // Đổ data lên form khi sửa (Chưa xong )
    // CreatedBy MTDUONG (15/06/2021)

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
      console.log(e)
    },

    // Sự kiện khi click vào dòng trong context menu
    // CreatedBy MTDUONG (15/06/2021)
    handleClick(index) {
      this.items[index].click.call(this);
    },

    // Format tiền
    // CreatedBy MTDUONG (15/06/2021)
    formatMoney(money) {
      return money === null
        ? "0"
        : !isNaN(money)
        ? money.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.")
        : money;
    },
    // Format ngày tháng
    // CreatedBy MTDUONG (15/06/2021)
    formatDate(date) {
      return date ? moment(String(date)).format("DD/MM/YYYY") : '';
    },

    // Focus input
    // CreatedBy MTDUONG (17/06/2021)
    focusInput(){
      this.$refs.search.focus()
    }
  },
};
</script>

<style scoped>



</style>