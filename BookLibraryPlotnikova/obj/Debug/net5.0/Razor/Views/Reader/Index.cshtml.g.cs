#pragma checksum "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e9dc08c718df595da14eba5dd7b22529b8be2d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reader_Index), @"mvc.1.0.view", @"/Views/Reader/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e9dc08c718df595da14eba5dd7b22529b8be2d5", @"/Views/Reader/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a278399f40f9092e79b47ce152ba615b95d2e355", @"/Views/_ViewImports.cshtml")]
    public class Views_Reader_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<Domain.Entities.Reader>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reader", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
   ViewData["Title"] = "Readers"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1e9dc08c718df595da14eba5dd7b22529b8be2d55209", async() => {
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
            WriteLiteral("\n\n\n<div class=\"container\">\n    <table>\n        <tr>\n            <th><h3>Читатели</h3></th>\n            <th>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e9dc08c718df595da14eba5dd7b22529b8be2d56453", async() => {
                WriteLiteral("\n                    <button type=\"submit\" class=\"btn btn-outline-dark\">Добавить читателя</button>\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </th>
        </tr>
    </table>

    <table class=""main_table"">
        <thead>
            <tr>
                <th>Имя</th>
                <th>Паспорт</th>
                <th>Email</th>
                <th>Книги</th>
                <th></th>
                <th></th>
                <th></th>
            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 33 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
             foreach (var item in @Model)
            {
                int numberOfBooks = item.BookCheckouts.Count(e => e.DateBookReturned == null);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 37 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 38 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                   Write(item.Passport);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 39 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                   Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 40 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                   Write(item.BookCheckouts.Count(bc => bc.DateBookReturned == null));

#line default
#line hidden
#nullable disable
            WriteLiteral(" шт.</td> \n                    <td>");
#nullable restore
#line 41 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                   Write(Html.ActionLink("Выдать", "GiveBooks", new { readerId = item.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>\n");
#nullable restore
#line 43 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                         if (numberOfBooks != 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                       Write(Html.ActionLink("Принять", "TakeBooks", new { readerId = item.Id}));

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                                                                                               
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\n                    <td>\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1592, "\"", 1651, 1);
#nullable restore
#line 49 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
WriteAttributeValue("", 1599, Url.Action("Info", "Reader", new { id = @item.Id }), 1599, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&#128269;</a>\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1693, "\"", 1754, 1);
#nullable restore
#line 50 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
WriteAttributeValue("", 1700, Url.Action("Change", "Reader", new { id = @item.Id }), 1700, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&#9999;</a>\n");
#nullable restore
#line 51 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                         if (numberOfBooks == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1873, "\"", 1934, 1);
#nullable restore
#line 53 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
WriteAttributeValue("", 1880, Url.Action("Delete", "Reader", new { id = @item.Id }), 1880, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&#10060;</a>\n");
#nullable restore
#line 54 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\n                </tr>\n");
#nullable restore
#line 57 "D:\VSU\Labs\5th_semester\.Net\BookLibraryPlotnikova\Views\Reader\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>     \n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<Domain.Entities.Reader>> Html { get; private set; }
    }
}
#pragma warning restore 1591
