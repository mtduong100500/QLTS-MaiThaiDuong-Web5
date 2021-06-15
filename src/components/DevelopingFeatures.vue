<template>
  <div class="overlays">
    <!--
            Tiêu đề và nút bấm
            CreatedBy MTDUONG (15/06/2021)
        -->
      <v-alert prominent type="info" class="developing-feature">
        <v-row align="center" class="d-flex flex-column align-center justify pt-7">
          <v-col class="grow">
            Tính năng này đang được phát triển
          </v-col>
          <v-col class="shrink mt-4">
            <v-btn @click="$store.commit('changeDevelopingState')" class="ml-12"
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
.developing-feature {
  background-color: #ffffff;
  position: fixed;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  height: 150px;
  width: 350px;
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