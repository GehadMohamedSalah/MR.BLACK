#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b3cb182394f39ae85f6f29e1c7e37a9c5faec2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Pagination), @"mvc.1.0.view", @"/Views/Shared/_Pagination.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b3cb182394f39ae85f6f29e1c7e37a9c5faec2f", @"/Views/Shared/_Pagination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Pagination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRBLACK.Models.ViewModels.PaginationVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
  
    var prevDisabled = !Model.PreviousPage ? "disabled" : "";
    var nextDisabled = !Model.NextPage ? "disabled" : "";
    var tbl_footer_msg = "عرض " + Model.StartIndex + " الى " + Model.EndIndex + " من " + Model.ItemsCount + " مدخلات ";


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-sm-4 mt-15\">\r\n        <p>\r\n            ");
#nullable restore
#line 11 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
       Write(tbl_footer_msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"col-sm-8\" style=\"text-align:left\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 482, "\"", 533, 4);
            WriteAttributeValue("", 490, "btn", 490, 3, true);
            WriteAttributeValue(" ", 493, "btn-default", 494, 12, true);
            WriteAttributeValue(" ", 505, "btnpagination", 506, 14, true);
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
WriteAttributeValue(" ", 519, prevDisabled, 520, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", "\r\n           onclick=\"", 534, "\"", 596, 3);
            WriteAttributeValue("", 556, "ReloadPagination(", 556, 17, true);
#nullable restore
#line 16 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
WriteAttributeValue("", 573, Model.PageIndex - 1, 573, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 595, ")", 595, 1, true);
            EndWriteAttribute();
            WriteLiteral(">السابق</a>\r\n");
#nullable restore
#line 17 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
         for (var i = 1; i <= Model.TotalPages; i++)
        {
            if (Model.PageIndex == i)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"btn btn-info btnpagination\"");
            BeginWriteAttribute("onclick", "\r\n                   onclick=\"", 782, "\"", 832, 3);
            WriteAttributeValue("", 812, "ReloadPagination(", 812, 17, true);
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
WriteAttributeValue("", 829, i, 829, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 831, ")", 831, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 23 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"btn btn-default btnpagination\"");
            BeginWriteAttribute("onclick", "\r\n                   onclick=\"", 946, "\"", 996, 3);
            WriteAttributeValue("", 976, "ReloadPagination(", 976, 17, true);
#nullable restore
#line 27 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
WriteAttributeValue("", 993, i, 993, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 995, ")", 995, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 28 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
            }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("class", " class=\"", 1044, "\"", 1095, 4);
            WriteAttributeValue("", 1052, "btn", 1052, 3, true);
            WriteAttributeValue(" ", 1055, "btn-default", 1056, 12, true);
            WriteAttributeValue(" ", 1067, "btnpagination", 1068, 14, true);
#nullable restore
#line 31 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
WriteAttributeValue(" ", 1081, nextDisabled, 1082, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", "\r\n           onclick=\"", 1096, "\"", 1158, 3);
            WriteAttributeValue("", 1118, "ReloadPagination(", 1118, 17, true);
#nullable restore
#line 32 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
WriteAttributeValue("", 1135, Model.PageIndex + 1, 1135, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1157, ")", 1157, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">التالي</a>
    </div>
</div>


<script type=""text/javascript"">
    function ReloadPagination(pageNum) {
        var inpSearchVal = document.getElementById(""inpSearch"").value;
        var pageSize = 5;
        if ($(""#entires"") != null || $(""#entires"") != undefined) {
            pageSize = $(""#entires"").val();
        }
        $.ajax({
            url: """);
#nullable restore
#line 45 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
             Write(Model.GetItemsUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            type: ""GET"",
            data: { searchStr: inpSearchVal, pageNumber: pageNum, pageSize: pageSize },
            success: function (results) {
                $(""#tbBody"").empty();
                $(""#tbBody"").html(results);
                $.ajax({
                    url: """);
#nullable restore
#line 52 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Shared\_Pagination.cshtml"
                     Write(Model.GetPaginationUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    type: ""GET"",
                    data: { searchStr: inpSearchVal, pageNumber: pageNum, pageSize: pageSize },
                    success: function (results) {
                        $(""#dvPagination"").empty();
                        $(""#dvPagination"").html(results);
                    }
                });
            }
        });
    }

    $(""#inpSearch"").keyup(function (event) {
        if (event.keyCode === 13) {
            ReloadPagination(1);
        }
    });

    function RemoveTableSearch(pageIndex) {
        $(""#inpSearch"").val("""");
        ReloadPagination(pageIndex);
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRBLACK.Models.ViewModels.PaginationVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
