FormatedorMensajesError = function (response) {
    if (isJson(response.responseText)) {
        var errores = JSON.parse(response.responseText);
        var message = '<span class="ui-icon ui-icon-alert" ' +
            'style="float:left; margin-right:.3em;"></span>';
        $.each(errores, function (key, value) {
            message += '<li>' + value + '</li>';
        });
        return message
    }
    else
        return '<span class="ui-icon ui-icon-alert" ' +
            'style="float:left; margin-right:.3em;"></span>' +
            response.responseText;
}