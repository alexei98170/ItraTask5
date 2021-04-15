$(document).ready(function () {
    $(".checkboxClas").click(function () {
        data = $(this).attr("data-number");
        if ($(this).is(":checked")) {
            url = "Users/SelectAll/1";
            $('body input:checkbox').prop('checked', true);
        }
        else {
            url = "Users/SelectAll/2";
            $('body input:checkbox').prop('checked', false);
        }
        $.ajax({
            type: "POST",
            url: url
        });
    });
});
