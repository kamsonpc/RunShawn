NProgress.start();

var interval = setInterval(function () { NProgress.inc(); }, 1000);

jQuery(window).load(function () {
    clearInterval(interval);
    NProgress.done();
});

jQuery(window).unload(function () {
    NProgress.start();
});