$(document).ready(function () {
    $('#myTable').DataTable({
        dom: "lBfrtip",
        "scrollX": true,
        "scrollY": '500px',
        "paging": true, 
        "searching": true, 
        "processing": true,
        "lengthMenu": [ [20, 30, 50, -1], [20, 30, 50, "All"] ],
    });
});

document.getElementById('uploadButton').addEventListener('click', function () {
    document.getElementById('excelFileInput').click();
});



document.getElementById("excelFileInput").addEventListener("change", function (e) {
    const file = e.target.files[0];

    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const data = new Uint8Array(e.target.result);
            const workbook = XLSX.read(data, { type: "array" });

            const sheetName = workbook.SheetNames[0];
            const worksheet = workbook.Sheets[sheetName];
            const jsonData = XLSX.utils.sheet_to_json(worksheet);

            const table = $('#myTable').DataTable();

            // Clear the existing table data
            table.clear().draw();

            // Add the new data
            for (const dataRow of jsonData) {
                table.row.add(Object.values(dataRow)).draw();
            }
        };

        reader.readAsArrayBuffer(file);
    }
});
