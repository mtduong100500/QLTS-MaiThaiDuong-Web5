var headers = [
    { text: "STT", value: "index", width: "40px", sortable: false },
    {
        text: "NGÀY GHI TĂNG",
        value: "increaseDate",
        width: "140px",
        sortable: false,
        align: 'center',
    },
    {
        text: "MÃ TÀI SẢN",
        value: "assetCode",
        width: "100px",
        sortable: false,    
    },
    {
        text: "TÊN TÀI SẢN",
        value: "assetName",
        width: "600px",
        sortable: false,
    },
    {
        text: "LOẠI TÀI SẢN",
        value: "assetTypeName",
        width: "150px",
        sortable: false,
    },
    {
        text: "PHÒNG BAN",
        value: "departmentName",
        width: "250px",
        sortable: false,
    },
    {
        text: "NGUYÊN GIÁ",
        value: "originalPrice",
        width: "150px",
        sortable: false,
        align: 'right'
    },
    {
        text: "CHỨC NĂNG",
        value: "actions",
        width: "100px",
        sortable: false,
        fixed: true,
    },
];

export default headers