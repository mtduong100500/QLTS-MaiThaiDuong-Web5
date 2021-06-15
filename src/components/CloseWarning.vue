<template>
  <div class="overlays">
    <!--
            Tiêu đề và nút bấm
            CreatedBy MTDUONG (15/06/2021)
        -->
      <v-alert prominent type="info" class="close-feature">
        <v-row align="center" class="d-flex flex-column align-center justify pt-7 pl-3">
          <v-col class="grow">
            Bạn có chắc muốn đóng cửa sổ này?
          </v-col>
          <v-col class="shrink mt-4">
            <v-btn @click="$store.commit('changeFormState'), $store.commit('changeCloseConfirmState')" class="mr-10">
                Xác nhận
            </v-btn>
            <v-btn @click="$store.commit('changeCloseConfirmState')"
              >Quay trở lại</v-btn
            >
          </v-col>
        </v-row>
      </v-alert>
  </div>
</template>

<script>
export default {
  name: "DevelopingFeatures",
};
</script>

<style>
.close-feature {
  background-color: #ffffff;
  position: fixed;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  height: 150px;
  width: 380px;
  z-index: 11;
  font-family: "GoogleSans-Regular";
  color: #000000;
}
.overlays {
  position: fixed;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 10;
}
</style>