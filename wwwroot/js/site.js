// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $(".checkboxClass").click(function () {
        data = $(this).attr("data-number");
        url = "Users/Select/" + data;
        $.ajax({
            type: "POST",
            url: url
        });
    });
});
<<<<<<< HEAD

=======
>>>>>>> 8fd4a6dbe2df0f7f653b7e7465f0bf71ecc57590
