#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10a44c7a0cac1e92b7cbdd8d4073297eac52bedf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department__TableList), @"mvc.1.0.view", @"/Views/Department/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10a44c7a0cac1e92b7cbdd8d4073297eac52bedf", @"/Views/Department/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Department__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.Department>>
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        ");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
   Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
   Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n");
#nullable restore
#line 18 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
         if(item.UcdsEductionManagement!= null)
        {
            var subjects = item.UcdsEductionManagement.Where(c => c.SubjectId != null).Select(c => c.SubjectId).Distinct().Count();

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 535, "\"", 606, 1);
#nullable restore
#line 21 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
WriteAttributeValue("", 542, subjects == 0 ? "#" : "/Subject/Index?searchStr="+item.ArName, 542, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <span");
            BeginWriteAttribute("class", " class=\"", 631, "\"", 690, 1);
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
WriteAttributeValue("", 639, subjects == 0 ? "text-gray" : "font-weight-bold", 639, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
                                                                             Write(subjects);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </a>\r\n");
#nullable restore
#line 24 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    <td>\r\n");
#nullable restore
#line 27 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
         if(item.UcdsEductionManagement != null && item.UcdsEductionManagement.Count() > 0)
        {
            foreach(var uc in item.UcdsEductionManagement)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>");
#nullable restore
#line 31 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
              Write(uc.College.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 31 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
                                   Write(uc.University.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 31 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
                                                           Write(uc.University.Country.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 32 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    <td>\r\n");
#nullable restore
#line 36 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
         if (item.ImgPath != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10a44c7a0cac1e92b7cbdd8d4073297eac52bedf9220", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1154, "~/Uploads/Images/Departments/", 1154, 29, true);
#nullable restore
#line 38 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
AddHtmlAttributeValue("", 1183, item.ImgPath, 1183, 13, false);

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
            WriteLiteral("\r\n            <br />\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1287, "\"", 1326, 2);
            WriteAttributeValue("", 1294, "/Department/RemoveImage/", 1294, 24, true);
#nullable restore
#line 40 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
WriteAttributeValue("", 1318, item.Id, 1318, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> حذف الصورة</a>\r\n");
#nullable restore
#line 41 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\r\n    <td>\r\n        <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1518, "\"", 1566, 3);
            WriteAttributeValue("", 1528, "FillPopup(\'/Department/Edit/", 1528, 28, true);
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
WriteAttributeValue("", 1556, item.Id, 1556, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1564, "\')", 1564, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-edit\"></i><span>  تعديل</span>\r\n        </button>\r\n        <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1745, "\"", 1795, 3);
            WriteAttributeValue("", 1755, "FillPopup(\'/Department/Delete/", 1755, 30, true);
#nullable restore
#line 47 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
WriteAttributeValue("", 1785, item.Id, 1785, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1793, "\')", 1793, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-trash\"></i><span>  حذف</span>\r\n        </button>\r\n    </td>\r\n</tr>\r\n");
#nullable restore
#line 52 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Department\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.Department>> Html { get; private set; }
    }
}
#pragma warning restore 1591
