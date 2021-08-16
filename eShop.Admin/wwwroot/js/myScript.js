$(document).ready(function () {
    jQueryModalGet = (url, title, Id) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                data: {
                    id: Id
                },
                success: function (response) {
                    $('#categoryModal .modal-body').html(response.html);
                    $('#categoryModal .modal-body #Id').val(response.id);
                    $('#categoryModal .modal-body #Name').val(response.name);
                    $('#categoryModal .modal-title').html(title);
                    $('#categoryModal').modal('show');
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalPost = (url, Model) => {
        try {
            $.ajax({
                type: 'POST',
                url: url,
                dataType: 'JSON',
                contentType: "application/json; charset=utf-8",
                data: {
                    category: Model
                },
                success: function (res) {
                    if (res.isValid) {
                        //$('#viewAll').html(res.html)
                        $('#categoryModal').modal('hide');
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }
    jQueryModalDelete = form => {
        if (confirm('Are you sure to delete this record ?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        //$('#viewAll').html(res.html);
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }
        return false;
    }
});