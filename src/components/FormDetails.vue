<template>
  <div class="overlay" @keyup.esc="$store.commit('changeFormState')">
    <div class="form d-flex flex-column">
      <div class="form-header d-flex justify-space-between">
        <h2 class="mt-8 mx-4">Ghi tăng tài sản</h2>
        <div class="btn-group d-flex my-6 mx-2">
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
      <div class="main-form">
        <!--Dòng 1-->
        <div class="row1 d-flex justify-space-between" >
          <div class="col1 mx-6">
            <div class="fields d-flex flex-column">
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
          </div>
          <div class="col2 mx-6">
            <div class="fields d-flex flex-column">
              <label class="mb-5">Tên tài sản (*)</label>
              <input type="text" class="input-disabled" disabled v-model="assets"/>
            </div>
          </div>
        </div>

        <!-- Dòng 2 -->
        <div class="row2 d-flex justify-space-between">
          <div class="col1 mx-6">
            <div class="fields d-flex flex-column">
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
          </div>
          <div class="col2 mx-6">
            <div class="fields d-flex flex-column">
              <label class="mb-3">Tên phòng ban (*)</label>
              <input type="text" class="input-disabled" disabled v-model="departments"/>
            </div>
          </div>
        </div>

        <!-- Dòng 3 -->
        <div class="row3 d-flex justify-space-between">
          <div class="col1 mx-6">
            <div class="fields d-flex flex-column">
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
          </div>
          <div class="col2 mx-6">
            <div class="fields d-flex flex-column">
              <label class="mb-3">Tên loại tài sản (*)</label>
              <input type="text" class="input-disabled" disabled v-model="assetsType"/>
            </div>
          </div>
        </div>

        <!--Dòng 4-->
        <div class="row4 d-flex justify-space-between">
          <div class="col1 mx-6">
            <div class="fields d-flex flex-column">
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
                  ></v-text-field>
                </template>
                <v-date-picker
                  v-model="date"
                  no-title
                  @input="menu2 = false"
                ></v-date-picker>
              </v-menu>
            </div>
          </div>
          <div class="col2 mx-6 d-flex justify-space-between">
            <div class="fields d-flex flex-column mr-4">
              <label class="mb-3">Thời gian sử dụng (năm)</label>
              <v-text-field
              outlined
              ></v-text-field>
            </div>
            <div class="fields d-flex flex-column">
              <label class="mb-3">Tỉ lệ hao mòn (%)</label>
              <v-text-field
              outlined
              ></v-text-field>
            </div>
          </div>
        </div>

        <!--Dòng 5-->
        <div class="row5 d-flex justify-space-between">
          <div class="col1 mx-6">
            <div class="fields d-flex flex-column">
              <label class="mb-3">Nguyên giá</label>
              <v-text-field
              outlined
              ></v-text-field>
            </div>
          </div>
          <div class="col2 mx-6">
            <div class="fields d-flex flex-column">
              <label class="mb-3">Giá trị hao mòn năm</label>
              <v-text-field
              outlined
              ></v-text-field>
            </div>
          </div>
        </div>
      </div>
      <div class="btn d-flex justify-space-between">
        <v-btn
        class="mx-6"
        >Hủy</v-btn>
        <v-btn
        color="#00abfe"
        class="white--text px-5 py-4 mx-6"
        >Lưu</v-btn>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "FormDetails",
  data() {
    return {
      assetsCodes: [
        {
          assetCode: "TS00001",
          assetName: "Laptop DEll"
        },
        {
          assetCode: "TS00002",
          assetName: "Laptop HP"
        },
        {
          assetCode: "TS00003",
          assetName: "Laptop ASUS"
        },
      ],
      departmentCodes: [
        {
          departmentCode: "DP0001",
          departmentName: "Phòng Đào tạo"
        },
        {
          departmentCode: "DP0002",
          departmentName: "Phòng hành chính"
        },
      ],
      assetTypeCodes: [
        {
          assetTypeCode: "DP0001",
          assetTypeName: "Laptop"
        },
        {
          assetTypeCode: "DP0002",
          assetTypeName: "PC"
        },
      ],
      menu2: false,
      date: '',
      assets: {
        assetCode: "",
        assetName: ""
      },
      departments: {
        departmentCode: "",
        departmentName: ""
      },
      assetsType: {
        assetTypeCode: "",
        assetTypeName: ""
      },
    };
  },
  methods:{
    test(){
      console.log(this.assets)
    }
  }
};
</script>

<style>

.v-text-field--outlined fieldset {
  border-radius: 0 !important;
  border-color: #dddddd !important;
}

.v-text-field--full-width.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__prepend-outer, .v-text-field--full-width.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__prepend-inner, .v-text-field--full-width.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__append-inner, .v-text-field--full-width.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__append-outer, .v-text-field--enclosed.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__prepend-outer, .v-text-field--enclosed.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__prepend-inner, .v-text-field--enclosed.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__append-inner, .v-text-field--enclosed.v-input--dense:not(.v-text-field--solo).v-text-field--outlined .v-input__append-outer {
    margin-top: 4px !important;
}
.v-input__control{
  min-height: 30px !important;
}
.v-text-field .v-input__control .v-input__slot {
    min-height: auto !important;
    display: flex !important;
    align-items: center !important;
  }

.form {
  background-color: #ffffff;
  position: fixed;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  height: 700px;
  width: 800px;
  z-index: 2;
  font-family: "GoogleSans-Regular";
  color: #000000;
}

.input-disabled {
  border: 1px solid #dddddd;
  height: 32px;
  width: 400px;
  background-color: #f5f5f5;
  text-indent: 10px;
}

@media only screen and (min-device-width: 768px) and (max-device-width: 1024px) {
  .form {
    height: 500px;
    width: 650px;
  }
}
@media only screen and (min-device-width: 1025px) and (max-device-width: 1920px) {
  .form {
    height: 500px;
    width: 700px;
  }
}

.overlay {
  position: fixed;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 2;
}
</style>