<template>
  <div class="main-content">
    <div class="toolbar">
      <div>
        <!--
          Ô input tìm kiếm
          CreatedBy MTDUONG (14/06/2021)
        -->
        <v-text-field
          placeholder="Tìm kiếm"
          outlined
          flat
          v-model="search"
          single-line
          hide-details
        >
          <template v-slot:append>
            <img
              width="24"
              height="24"
              src="../assets/icon/search-eye-line.svg"
            />
          </template>
        </v-text-field>
      </div>

      <!--
        3 nút bấm: Thêm, load lại bảng và xóa
        CreatedBy MTDUONG (14/06/2021)
      -->
      <div class="btn-group d-flex align-center">
        <v-btn color="#00abfe" small class="white--text px-7 py-4">Thêm</v-btn>
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
        :items="items"
        :headers="headers"
        fixed-header
        height="770"
        :custom-filter="filter"
        hide-default-footer
        disable-pagination
      >
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
                  v-bind="attrs" v-on="on"
                ></v-img>
              </template>
              <span>Xóa</span>
            </v-tooltip>
          </div>
        </template>
      </v-data-table>
    </div>

    <!--
      Thông tin về tổng số tài sản và tổng nguyên giá
      CreatedBy MTDUONg (14/06/2021)
    -->
    <div class="d-flex table-footer py-8 justify-space-between align-center">
      <div class="px-6 font-weight-bold">Tổng số tài sản: {{propertySum}}</div>
      <div class="px-6 font-weight-bold">Tổng nguyên giá: {{priceSumFunc()}}</div>
    </div>
  </div>
</template>

<script>
import data from "./data";
export default {
  name: "taisan",
  data() {
    return {

      // Chứa các thông tin của table headers
      // CreatedBy MTDUONG (14/06/2021)
      headers: [
        { text: "STT", value: "STT", sortable: false },
        { text: "NGÀY GHI TĂNG", value: "Date", sortable: false },
        { text: "MÃ TÀI SẢN", value: "PropertyCode", sortable: false },
        { text: "TÊN TÀI SẢN", value: "PropertyName", sortable: false },
        { text: "LOẠI TÀI SẢN", value: "PropertyType", sortable: false },
        { text: "PHÒNG BAN", value: "Department", sortable: false },
        { text: "NGUYÊN GIÁ", value: "Price", sortable: false },
        { text: "CHỨC NĂNG", value: "actions", sortable: false },
      ],

      // Dùng để lưu trữ dữ liệu để truyền lên table
      // CreatedBy MTDUONG (14/06/2021)
      items: data,

      // model dùng cho chức năng tìm kiếm
      search: "",

      // Tính tổng số tài sản
      // CreatedBy MTDUONG (14/06/2021)
      propertySum: data.length,

      // Tính tổng nguyên giá
      // CreatedBy MTDUONG (14/06/2021)
      priceSum: ''
    };
  },
  computed:{
    
  },
  
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
    priceSumFunc(items){
      for(item in items){
        this.priceSum += parseInt(item.Price);
      }
      return this.priceSum;
    }
  },
};
</script>

<style lang="scss">
.table-footer{
}
.btn-hover:hover {
  cursor: pointer;
  background-color: #dddddd;
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
table td + td {
  border-left: 1px solid #dddddd;
}
.v-data-table__wrapper table tbody tr td{
    height: 38px !important;
}
tr:hover {
  background-color: #f0f8ff;
}
.ghitang {
  background-color: aquamarine;
}
.v-input{
    font-size: 13px !important;
}
.toolbar {
  display: flex;
  justify-content: space-between;
  padding: 0 24px 0 24px;
}

</style>