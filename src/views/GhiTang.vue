<template>
  <div class="main-content">
    <div class="toolbar">
      <div class="search-icon">
        <!--
          Ô input tìm kiếm
          CreatedBy MTDUONG (14/06/2021)
        -->
        <input
          type="text"
          v-model="search"
          placeholder="Tìm kiếm"
          class="search-bar"
        />
      </div>

      <!--
        3 nút bấm: Thêm, load lại bảng và xóa
        CreatedBy MTDUONG (14/06/2021)
      -->
      <div class="btn-group d-flex align-center">
        <v-btn color="#00abfe" small class="white--text px-7 py-4" @click="$store.commit('changeFormState')">Thêm</v-btn>
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
      CreatedBy MTDUONg (14/06/2021)
    -->
    <div class="table">
      <v-data-table
        :items="assets"
        :headers="headers"
        fixed-header
        :custom-filter="filter"
        hide-default-footer
        disable-pagination
      >
        <template #items="{ item }">
          <tr>
            <td>{{ item.STT }}</td>
            <td>{{ item.PropertyCode }}</td>
            <td>{{ item.PropertyName }}</td>
            <td>{{ item.PropertyType }}</td>
            <td>{{ item.Department }}</td>
            <td>{{ item.Price }}</td>
          </tr>
        </template>
        <template #item.actions="{ item }">
          <div class="d-flex align-center">
            <v-tooltip bottom>
              <template #activator="{ on, attrs }">
                <v-icon small class="mr-2 btn-hover" v-bind="attrs" v-on="on">
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
                <v-icon small class="ml-2 btn-hover" v-bind="attrs" v-on="on">
                  mdi-history
                </v-icon>
              </template>
              <span>Nhân bản dữ liệu</span>
            </v-tooltip>
          </div>
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
    
  </div>
</template>

<script>
import data from "./data";
export default {
  name: "taisan",
  components:{
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
      priceSum: "",

      // Chọn nhiều dòng

    };
  },
  computed: {},
  
  methods: {
    // Filter theo tên và mã nhân viên
    // CreatedBy MTDUONG(13/06/2021)
    filter(value, search, item) {
      let inName = RegExp(search, "i").test(item.PropertyName);
      let inCode = false;
      return inName || inCode;
    },

    // Tính tổng nguyên giá
    // CreatedBY MTDUONG (14/06/2021)
    priceSumFunc(data) {
      for (item in data) {
        this.priceSum += parseInt(item.Price);
      }
      return this.priceSum;
    },

    
  },
};
</script>

<style lang="scss">

@media only screen and (min-device-width: 768px) and (max-device-width: 1024px) {
  .v-data-table__wrapper {
    height: 590px;
  }
}
@media only screen and (min-device-width: 1025px) and (max-device-width: 1920px) {
  .v-data-table__wrapper {
    height: 785px;
  }
}

table > tbody > tr > td:last-child,
table > thead > tr > th:last-child {
  position: sticky !important;
  position: -webkit-sticky !important;
  right: 0;
  background-color: #ffffff;
}
table > thead > tr > th:nth-child(1) {
  z-index: 9999;
}
.tonggia {
  margin-right: 200px;
}
.search-icon {
  background-image: url("../assets/icon/search-eye-line.svg");
  width: 20px;
  height: 20px;
  background-repeat: no-repeat;
}
.search-bar {
  min-width: 300px;
  height: 34px;
  border: 1px solid #dddddd;
  border-radius: 4px;
  text-indent: 8px;
}
.btn-hover:hover {
  cursor: pointer;
  
}
.btn-delete:hover, .btn-reload:hover{
  background-color: #dddddd;
  transform: scale(1.1);
}
.btn-reload {
  margin: 0 10px;
}
.btn-delete,
.btn-reload {
  border: 1px solid #dddddd;
  border-radius: 4px;
  padding: 8px;
}
.v-data-table {
  padding: 0 24px 0 24px;
  border-bottom: 1px solid #dddddd;
}
table th + th {
  font-size: 15px;
}
table td + td {
  font-size: 13px !important;
  border-left: 1px solid #dddddd;
}
.v-data-table__wrapper table > tbody > tr > td {
  height: 38px !important;
}
.v-data-table__wrapper > table > thead > tr > th {
  font-size: 11px !important;
}
.v-data-table__wrapper > table > thead > tr:hover {
}
tr:hover {
  background-color: #f0f8ff;
}
.ghitang {
  background-color: aquamarine;
}
.v-input {
  font-size: 13px !important;
}
.toolbar {
  display: flex;
  justify-content: space-between;
  padding: 0 24px 0 24px;
  margin: 16px 0;
}
</style>