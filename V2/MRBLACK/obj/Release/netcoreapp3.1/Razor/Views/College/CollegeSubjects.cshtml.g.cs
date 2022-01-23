#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1623286d4727f4b4b641dcd073c9631473ce9377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_College_CollegeSubjects), @"mvc.1.0.view", @"/Views/College/CollegeSubjects.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1623286d4727f4b4b641dcd073c9631473ce9377", @"/Views/College/CollegeSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_College_CollegeSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRBLACK.Models.Database.College>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<button type=\"button\" class=\"btn btn-buy\" onclick=\"BackToPreviousPage()\"><i class=\"fa fa-forward\"></i> العودة للصفحة السابقة</button>\r\n\r\n\r\n<h1 class=\"text-center\">مواد كلية (");
#nullable restore
#line 9 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                              Write(Model.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h1>
<div class=""panel panel-default"">
    <div class=""panel-heading"">
        <div class=""row"">
            <div class=""col-sm-6"">
            </div>
            <div class=""col-sm-6"">
                <div class=""input-group mt-5"">
                    <input class=""form-control left-border-none"" type=""text"" id=""Search"" maxlength=""20"" placeholder=""اكتب للبحث"" onkeyup=""SearchInTable()"">
                    <span class=""input-group-addon transparent"" onclick=""SearchInTable()"">
                        <i class='fa fa-search' aria-hidden='true'></i>
                    </span>
                    <span class=""input-group-addon transparent"" onclick=""RemoveSearchText()"">
                        <i class='fa fa-times' aria-hidden='true'></i>
                    </span>

                </div>
            </div>
        </div>

    </div>
    <div class=""panel-body"">
        <div class=""table-responsive"">
            <table class=""table table-striped table-hover table-bordered"">
            ");
            WriteLiteral(@"    <thead class=""bg-blue"">
                    <tr>
                        <th>#</th>
                        <th>مادة</th>
                        <th>قسم</th>
                        <th>كلية</th>
                        <th>جامعة</th>
                        <th>دولة</th>
                    </tr>
                </thead>
                <tbody id=""tbBody"">
");
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                      
                        var i = 1;
                        var str = "";
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                     foreach (var item in Model.UcdsEductionManagement.Where(c => c.UniversityId != null && c.DepartmentId != null && c.SubjectId != null))
                    {
                        var x = item.UniversityId + "_" + item.CollegeId + "_" + item.DepartmentId + "_" + item.SubjectId;
                        if (!str.Contains(x))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"Search\">\r\n                                <td>");
#nullable restore
#line 54 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 55 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                               Write(item.Subject.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 56 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                               Write(item.Department.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 57 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                               Write(item.College.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 58 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                               Write(item.University.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 59 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                               Write(item.University.Country.ArName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 61 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\CollegeSubjects.cshtml"
                            i++;
                            str += "," + x;
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>

    </div>
</div>


<script>
    function Contains(text_one, text_two) {
        if (text_one.indexOf(text_two) != -1)
            return true;
    }

    function SearchInTable() {
        var searchText = $(""#Search"").val().toLowerCase();
        $("".Search"").each(function () {
            if (!Contains($(this).text().toLowerCase(), searchText)) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });
    }

    function RemoveSearchText() {
        $(""#Search"").val("""");
        SearchInTable();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRBLACK.Models.Database.College> Html { get; private set; }
    }
}
#pragma warning restore 1591
