#pragma checksum "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1bb6d135f3ae60257aed2aafc161a2ecbbdafc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registros_Calificacion), @"mvc.1.0.view", @"/Views/Registros/Calificacion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1bb6d135f3ae60257aed2aafc161a2ecbbdafc6", @"/Views/Registros/Calificacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Registros_Calificacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
  
    ViewData["Title"] = "Calificacion";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Calificar jugadores del Sistema
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es con fin de calificar la información de un jugador.
        </small>
    </h1>
</div><!-- /.page-header -->

<div class=""row"">
    <div class=""col-xs-12"">
        <!-- PAGE CONTENT BEGINS -->
        <div class=""alert alert-info"">
            <button class=""close"" data-dismiss=""alert"">
                <i class=""ace-icon fa fa-times""></i>
            </button>

            <i class=""ace-icon fa fa-hand-o-right""></i>
            Nota: solo existe la baja logica.
        </div>

        <table id=""grid-table""></table>
        <div id=""grid-pager""></div>

        <!-- PAGE CONTENT ENDS -->
    </div><!-- /.col -->
</div><!-- /.row -->

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <!-- inline scripts related to this page -->\r\n    <script type=\"text/javascript\">\r\n\r\n        // Variable Globales\r\n        var listaLigas = JSON.parse(\'");
#nullable restore
#line 43 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                Write(ViewBag.LigasLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaDirigentes = JSON.parse(\'");
#nullable restore
#line 44 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                     Write(ViewBag.DirigentesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaEquipos = JSON.parse(\'");
#nullable restore
#line 45 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                  Write(ViewBag.EquiposLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaEstadosCiviles = JSON.parse(\'");
#nullable restore
#line 46 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                         Write(ViewBag.EstadosCivilesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaInstrucciones = JSON.parse(\'");
#nullable restore
#line 47 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                        Write(ViewBag.InstruccionesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaProfesiones = JSON.parse(\'");
#nullable restore
#line 48 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                      Write(ViewBag.ProfesionesLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaProvincias = JSON.parse(\'");
#nullable restore
#line 49 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                     Write(ViewBag.ProvinciasLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaParroquias = JSON.parse(\'");
#nullable restore
#line 50 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Registros\Calificacion.cshtml"
                                     Write(ViewBag.ParroquiasLista);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'.replace(/&quot;/g, '""'));

        jQuery(function ($) {

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
                        $(grid_selector).jqGrid('setGridWidth', parent_column.width());
                    }, 20);
                }
            })

            jQuery(grid_selector).jqGrid({
  ");
                WriteLiteral(@"              url: ""/Equipos/ObtenerEquipos"",
                datatype: 'json',
                mtype: 'GET',
                height: 320,
                colNames: ['ID', 'Nombre', 'Color', 'Fecha Fundación', 'Dirigente', 'Liga', 'Foto'],
                colModel: [
                    { key: true, hidden: true, name: 'id', index: 'id', editable: false },
                    { name: 'nombre', index: 'nombre', width: 150, editable: false },
                    { name: 'color', index: 'color', width: 50, editable: false },
                    { name: 'fechaFundacion', index: 'fechaFundacion', width: 90, editable: false, sorttype: ""date"", formatter: dateTable },
                    { name: 'dirigenteID', index: 'dirigenteID', width: 150, editable: false, edittype: 'select', formatter: 'select', editoptions: { value: getDirigentes() } },
                    { name: 'ligaID', index: 'ligaID', width: 150, editable: false, edittype: 'select', formatter: 'select', editoptions: { value: getLigas() } },
  ");
                WriteLiteral(@"                  { name: 'foto', index: 'foto', width: 150, align: 'center', editable: false, edittype: ""file"", editoptions: { enctype: 'multipart/form-data' }, formatter: imageFormat }
                ],
                iconSet: ""fontAwesome"",
                viewrecords: true,
                rowNum: 5,
                rowList: [5, 10, 15, 20, 25],
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
                    }, 0);
                },
                caption: ""Equipos"",
                subGrid: true,
                subGridOptions: {
                    plusicon: ""fas fa-chevron-right"",
  ");
                WriteLiteral(@"                  minusicon: ""fas fa-chevron-down"",
                    openicon: ""fas fa-angle-double-right"",
                    expandOnLoad: false,
                    selectOnExpand: false,
                    reloadOnExpand: true
                },
                subGridRowExpanded: function (subgrid_id, row_id) {
                    // we pass two parameters
                    // subgrid_id is a id of the div tag created within a table
                    // the row_id is the id of the row
                    // If we want to pass additional parameters to the url we can use
                    // the method getRowData(row_id) - which returns associative array in type name-value
                    // here we can easy construct the following
                    var subgrid_table_id;
                    subgrid_table_id = subgrid_id + ""_t"";
                    jQuery(""#"" + subgrid_id).html(""<table id='"" + subgrid_table_id + ""' class='scroll'></table>"");
                    jQuery(""#"" + ");
                WriteLiteral(@"subgrid_table_id).jqGrid({
                        url: ""/Jugadores/ObtenerJugadores"",
                        datatype: 'json',
                        mtype: 'GET',
                        postData: { equipoID: function () { return row_id; } },
                        height: '100%',
                        colNames: ['ID', 'Equipo', 'Estado Civil', 'Instrucción', 'Profesión', 'Provincia', 'Parroquia', 'Cédula de identidad', 'Nombre', 'Apellido', 'Fecha de Nacimiento', 'Carnet', 'Fecha de Afiliacion', 'Activo', 'Aprobado' , 'Foto', ''],
                        colModel: [
                            { key: true, hidden: true, name: 'id', index: 'id', editable: true },
                            { name: 'equipoID', index: 'equipoID', hidden: true, editable: false, editrules: { edithidden: false }, edittype: 'select', formatter: 'select', editoptions: { value: getEquipos() } },
                            { name: 'estadoCivilID', index: 'estadoCivilID', hidden: true, editable: true, editrules: { ed");
                WriteLiteral(@"ithidden: true }, edittype: 'select', formatter: 'select', editoptions: { value: getEstadosCiviles(), disabled: true } },
                            { name: 'instruccionID', index: 'instruccionID', hidden: true, editable: true, editrules: { edithidden: true }, edittype: 'select', formatter: 'select', editoptions: { value: getInstrucciones(), disabled: true } },
                            { name: 'profesionID', index: 'profesionID', hidden: true, editable: true, editrules: { edithidden: true }, edittype: 'select', formatter: 'select', editoptions: { value: getProfesiones(), disabled: true } },
                            { name: 'provinciaID', index: 'provinciaID', hidden: true, editable: true, editrules: { edithidden: true }, edittype: 'select', formatter: 'select', editoptions: { value: getProvincias(), disabled: true } },
                            { name: 'parroquiaID', index: 'parroquiaID', hidden: true, editable: true, editrules: { edithidden: true }, edittype: 'select', formatter: 'select', edito");
                WriteLiteral(@"ptions: { value: getParroquias(), disabled: true } },
                            { name: 'cedula', index: 'cedula', editable: true, editoptions: { readonly: ""readonly""} },
                            { name: 'nombre', index: 'nombre', editable: true, editoptions: { readonly: ""readonly""} },
                            { name: 'apellido', index: 'apellido', editable: true, editoptions: { readonly: ""readonly"" } },
                            { name: 'fechaNacimiento', index: 'fechaNacimiento', align: 'center', editable: true, sorttype: ""date"", unformat: pickDate, formatter: dateTable, editoptions: { readonly: ""readonly"" } },
                            { name: 'carnet', index: 'carnet', align: 'center', editable: true, editoptions: { readonly: ""readonly"" } },
                            { name: 'fechaAfiliacion', index: 'fechaAfiliacion', align: 'center', editable: true, sorttype: ""date"", unformat: pickDate, formatter: dateTable, editoptions: { readonly: ""readonly"" } },
                            { name");
                WriteLiteral(@": 'estado', index: 'estado', hidden: true, editable: true, editrules: { edithidden: false }, hidedlg: true, edittype: ""checkbox"", align: 'center', formatter: checkTable, editoptions: { readonly: ""readonly"" } },
                            { name: 'calificado', index: 'calificado', width: 70, editable: false, edittype: ""checkbox"", align: 'center', formatter: checkTable},
                            { name: 'foto', index: 'foto', align: 'center', editable: true, edittype: ""custom"", editoptions: { enctype: 'multipart/form-data', custom_element: imageFormatEdit }, formatter: imageFormat, unformat: imageUnFormat},
                            {
                                name: 'myac', width: 80, fixed: true, sortable: false, resize: false, formatter: 'actions',
                                formatoptions: {
                                    key: true,
                                    editbutton: true,
                                    delbutton: false,
                                    edit");
                WriteLiteral(@"formbutton: true,
                                    editOptions: {
                                        url: ""/Jugadores/Calificar"",
                                        mtype: 'PUT',
                                        modal: true,
                                        recreateForm: true,
                                        closeAfterEdit: true,
                                        reloadAfterSubmit: true,
                                        beforeShowForm: function (form) {
                                            form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />');
                                            var dlgDiv = form.closest('.ui-jqdialog');
                                            dlgDiv[0].style.top = ""0px"";
                                            dlgDiv[0].style.left = Math.round((screen.width / 2) - (dlgDiv.width() / 2)) + ""px"";
                                            dlgDiv.find("".ui-jqdialog");
                WriteLiteral(@"-title"").html(""Calificación"");
                                            dlgDiv.find(""#sData"").text('Aprobar');
                                        },
                                        errorTextFormat: FormatedorMensajesError,
                                    }
                                }
                            },
                        ],
                        rowNum: 30,
                        viewrecords: true,
                        shrinkToFit: true,
                        autowidth: true,
                        altRows: true,
                        sortname: 'num',
                        sortorder: ""asc""
                    }).setGridWidth($(grid_selector).width() * .98);
                }

            });

            $(window).triggerHandler('resize.jqGrid');//trigger window resize to make the grid get the correct size

            $(document).one('ajaxloadstart.page', function (e) {
                $.jgrid.gridDestroy(grid_selector);
        ");
                WriteLiteral(@"        $('.ui-jqdialog').remove();
            });
        });

        function getDirigentes() {
            return listaDirigentes;
        }

        function getLigas() {
            return listaLigas;
        }

        function getEquipos() {
            return listaEquipos;
        }

        function getEstadosCiviles() {
            return listaEstadosCiviles;
        }

        function getInstrucciones() {
            return listaInstrucciones;
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
