// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#rowAdder").click(function () {

    newRowAdd =
        '<div id="row"> <div class="input-group m-3">' +
        '<div class="input-group-prepend">' +
        '<button class="btn btn-danger" id="DeleteRow" type="button">' +
        '<i class="bi bi-trash"></i> Delete</button> </div>' +
        '<input asp-for="Instructions" type="text" class="form-control m-input"> </div> </div>'
        ;

    $('#newinput').append(newRowAdd);
});

$("body").on("click", "#DeleteRow", function () {
    $(this).parents("#row").remove()
    ;
})