
function getCategory(id) {
    $.ajax({
        type: "GET",
        url: `/Category/GetCategories/${id}`,
        dataType: "json",
        success: function (data) {
            $('#Name').val(data.Name);
        },
        error: function () {
            console.log('something went wrong');
        }
    });
}



