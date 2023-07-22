$(document).ready(function () {
    var navbarCollapse = $('.navbar-collapse');

    // وقتی روی دکمه کلیک شود
    $('.navbar-toggler').click(function () {
        navbarCollapse.toggleClass('show');
    });

    // وقتی روی هر جای صفحه کلیک شود
    $(document).click(function (event) {
        var clickTarget = $(event.target);
        var navbarToggler = $('.navbar-toggler');

        if (!clickTarget.closest('.navbar').length && navbarCollapse.hasClass('show')) {
            navbarCollapse.removeClass('show');
        } else if (clickTarget.closest('.navbar-toggler').length && navbarCollapse.hasClass('show')) {
            navbarCollapse.removeClass('show');
        } else if (clickTarget.closest('.navbar-toggler').length && !navbarCollapse.hasClass('show')) {
            navbarCollapse.addClass('show');
        }
    });
});


