#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d701425e6807a32ca59a74ecf2b07af82ebde6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Term__TableList), @"mvc.1.0.view", @"/Views/Term/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d701425e6807a32ca59a74ecf2b07af82ebde6f", @"/Views/Term/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Term__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.Term>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 397, "\"", 439, 3);
            WriteAttributeValue("", 407, "FillPopup(\'/Term/Edit/", 407, 22, true);
#nullable restore
#line 16 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
WriteAttributeValue("", 429, item.Id, 429, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 437, "\')", 437, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i>\r\n            </button>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 610, "\"", 654, 3);
            WriteAttributeValue("", 620, "FillPopup(\'/Term/Delete/", 620, 24, true);
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
WriteAttributeValue("", 644, item.Id, 644, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 652, "\')", 652, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i>\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 24 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Term\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.Term>> Html { get; private set; }
    }
}
#pragma warning restore 1591
