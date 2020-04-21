#pragma checksum "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Catalogos\EstadosCiviles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b21df79183b4c08c6d547e6999be6ee856112ea7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalogos_EstadosCiviles), @"mvc.1.0.view", @"/Views/Catalogos/EstadosCiviles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b21df79183b4c08c6d547e6999be6ee856112ea7", @"/Views/Catalogos/EstadosCiviles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalogos_EstadosCiviles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Catalogos\EstadosCiviles.cshtml"
  
    ViewData["Title"] = "EstadosCiviles";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Catalogos\EstadosCiviles.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Estados Civiles en el Sistema
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es para alta, baja y actulización de un estado civil.
        </small>
    </h1>
</div><!-- /.page-header -->

<div class=""row"">
    <div class=""col-xs-12"">
        <!-- PAGE CONTENT BEGINS -->
");
            WriteLiteral("\r\n        <table id=\"grid-table\"></table>\r\n        <div id=\"grid-pager\"></div>\r\n\r\n        <!-- PAGE CONTENT ENDS -->\r\n    </div><!-- /.col -->\r\n</div><!-- /.row -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <!-- inline scripts related to this page -->
    <script type=""text/javascript"">

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
    ");
                WriteLiteral(@"        })

            jQuery(grid_selector).jqGrid({
                url: ""/EstadosCiviles/ObtenerEstadosCiviles"",
                datatype: 'json',
                mtype: 'GET',
                height: 400,
                colNames: ['ID', 'Descripción del estado civil'],
                colModel: [
                    { key: true, hidden: true, name: 'id', index: 'id', editable: true },
                    { name: 'descripcion', index: 'descripcion', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""50"" } }
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
                    $(""#grid-pager_left"")");
                WriteLiteral(@".css('width', '') // Unicamente aplicar cuando sean pocas colunas y no sea bien la barra de iconos
                    setTimeout(function () {
                        updatePagerIcons(table);
                        enableTooltips(table);
                    }, 0);
                },
                caption: ""Estados Civiles"",

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
                    ");
                WriteLiteral(@"refresh: true,
                    refreshicon: 'ace-icon fas fa-sync-alt green',
                    view: true,
                    viewicon: 'ace-icon fas fa-search-plus grey',
                },
                {
                    //edit record form
                    //closeAfterEdit: true,
                    //width: 700,
                    url: ""/EstadosCiviles/Editar"",
                    mtype: 'PUT',
                    closeAfterEdit: true,
                    recreateForm: true,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                    },
                    errorTextFormat: FormatedorMensajesError,
                },
                {
                    //new record form
                    //width: 700,
                    url: ""/EstadosCivi");
                WriteLiteral(@"les/Crear"",
                    mtype: 'POST',
                    closeAfterAdd: true,
                    recreateForm: true,
                    viewPagerButtons: false,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar')
                            .wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                    },
                    errorTextFormat: FormatedorMensajesError,
                },
                {
                    //delete record form
                    url: ""/EstadosCiviles/Eliminar"",
                    mtype: 'DELETE',
                    recreateForm: true,
                    width: 400,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        if (form.data('styled')) return false;

                        form.closest('.ui-jqdia");
                WriteLiteral(@"log').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_delete_form(form);

                        form.data('styled', true);

                        form.find("".delmsg"").text(""¿Desea eliminar el estado civil?"");
                        form.closest('.ui-jqdialog').find(""#dData"").text('Eliminar');
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
                 ");
                WriteLiteral(@"       style_search_filters($(this));
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