$('#categoryModal').on('show.bs.modal', function (event) {
    modal.find('.modal-title').text('კატეგორიის რედაქტირება');

    $.ajax({
        type: "GET",
        url: `/Category/GetCategories/`,
        data: { id: id },
        dataType: "json",
        success: function (data) {
            $('#Name').val(data.Name);
        },
        error: function (err) {
            console.log('somthing went wrong:', err);

        }
    });
})
        