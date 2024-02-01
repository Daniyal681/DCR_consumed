$(document).ready(function () {

    $('#producttable').DataTable({
        processing: true,
        serverSide: true,
        paging: true,
        filter: true,
        lengthMenu: [
            [10, 20, 50, 75, 100, -1],
            [10, 20, 50, 75, 100, "All"]
        ],
        pageLength: 10,
        scrollX: true,
        ajax: {
            url: '/Product/GetProducts',
            type: "POST"
        },
        columns: [
            { data: "productId", "name": "ProductId" },
            { data: "productType", "name": "ProductType" },
            { data: "materialId", "name": "MaterialId" },
            { data: "productPrice", "name": "ProductPrice" },
            { data: "productSku", "name": "ProductSku" },
            { data: "productCode", "name": "ProductCode" },
            { data: "marketName", "name": "MarketName" },
            { data: "brand", "name": "Brand" },
            { data: "memory", "name": "Memory" },
            { data: "model", "name": "Model" },
            { data: "color", "name": "Color" },
            { data: "series", "name": "Series" },
            {
                data: "productId", render: function (data, type, row, meta) {
                    return "<button class='btn btn-primary'><i class='fa fa-edit'></i></button>" +
                        "<button class='btn btn-danger'><i class='fa fa-trash'></i></button>"
                }

            }
        ],
        columnDefs: [
            {
                targets: [0],
                // visible: false,
                searchable: false
            }
        ]
    });
});
