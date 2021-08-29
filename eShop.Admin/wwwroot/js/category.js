$('#categoryModal').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget)// Button that triggered the modal
    let id = button.data('id') // Extract info from data-* attributes

    let modal = $(this)
    
    modal.find('.modal-title').text('კატეგორიის რედაქტირება');

    $.ajax({
        type: "GET",
        url: `/Category/GetCategory/`,
        data: { id: id },
        dataType: "json",
        success: function (data) {
            $('#CategoryName').val(data.CategoryName);
            $('#CategoryID').val(data.Id);
        },
        error: function (err) {
            console.log('somthing went wrong:', err);

        }
    });
})


