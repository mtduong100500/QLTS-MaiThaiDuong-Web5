<template>
  <!-- 
    Overlay để hiện Form
    CreatedBy MTDUONG (14/06/2021)
  -->
  <div class="overlay" @keyup.esc="closeDialog = true">
    <!--
      Nội dung chính của Form
      CreatedBy MTDUONG (14/06/2021)
    -->
    <v-form class="form d-flex flex-column" ref="form">
      <div class="form-header d-flex justify-space-between px-6">
        <h2 class="mt-8 my-12">Ghi tăng tài sản</h2>
        <div class="btn-group d-flex mt-6">
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-img
                src="../assets/icon/help.svg"
                max-width="15"
                max-height="15"
                v-on="on"
                v-bind="attrs"
                class="btn-hover"
                @click="developingDialog = true"
              ></v-img>
            </template>
            <span>Trợ giúp</span>
          </v-tooltip>
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-img
                src="../assets/icon/cancel.svg"
                max-width="15"
                max-height="15"
                v-on="on"
                v-bind="attrs"
                class="btn-hover ml-2 mr-4"
                @click="closeDialog = true"
              ></v-img>
            </template>
            <span>Thoát</span>
          </v-tooltip>
        </div>
      </div>
      <div class="main-form px-6 mb-4" >
        <!--Dòng 1-->
        <v-row justify="space-around">
          
          <v-col md="4">
            <v-btn class="elevation-0" plain color="#dddddd"  @keyup.tab="focusLast" small max-width="3" width="3"></v-btn>
            <div v-show="hide">
              <v-btn @keyup.shift.tab="focusLast"></v-btn>
            </div>
            <div class="d-flex flex-column">
              <label class="mb-5">Mã tài sản (*)</label>
              <v-text-field
               outlined
               v-model="assetCode"
               :rules="inputRules"
               autofocus
               tabindex="0"
               ref="firstInput"
              ></v-text-field>
            </div>
            
          </v-col>
          <v-col md="8">
            <div class="d-flex flex-column">
              <label class="mb-5">Tên tài sản (*)</label>
              <v-text-field
              v-model="assetName"
               outlined
               :rules="inputRules"
              ></v-text-field>
            </div>
          </v-col>
        </v-row>

        <!-- Dòng 2 -->
        <v-row justify="space-around">
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Mã phòng ban</label>
              <v-autocomplete
                dense
                outlined
                auto-select-first
                :items="departmentCombo"
                v-model="department"
                item-text="departmentCode"
                item-value="departmentName"
              ></v-autocomplete>
            </div>
          </v-col>
          <v-col md="8">
            <div class="d-flex flex-column">
              <label class="mb-3">Tên phòng ban</label>
              <input
                type="text"
                class="input-disabled"
                disabled
                v-model="department"
              />
            </div>
          </v-col>
        </v-row>

        <!-- Dòng 3 -->
        <v-row justify="space-around">
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Mã loại tài sản</label>
              <v-autocomplete
                dense
                outlined
                auto-select-first
                :items="assetTypeCombo"
                v-model="assetsType"
                item-text="assetTypeCode"
                item-value="assetTypeName"
              ></v-autocomplete>
            </div>
          </v-col>
          <v-col md="8">
            <div class="d-flex flex-column">
              <label class="mb-3">Tên loại tài sản</label>
              <input
                type="text"
                class="input-disabled"
                disabled
                v-model="assetsType"
              />
            </div>
          </v-col>
        </v-row>

        <!--Dòng 4-->
        <v-row justify="space-around">
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Ngày ghi tăng</label>
              <v-menu
                v-model="menu2"
                :close-on-content-click="false"
                transition="scale-transition"
                offset-y
                min-width="auto"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    readonly
                    v-bind="attrs"
                    v-on="on"
                    outlined
                    :value="formatDateWithMomentJS"
                  >
                    <template v-slot:append>
                      <img
                        max-width="24"
                        max-height="24"
                        src="../assets/icon/calendar-60.svg"
                      />
                    </template>
                  </v-text-field>
                </template>
                <v-date-picker
                  :first-day-of-week="1"
                  locale="vi-VN"
                  v-model="date"
                  no-title
                  @input="menu2 = false"
                ></v-date-picker>
              </v-menu>
            </div>
          </v-col>
          <v-col class="d-flex" md="8">
            <div class="d-flex flex-column">
              <label class="mb-3">Thời gian sử dụng (năm)</label>
              <v-text-field outlined :rules="inputNumberRules" ></v-text-field>
            </div>
            <div class="d-flex flex-column ml-6">
              <label class="mb-3">Tỉ lệ hao mòn (%)</label>
              <v-text-field outlined :rules="inputNumberRules"></v-text-field>
            </div>
          </v-col>
        </v-row>

        <!--Dòng 5-->
        <v-row>
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Nguyên giá</label>
              <v-text-field outlined :rules="inputNumberRules"></v-text-field>
            </div>
          </v-col>
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Giá trị hao mòn năm</label>
              <v-text-field outlined :rules="inputNumberRules" ref="lastInput"></v-text-field>
            </div>
          </v-col>
        </v-row>
      </div>
      <!--
        Hai nút bấm dưới cùng của FORM
        CreatedBy MTDUONG (17/05/2021)
      -->
      <div
        class="btn d-flex justify-space-between py-2"
        style="background-color: #dddddd; height: 100%"
      >
        <div class="d-flex align-center" @click="closeDialog = true">
          <v-btn
            class="mx-6 px-9 elevation-0 text-capitalize"
            
            >Hủy</v-btn
          >
        </div>
        
        <div class="d-flex align-center" @click="submit">
          <v-btn
            color="#00abfe"
            class="white--text px-9 py-4  elevation-0 text-capitalize"
            >Lưu</v-btn
          >
        <v-btn class="elevation-0" plain color="#dddddd"  @keyup.tab="focusFirst" small max-width="3" width="3"></v-btn>

        </div>
      </div>
    </v-form>

    <!--
      Thông báo đóng cửa sổ
      CreatedBy MTDUONG (17/06/2021)
    -->
    <v-dialog
      v-model="closeDialog"
      persistent
      max-width="350"
      no-click-animation
    >
      <v-card>
        <v-card-title class="text-h5">
         Thông báo
        </v-card-title >
        <v-card-text class="text-h6">Bạn có chắc muốn đóng cửa sổ này? </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="green darken-1"
            text
            @click="closeDialog = false"
          >
            Hủy
          </v-btn>
          <v-btn
            color="green darken-1"
            text
            @click="$store.commit('changeFormState')"
          >
            Đồng ý
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!--
      Thông báo chức năng đang được phát triển
      CreatedBy MTDUONG (17/06/2021)
    -->
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
import moment from "moment";
import "../assets/css/formdetails.css";
import axios from 'axios';
export default {
  name: "FormDetails",
  data() {
    return {
      
      // Trạng thái của các thông báo
      // CreatedBy MTDUONG (17/05/2021)
      developingDialog: false,
      closeDialog: false,

      // Model của các input
      // CreatedBy MTDUONG (17/05/2021)
      assetName:'',
      assetCode:'',

      // Select Box loại tài sản
      // CreatedBy MTDUONG (15/05/2021)
      assetsType: null,
      assetTypeCombo: [],

      // Select Box loại tài sản
      // CreatedBy MTDUONG (15/05/2021)
      department: null,
      departmentCombo: [],

      // Datepicker
      // CreatedBy MTDUONG (15/05/2021)
      menu2: false,
      date: "",

      // Validate input text
      // CreatedBy MTDUONG (17/05/2021)
      inputRules:[
        v => v && v.length >= 3 || 'Cần nhập ít nhất 3 kí tự',
        v => v && v.length <= 10 || 'Chỉ có thể nhập nhiều nhất 10 kí tự'
      ],

      // Validate input số
      // CreatedBy MTDUONG (17/05/2021)
      inputNumberRules:[
        v => v && v.length >= 3 || 'Cần nhập ít nhất 3 kí tự',
        v => v && !isNaN(v) || "Bạn chỉ được nhập chữ số",
        v => v && v.length <= 10 || 'Chỉ có thể nhập nhiều nhất 10 kí tự'
      ],

 
    };
  },
  created() {
    this.getComboDepartmentData()
    this.getComboAssetTypeData()
  },
   
  computed: {
    // Format text hiện trên datepicker
    formatDateWithMomentJS() {
      return this.date ? moment(String(this.date)).format("DD/MM/YYYY") : "";
    },
  },
  methods: {
    // Validate Form
    submit(){
      if(this.$refs.form.validate()){
        console.log('Lỗi')
      }
    },
    // Focus vào input đầu
    // CreatedBy MTDUONG (18/06/2021)
    focusFirst(){
      this.$refs.firstInput.focus()
    },

    // Focus vào input cuối
    // CreatedBy MTDUONG (18/06/2021)
    focusLast(){
      this.$refs.lastInput.focus()
    },

    // Lấy data đổ vào combobox loại tài sản
    // CreatedBy MTDUONG (18/06/2021)
    async getComboAssetTypeData(){
      await axios.get("https://localhost:44331/api/AssetTypes").then(res => {
        this.assetTypeCombo = res.data
      })
    },

    // Lấy data đổ vào combobox phòng ban
    // CreatedBy MTDUONG (18/06/2021)
    async getComboDepartmentData(){
      await axios.get("https://localhost:44331/api/Departments").then(res => {
        this.departmentCombo = res.data
      })
    }
    
  },
};
</script>

<style>
</style>