#pragma checksum "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "293b23db4ab87a80b4316e0604df47ce60e2d833"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Publisher_Info), @"mvc.1.0.view", @"/Views/Publisher/Info.cshtml")]
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
#line 1 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\_ViewImports.cshtml"
using LibraryPlotnikova;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\_ViewImports.cshtml"
using LibraryPlotnikova.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"293b23db4ab87a80b4316e0604df47ce60e2d833", @"/Views/Publisher/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a278399f40f9092e79b47ce152ba615b95d2e355", @"/Views/_ViewImports.cshtml")]
    public class Views_Publisher_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Domain.Entities.Publisher>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/info.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/tables.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
   ViewData["Title"] = "Publisher Info"; 

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "293b23db4ab87a80b4316e0604df47ce60e2d8334357", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "293b23db4ab87a80b4316e0604df47ce60e2d8335469", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n<div class=\"container\">\n    <table>\n        <tr>\n            <th colspan=\"2\">");
#nullable restore
#line 9 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
                       Write(Html.ActionLink("Назад ко всем издателям", "Index", "Publisher"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n        </tr>\n        <tr>\n            <th><h3>");
#nullable restore
#line 12 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3></th>\n            <th>\n                <a");
            BeginWriteAttribute("href", " href=\"", 427, "\"", 491, 1);
#nullable restore
#line 14 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
WriteAttributeValue("", 434, Url.Action("Update", "Publisher", new { id = Model.Id }), 434, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&#9999;</a>\n                <a");
            BeginWriteAttribute("href", " href=\"", 523, "\"", 596, 1);
#nullable restore
#line 15 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
WriteAttributeValue("", 530, Url.Action("DeletionAttempt", "Publisher", new { id = Model.Id }), 530, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&#10060;</a>\n            </th>\n        </tr>\n    </table>\n\n    <br />\n    <div class=\"info-block\"><a class=\"info-header\">Страна</a> ");
#nullable restore
#line 21 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
                                                         Write(Model.Country.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
#nullable restore
#line 23 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
     if (Model.Books.Any())
    {
        int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"info-block\">\n            <div class=\"info-header\">Книги (");
#nullable restore
#line 27 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
                                       Write(Model.Books.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" шт.)</div>\n");
#nullable restore
#line 28 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
             foreach (var item in Model.Books)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>");
#nullable restore
#line 30 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(". ");
#nullable restore
#line 30 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
                    Write(Html.ActionLink($"{item.Name}", "Info", "Book", new { id = @item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
#nullable restore
#line 30 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
                                                                                                      i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n");
#nullable restore
#line 33 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Publisher\Info.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Domain.Entities.Publisher> Html { get; private set; }
    }
}
#pragma warning restore 1591
