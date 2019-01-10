$(document).ready(function () {
    var closed = true;

    $("#hamburger").click(function () {
        if (closed) {
            $(".page-header nav ul").slideDown();
            $(this).toggleClass('open');
            closed = false;
        }
        else {
            $(".page-header nav ul").slideUp();
            $(this).toggleClass('open');
            closed = true;
        }
    });
});