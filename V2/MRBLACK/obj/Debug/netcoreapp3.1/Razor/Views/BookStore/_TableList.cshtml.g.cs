#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a339fd32105d9db6c9587b51b64ebd5110afdf6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookStore__TableList), @"mvc.1.0.view", @"/Views/BookStore/_TableList.cshtml")]
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
#line 1 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\_ViewImports.cshtml"
using MRBLACK;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\_ViewImports.cshtml"
using MRBLACK.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a339fd32105d9db6c9587b51b64ebd5110afdf6b", @"/Views/BookStore/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_BookStore__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.BookStore>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>BS_");
#nullable restore
#line 11 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
      Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
   Write(item.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
   Write(item.ArAuthoreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 14 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
   Write(item.BookCategory.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n");
#nullable restore
#line 17 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
         if (item.BookCoverImgPath != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a339fd32105d9db6c9587b51b64ebd5110afdf6b6857", async() => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a339fd32105d9db6c9587b51b64ebd5110afdf6b7073", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 490, "~/Uploads/Books/", 490, 16, true);
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 506, item.EnName, 506, 12, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 518, "/", 518, 1, true);
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 519, item.BookCoverImgPath, 519, 22, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 411, "~/Uploads/Books/", 411, 16, true);
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 427, item.EnName, 427, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 439, "/", 439, 1, true);
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 440, item.BookCoverImgPath, 440, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <br />\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 636, "\"", 674, 2);
            WriteAttributeValue("", 643, "/BookStore/RemoveImage/", 643, 23, true);
#nullable restore
#line 21 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
WriteAttributeValue("", 666, item.Id, 666, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> ?????? ????????????</a>\r\n");
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    <td>\r\n");
#nullable restore
#line 25 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
         if (item.BookPdfPath != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a339fd32105d9db6c9587b51b64ebd5110afdf6b11938", async() => {
                WriteLiteral(" ?????? ???? pdf");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 844, "~/Uploads/Books/", 844, 16, true);
#nullable restore
#line 27 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 860, item.EnName, 860, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 872, "/", 872, 1, true);
#nullable restore
#line 27 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 873, item.BookPdfPath, 873, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <br />\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 959, "\"", 995, 2);
            WriteAttributeValue("", 966, "/BookStore/RemovePdf/", 966, 21, true);
#nullable restore
#line 29 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
WriteAttributeValue("", 987, item.Id, 987, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> ?????? pdf</a>\r\n");
#nullable restore
#line 30 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    <td>\r\n");
#nullable restore
#line 33 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
         if (item.BookVoicePath != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a339fd32105d9db6c9587b51b64ebd5110afdf6b14955", async() => {
                WriteLiteral("?????????? ????????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1164, "~/Uploads/Books/", 1164, 16, true);
#nullable restore
#line 35 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 1180, item.EnName, 1180, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 1192, "/", 1192, 1, true);
#nullable restore
#line 35 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
AddHtmlAttributeValue("", 1193, item.BookVoicePath, 1193, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <br />\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1282, "\"", 1320, 2);
            WriteAttributeValue("", 1289, "/BookStore/RemoveVoice/", 1289, 23, true);
#nullable restore
#line 37 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
WriteAttributeValue("", 1312, item.Id, 1312, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> ?????? ?????????? ????????????</a>\r\n");
#nullable restore
#line 38 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    <td>\r\n        <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1455, "\"", 1486, 2);
            WriteAttributeValue("", 1462, "/BookStore/Edit/", 1462, 16, true);
#nullable restore
#line 41 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
WriteAttributeValue("", 1478, item.Id, 1478, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-edit\"></i><span>  ??????????</span>\r\n        </a>\r\n        <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1660, "\"", 1709, 3);
            WriteAttributeValue("", 1670, "FillPopup(\'/BookStore/Delete/", 1670, 29, true);
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
WriteAttributeValue("", 1699, item.Id, 1699, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1707, "\')", 1707, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-trash\"></i><span>  ??????</span>\r\n        </button>\r\n    </td>\r\n</tr>\r\n");
#nullable restore
#line 49 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookStore\_TableList.cshtml"
    i++;
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.BookStore>> Html { get; private set; }
    }
}
#pragma warning restore 1591
