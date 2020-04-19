#pragma checksum "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Administracion\Usuarios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58f72346f9bb03b905ffa95a7d3a6a5b907bffb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administracion_Usuarios), @"mvc.1.0.view", @"/Views/Administracion/Usuarios.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58f72346f9bb03b905ffa95a7d3a6a5b907bffb0", @"/Views/Administracion/Usuarios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73406d7ec9995881ab04b55fd2cec498dfc6fbf", @"/Views/_ViewImports.cshtml")]
    public class Views_Administracion_Usuarios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Administracion\Usuarios.cshtml"
  
    ViewData["Title"] = "Usuarios";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\AdminTorneos\Web\TorneoAdmin-App\TorneosAdmin.Web\Views\Administracion\Usuarios.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <h1>
        Usuarios del Sistema
        <small>
            <i class=""ace-icon fa fa-angle-double-right""></i>
            Esta sección es para alta baja y actulización de un usuario.
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
            Nota: Para un usuario nuevo la contraseña es la misma que el usuario.
        </div>

        <table id=""grid-table""></table>
        <div id=""grid-pager""></div>

        <!-- PAGE CONTENT ENDS -->
    </div><!-- /.col -->
</div><!-- /.row -->

");
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
                WriteLiteral(@"      })

            jQuery(grid_selector).jqGrid({
                url: ""/Usuarios/ObtenerUsuarios"",
                datatype: 'json',
                mtype: 'GET',
                height: 250,
                colNames: ['ID', 'Usuario', 'Nombre', 'Apellido Paterno', 'Apellido Materno', 'Correo Electrónico', 'Telefono', 'Activo?'],
                colModel: [
                    { key: true, hidden: true, name: 'id', index: 'id', editable: true },
                    { name: 'usuario', index: 'usuario', width: 150, editable: false, editoptions: { size: ""20"", maxlength: ""30"" } },
                    { name: 'nombre', index: 'uombre', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""30"" } },
                    { name: 'apellidoPaterno', index: 'apellidoPaterno', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""30"" } },
                    { name: 'apellidoMaterno', index: 'apellidoMaterno', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""30""");
                WriteLiteral(@" } },
                    { name: 'correoElectronico', index: 'correoElectronico', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""30"" } },
                    { name: 'telefono', index: 'telefono', width: 150, editable: true, editoptions: { size: ""20"", maxlength: ""30"" } },
                    { name: 'estado', index: 'estado', width: 70, editable: false, edittype: ""checkbox"", align: 'center', formatter: checkTable }
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
                        enableTooltips(table);");
                WriteLiteral(@"
                    }, 0);
                },
                caption: ""Usuarios"",

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
                {
                    //edit");
                WriteLiteral(@" record form
                    //closeAfterEdit: true,
                    //width: 700,
                    url: ""/Usuarios/Editar"",
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
                    url: ""/Usuarios/Crear"",
                    mtype: 'POST',
                    closeAfterAdd: true,
                    recreateForm: true,
                    viewPagerButtons: false,
                    beforeShowForm: function (e) {
                        var for");
                WriteLiteral(@"m = $(e[0]);
                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar')
                            .wrapInner('<div class=""widget-header"" />')
                        style_edit_form(form);
                    },
                    errorTextFormat: FormatedorMensajesError,
                },
                {
                    //delete record form
                    url: ""/Usuarios/Eliminar"",
                    mtype: 'PUT',
                    recreateForm: true,
                    width: 400,
                    beforeShowForm: function (e) {
                        var form = $(e[0]);
                        if (form.data('styled')) return false;

                        form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                        style_delete_form(form);

                        form.data('styled', true);
                    },
                    errorTextFormat: FormatedorMensajesError,");
                WriteLiteral(@"
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
                        style_search_filters($(this));
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
                    ");
                WriteLiteral(@"    var form = $(e[0]);
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
