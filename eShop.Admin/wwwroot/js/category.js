

function getCategory(id) {
    $.ajax({
        type: "GET",
        url: `/Category/GetCategories/${id}`,
        dataType: "json",
        success: function (data) {
            console.log('data:', data)
        },
        error: function () {
            console.log('something went wrong');
        }
    });
}
