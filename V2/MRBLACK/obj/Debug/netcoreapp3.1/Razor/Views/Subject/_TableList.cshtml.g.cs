#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d86eafcf3bfa035e4d773c9ff828c2294e590c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subject__TableList), @"mvc.1.0.view", @"/Views/Subject/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d86eafcf3bfa035e4d773c9ff828c2294e590c1", @"/Views/Subject/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Subject__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.Subject>>
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
 foreach (var item in Model)
{
    var ucdsCount = 0;
    //var allucds = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>SUB_");
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 18 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 21 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
             if (item.UcdsEductionManagement != null && item.UcdsEductionManagement.Count() > 0)
            {
                ucdsCount = item.UcdsEductionManagement.Where(c => c.DepartmentId != null && c.CollegeId != null && c.UniversityId != null).Select(c => c.DepartmentId + "_" + c.CollegeId + "_" + c.UniversityId + "_" + c.University.CountryId).Distinct().Count();
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 846, "\"", 917, 1);
#nullable restore
#line 25 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
WriteAttributeValue("", 853, ucdsCount == 0 ? "#" : "/Subject/SubjectDepartments/"+item.Id, 853, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <span");
            BeginWriteAttribute("class", " class=\"", 942, "\"", 1002, 1);
#nullable restore
#line 26 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
WriteAttributeValue("", 950, ucdsCount == 0 ? "text-gray" : "font-weight-bold", 950, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
                                                                              Write(ucdsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </a>\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 30 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
             if (item.Service != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 32 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
                 Write(item.Service.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 33 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>0</span>\r\n");
#nullable restore
#line 37 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 40 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
             if (item.ServiceCategoryRequest != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 42 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
                 Write(item.ServiceCategoryRequest.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 43 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>0</span>\r\n");
#nullable restore
#line 47 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 50 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
             if (item.ImgPath != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6d86eafcf3bfa035e4d773c9ff828c2294e590c110227", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1643, "~/Uploads/Images/Subjects/", 1643, 26, true);
#nullable restore
#line 52 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
AddHtmlAttributeValue("", 1669, item.ImgPath, 1669, 13, false);

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
            BeginWriteAttribute("href", " href=\"", 1781, "\"", 1817, 2);
            WriteAttributeValue("", 1788, "/Subject/RemoveImage/", 1788, 21, true);
#nullable restore
#line 54 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
WriteAttributeValue("", 1809, item.Id, 1809, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> ?????? ????????????</a>\r\n");
#nullable restore
#line 55 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2025, "\"", 2070, 3);
            WriteAttributeValue("", 2035, "FillPopup(\'/Subject/Edit/", 2035, 25, true);
#nullable restore
#line 58 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
WriteAttributeValue("", 2060, item.Id, 2060, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2068, "\')", 2068, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i><span>  ??????????</span>\r\n            </button>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2261, "\"", 2308, 3);
            WriteAttributeValue("", 2271, "FillPopup(\'/Subject/Delete/", 2271, 27, true);
#nullable restore
#line 61 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
WriteAttributeValue("", 2298, item.Id, 2298, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2306, "\')", 2306, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i><span>  ??????</span>\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 66 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Subject\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.Subject>> Html { get; private set; }
    }
}
#pragma warning restore 1591
