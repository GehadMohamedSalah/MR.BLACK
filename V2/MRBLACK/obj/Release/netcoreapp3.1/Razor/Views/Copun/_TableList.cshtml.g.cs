#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a20a7a92a7ff3da615f6af41e83877b287c66cdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Copun__TableList), @"mvc.1.0.view", @"/Views/Copun/_TableList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a20a7a92a7ff3da615f6af41e83877b287c66cdb", @"/Views/Copun/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Copun__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.Database.Copun>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>COP_");
#nullable restore
#line 11 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.NameOrCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 16 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
             if (item.Category != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 18 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
                 Write(item.Category.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 19 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.DiscountPercentage));

#line default
#line hidden
#nullable disable
            WriteLiteral(" %\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 25 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
             if (item.DiscountOnWho == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>المنصة</span>\r\n");
#nullable restore
#line 28 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>مقدم الخدمة</span>\r\n");
#nullable restore
#line 32 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 35 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
              
                var s = (DateTime)item.StartDate;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 38 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(s.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 41 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
              
                var e = (DateTime)item.EndDate;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(e.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n\r\n        <td>\r\n");
#nullable restore
#line 48 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
              
                var asd = (DateTime)item.AccountStartDate;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 51 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(asd.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 54 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
       Write(item.MinInvoiceVal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 55 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
             if (item.CurrencyType != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>   ");
#nullable restore
#line 57 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
                    Write(item.CurrencyType.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 58 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n            <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1481, "\"", 1508, 2);
            WriteAttributeValue("", 1488, "/Copun/Edit/", 1488, 12, true);
#nullable restore
#line 61 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
WriteAttributeValue("", 1500, item.Id, 1500, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-edit\"></i><span>  تعديل</span>\r\n            </a>\r\n            <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1694, "\"", 1739, 3);
            WriteAttributeValue("", 1704, "FillPopup(\'/Copun/Delete/", 1704, 25, true);
#nullable restore
#line 64 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
WriteAttributeValue("", 1729, item.Id, 1729, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1737, "\')", 1737, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa fa-trash\"></i><span>  حذف</span>\r\n            </button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 69 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Copun\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.Database.Copun>> Html { get; private set; }
    }
}
#pragma warning restore 1591
