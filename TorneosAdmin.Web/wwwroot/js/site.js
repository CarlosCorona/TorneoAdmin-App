﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Metodo para envíar siempre en las peticiones de ajas el ValidateAntiForgeryToken al servidor
$(document).ajaxSend(function (event, jqXHR, options) {
    jqXHR.setRequestHeader("RequestVerificationToken", jQuery("input[name=__RequestVerificationToken]").val());
});

// Validador de cadenas json
function isJson(item) {
    item = typeof item !== "string"
        ? JSON.stringify(item)
        : item;

    try {
        item = JSON.parse(item);
    } catch (e) {
        return false;
    }

    if (typeof item === "object" && item !== null) {
        return true;
    }

    return false;
}

//Formatear la fecha 
Date.prototype.ddmmyyyy = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [(dd > 9 ? '' : '0') + dd, (mm > 9 ? '' : '0') + mm, this.getFullYear() ].join('/');
};

//format element checkbox in table
function checkTable(cellvalue, options, cell) {
    if (cellvalue)
        return '<label> <input class="ace ace-switch ace-switch-4" checked type="checkbox" disabled /> <span class="lbl" data-lbl="SI&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NO"></span></label>'
    else
        return '<label> <input class="ace ace-switch ace-switch-4" type="checkbox" disabled /> <span class="lbl" data-lbl="SI&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NO"></span></label>'
}

//format element date in table
function dateTable(cellvalue, options, cell) {
    return cellvalue.substr(8, 2) + '/' + cellvalue.substr(5, 2) + '/' + cellvalue.substr(0, 4);
}

//format element imagen in table
function imageFormat(cellvalue, options, rowObject) {
    if (cellvalue === null)
        return '<img src="../images/avatars/noimagen.png" height="50" width="50"/>';
    else
        return '<img src="data:image/png;base64,' + cellvalue + '" height="50" width="50"/>';
}
function imageUnFormat(cellvalue, options, cell) {
    return $('img', cell).attr('src');
}

function imageFormatEdit(value, options) {
    var el = document.createElement("img");
    el.src = value;
    el.width = 230;
    el.height = 230;
    return el;
}

//switch element when editing inline
function aceSwitch(cellvalue, options, cell) {
    setTimeout(function () {
        $(cell).find('input[type=checkbox]')
            .addClass('ace ace-switch ace-switch-5')
            .after('<span class="lbl"></span>');
    }, 0);
}

//enable datepicker when editing inline
function pickDate(cellvalue, options, cell) {
    setTimeout(function () {
        $(cell).find('input[type=text]').datepicker();
    }, 0);
}

// Formatter Telefon when editing inline
function telefonoCell(cellvalue, options, cell) {
    setTimeout(function () {
        $(cell).find('input[type=text]')
            .mask('(999) 999-9999');
    }, 0);
}

function style_edit_form(form) {
    //enable datepicker on "sdate" field and switches for "stock" field
    form.find('input[name*="fecha"]').datepicker();
    form.find('input[name*="fecha"]').datepicker('setDate', new Date());
    //Enable switch element when editing
    //form.find('input[name=estado]').addClass('ace ace-switch ace-switch-5').wrap('<label class="inline" />').after('<span class="lbl"></span>');

    //Mask Telefon element when editing
    form.find('input[name=telefono]').mask('(999) 999-9999');

    //Spinner element when editing
    form.find('input[name=carnet]').ace_spinner({ value: 1, min: 0, max: 200, step: 1, btn_up_class: 'btn-info', btn_down_class: 'btn-info' })

    // Agregamos al campo para carga de archivos
    if (form.find('input[name=foto]').length > 0) {
        form.find('input[name=foto]').ace_file_input({ style: 'well', btn_choose: 'Subir foto', btn_change: 'Cambiar', droppable: true, onchange: null, thumbnail: false, allowExt: ['jpg', 'jpeg', 'png', 'bmp'], allowMime: ['image/jpg', 'image/jpeg', 'image/png', 'image/bmp'], before_change: CargarFoto, before_remove: ElimarFoto });
        form.find('.ace-file-container').css('width', '180px').css('height', '120px');
        form.find('.ace-file-input').css('width', '180px')
    }

    //update buttons classes
    var buttons = form.next().find('.EditButton .fm-button');
    buttons.addClass('btn btn-sm').find('[class*="-icon"]').hide();//ui-icon, s-icon
    buttons.eq(0).addClass('btn-primary').prepend('<i class="ace-icon fa fa-check"></i>');
    buttons.eq(1).prepend('<i class="ace-icon fa fa-times"></i>')

    buttons = form.next().find('.navButton a');
    buttons.find('.ui-icon').hide();
    buttons.eq(0).append('<i class="ace-icon fa fa-chevron-left"></i>');
    buttons.eq(1).append('<i class="ace-icon fa fa-chevron-right"></i>');
}

function style_delete_form(form) {
    var buttons = form.next().find('.EditButton .fm-button');
    buttons.addClass('btn btn-sm btn-white btn-round').find('[class*="-icon"]').hide();//ui-icon, s-icon
    buttons.eq(0).addClass('btn-danger').prepend('<i class="ace-icon fa fa-trash-o"></i>');
    buttons.eq(1).addClass('btn-default').prepend('<i class="ace-icon fa fa-times"></i>')
}

function style_search_filters(form) {
    form.find('.delete-rule').val('X');
    form.find('.add-rule').addClass('btn btn-xs btn-primary');
    form.find('.add-group').addClass('btn btn-xs btn-success');
    form.find('.delete-group').addClass('btn btn-xs btn-danger');
}

function style_search_form(form) {
    var dialog = form.closest('.ui-jqdialog');
    var buttons = dialog.find('.EditTable')
    buttons.find('.EditButton a[id*="_reset"]').addClass('btn btn-sm btn-info').find('.ui-icon').attr('class', 'ace-icon fa fa-retweet');
    buttons.find('.EditButton a[id*="_query"]').addClass('btn btn-sm btn-inverse').find('.ui-icon').attr('class', 'ace-icon fa fa-comment-o');
    buttons.find('.EditButton a[id*="_search"]').addClass('btn btn-sm btn-purple').find('.ui-icon').attr('class', 'ace-icon fa fa-search');
}

function beforeDeleteCallback(e) {
    var form = $(e[0]);
    if (form.data('styled')) return false;

    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
    style_delete_form(form);

    form.data('styled', true);
}

function beforeEditCallback(e) {
    var form = $(e[0]);
    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
    style_edit_form(form);
}

//it causes some flicker when reloading or navigating grid
//it may be possible to have some custom formatter to do this as the grid is being created to prevent this
//or go back to default browser checkbox styles for the grid
function styleCheckbox(table) {

    $(table).find('input:checkbox').addClass('ace').wrap('<label />')
        .after('<span class="lbl align-top" />')

    $('.ui-jqgrid-labels th[id*="_cb"]:first-child')
        .find('input.cbox[type=checkbox]').addClass('ace')
        .wrap('<label />').after('<span class="lbl align-top" />');
}

//unlike navButtons icons, action icons in rows seem to be hard-coded
//you can change them like this in here if you want
function updateActionIcons(table) {
    /**
    var replacement =
    {
        'ui-ace-icon fa fa-pencil' : 'ace-icon fa fa-pencil blue',
        'ui-ace-icon fa fa-trash-o' : 'ace-icon fa fa-trash-o red',
        'ui-icon-disk' : 'ace-icon fa fa-check green',
        'ui-icon-cancel' : 'ace-icon fa fa-times red'
    };
    $(table).find('.ui-pg-div span.ui-icon').each(function(){
        var icon = $(this);
        var $class = $.trim(icon.attr('class').replace('ui-icon', ''));
        if($class in replacement) icon.attr('class', 'ui-icon '+replacement[$class]);
    })
    */
}

//replace icons with FontAwesome icons like above
function updatePagerIcons(table) {
    var replacement =
    {
        'ui-icon-seek-first': 'ace-icon fas fa-angle-double-left bigger-140',
        'ui-icon-seek-prev': 'ace-icon fas fa-angle-left bigger-140',
        'ui-icon-seek-next': 'ace-icon fas fa-angle-right bigger-140',
        'ui-icon-seek-end': 'ace-icon fas fa-angle-double-right bigger-140'
    };
    $('.ui-pg-table:not(.navtable) > tbody > tr > .ui-pg-button > .ui-icon').each(function () {
        var icon = $(this);
        var $class = $.trim(icon.attr('class').replace('ui-icon', ''));

        if ($class in replacement) icon.attr('class', 'ui-icon ' + replacement[$class]);
    })
}

function enableTooltips(table) {
    $('.navtable .ui-pg-button').tooltip({ container: 'body' });
    $(table).find('.ui-pg-div').tooltip({ container: 'body' });
}

function insertaEquipos(item) {
    // Test to see if the browser supports the HTML template element by checking
    // for the presence of the template element's content attribute.
    if ('content' in document.createElement('template')) {
        var t = document.querySelector('#equipoRow'),
            tr = t.content.querySelector("tr"),
            td = t.content.querySelectorAll("td"),
            pv = td[7].querySelectorAll(".profile-info-value");

        // Instantiate the table with the existing HTML tbody 
        td[1].textContent = item.id
        td[2].textContent = item.liga;
        td[3].textContent = item.categoria;
        td[4].textContent = item.nombreEquipo;
        td[5].querySelector('span').textContent = item.estado;
        if (item.estado === 'INACTIVO') {
            span = $(td[5].querySelector('span'));
            span.removeClass("label-success arrowed-right arrowed-out");
            span.addClass("label-danger arrowed-righ arrowed");
        }
        else {
            span = $(td[5].querySelector('span'));
            span.removeClass("label-danger arrowed-righ arrowed");
            span.addClass("label-success arrowed-right arrowed-out");
        }
        var foto = td[6].querySelector('img');
        if (item.foto === null)
            $(foto).attr("src", "../images/avatars/noimagen.png");
        else
            $(foto).attr("src", "data: image / png; base64," + item.foto);
        td[7].querySelector('.white').textContent = item.nombreEquipo;
        pv[0].querySelector('span').textContent = item.nombreEquipo;
        pv[1].querySelector('span').textContent = item.liga;
        pv[2].querySelector('span').textContent = item.dirigente;
        pv[3].querySelector('span').textContent = item.fundacion;
        pv[4].querySelector('span').textContent = item.color;
        pv[5].querySelector('span').textContent = item.jugadores;

        // Clone the new row and insert it into the table
        var tb = document.querySelector("#equipos-table tbody");
        //debugger;
        var clone = document.importNode(t.content, true);
        tb.appendChild(clone);

    } else {
        // Find another way to add the rows to the table because 
        // the HTML template element is not supported.
    }
}