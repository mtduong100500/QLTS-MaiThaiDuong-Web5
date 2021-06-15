<template>
  <!-- 
    Overlay để hiện Form
    CreatedBy MTDUONG (14/06/2021)
  -->
  <div class="overlay" @keyup.esc="$store.commit('changeFormState')">
    <!--
      Nội dung chính của Form
      CreatedBy MTDUONG (14/06/2021)
    -->
    <v-container class="form d-flex flex-column">
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
                @click="test"
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
                @click="$store.commit('changeFormState')"
              ></v-img>
            </template>
            <span>Thoát</span>
          </v-tooltip>
        </div>
      </div>
      <div class="main-form px-6 mb-4">
        <!--Dòng 1-->
        <v-row justify="space-around">
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-5">Mã tài sản (*)</label>
              <v-autocomplete
                dense
                outlined
                auto-select-first
                class="elevation-0"
                autofocus
                :items="assetsCodes"
                v-model="assets"
                item-text="assetCode"
                item-value="assetName"
              ></v-autocomplete>
            </div>
          </v-col>
          <v-col md="8">
            <div class="d-flex flex-column">
              <label class="mb-5">Tên tài sản (*)</label>
              <input
                type="text"
                class="input-disabled"
                disabled
                v-model="assets"
              />
            </div>
          </v-col>
        </v-row>

        <!-- Dòng 2 -->
        <v-row justify="space-around">
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Mã phòng ban (*)</label>
              <v-autocomplete
                dense
                outlined
                auto-select-first
                :items="departmentCodes"
                v-model="departments"
                item-text="departmentCode"
                item-value="departmentName"
              ></v-autocomplete>
            </div>
          </v-col>
          <v-col md="8">
            <div class="d-flex flex-column">
              <label class="mb-3">Tên phòng ban (*)</label>
              <input
                type="text"
                class="input-disabled"
                disabled
                v-model="departments"
              />
            </div>
          </v-col>
        </v-row>

        <!-- Dòng 3 -->
        <v-row justify="space-around">
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Mã loại tài sản (*)</label>
              <v-autocomplete
                dense
                outlined
                auto-select-first
                :items="assetTypeCodes"
                v-model="assetsType"
                item-text="assetTypeCode"
                item-value="assetTypeName"
              ></v-autocomplete>
            </div>
          </v-col>
          <v-col md="8">
            <div class="d-flex flex-column">
              <label class="mb-3">Tên loại tài sản (*)</label>
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
                    v-model="date"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                    outlined
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
              <v-text-field outlined></v-text-field>
            </div>
            <div class="d-flex flex-column ml-6">
              <label class="mb-3">Tỉ lệ hao mòn (%)</label>
              <v-text-field outlined></v-text-field>
            </div>
          </v-col>
        </v-row>

        <!--Dòng 5-->
        <v-row>
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Nguyên giá</label>
              <v-text-field outlined></v-text-field>
            </div>
          </v-col>
          <v-col md="4">
            <div class="d-flex flex-column">
              <label class="mb-3">Giá trị hao mòn năm</label>
              <v-text-field outlined></v-text-field>
            </div>
          </v-col>
        </v-row>
      </div>
      <!---->
      <div class="btn d-flex justify-space-between py-2" style="background-color: #dddddd; height:100%">
        <div class="d-flex align-center">
            <v-btn class="mx-6 px-9 elevation-0 text-capitalize ">Hủy</v-btn>
        </div>
        <div class="d-flex align-center">
          <v-btn color="#00abfe" class="white--text px-9 py-4 mx-6 elevation-0 text-capitalize">Lưu</v-btn>
        </div>
      </div>
    </v-container>
  </div>
</template>

<script>
import '../assets/css/formdetails.css'
export default {
  name: "FormDetails",
  data() {
    return {
      assets: null,
      departments: null,
      assetsType: null,
      assetsCodes: [
        {
          assetCode: "TS00001",
          assetName: "Laptop DEll",
        },
        {
          assetCode: "TS00002",
          assetName: "Laptop HP",
        },
        {
          assetCode: "TS00003",
          assetName: "Laptop ASUS",
        },
      ],
      departmentCodes: [
        {
          departmentCode: "DP0001",
          departmentName: "Phòng Đào tạo",
        },
        {
          departmentCode: "DP0002",
          departmentName: "Phòng hành chính",
        },
      ],
      assetTypeCodes: [
        {
          assetTypeCode: "DP0001",
          assetTypeName: "Laptop",
        },
        {
          assetTypeCode: "DP0002",
          assetTypeName: "PC",
        },
      ],
      menu2: false,
      date: "",
    };
  },
  methods: {
    test() {},
  },
};
</script>

<style>

</style>