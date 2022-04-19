var table;

$(document).ready(function () {
    table = $("#employeeDatatable").DataTable({
        processing: true,
        serverSide: true,
        autoWidth: true,
        deferRender: true,
        searching: false,
        ajax: {

            type: "POST",
            url: "/Employee/EmployeeList",
            "datatype": "json",
            async: true,
            data: function (data) {
                return (data);
            }
        },
        columns: [
            { "orderable": false, "data": "id", "name": "Id" },
            { "data": "firstName", "name": "First Name" },
            { "data": "lastName", "name": "Last Name" },
            {
                "data": "dob", "name": "Date Of Birth",
                "render": function (data, type, row) {
                    if (data) {
                        return window.moment(data).format("DD/MM/YYYY");
                    }
                    else {
                        return null;
                    }
                },
            },
            {
                "data": "joinDate", "name": "Join Date",
                "render": function (data, type, row) {
                    if (data)
                        return window.moment(data).format("DD/MM/YYYY");
                    else
                        return null;
                },
            },
            { "data": "gender", "name": "Gender" },
            { "data": "role", "name": "Role" },
            { "data": "skills", "name": "Skills", },
            {
                "data": "id",
                "orderable": false,
                "render": function (data, row) { return "<a href='/Employee/Edit?id=" + data + "' class=''; ><img alt='' src='../css/images/edit-ic.png'/></a><a href='#' style='padding-left: 10px;' onclick=DeletEmployee('" + data + "'); ><img alt='' src='../css/images/delete-ic.png'/></a>"; }
            },
        ]
    });


});

function DeletEmployee(id) {

    if (confirm('Are you sure want to delete?')) {
        fetch(`/Employee/Delete/${id}`,
            {
                method: 'DELETE',
                cache: 'no-cache'
            })
            .then((response) => {
                table.ajax.reload();
            })
            .catch((error) => {
                console.log(error);
            });
    }
}