#pragma checksum "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44ded09ad9ca99e96eff8987847004db432135a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Campeonato_Asignacion), @"mvc.1.0.view", @"/Views/Campeonato/Asignacion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ded09ad9ca99e96eff8987847004db432135a2", @"/Views/Campeonato/Asignacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Campeonato_Asignacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
  
    ViewData["Title"] = "Partidos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Partidos
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es para la asignación de árbitros y vocales a un partido.
        </small>
    </h1>
</div><!-- /.page-header -->

<div class=""row"">
    <div class=""col-xs-12"">
        <!-- PAGE CONTENT BEGINS -->
");
            WriteLiteral("        <div class=\"form-inline\">\r\n            <h4>\r\n                <i class=\"ace-icon fas fa-hand-point-right icon-animated-hand-pointer blue\"></i>\r\n                <select class=\"form-control\" id=\"formCampeonatos\" onchange=\"onchangeList()\">\r\n");
#nullable restore
#line 34 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                     foreach (var item in ViewBag.CampeonatosLista)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44ded09ad9ca99e96eff8987847004db432135a24637", async() => {
#nullable restore
#line 36 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                             Write(item.Value);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                           WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n                &nbsp;\r\n                <select class=\"form-control\" id=\"formCategoria\" onchange=\"onchangeList()\">\r\n");
#nullable restore
#line 41 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                     foreach (var item in ViewBag.CategoriasLista)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44ded09ad9ca99e96eff8987847004db432135a27144", async() => {
#nullable restore
#line 43 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                             Write(item.Value);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                           WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n                &nbsp;\r\n                <select class=\"form-control\" id=\"formSerie\" onchange=\"onchangeList()\">\r\n");
#nullable restore
#line 48 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                     foreach (var item in ViewBag.SeriesLista)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44ded09ad9ca99e96eff8987847004db432135a29643", async() => {
#nullable restore
#line 50 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                             Write(item.Value);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                           WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 51 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n                &nbsp;\r\n                <select class=\"form-control\" id=\"formRonda\" onchange=\"onchangeList()\">\r\n");
#nullable restore
#line 55 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                     foreach (var item in ViewBag.RondasLista)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44ded09ad9ca99e96eff8987847004db432135a212142", async() => {
#nullable restore
#line 57 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                             Write(item.Value);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                           WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 58 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n                <select class=\"form-control\" id=\"formFecha\" onchange=\"onchangeListFecha()\">\r\n");
#nullable restore
#line 61 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                     foreach (var item in ViewBag.FechasLista)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44ded09ad9ca99e96eff8987847004db432135a214621", async() => {
#nullable restore
#line 63 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                             Write(item.Value);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                           WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 64 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n            </h4>\r\n        </div>\r\n        <br />\r\n        <table id=\"grid-table\"></table>\r\n        <div id=\"grid-pager\"></div>\r\n\r\n        <!-- PAGE CONTENT ENDS -->\r\n    </div><!-- /.col -->\r\n</div><!-- /.row -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <!-- inline scripts related to this page -->\r\n    <script type=\"text/javascript\">\r\n        // Variable Globales\r\n        var ArbitrosFotos;\r\n        var listaEstados = JSON.parse(\'");
#nullable restore
#line 81 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                  Write(ViewBag.PartidosEstadosLista);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'.replace(/&quot;/g, \'\"\'));\r\n        var listaArbitros = JSON.parse(\'");
#nullable restore
#line 82 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Campeonato\Asignacion.cshtml"
                                   Write(ViewBag.ArbitrosLista);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'.replace(/&quot;/g, '""'));

        jQuery(function ($) {

            var grid_selector = ""#grid-table"";
            var pager_selector = ""#grid-pager"";
            var parent_column = $(grid_selector).closest('[class*=""col-""]');

            // Actualizar las parroquias cuando se hace cambio de provincia.
            var cambioArbitrol = function (id, control) {
                if (control.id == ""arbitroIDCentral"") {
                    
                    if (id == 0) {
                        $('#fotoCentral').attr(""src"",""../images/avatars/noimagen.png"");
                    }
                    else {
                        $.get(""../Arbitros/ObtenerFotoArbitro"", { arbitroID: id }, function (data) {
                            if (data == null)
                                $('#fotoCentral').attr(""src"", ""../images/avatars/noimagen.png"");
                            else
                                $('#fotoCentral').attr(""src"", ""data:image/png;base64,"" + data);
             ");
                WriteLiteral(@"           });
                    }
                }
                if (control.id == ""arbitroIDLateraDerecho"") {
                    if (id == 0) {
                        $('#fotoDerecho').attr(""src"", ""../images/avatars/noimagen.png"");
                    }
                    else {
                        $.get(""../Arbitros/ObtenerFotoArbitro"", { arbitroID: id }, function (data) {
                            if (data == null)
                                $('#fotoDerecho').attr(""src"", ""../images/avatars/noimagen.png"");
                            else
                                $('#fotoDerecho').attr(""src"", ""data:image/png;base64,"" + data);
                        });
                    }
                }
                if (control.id == ""arbitroIDLateralIzquierdo"") {
                    if (id == 0) {
                        $('#fotoIzquierdo').attr(""src"", ""../images/avatars/noimagen.png"");
                    }
                    else {
                        $.get("".");
                WriteLiteral(@"./Arbitros/ObtenerFotoArbitro"", { arbitroID: id }, function (data) {
                            if (data == null)
                                $('#fotoIzquierdo').attr(""src"", ""../images/avatars/noimagen.png"");
                            else
                                $('#fotoIzquierdo').attr(""src"", ""data:image/png;base64,"" + data);
                        });
                    }
                }
                return true;
            };

            // Configuramos los eventos para cuando cambie la provincia seleccionada
            var dataEventsArbtros = [
                { type: ""change"", fn: function (e) { cambioArbitrol($(e.target).val(), e.target); } },
                { type: ""keyup"", fn: function (e) { $(e.target).trigger(""change""); } }
            ];

            //resize to fit page size
            $(window).on('resize.jqGrid', function () {
                $(grid_selector).jqGrid('setGridWidth', parent_column.width());
            });

            //resize on ");
                WriteLiteral(@"sidebar collapse/expand
            $(document).on('settings.ace.jqGrid', function (ev, event_name, collapsed) {
                if (event_name === 'sidebar_collapsed' || event_name === 'main_container_fixed') {
                    //setTimeout is for webkit only to give time for DOM changes and then redraw!!!
                    setTimeout(function () {
                        $(grid_selector).jqGrid('setGridWidth', parent_column.width());
                    }, 20);
                }
            })

            jQuery(grid_selector).jqGrid({
                url: ""/Partidos/ObtenerPartidos"",
                datatype: 'json',
                mtype: 'GET',
                postData: {
                    campeonatoID: $(""#formCampeonatos"").val(), categoriaID: $(""#formCategoria"").val(), serieID: $(""#formSerie"").val(), ronda: $(""#formRonda"").val(), fecha: $(""#formFecha"").val()
                },
                height: 400,
                colNames: ['ID', 'Estado del Partido', 'Partido ', 'Árbi");
                WriteLiteral(@"tro Central', 'Foto', 'Árbitro Latera Derecho', 'Foto', 'Árbitro Lateral Izquierdo', 'Foto', 'Vocal Equipo Local', 'Vocal Equipo Visitante',''],
                colModel: [
                    { key: true, hidden: true, name: 'id', index: 'id', editable: true },
                    { name: 'partidoEstadoID', index: 'partidoEstadoID', editable: false, edittype: 'select', formatter: 'select', editoptions: { value: getEstados() } },
                    { name: 'partido', index: 'partido', editable: true, editoptions: { size: ""20"", readonly: true } },
                    { name: 'arbitroIDCentral', index: 'arbitroIDCentral', editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getArbitros(), dataEvents: dataEventsArbtros } },
                    { name: 'fotoCentral', jsonmap: 'arbitroIDCentral', align: 'center', editable: true, edittype: ""custom"", editoptions: { enctype: 'multipart/form-data', custom_element: imageFormatEditArbitro }, formatter: imageFormatArbitroCentral, unformat");
                WriteLiteral(@": imageUnFormat },
                    { name: 'arbitroIDLateraDerecho', index: 'arbitroIDLateraDerecho', editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getArbitros(), dataEvents: dataEventsArbtros } },
                    { name: 'fotoDerecho', jsonmap: 'arbitroIDLateraDerecho', align: 'center', editable: true, edittype: ""custom"", editoptions: { enctype: 'multipart/form-data', custom_element: imageFormatEditArbitro }, formatter: imageFormatArbitroDerecho, unformat: imageUnFormat },
                    { name: 'arbitroIDLateralIzquierdo', index: 'arbitroIDLateralIzquierdo', editable: true, edittype: 'select', formatter: 'select', editoptions: { value: getArbitros(), dataEvents: dataEventsArbtros } },
                    { name: 'fotoIzquierdo', jsonmap: 'arbitroIDLateralIzquierdo', align: 'center', editable: true, edittype: ""custom"", editoptions: { enctype: 'multipart/form-data', custom_element: imageFormatEditArbitro }, formatter: imageFormatArbitroIzquierdo, unformat: ima");
                WriteLiteral(@"geUnFormat },
                    { name: 'vocalEquipoLocal', index: 'vocalEquipoLocal', editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    { name: 'vocalEquipoVisitante', index: 'vocalEquipoVisitante', editable: true, editoptions: { size: ""20"", maxlength: ""100"" } },
                    {
                        name: 'myac', width: 80, fixed: true, sortable: false, resize: false, formatter: 'actions',
                        formatoptions: {
                            key: true,
                            editbutton: true,
                            delbutton: false,
                            editformbutton: true,
                            editOptions: {
                                url: ""/Partidos/Editar"",
                                mtype: 'PUT',
                                modal: true,
                                viewPagerButtons: false,
                                closeAfterEdit: true,
                                recreateForm");
                WriteLiteral(@": true,
                                beforeShowForm: function (form) {
                                    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                                    style_edit_form(form);
                                },
                                errorTextFormat: FormatedorMensajesError
                            },
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
                       ");
                WriteLiteral(@" enableTooltips(table);
                    }, 0);
                },
                caption: ""Árbitros"",

            });

            $(window).triggerHandler('resize.jqGrid');//trigger window resize to make the grid get the correct size

            $(document).one('ajaxloadstart.page', function (e) {
                $.jgrid.gridDestroy(grid_selector);
                $('.ui-jqdialog').remove();
            });
        });

        function getEstados() {
            return listaEstados;
        }

        function getArbitros() {
            return listaArbitros;
        }

        function onchangeList() {
            //form variables for searching
            var jornadaModel = {
                campeonatoID: $(""#formCampeonatos"").val(), categoriaID: $(""#formCategoria"").val(), serieID: $(""#formSerie"").val(), ronda: $(""#formRonda"").val()
            };

            $.get(""../Jornadas/ObtenerJornadasFechas"", jornadaModel, function (data) {
                $(""#formFecha"").emp");
                WriteLiteral(@"ty();

                $.each(data, function (index, fecha) {
                    $(""#formFecha"").append(new Option(fecha.fecha, fecha.id));
                });

                jQuery(""#grid-table"").setGridParam({
                    postData: {
                        campeonatoID: $(""#formCampeonatos"").val(), categoriaID: $(""#formCategoria"").val(), serieID: $(""#formSerie"").val(), ronda: $(""#formRonda"").val(), fecha: data[0].id
                    },
                    page: 1
                }).trigger(""reloadGrid"");
            });
        }

        function onchangeListFecha() {
            jQuery(""#grid-table"").setGridParam({
                postData: {
                    campeonatoID: $(""#formCampeonatos"").val(), categoriaID: $(""#formCategoria"").val(), serieID: $(""#formSerie"").val(), ronda: $(""#formRonda"").val(), fecha: $(""#formFecha"").val()
                },
                page: 1
            }).trigger(""reloadGrid"");
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