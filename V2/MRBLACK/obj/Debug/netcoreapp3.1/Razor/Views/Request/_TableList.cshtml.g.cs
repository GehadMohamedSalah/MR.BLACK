#pragma checksum "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "927e5b5821095152f2576c46a9bf7552cdbf687a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request__TableList), @"mvc.1.0.view", @"/Views/Request/_TableList.cshtml")]
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
#line 1 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\_ViewImports.cshtml"
using MRBLACK;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\_ViewImports.cshtml"
using MRBLACK.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
using MRBLACK.Models.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"927e5b5821095152f2576c46a9bf7552cdbf687a", @"/Views/Request/_TableList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Request__TableList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MRBLACK.Models.ViewModels.RequestIndexVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
  
    Layout = null;
    var i = ViewBag.PageStartRowNum;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 11 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            ");
#nullable restore
#line 13 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 16 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.StudentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 19 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
       Write(Html.DisplayFor(modelItem => item.RequestDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 22 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
             if (item.Status == (int)Status.Pending)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"text-blue\">قيد الانتظار</span>\r\n");
#nullable restore
#line 25 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
            }
            else if (item.Status == (int)Status.Accepted)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"text-black\">تم الموافقة وقيد العمل</span>\r\n");
#nullable restore
#line 29 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
            }
            else if (item.Status == (int)Status.Finished)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"text-warning\">تم الانتهاء</span>\r\n");
#nullable restore
#line 33 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
            }
            else if (item.Status == (int)Status.Delivered)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"text-success\">تم التسليم</span>\r\n");
#nullable restore
#line 37 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 40 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
             if (item.Total == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>لم تحدد بعد</span>\r\n");
#nullable restore
#line 43 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Total));

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
                                                         
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n        <td>\r\n");
#nullable restore
#line 50 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
             if (ViewBag.IsStudent == true)
            {
                if (item.Status == (int)Status.Pending && item.ProvidersAccepted == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1592, "\"", 1621, 2);
            WriteAttributeValue("", 1599, "/Request/Edit/", 1599, 14, true);
#nullable restore
#line 54 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
WriteAttributeValue("", 1613, item.Id, 1613, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i><span>  تعديل</span></a>\r\n");
#nullable restore
#line 55 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
                }
                if (item.Status == (int)Status.Pending)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#flipFlop\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1878, "\"", 1925, 3);
            WriteAttributeValue("", 1888, "FillPopup(\'/Request/Delete/", 1888, 27, true);
#nullable restore
#line 58 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
WriteAttributeValue("", 1915, item.Id, 1915, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1923, "\')", 1923, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fa fa-trash\"></i><span>  حذف</span>\r\n                    </button>\r\n");
#nullable restore
#line 61 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 2103, "\"", 2135, 2);
            WriteAttributeValue("", 2110, "/Request/Details/", 2110, 17, true);
#nullable restore
#line 63 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
WriteAttributeValue("", 2127, item.Id, 2127, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-eye\"></i></a>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 66 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Request\_TableList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MRBLACK.Models.ViewModels.RequestIndexVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
