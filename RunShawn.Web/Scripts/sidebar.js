$(document).ready(function () {
    var defaultActivedMenu = $(".category-header .active")
    defaultActivedMenu.siblings("ol").slideDown('fast', 'linear');

    function ResetMenu()
    {
        var activedMenu = $(".category-header.active");
        activedMenu.each(function( index ) {
         $(this).removeClass("active");
         $(this).siblings("ol").slideUp('fast','linear');    
        });
    }
    $( ".category-header" ).click(function() {
        var link = $(this);
        if(!$(this).hasClass("active"))
        {
                                
            ResetMenu();
            link.siblings("ol").slideDown('fast','linear');
            link.addClass('active');
        }
        else
        {
            ResetMenu();
            link.siblings("ol").slideUp('fast','linear');
            link.removeClass('active');
        }
    });

    $( ".user-image").click(function() {
        var link = $(this);
        if(!$(this).hasClass("active"))
        {
            link.siblings(".dropdown_list-user").fadeIn('fast','linear');
            link.addClass('active');
        }
        else
        {
            link.siblings(".dropdown_list-user").fadeOut('fast','linear');
            link.removeClass('active');
        }
    });

    $( "#notification-button").click(function() {
        var link = $(this);
        if(!$(this).hasClass("active"))
        {
            link.siblings(".dropdown_list-notifications").fadeIn('fast','linear');
            link.addClass('active');
        }
        else
        {
            link.siblings(".dropdown_list-notifications").fadeOut('fast','linear');
            link.removeClass('active');
        }
    });
});