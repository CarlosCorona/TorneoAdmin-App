#pragma checksum "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "352c0d3af3b667a65af9aa4031b82745ee634ce0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registros_Jugadores), @"mvc.1.0.view", @"/Views/Registros/Jugadores.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\_ViewImports.cshtml"
using TorneosAdmin.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\_ViewImports.cshtml"
using TorneosAdmin.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"352c0d3af3b667a65af9aa4031b82745ee634ce0", @"/Views/Registros/Jugadores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Registros_Jugadores : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
  
    ViewData["Title"] = "Jugadores";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Jugadores
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es para alta, baja y actulización de Jugadores.
        </small>
    </h1>
</div><!-- /.page-header -->

<div class=""row"">
    <div class=""col-xs-12"">
        <!-- PAGE CONTENT BEGINS -->
        <div class=""alert alert-warning"">
            <button class=""close"" data-dismiss=""alert"">
                <i class=""ace-icon fa fa-times""></i>
            </button>

            <i class=""ace-icon fa fa-hand-o-right""></i>
            Todas las fotos seran modificadas en la aplicación para tener una resolución de 400 x 420 pixeles.
        </div>

        <div style=""width:100%;overflow:auto;"">
            <table id=""grid-table"" class=""col-md-12""></table>
            <div id=""grid-pager""></div>
        </div>
        <!-- PAGE CONTENT ENDS -->
    </div><!-- /.col -->
</div><!-- /.row -->

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <!-- inline scripts related to this page -->\r\n    <script type=\"text/javascript\">\r\n        // Variable Globales\r\n        var NombreArchivoFoto = \'\';\r\n        var listaEquipos = JSON.parse(\'");
#nullable restore
#line 44 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                  Write(ViewBag.EquiposLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaEstadosCiviles = JSON.parse(\'");
#nullable restore
#line 45 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                         Write(ViewBag.EstadosCivilesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaInstrucciones = JSON.parse(\'");
#nullable restore
#line 46 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                        Write(ViewBag.InstruccionesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaProfesiones = JSON.parse(\'");
#nullable restore
#line 47 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                      Write(ViewBag.ProfesionesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaProvincias = JSON.parse(\'");
#nullable restore
#line 48 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                     Write(ViewBag.ProvinciasLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaParroquias = JSON.parse(\'");
#nullable restore
#line 49 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                     Write(ViewBag.ParroquiasLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaRelacionPro = JSON.parse(\'");
#nullable restore
#line 50 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                                      Write(ViewBag.RelacionProParLista);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'.replace(/&quot;/g, '""'));

        jQuery(function ($) {

            var grid_selector = ""#grid-table"";
            var pager_selector = ""#grid-pager"";
            var parent_column = $(grid_selector).closest('[class*=""col-""]');

            var cambioProvincia = function (provinciaID, provinciaElem) {

                // build ""state"" options based on the selected ""provincias"" value
                var $select, selectedValues,selectVal,
                    $provinciaElem = $(provinciaElem);

                // populate the subset of countries
                if ($provinciaElem.is("".FormElement"")) {
                    // form editing
                    $select = $provinciaElem.closest(""form.FormGrid"")
                        .find(""select#parroquiaID.FormElement"");
                } else {
                    // inline editing
                    $select = $(""select#"" + $.jgrid.jqID($provinciaElem.closest(""tr.jqgrow"").attr(""id"")) + ""parroquiaID"");
                }

              ");
                WriteLiteral(@"  selectVal = $select.val();

                // Limpiamos la lista parroquias
                $select.find('option').remove();

                var giveValue = function (myKey) {
                    return listaParroquias[myKey];
                };
                // Agregamos los elementos de la selección
                jQuery.each(listaRelacionPro, function (index) {
                    if (this.Provincia === provinciaID) {
                        var text = giveValue(this.Parroquia) ;
                        $select.append($(""<option />"").val(this.Parroquia).text(text));
                    }
                });
                return true;
            };

            var dataInitProvincia = function (elem) {
                setTimeout(function () {
                    $(elem).change();
                }, 0);
            };

            var dataEventsProvincia = [
                { type: ""change"", fn: function (e) { cambioProvincia($(e.target).val(), e.target); } },
            ");
                WriteLiteral(@"    { type: ""keyup"", fn: function (e) { $(e.target).trigger(""change""); } }
            ];

            //resize to fit page size
            $(window).on('resize.jqGrid', function () {
                $(grid_selector).jqGrid('setGridWidth', parent_column.width());
            });

            //resize on sidebar collapse/expand
            $(document).on('settings.ace.jqGrid', function (ev, event_name, collapsed) {
                if (event_name === 'sidebar_collapsed' || event_name === 'main_container_fixed') {
                    //setTimeout is for webkit only to give time for DOM changes and then redraw!!!
                    setTimeout(function () {
                        $(grid_selector).jqGrid('setGridWidth', parent_column.width());
                    }, 20);
                }
            })

            function getEquipos() {
                return listaEquipos;
            }

            function getEstadosCiviles() {
                return listaEstadosCiviles;
            ");
                WriteLiteral(@"}

            function getInstrucciones() {
                return listaInstrucciones;
            }

            function getProfesiones() {
                return listaProfesiones;
            }

            function getProfesiones() {
                return listaProfesiones;
            }

            function getProvincias() {
                return listaProvincias;
            }

            function getParroquias() {
                return listaParroquias;
            }

            jQuery(grid_selector).jqGrid({
                url: ""/Jugadores/ObtenerJugadores"",
                datatype: 'json',
                mtype: 'GET',
                height: 400,
                width: 2000,
                colNames: ['ID', 'Equipo', 'Estado Civil', 'Instrucción', 'Profesión', 'Provincia', 'Parroquia', 'Cédula de identidad', 'Nombre', 'Apellido', 'Fecha de Nacimiento', 'Carnet', 'Fecha de Afiliacion', 'Activo','Foto'],
                colModel: [
                    { key: true, h");
                WriteLiteral(@"idden: true, name: 'id', index: 'id', editable: true },
                    { name: 'equipoID', index: 'equipoID', width: 150, editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getEquipos() } },
                    { name: 'estadoCivilID', index: 'estadoCivilID', width: 100, editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getEstadosCiviles() } },
                    { name: 'instruccionID', index: 'instruccionID', width: 100, editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getInstrucciones() } },
                    { name: 'profesionID', index: '´profesionID', width: 100, editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getProfesiones() } },
                    { name: 'provinciaID', index: '´provinciaID', width: 400, editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getProvincias(), dataInit: dataInitProvincia, dataEvents: dataEventsProvincia } },
      ");
                WriteLiteral(@"              { name: 'parroquiaID', index: '´parroquiaID', width: 200, editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getParroquias() } },
                    { name: 'cedula', index: 'cedula', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""10"" } },
                    { name: 'nombre', index: 'nombre', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'apellido', index: 'apellido', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'fechaNacimiento', index: 'fechaNacimiento', align: 'center', width: 180, editable: true, sorttype: ""date"", unformat: pickDate, formatter: dateTable },
                    { name: 'carnet', index: 'carnet', align: 'center', width: 80, editable: true, editoptions: { size: ""20""} },
                    { name: 'fechaAfiliacion', index: 'fechaAfiliacion', align: 'center', width: 180, editable: true, sorttype: ""date"", un");
                WriteLiteral(@"format: pickDate, formatter: dateTable },
                    { name: 'estado', index: 'estado', width: 70, editable: false, edittype: ""checkbox"", align: 'center', formatter: checkTable },
                    { name: 'foto', index: 'foto', width: 150, align:'center', editable: true, edittype: ""file"", editoptions: { enctype: 'multipart/form-data' }, formatter: imageFormat }
                ],

                viewrecords: true,
                rowNum: 10,
                rowList: [10, 20, 30],
                pager: pager_selector,
                autowidth: true,
                shrinkToFit: false,
                forceFit: true,
                altRows: true,
                //toppager: true,

                multiselect: false,
                //multikey: ""ctrlKey"",
                //multiboxonly: true,

                loadComplete: function () {
                    var table = this;
                    setTimeout(function () {
                        updatePagerIcons(table);
       ");
                WriteLiteral(@"                 enableTooltips(table);
                    }, 0);
                },
                caption: ""Jugadores"",

            });

            $(window).triggerHandler('resize.jqGrid');//trigger window resize to make the grid get the correct size

            //navButtons
            jQuery(grid_selector).jqGrid('navGrid', pager_selector,
                { 	//navbar options
                    edit: true,
                    editicon: 'ace-icon fas fa-pencil-alt blue',
                    add: true,
                    addicon: 'ace-icon fas fa-plus-circle purple',
                    del: true,
                    delicon: 'ace-icon fas fa-trash-alt red',
                    search: true,
                    searchicon: 'ace-icon fas fa-search orange',
                    refresh: true,
                    refreshicon: 'ace-icon fas fa-sync-alt green',
                    view: true,
                    viewicon: 'ace-icon fas fa-search-plus grey',
                },
     ");
                WriteLiteral(@"           {
                    //edit record form
                    //closeAfterEdit: true,
                    //width: 700,
                    url: ""/Jugadores/Editar"",
                    mtype: 'PUT',
                    closeAfterEdit: true,
                    recreateForm: true,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                        NombreArchivoFoto = '';
                    },
                    editData: {
                        NombreArchivo: function () { return NombreArchivoFoto; }
                    },
                    errorTextFormat : FormatedorMensajesError,
                },
                {
                    //new record form
                    //width: 700,
                    url: ""/Jugadores/Crear"",
                 ");
                WriteLiteral(@"   mtype: 'POST',
                    closeAfterAdd: true,
                    recreateForm: true,
                    viewPagerButtons: false,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar')
                            .wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                        NombreArchivoFoto = '';
                    },
                    editData: {
                        NombreArchivo: function () { return NombreArchivoFoto; }
                    },
                    errorTextFormat: FormatedorMensajesError,
                },
                {
                    //delete record form
                    url: ""/Jugadores/Eliminar"",
                    mtype: 'PUT',
                    recreateForm: true,
                    width: 400,
                    beforeShowForm: function (e) {
        ");
                WriteLiteral(@"                var form = $(e[0]);
                        if (form.data('styled')) return false;

                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_delete_form(form);

                        form.data('styled', true);
                    },
                    errorTextFormat: FormatedorMensajesError,
                    onClick: function (e) {
                        //alert(1);
                    }
                },
                {
                    //search form
                    recreateForm: true,
                    afterShowSearch: function (e) {
                        var form = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-title').wrap('<div class=""widget-header"" />')
                        style_search_form(form);
                    },
                    afterRedraw: function () {
                        style_search_filters");
                WriteLiteral(@"($(this));
                    }
                    ,
                    multipleSearch: true,
                    /**
                    multipleGroup:true,
                    showQuery: true
                    */
                },
                {
                    //view record form
                    recreateForm: true,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-title').wrap('<div class=""widget-header"" />')
                    }
                }
            )

            $(document).one('ajaxloadstart.page', function (e) {
                $.jgrid.gridDestroy(grid_selector);
                $('.ui-jqdialog').remove();
            });
        });

        function CargarFoto(files, dropped) {

            var archivo = files[0];

            if (typeof archivo === 'string') {
                //older browsers that don't support FileReader API, s");
                WriteLiteral(@"uch as IE
                alert(""Versión antigua de explorador y se soporta la funcionalidad, favor de actulizar versión"");
                return false;
            } else if ('File' in window && archivo instanceof window.File) {
                //file is a ""File"" object with following properties
                var fd = new FormData();//empty FormData object
                fd.append('archivo', archivo);

                var deferred = $.ajax({
                    url: '");
#nullable restore
#line 321 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                     Write(Url.Action("SubirFoto", "Jugadores"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    type: 'POST',
                    processData: false,//important
                    contentType: false,//important
                    dataType: 'json',//depending on your server side response
                    data: fd
                });

                deferred.done(function (result) {
                    if (NombreArchivoFoto !== '') {
                        $.post('");
#nullable restore
#line 331 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
                           Write(Url.Action("ElimintarFoto", "Jugadores"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { archivo: NombreArchivoFoto }).done(function (response) {
                            console.log('El archivo: ' + NombreArchivoFoto + ' es reemplazado por ' + result.foto + 'en el servidor');
                            NombreArchivoFoto = result.foto;
                        }).fail(function (error) {
                            console.log('El no se elimno el archivo: ' + NombreArchivoFoto + ' en el servidor');
                            NombreArchivoFoto = result.foto;
                        });
                    }
                    else {
                        console.log('Se cargo el archivo: ' + result.foto + ' en del servidor');
                        NombreArchivoFoto = result.foto;
                    }
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    alert('error al cargar el archivo')
                });
                return true;
            }
        }

        function ElimarFoto() {
            $.post('");
#nullable restore
#line 351 "D:\AdminTorneos\Web\TorneosAdmin.Web\TorneosAdmin.Web\Views\Registros\Jugadores.cshtml"
               Write(Url.Action("ElimintarFoto", "Jugadores"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { archivo: NombreArchivoFoto }).done(function (response) {
                console.log('Se elimino el archivo: ' + NombreArchivoFoto + ' del servidor');
                NombreArchivoFoto = '';
            });
            return true;
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
