<template>
    <div class="d-flex">
        
        <div>
            <v-breadcrumbs :items="links"></v-breadcrumbs>
        </div>
        <v-spacer></v-spacer>
        <div class="d-flex align-center">
            <v-toolbar-title>Sở tài chính</v-toolbar-title>
            <v-select
            :items="years"
            label="Outlined style"
            dense
            outlined
            ></v-select>
            <v-avatar size="24">
                <!--
                <img
                    src="../assets/icon/avatar-default.png"
                    alt="Duong"
                >
                -->
            </v-avatar>
            <v-toolbar-title>Mai Thái Dương</v-toolbar-title>
            <v-btn icon class="d-flex align-start">
                <!--<v-img src="../assets/icon/option.png" height="24" contain></v-img>-->
            </v-btn>
        </div>
    </div>
    
</template>

<script>
export default {
    name: "Header",
    data(){
        return{
            links: [
                {
                text: 'Tài sản',
                disabled: false,
                href: '/taisan',
                },
                {
                text: 'Ghi tăng',
                disabled: true,
                href: 'breadcrumbs_link_2',
                },
            ],
            years: ['2019', '2020', '2021'],
        }
    }
}
</script>
<style scoped>

.v-responsive__content:hover{
    background-color: #ffffff;
}

</style>