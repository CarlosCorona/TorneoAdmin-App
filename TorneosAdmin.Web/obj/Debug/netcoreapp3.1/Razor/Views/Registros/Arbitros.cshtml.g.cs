#pragma checksum "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Arbitros.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77a5649cb7e6b02164b09ea64d951d5572ddada4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registros_Arbitros), @"mvc.1.0.view", @"/Views/Registros/Arbitros.cshtml")]
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
#line 1 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\_ViewImports.cshtml"
using TorneosAdmin.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\_ViewImports.cshtml"
using TorneosAdmin.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77a5649cb7e6b02164b09ea64d951d5572ddada4", @"/Views/Registros/Arbitros.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Registros_Arbitros : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Arbitros.cshtml"
  
    ViewData["Title"] = "Árbitros";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Arbitros.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Árbitros
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es para alta, baja y actualización de un árbitro.
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
        <h4>
            <i class=""ace-icon fas fa-hand-point-right icon-animated-hand-pointer blue""></i>
            <a id=""btnAgregaArbitro"" class=""blue""> Agregar Árbitro </a>
        </h4>
        <br />
        <table id=""grid-table""></table>
        <div id=""grid-pager""></div>

      ");
            WriteLiteral("  <!-- PAGE CONTENT ENDS -->\r\n    </div><!-- /.col -->\r\n</div><!-- /.row -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <!-- inline scripts related to this page -->
    <script type=""text/javascript"">
        // Variable Globales
        var NombreArchivoFoto = '';

        jQuery(function ($) {

            // boton para agrega un nuevo dirigente.
            $(""#btnAgregaArbitro"").on(""click"", function () {
                addRow();
            });

            var grid_selector = ""#grid-table"";
            var pager_selector = ""#grid-pager"";
            var parent_column = $(grid_selector).closest('[class*=""col-""]');

            //resize to fit page size
            $(window).on('resize.jqGrid', function () {
                $(grid_selector).jqGrid('setGridWidth', parent_column.width());
            });

            //resize on sidebar collapse/expand
            $(document).on('settings.ace.jqGrid', function (ev, event_name, collapsed) {
                if (event_name === 'sidebar_collapsed' || event_name === 'main_container_fixed') {
                    //setTimeout is for webkit only to give");
                WriteLiteral(@" time for DOM changes and then redraw!!!
                    setTimeout(function () {
                        $(grid_selector).jqGrid('setGridWidth', parent_column.width());
                    }, 20);
                }
            })

            jQuery(grid_selector).jqGrid({
                url: ""/Arbitros/ObtenerArbitros"",
                datatype: 'json',
                mtype: 'GET',
                height: 400,
                colNames: ['ID', 'Cédula de identidad', 'Nombre', 'Apellido', 'Dirección', 'País', 'Teléfono', 'Correo Electrónico', 'Activo', 'Foto', ''],
                colModel: [
                    { key: true, hidden: true, name: 'id', index: 'id', editable: true },
                    { name: 'cedula', index: 'cedula', width: 100, editable: true, editoptions: { size: ""20"", maxlength: ""10"" } },
                    { name: 'nombre', index: 'nombre', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'apellido', index: '");
                WriteLiteral(@"apellido', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'direccion', index: 'direccion', width: 150, hidden: true, editable: true, editrules: { edithidden: true }, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'pais', index: 'pais', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'telefono', index: 'telefono', width: 150, hidden: true, editable: true, editrules: { edithidden: true }, editoptions: { size: ""20"", maxlength: ""15"" } },
                    { name: 'correoElectronico', index: 'correoElectronico', width: 200, hidden: true, editable: true, editrules: { edithidden: true }, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'estado', index: 'estado', width: 70, editable: false, edittype: ""checkbox"", align: 'center', formatter: checkTable },
                    { name: 'foto', index: 'foto', width: 150, align: 'center', editabl");
                WriteLiteral(@"e: true, edittype: ""file"", editoptions: { enctype: 'multipart/form-data' }, formatter: imageFormat },
                    {
                        name: 'myac', width: 80, fixed: true, sortable: false, resize: false, formatter: 'actions',
                        formatoptions: {
                            key: true,
                            editbutton: true,
                            delbutton: true,
                            editformbutton: true,
                            editOptions: {
                                url: ""/Arbitros/Editar"",
                                mtype: 'PUT',
                                modal: true,
                                closeAfterEdit: true,
                                recreateForm: true,
                                beforeShowForm: function (form) {
                                    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                                    style_edit");
                WriteLiteral(@"_form(form);
                                },
                                onClose: function (formId) {
                                    if (NombreArchivoFoto !== '')
                                        ElimarFoto();
                                },
                                editData: {
                                    NombreArchivo: function () { return NombreArchivoFoto; }
                                },
                                errorTextFormat: FormatedorMensajesError
                            },
                            delOptions: {
                                url: ""/Arbitros/Eliminar"",
                                mtype: 'PUT',
                                modal: true,
                                recreateForm: true,
                                width: 400,
                                beforeShowForm: function (form) {
                                    if (form.data('styled')) return false;

                                  ");
                WriteLiteral(@"  form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                                    style_delete_form(form);

                                    form.data('styled', true);
                                },
                                errorTextFormat: FormatedorMensajesError
                            }
                        }
                    }
                ],

                viewrecords: true,
                rowNum: 10,
                rowList: [10, 20, 30],
                pager: pager_selector,
                altRows: true,
                //toppager: true,

                multiselect: false,
                //multikey: ""ctrlKey"",
                //multiboxonly: true,

                loadComplete: function () {
                    var table = this;
                    setTimeout(function () {
                        updatePagerIcons(table);
                        enableTooltips(table);
                  ");
                WriteLiteral(@"  }, 0);
                },
                caption: ""Árbitros"",

            });

            $(window).triggerHandler('resize.jqGrid');//trigger window resize to make the grid get the correct size

            function addRow() {
                // Get the currently selected row
                $(grid_selector).jqGrid('editGridRow', 'new', {
                    url: ""/Arbitros/Crear"",
                    mtype: 'POST',
                    modal: true,
                    closeAfterAdd: true,
                    recreateForm: true,
                    viewPagerButtons: false,
                    beforeShowForm: function (form) {
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                        NombreArchivoFoto = '';
                    },
                    onClose: function (formId) {
                        if (NombreArchivoFoto !== '')
               ");
                WriteLiteral(@"             ElimarFoto();
                    },
                    editData: {
                        NombreArchivo: function () { return NombreArchivoFoto; }
                    },
                    errorTextFormat: FormatedorMensajesError
                });
            }

            $(document).one('ajaxloadstart.page', function (e) {
                $.jgrid.gridDestroy(grid_selector);
                $('.ui-jqdialog').remove();
            });
        });

        function CargarFoto(files, dropped) {

            var archivo = files[0];

            if (typeof archivo === 'string') {
                //older browsers that don't support FileReader API, such as IE
                alert(""Versión antigua de explorador y se soporta la funcionalidad, favor de actulizar versión"");
                return false;
            } else if ('File' in window && archivo instanceof window.File) {
                //file is a ""File"" object with following properties
                var fd = new");
                WriteLiteral(" FormData();//empty FormData object\r\n                fd.append(\'archivo\', archivo);\r\n\r\n                var deferred = $.ajax({\r\n                    url: \'");
#nullable restore
#line 206 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Arbitros.cshtml"
                     Write(Url.Action("SubirFoto", "Arbitros"));

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
#line 216 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Arbitros.cshtml"
                           Write(Url.Action("ElimintarFoto", "Arbitros"));

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
#line 236 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Arbitros.cshtml"
               Write(Url.Action("ElimintarFoto", "Arbitros"));

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
