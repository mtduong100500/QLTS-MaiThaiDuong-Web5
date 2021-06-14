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
        <v-btn
          color="#00abfe"
          small
          class="white--text px-7 py-4"
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
          <tr class="table-content">
            <td>{{ item.STT }}</td>
            <td>{{ item.PropertyCode }}</td>
            <td>{{ item.PropertyName }}</td>
            <td>{{ item.PropertyType }}</td>
            <td>{{ item.Department }}</td>
            <td>{{ item.Price }}</td>
          </tr>
        </template>

        <!-- 
          3 nút sửa xóa nhân bản trong mỗi dòng của table
          CreatedBy MTDUONG (14/06/2021)
        -->
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
import '../assets/css/ghitang.css'
export default {
  name: "taisan",
  components: {},
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

<style>

</style>