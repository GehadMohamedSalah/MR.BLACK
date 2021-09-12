#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "152c75ba185cb67e8705be58c14c3c1eee3a2a29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_College_Index), @"mvc.1.0.view", @"/Views/College/Index.cshtml")]
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\Index.cshtml"
using MRBLACK.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"152c75ba185cb67e8705be58c14c3c1eee3a2a29", @"/Views/College/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_College_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRBLACK.Helper.PagedList<MRBLACK.Models.Database.College>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Pagination", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var paginationVM = new PaginationVM()
    {
        PageIndex = Model.PageIndex,
        TotalPages = Model.TotalPages,
        PreviousPage = Model.PreviousPage,
        NextPage = Model.NextPage,
        GetItemsUrl = "/College/GetItems",
        GetPaginationUrl = "/College/GetPagination"
    };

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""text-center"">شاشة الكليات</h1>
<div class=""panel panel-default"">
    <div class=""panel-heading"">
        <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#flipFlop"" onclick=""FillPopup('/College/Create')"">
            اضافة جديد
        </button>
        <div class=""input-group mt-5"">
            <input class=""form-control left-border-none"" type=""text"" id=""inpSearch"" placeholder=""اكتب للبحث""");
            BeginWriteAttribute("value", " value=\"", 945, "\"", 953, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <span class=\"input-group-addon transparent\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1012, "\"", 1056, 3);
            WriteAttributeValue("", 1022, "ReloadPagination(", 1022, 17, true);
#nullable restore
#line 25 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\Index.cshtml"
WriteAttributeValue("", 1039, Model.PageIndex, 1039, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1055, ")", 1055, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                <i class='fa fa-search' aria-hidden='true'></i>
            </span>
        </div>
    </div>
    <div class=""panel-body"">
        <table class=""table table-striped table-hover table-bordered"">
            <thead>
                <tr>
                    <td>الاسم</td>
                    <td>الاسم بالعربية</td>
                    <td>الاجراءات</td>
                </tr>
            </thead>
            <tbody id=""tbBody"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "152c75ba185cb67e8705be58c14c3c1eee3a2a296194", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 40 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.ToList();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n        <div id=\"dvPagination\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "152c75ba185cb67e8705be58c14c3c1eee3a2a297872", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 44 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\College\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = paginationVM;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRBLACK.Helper.PagedList<MRBLACK.Models.Database.College>> Html { get; private set; }
    }
}
#pragma warning restore 1591
