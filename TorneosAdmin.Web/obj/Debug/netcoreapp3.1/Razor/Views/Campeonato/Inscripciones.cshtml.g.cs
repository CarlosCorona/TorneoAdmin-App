#pragma checksum "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Inscripciones.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08cf5b9647550be901f58cb847913ffd5d241e62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Campeonato_Inscripciones), @"mvc.1.0.view", @"/Views/Campeonato/Inscripciones.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08cf5b9647550be901f58cb847913ffd5d241e62", @"/Views/Campeonato/Inscripciones.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Campeonato_Inscripciones : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Inscripciones.cshtml"
  
    ViewData["Title"] = "Inscripciones";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Inscripciones.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Inscripciones
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es para alta, baja y actualización de inscripciones.
        </small>
    </h1>
</div><!-- /.page-header -->

<div class=""row"">
    <div class=""col-xs-12"">
        <!-- PAGE CONTENT BEGINS -->
");
            WriteLiteral(@"        <h4>
            <i class=""ace-icon fas fa-hand-point-right icon-animated-hand-pointer blue""></i>
            <a id=""btnAgregaInscripcion"" class=""blue""> Agregar Inscripción </a>
        </h4>
        <br />
        <table id=""grid-table""></table>
        <div id=""grid-pager""></div>

        <!-- PAGE CONTENT ENDS -->
    </div><!-- /.col -->
</div><!-- /.row -->

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <!-- inline scripts related to this page -->\r\n    <script type=\"text/javascript\">\r\n        // Variable Globales\r\n        var listaCampeonatos = JSON.parse(\'");
#nullable restore
#line 46 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Inscripciones.cshtml"
                                      Write(ViewBag.CampeonatosLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaEquipos = JSON.parse(\'");
#nullable restore
#line 47 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Inscripciones.cshtml"
                                  Write(ViewBag.EquiposLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaUsuarios = JSON.parse(\'");
#nullable restore
#line 48 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Inscripciones.cshtml"
                                   Write(ViewBag.UsuariosLista);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'.replace(/&quot;/g, '""'));
        
        jQuery(function ($) {

            // boton para agrega un nuevo campeonato.
            $(""#btnAgregaInscripcion"").on(""click"", function () {
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
                    //setTimeout is for webkit only to give time for DOM changes and then redraw!!!
                    setTimeout(function () {
                        $(");
                WriteLiteral(@"grid_selector).jqGrid('setGridWidth', parent_column.width());
                    }, 20);
                }
            })

            function getCampeonatos() {
                return listaCampeonatos;
            }

            function getEquipos() {
                return listaEquipos;
            }

            function getUsuarios() {
                return listaUsuarios;
            }

            jQuery(grid_selector).jqGrid({
                url: ""/Inscripciones/ObtenerInscripciones"",
                datatype: 'json',
                mtype: 'GET',
                height: 400,
                colNames: ['ID', 'Campeonato', 'Equipo', 'Foto', 'Usuario que registro', 'Fecha Inscripcion', ''],
                colModel: [
                    { key: true, hidden: true, name: 'id', index: 'id', editable: true },
                    { name: 'campeonatoID', index: 'campeonatoID', editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getCampeonatos() } },
   ");
                WriteLiteral(@"                 { name: 'equipoID', index: 'equipoID', editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getEquipos() } },
                    { name: 'foto', jsonmap: 'equipoID', align: 'center', editable: false, edittype: ""custom"", editoptions: { enctype: 'multipart/form-data', custom_element: imageFormatEdit }, formatter: imageFormatEquipo, unformat: imageUnFormat },
                    { name: 'usuarioID', index: 'usuarioID', editable: false, edittype: 'select', formatter: 'select', editoptions: { value: getUsuarios() } },
                    { name: 'fechaInscripcion', index: 'fechaInscripcion', editable: false, sorttype: ""date"", unformat: pickDate, formatter: dateTable },
                    {
                        name: 'myac', width:50, fixed: true, sortable: false, resize: false, formatter: 'actions',
                        formatoptions: {
                            key: true,
                            editbutton: false,
                            delbut");
                WriteLiteral(@"ton: true,
                            editformbutton: false,
                            //editOptions: {
                            //    url: ""/Inscripciones/Editar"",
                            //    mtype: 'PUT',
                            //    viewPagerButtons: false,
                            //    closeAfterEdit: true,
                            //    recreateForm: true,
                            //    beforeShowForm: function (form) {
                            //        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                            //        form.find('#campeonatoID').attr(""disabled"", true)
                            //        form.find('#equipoID').attr(""disabled"", true)
                            //        style_edit_form(form);
                            //    },
                            //    errorTextFormat: FormatedorMensajesError
                            //},
                            delOpt");
                WriteLiteral(@"ions: {
                                url: ""/Inscripciones/Eliminar"",
                                mtype: 'PUT',
                                recreateForm: true,
                                width: 400,
                                beforeShowForm: function (form) {
                                    if (form.data('styled')) return false;

                                    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                                    style_delete_form(form);

                                    form.data('styled', true);

                                    form.find("".delmsg"").text(""¿Desea eliminar la inscripción?"");
                                    form.closest('.ui-jqdialog').find(""#dData"").text('Eliminar');
                                },
                                errorTextFormat: FormatedorMensajesError
                            }
                        }
                    }
  ");
                WriteLiteral(@"              ],

                viewrecords: true,
                rowNum: 10,
                rowList: [10, 20, 30],
                pager: pager_selector,
                altRows: true,
                shrinkToFit: true,
                autowidth: true,
                //toppager: true,

                multiselect: false,
                //multikey: ""ctrlKey"",
                //multiboxonly: true,

                loadComplete: function () {
                    var table = this;
                    setTimeout(function () {
                        updatePagerIcons(table);
                        enableTooltips(table);
                    }, 0);
                },
                caption: ""Inscripciones"",

            });

            $(window).triggerHandler('resize.jqGrid');//trigger window resize to make the grid get the correct size

            function addRow() {
                // Get the currently selected row
                $(grid_selector).jqGrid('editGridRow', 'new");
                WriteLiteral(@"', {
                    url: ""/Inscripciones/Crear"",
                    mtype: 'POST',
                    closeAfterAdd: true,
                    recreateForm: true,
                    viewPagerButtons: false,
                    beforeShowForm: function (form) {
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                        form.find(""#tr_foto"").hide();
                    },
                    errorTextFormat: FormatedorMensajesError,
                });
            }

            $(document).one('ajaxloadstart.page', function (e) {
                $.jgrid.gridDestroy(grid_selector);
                $('.ui-jqdialog').remove();
            });
        });
 
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
