#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d17e534dae8acff6c09581d5b8f0bf8f85ab45dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookCategory__TableList), @"mvc.1.0.view", @"/Views/BookCategory/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d17e534dae8acff6c09581d5b8f0bf8f85ab45dd", @"/Views/BookCategory/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_BookCategory__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.BookCategory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.EnName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            <button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 464, "\"", 514, 3);
            WriteAttributeValue("", 474, "FillPopup(\'/BookCategory/Edit/", 474, 30, true);
#nullable restore
#line 18 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
WriteAttributeValue("", 504, item.Id, 504, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 512, "\')", 512, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i><span>  تعديل</span>\r\n            </button>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 705, "\"", 757, 3);
            WriteAttributeValue("", 715, "FillPopup(\'/BookCategory/Delete/", 715, 32, true);
#nullable restore
#line 21 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
WriteAttributeValue("", 747, item.Id, 747, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 755, "\')", 755, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i><span>  حذف</span>\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 26 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\BookCategory\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.BookCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
