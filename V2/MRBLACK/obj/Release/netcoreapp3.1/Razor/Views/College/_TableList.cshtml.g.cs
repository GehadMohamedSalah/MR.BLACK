#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4f0cad9a3644d2f098ced034de9374af48c08d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_College__TableList), @"mvc.1.0.view", @"/Views/College/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4f0cad9a3644d2f098ced034de9374af48c08d8", @"/Views/College/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_College__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.College>>
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
 foreach (var item in Model)
{
    var ucdsCount = 0;
    var allucds = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>COG_");
#nullable restore
#line 14 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 16 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            <a href=\"/AcademicYear/Index\">\r\n                <span");
            BeginWriteAttribute("class", " class=\"", 506, "\"", 567, 1);
#nullable restore
#line 23 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 514, item.Years == 0 ? "text-gray" : "font-weight-bold", 514, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
                                                                               Write(item.Years);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </a>\r\n        </td>\r\n        <td>\r\n            <a href=\"/Term/Index\">\r\n                <span");
            BeginWriteAttribute("class", " class=\"", 693, "\"", 754, 1);
#nullable restore
#line 28 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 701, item.Terms == 0 ? "text-gray" : "font-weight-bold", 701, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
                                                                               Write(item.Terms);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </a>\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 32 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
             if (item.UcdsEductionManagement != null)
            {
                var depts = item.UcdsEductionManagement.Where(c => c.DepartmentId != null).Select(c => c.DepartmentId).Distinct().Count();

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 1051, "\"", 1122, 1);
#nullable restore
#line 35 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 1058, depts == 0 ? "#" : "/Department/Index?searchStr="+item.ArName, 1058, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <span");
            BeginWriteAttribute("class", " class=\"", 1151, "\"", 1207, 1);
#nullable restore
#line 36 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 1159, depts == 0 ? "text-gray" : "font-weight-bold", 1159, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 36 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
                                                                              Write(depts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </a>\r\n");
#nullable restore
#line 38 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 41 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
             if (item.UcdsEductionManagement != null)
            {
                var subjects = item.UcdsEductionManagement.Where(c => c.SubjectId != null).Select(c => c.SubjectId).Distinct().Count();

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 1515, "\"", 1586, 1);
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 1522, subjects == 0 ? "#" : "/Subject/Index?searchStr="+item.ArName, 1522, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <span");
            BeginWriteAttribute("class", " class=\"", 1615, "\"", 1674, 1);
#nullable restore
#line 45 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 1623, subjects == 0 ? "text-gray" : "font-weight-bold", 1623, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
                                                                                 Write(subjects);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </a>\r\n");
#nullable restore
#line 47 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            <span class=\"text-gray\">0</span>\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 53 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
             if (item.UcdsEductionManagement != null && item.UcdsEductionManagement.Count() > 0)
            {
                foreach (var ucds in item.UcdsEductionManagement.Select(c => c.University).Distinct())
                {
                    ucdsCount++;
                    allucds += ucds.ArName + "_";
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
                                                                  
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 2272, "\"", 2343, 1);
#nullable restore
#line 62 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 2279, ucdsCount == 0 ? "#" : "/University/Index?searchStr="+allucds, 2279, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <span");
            BeginWriteAttribute("class", " class=\"", 2368, "\"", 2428, 1);
#nullable restore
#line 63 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 2376, ucdsCount == 0 ? "text-gray" : "font-weight-bold", 2376, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 63 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
                                                                              Write(ucdsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </a>\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 67 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
             if (item.ImgPath != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d4f0cad9a3644d2f098ced034de9374af48c08d813828", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2577, "~/Uploads/Images/Colleges/", 2577, 26, true);
#nullable restore
#line 69 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
AddHtmlAttributeValue("", 2603, item.ImgPath, 2603, 13, false);

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
            BeginWriteAttribute("href", " href=\"", 2715, "\"", 2751, 2);
            WriteAttributeValue("", 2722, "/College/RemoveImage/", 2722, 21, true);
#nullable restore
#line 71 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 2743, item.Id, 2743, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-danger\"><i class=\"fa fa-times\"></i> حذف الصورة</a>\r\n");
#nullable restore
#line 72 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2959, "\"", 3004, 3);
            WriteAttributeValue("", 2969, "FillPopup(\'/College/Edit/", 2969, 25, true);
#nullable restore
#line 75 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 2994, item.Id, 2994, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3002, "\')", 3002, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i>  تعديل\r\n            </button>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3182, "\"", 3229, 3);
            WriteAttributeValue("", 3192, "FillPopup(\'/College/Delete/", 3192, 27, true);
#nullable restore
#line 78 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
WriteAttributeValue("", 3219, item.Id, 3219, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3227, "\')", 3227, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i>  حذف\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 83 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.College>> Html { get; private set; }
    }
}
#pragma warning restore 1591
