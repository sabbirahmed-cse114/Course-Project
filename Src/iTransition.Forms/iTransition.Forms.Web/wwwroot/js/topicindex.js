$(function () {
    $("#topicTable").DataTable({
        processing: true,
        serverSide: true,
        responsive: true,
        lengthChange: false,
        filter: false,
        autoWidth: true,
        ajax: {
            url: "/Admin/Topic/GetTopicJsonData",
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
                        <button type="button" class="btn show-bs-modal"
                            data-bs-toggle="modal" data-bs-target="#delete-modal"
                            data-id='${data}' title="Delete">
                            <i class="bi bi-trash text-danger"></i>
                        </button>`;
                }
            }
        ],
    });

    $('#topicTable').on('click', '.show-bs-modal', function () {
        let id = $(this).data("id");
        $("#deleteId").val(id);
        $("#delete-form").attr("action", "/Admin/Topic/Delete");
    });
});