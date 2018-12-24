$('.btn-remove').darkTooltip({
    trigger: 'click',
    animation: 'flipIn',
    gravity: 'west',
    confirm: true,
    content: "Jesteś pewny usunięcia ?",
    yes: 'Tak',
    no: 'Nie',
    finalMessage: 'Usuwanie ..',
    onYes: function (btn) {
        window.location.href = $(btn).attr('href');
    }
});
