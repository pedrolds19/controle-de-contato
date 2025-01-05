function validarNumeros(event) {
    var tecla = event.key;

    if (!/^\d$/.test(tecla) && tecla !== "Backspace") {
        event.preventDefault();
    }
}

$('.close-alert').click(function () {
    $('.alert').hide('hide');
})