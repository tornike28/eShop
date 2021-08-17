
function getCategory(id) {
    modal.find('.modal-title').text('პროდუქტის რედაქტირება');

    $.ajax({
        type: "GET",
        url: `/Category/GetCategories/${id}`,
        dataType: "json",
        success: function (data) {
            $('#ID').val(data.ID);
            $('#Name').val(data.Name);
            $('#Unit').val(data.Unit);
            $('#Description').val(data.Description);
            $('#Price').val(data.Price);
            $('#Quantity').val(data.Quantity);
        },
        error: function () {
            console.log('something went wrong');
        }
    });
}



