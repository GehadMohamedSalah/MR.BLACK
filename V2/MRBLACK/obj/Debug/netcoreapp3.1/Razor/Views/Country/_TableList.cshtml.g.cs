#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "127247e437174d1bbe31102f9cd3b05b142380fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Country__TableList), @"mvc.1.0.view", @"/Views/Country/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"127247e437174d1bbe31102f9cd3b05b142380fc", @"/Views/Country/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Country__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.Country>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n\r\n        <td>");
#nullable restore
#line 18 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.CurrencyType.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n");
#nullable restore
#line 20 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
             if (item.University != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 513, "\"", 602, 1);
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
WriteAttributeValue("", 520, item.University.Count() == 0 ? "#" : "/University/Index?searchStr="+item.ArName, 520, 82, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <span");
            BeginWriteAttribute("class", " class=\"", 631, "\"", 705, 1);
#nullable restore
#line 23 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
WriteAttributeValue("", 639, item.University.Count() == 0 ? "text-gray" : "font-weight-bold", 639, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
                                                                                                Write(item.University.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </a>\r\n");
#nullable restore
#line 25 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 28 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
             if (item.ImgPath != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "127247e437174d1bbe31102f9cd3b05b142380fc7976", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 887, "~/Uploads/Images/Countries/", 887, 27, true);
#nullable restore
#line 30 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
AddHtmlAttributeValue("", 914, item.ImgPath, 914, 13, false);

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
            WriteLiteral("\r\n                <br />\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1026, "\"", 1062, 2);
            WriteAttributeValue("", 1033, "/Country/RemoveImage/", 1033, 21, true);
#nullable restore
#line 32 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
WriteAttributeValue("", 1054, item.Id, 1054, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> حذف الصورة</a>\r\n");
#nullable restore
#line 33 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1270, "\"", 1315, 3);
            WriteAttributeValue("", 1280, "FillPopup(\'/Country/Edit/", 1280, 25, true);
#nullable restore
#line 36 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
WriteAttributeValue("", 1305, item.Id, 1305, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1313, "\')", 1313, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i><span>  تعديل</span>\r\n            </button>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1506, "\"", 1553, 3);
            WriteAttributeValue("", 1516, "FillPopup(\'/Country/Delete/", 1516, 27, true);
#nullable restore
#line 39 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
WriteAttributeValue("", 1543, item.Id, 1543, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1551, "\')", 1551, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i><span>  حذف</span>\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Country\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.Country>> Html { get; private set; }
    }
}
#pragma warning restore 1591
