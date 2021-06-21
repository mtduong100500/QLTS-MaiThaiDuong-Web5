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
        <v-text-field
          v-model="search"
          placeholder="Tìm kiếm"
          class="search-bar"
          outlined
          autofocus
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
          @click="
            $store.commit('changeFormState');
            status = 'add';
          "
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
              @click="reloadTable(); $store.commit('changeLoadingState')"
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
              @click="multipleDelete"
            >
              <v-img
                height="15"
                width="15"
                src="../assets/icon/trash.svg"
              ></v-img>
            </div>
          </template>
          <span>Xóa nhiều dòng</span>
        </v-tooltip>
      </div>
    </div>

    <!--
      Context Menu của table
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

    <!--
      Bảng dữ liệu
      CreatedBy MTDUONG (14/06/2021)
    -->
    <div class="table">
      <v-data-table
        v-model="selected"
        :items="assets"
        :headers="headers"
        :custom-filter="searchByNameAndCode"
        :search="search"
        fixed-header
        hide-default-footer
        disable-pagination
        no-data-text="Không có dữ liệu"
        no-results-text="Không có bản ghi nào được tìm thấy"
      >
        <template #item="{ item }">
          <tr
            @contextmenu.prevent="show($event, item)"
            :class="selected.indexOf(item.assetId) > -1 ? 'cyan lighten-4' : ''"
            @click.ctrl.stop.exact="rowClicked(item)"
          >
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
                      @click="
                        editItem(item);
                        status = 'edit';
                        $store.commit('changeEditFormState');
                      "
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
                      @click="
                        deleteItem(item);
                        deleteDialog = true;
                      "
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
                      @click="
                        duplicate(item);
                        status = 'duplicate';
                        $store.commit('changeDuplicateState');
                      "
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
      Thông báo khi thêm thành công
      CreatedBy MTDUONG (18/06/2021)
    -->
    <v-snackbar
      v-model="$store.state.successAdd"
      :timeout="timeout"
      color="success"
      right
      bottom
    >
      Thêm thành công
    </v-snackbar>
    <!--
      Thông báo khi sửa thành công
      CreatedBy MTDUONG (18/06/2021)
    -->
    <v-snackbar
      v-model="$store.state.successEdit"
      :timeout="timeout"
      color="success"
      right
      bottom
    >
      Sửa thành công
    </v-snackbar>

    <v-snackbar
      v-model="$store.state.successDelete"
      :timeout="timeout"
      color="success"
      right
      bottom
    >
      Xóa thành công
    </v-snackbar>
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
          <v-btn
            color="green darken-1"
            text
            @click="
              reloadTable();
              $store.commit('changeDeleteNoti')
              deleteDialog = false
            "
          >
            Đồng ý
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!--
      FORM thêm
      CreatedBy MTDUONG (17/06/2021)
      -->
    <FormDetails v-if="$store.state.isOpen" :status="status" />
    <!--
      FORM sửa
      CreatedBy MTDUONG (17/06/2021)
      -->
    <FormDetails
      v-if="$store.state.isEdited"
      :item="editedAsset"
      :status="status"
    />
    <!--
      Form nhân bản
      CreatedBy MTDUONG (19/06/2021)
    -->
    <FormDetails
      v-if="$store.state.isDuplicated"
      :item="duplicateAsset"
      :status="status"
    />
  </div>
</template>

<script>
import "../assets/css/ghitang.css";
import moment from "moment";
import FormDetails from "../components/FormDetails.vue";
import headers from "../common/header-table";
import api from "../service/api";

export default {
  name: "taisan",
  components: {
    FormDetails,
  },

  data() {
    return {
      // Thông báo thành công
      timeout: 2000,
      // Chứa thông tin các dòng được chọn
      // CreatedBy MTDUONG (19/06/2021)
      selected: [],

      // Trạng thái của FORM - Cho FORM biết được là thêm mới, sửa hay nhân bản
      // CreatedBy MTDUONG (19/06/2021)
      status: "",

      // Đổ dữ liệu để truyền lên props của Form nhân bản
      // CreatedBy MTDUONG (19/06/2021)
      duplicateAsset: {},

      // Đổ dữ liệu để truyền lên props của Form sửa
      // CreatedBy MTDUONG (19/06/2021)
      editedAsset: {},

      deleteDialog: false,
      // Chứa các thông tin của table headers
      // CreatedBy MTDUONG (14/06/2021)
      headers: headers,

      // Số thứ tự trong bản
      index: 0,
      // model dùng cho chức năng tìm kiếm
      search: "",

      // Tính tổng số tài sản
      // CreatedBy MTDUONG (14/06/2021)
      propertySum: "",

      // Tính tổng nguyên giá
      // CreatedBy MTDUONG (14/06/2021)
      priceSum: 0,

      // Context Menu
      // CreatedBy MTDUONG (15/06/2021)
      items: [
        // Ô thêm trong context Menu
        {
          title: "Thêm",
          click() {
            this.$store.commit("changeFormState");
            this.status = "add";
          },
        },
        // Ô sửa trong context Menu
        {
          title: "Sửa",
          click() {
            this.$store.commit("changeEditFormState");
            this.status = "edit";
            this.editedAsset = this.contextItem;
          },
        },
        // Ô xóa trong context Menu
        {
          title: "Xóa",
          click() {
            this.deleteDialog = true;
            this.deleteItem(this.contextItem);
          },
        },
        // Ô nhân bản trong context Menu
        {
          title: "Nhân bản",
          click() {
            this.$store.commit("changeDuplicateState");
            this.status = "duplicate";
            this.duplicateAsset = this.contextItem;
          },
        },
      ],

      // Tọa độ chuột và trạng thái của context menu
      showMenu: false,
      x: 0,
      y: 0,

      // Khởi tạo data của context menu
      // Khi chuột phải vào dòng trong bảng sẽ nhận vào thông tin của dòng trong bảng
      // CreatedBY MTDUONG(19/06/2021)
      contextItem: {},
    };
  },

  // Khởi tạo loading
  // CreatedBy MTDUONG (18/06/2021)
  created() {
    this.$store.commit("changeLoadingState");
  },

  // Khởi tạo 2 biến thay đổi trong VUEX
  // CreatedBy MTDUONG (18/06/2021)
  computed: {
    assets() {
      return this.$store.state.assets;
    },
    overlay() {
      return this.$store.state.overlay;
    },
  },

  // Tính tổng nguyên giá, load data
  // CreatedBy MTDUONG (18/06/2021)
  async mounted() {
    await this.$store.dispatch("loadData");
    this.priceSumFunc();
    this.$store.commit("changeLoadingState");
  },

  methods: {

    // Chọn nhiều dòng
    // CreatedBy MTDUONG (19/06/2021)
    rowClicked(row) {
      this.toggleSelection(row.assetId);
    },
    toggleSelection(keyID) {
      if (this.selected.includes(keyID)) {
        this.selected = this.selected.filter(
          (selectedKeyID) => selectedKeyID !== keyID
        );
      } else {
        this.selected.push(keyID);
      }
    },
    // Thay đổi trạng thái đóng mở của thông báo xóa
    // CreatedBy MTDUONG (18/06/2021)
    changeDelete() {
      this.deleteDialog = !this.deleteDialog;
    },


    // Xóa một bản ghi
    // CreatedBy MTDUONG (18/06/2021)
    async deleteItem(item) {
      await api()
        .delete(`/assets/${item.assetId}`)
        .then((res) => {
          this.deleteDialog = true;
        });
    },

    // Xóa nhiều
    // CreatedBy MTDUONG (19/06/2021)
    async multipleDelete(item) {
      for (item in this.selected) {
        if (this.selected.hasOwnProperty(item)) {
          var value = this.selected[item];
          await api().delete(`/assets/${value}`)
        }
      }
      this.deleteDialog = true
    },

    // Gán data cho props để truyền lên Form khi sửa
    // CreatedBy MTDUONG (18/06/2021)
    editItem(item) {
      this.editedAsset = item;
    },

    // Gán data cho props để truyền lên Form khi nhân bản
    // CreatedBy MTDUONG (18/06/2021)
    duplicate(item) {
      this.duplicateAsset = item;
    },

    // Load lại dữ liệu
    // CreatedBy MTDUONG (17/06/2021)
    reloadTable() {
      this.$store.dispatch("loadData");
    },

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

    // Tính tổng nguyên giá
    // CreatedBY MTDUONG (14/06/2021)
    priceSumFunc() {
      var sum = 0;
      this.assets.filter((data) => {
        sum += data.originalPrice;
      });

      return (sum = this.formatMoney(sum));
    },

    // Chuột phải sẽ hiện context menu
    // CreatedBy MTDUONG (15/06/2021)
    show(e, item) {
      e.preventDefault();
      this.showMenu = false;
      this.x = e.clientX;
      this.y = e.clientY;
      this.$nextTick(() => {
        this.showMenu = true;
      });
      this.contextItem = item;
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
      return date ? moment(String(date)).format("DD/MM/YYYY") : "";
    },

    // Focus input
    // CreatedBy MTDUONG (17/06/2021)
    focusInput() {
      this.$refs.search.focus();
    },
  },
};
</script>

<style scoped>
</style>