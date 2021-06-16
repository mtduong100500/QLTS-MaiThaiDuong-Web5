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
            <div class="btn-delete btn-hover" v-on="on" v-bind="attrs">
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
        :custom-filter="filter"
        hide-default-footer
        disable-pagination
        v-model="selectedRows"
      >
        <template #item="{ item }" > 
          <tr @contextmenu.prevent="show" :class="[selectedRows.indexOf(item.STT)>-1?'cyan':'' ]" @click.ctrl.prevent="rowClicked(item)" >
            <td>{{ item.STT }}</td>
            <td class="text-center">{{ item.Date }}</td>
            <td>{{ item.PropertyCode }}</td>
            <td>{{ item.PropertyName }}</td>
            <td>{{ item.PropertyType }}</td>
            <td>{{ item.Department }}</td>
            <td class="text-right">{{ formatMoney(item.Price) }}</td>

            <!-- 
              3 nút sửa xóa nhân bản trong mỗi dòng của table
              CreatedBy MTDUONG (14/06/2021)
            -->
            <td :class="selectedRows.indexOf(item.STT)>-1?'cyan':''">
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
        Tổng số tài sản: {{ propertySum }}
      </div>
      <div class="px-x font-weight-bold tonggia">
        Tổng nguyên giá: {{ priceSumFunc() }}
      </div>
    </div>
    <FormDetails v-if="$store.state.isOpen" />
  </div>
</template>

<script>
import data from "./data";
import "../assets/css/ghitang.css";
import FormDetails from "../components/FormDetails.vue";

export default {
  name: "taisan",
  components: {
    FormDetails,
  },
  data() {
    return {
      // Chứa các thông tin của table headers
      // CreatedBy MTDUONG (14/06/2021)
      headers: [
        { text: "STT", value: "STT", width: "80px", sortable: false },
        {
          text: "NGÀY GHI TĂNG",
          value: "Date",
          width: "140px",
          sortable: false,
        },
        {
          text: "MÃ TÀI SẢN",
          value: "PropertyCode",
          width: "100px",
          sortable: false,
        },
        {
          text: "TÊN TÀI SẢN",
          value: "PropertyName",
          width: "600px",
          sortable: false,
        },
        {
          text: "LOẠI TÀI SẢN",
          value: "PropertyType",
          width: "150px",
          sortable: false,
        },
        {
          text: "PHÒNG BAN",
          value: "Department",
          width: "250px",
          sortable: false,
        },
        { text: "NGUYÊN GIÁ", value: "Price", width: "150px", sortable: false },
        {
          text: "CHỨC NĂNG",
          value: "actions",
          width: "100px",
          sortable: false,
          fixed: true,
        },
      ],

      // Dùng để lưu trữ dữ liệu để truyền lên table
      // CreatedBy MTDUONG (14/06/2021)
      assets: data,

      // model dùng cho chức năng tìm kiếm
      search: "",

      // Tính tổng số tài sản
      // CreatedBy MTDUONG (14/06/2021)
      propertySum: data.length,

      // Tính tổng nguyên giá
      // CreatedBy MTDUONG (14/06/2021)
      priceSum: 0,

      // đổ dữ liệu lên form khi sửa
      // CreatedBy MTDUONG (15/06/2021)
      editedIndex: -1,
      editedItem: {
        STT: "",
        PropertyCode: "",
        PropertyName: "",
        PropertyType: "",
        Department: "",
        Price: "",
      },

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


  methods: {
    // Filter theo tên và mã nhân viên (Chưa hoạt động)
    // CreatedBy MTDUONG(13/06/2021)
    filter(value, search, item) {
      let inName = RegExp(search, "i").test(item.PropertyName);
      let inCode = false;
      return inName || inCode;
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
      this.toggleSelection(row.STT);
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