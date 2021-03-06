#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63878a0154be62e934ff763f4b5213e553a57854"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Group__TableList), @"mvc.1.0.view", @"/Views/Group/_TableList.cshtml")]
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
#nullable restore
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
using MRBLACK.Models.Database;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63878a0154be62e934ff763f4b5213e553a57854", @"/Views/Group/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Group__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.Group>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 11 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>GRP_");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 14 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 17 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 20 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
              
                var ucds = item.Department.UcdsEductionManagement.ToList();
                University university = null;
                Country country = null;
                College college = null;
                Department department = item.Department;
                if (ucds != null && ucds.Count > 0)
                {
                    if (ucds.FirstOrDefault(c => c.UniversityId == item.DptUniversityId) != null)
                    {
                        university = ucds.FirstOrDefault(c => c.UniversityId == item.DptUniversityId).University;
                        country = university.Country;
                    }
                    if (ucds.FirstOrDefault(c => c.CollegeId == item.DptCollegeId) != null)
                    {
                        college = ucds.FirstOrDefault(c => c.CollegeId == item.DptCollegeId).College;
                    }
                }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
             if (country != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 41 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
                 Write(country.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - </span>\r\n");
#nullable restore
#line 42 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
             if (university != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 45 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
                 Write(university.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - </span>\r\n");
#nullable restore
#line 46 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
             if (college != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 49 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
                 Write(college.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - </span>\r\n");
#nullable restore
#line 50 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
             if (department != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 53 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
                 Write(department.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 54 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1957, "\"", 2000, 3);
            WriteAttributeValue("", 1967, "FillPopup(\'/Group/Edit/", 1967, 23, true);
#nullable restore
#line 57 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
WriteAttributeValue("", 1990, item.Id, 1990, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1998, "\')", 1998, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i> <span>  ??????????</span>\r\n            </button>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2192, "\"", 2237, 3);
            WriteAttributeValue("", 2202, "FillPopup(\'/Group/Delete/", 2202, 25, true);
#nullable restore
#line 60 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
WriteAttributeValue("", 2227, item.Id, 2227, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2235, "\')", 2235, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i><span>  ??????</span>\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 65 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Group\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.Group>> Html { get; private set; }
    }
}
#pragma warning restore 1591
