$(function () {
    $("#tagTable").DataTable({
        processing: true,
        serverSide: true,
        responsive: true,
        lengthChange: false,
        filter: false,
        autoWidth: true,
        ajax: {
            url: "/Admin/Tag/GetTagJsonData",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                d.SearchItem = {
                };
                return JSON.stringify(d);
            }
        },
        columnDefs: [
            {
                orderable: false,
                targets: 1,
                className: "text-center",
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-sm show-bs-modal"
                            data-bs-toggle="modal" data-bs-target="#updateTagModal"
                            value='${data}' data-name='${row[0]}' 
                            data-description='${row[1]}' data-id='${data}' title="Update">
                            <i class="bi bi-pencil-square text-info"></i>
                        </button>
                        <button type="button" class="btn btn-sm show-bs-modal"
                            data-bs-toggle="modal" data-bs-target="#delete-modal"
                            data-id='${data}' title="Delete">
                            <i class="bi bi-trash text-danger"></i>
                        </button>`;
                }
            }
        ],
    });

    $('#tagTable').on('click', '.show-bs-modal', function () {
        let id = $(this).data("id");
        let name = $(this).data("name");

        $("#deleteId").val(id);
        $("#delete-form").attr("action", "/Admin/Tag/Delete");

        $("#updateId").val(id);
        $("#UpdateName").val(name);
        $("#update-form").attr("action", "/Admin/Tag/Update/{id}");
    });
});
