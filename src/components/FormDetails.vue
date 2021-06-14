<template>
  <v-overlay :value="overlay">
    <div class="form">
      <div class="form-header d-flex justify-space-between">
          <h2 class="mt-10 mx-4">Ghi tăng tài sản</h2>
        <div class="btn-group d-flex  my-6">
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-img
                src="../assets/icon/help.svg"
                width="20"
                height="20"
                v-on="on"
                v-bind="attrs"
                class="btn-hover"
              ></v-img>
            </template>
            <span>Trợ giúp</span>
          </v-tooltip>
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-img
                src="../assets/icon/cancel.svg"
                width="20"
                height="20"
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
    </div>
  </v-overlay>
</template>

<script>
export default {
  name: "FormDetails",
};
</script>

<style scoped>
.form {
  background-color: #ffffff;
  position: fixed;
  height: 700px;
  width: 800px;
  top: 120px;
  left: 560px;
  z-index: 2;
  font-family: "GoogleSans-Regular";
  color: #000000;
}

</style>