#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42b462e17b325a3c09217bcb02c536c86f96a908"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partials_AdminSideMenu), @"mvc.1.0.view", @"/Views/Partials/AdminSideMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42b462e17b325a3c09217bcb02c536c86f96a908", @"/Views/Partials/AdminSideMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Partials_AdminSideMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRBLACK.Models.ViewModels.SideMenuVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:45px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/assets/imgs/avatar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<aside class=\"main-sidebar\">\n    <!-- sidebar: style can be found in sidebar.less -->\n    <section class=\"sidebar\">\n        <!-- Sidebar user panel -->\n        <div class=\"user-panel\">\n            <div class=\"pull-right image\">\n");
#nullable restore
#line 8 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
                 if (Model.UserImage != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "42b462e17b325a3c09217bcb02c536c86f96a9084780", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 350, "~/Content/Images/Users/", 350, 23, true);
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
AddHtmlAttributeValue("", 373, Model.UserImage, 373, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
AddHtmlAttributeValue("", 435, Model.Name, 435, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 10 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
                                                                                                                   }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "42b462e17b325a3c09217bcb02c536c86f96a9087300", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
AddHtmlAttributeValue("", 584, Model.Name, 584, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 13 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
                                                                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n            <div class=\"pull-left info\">\n                <p>");
#nullable restore
#line 16 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                <a href=""#""><i class=""fa fa-circle text-success""></i> متواجد</a>
            </div>
        </div>
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class=""sidebar-menu"">
            <li class=""treeview"">
            </li>
            <li");
            BeginWriteAttribute("class", " class=\"", 980, "\"", 1075, 2);
            WriteAttributeValue("", 988, "treeview", 988, 8, true);
#nullable restore
#line 24 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("  ", 996, Context.Request.Path.ToString().ToLower().Contains("home") ? "active" : "", 998, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a href=\"/Home/Index\">\n                    <i class=\"fa fa-book\"></i> <span>الرئيسية</span>\n                </a>\n            </li>\n            <li");
            BeginWriteAttribute("class", " class=\"", 1240, "\"", 1334, 2);
            WriteAttributeValue("", 1248, "treeview", 1248, 8, true);
#nullable restore
#line 29 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 1256, Context.Request.Path.ToString().ToLower().Contains("role") ? "active" : "", 1257, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a");
            BeginWriteAttribute("href", " href=\"", 1355, "\"", 1390, 1);
#nullable restore
#line 30 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 1362, Url.Action("Index", "Role"), 1362, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <i class=\"fa fa-circle\"></i> <span>الادوار و الصلاحيات</span>\n                </a>\n            </li>\n            <li");
            BeginWriteAttribute("class", " class=\"", 1529, "\"", 1631, 2);
            WriteAttributeValue("", 1537, "treeview", 1537, 8, true);
#nullable restore
#line 34 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 1545, Context.Request.Path.ToString().ToLower().Contains("currencytype") ? "active" : "", 1546, 85, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a");
            BeginWriteAttribute("href", " href=\"", 1652, "\"", 1695, 1);
#nullable restore
#line 35 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 1659, Url.Action("Index", "CurrencyType"), 1659, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <i class=\"fa fa-coins\"></i> <span>العملات</span>\n                </a>\n            </li>\n            <li");
            BeginWriteAttribute("class", " class=\"", 1821, "\"", 2487, 2);
            WriteAttributeValue("", 1829, "treeview", 1829, 8, true);
#nullable restore
#line 39 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 1837, Context.Request.Path.ToString().ToLower().Contains("country") 
                || Context.Request.Path.ToString().ToLower().Contains("university")
                ||Context.Request.Path.ToString().ToLower().Contains("college")
                || Context.Request.Path.ToString().ToLower().Contains("department")
                ||Context.Request.Path.ToString().ToLower().Contains("academicyear")
                ||Context.Request.Path.ToString().ToLower().Contains("term")
                ||Context.Request.Path.ToString().ToLower().Contains("subject")
                ||Context.Request.Path.ToString().ToLower().Contains("copun") ? "active" : "", 1838, 649, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a href=\"#\">\n                    <i class=\"fa fa-cogs\"></i> <span>الاعدادات العامة</span>\n                </a>\n                <ul class=\"treeview-menu\">\n                    <li");
            BeginWriteAttribute("class", " class=\"", 2683, "\"", 2780, 2);
            WriteAttributeValue("", 2691, "treeview", 2691, 8, true);
#nullable restore
#line 51 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 2699, Context.Request.Path.ToString().ToLower().Contains("country") ? "active" : "", 2700, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2809, "\"", 2847, 1);
#nullable restore
#line 52 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 2816, Url.Action("Index", "Country"), 2816, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-flag\"></i> <span>الدول</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 3002, "\"", 3102, 2);
            WriteAttributeValue("", 3010, "treeview", 3010, 8, true);
#nullable restore
#line 56 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 3018, Context.Request.Path.ToString().ToLower().Contains("university") ? "active" : "", 3019, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 3131, "\"", 3172, 1);
#nullable restore
#line 57 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 3138, Url.Action("Index", "University"), 3138, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-university\"></i> <span>الجامعات</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 3336, "\"", 3433, 2);
            WriteAttributeValue("", 3344, "treeview", 3344, 8, true);
#nullable restore
#line 61 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 3352, Context.Request.Path.ToString().ToLower().Contains("college") ? "active" : "", 3353, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 3462, "\"", 3500, 1);
#nullable restore
#line 62 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 3469, Url.Action("Index", "College"), 3469, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-school\"></i> <span>الكليات</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 3659, "\"", 3759, 2);
            WriteAttributeValue("", 3667, "treeview", 3667, 8, true);
#nullable restore
#line 66 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 3675, Context.Request.Path.ToString().ToLower().Contains("department") ? "active" : "", 3676, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 3788, "\"", 3829, 1);
#nullable restore
#line 67 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 3795, Url.Action("Index", "Department"), 3795, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-industry\"></i> <span>الاقسام</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 3990, "\"", 4092, 2);
            WriteAttributeValue("", 3998, "treeview", 3998, 8, true);
#nullable restore
#line 71 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 4006, Context.Request.Path.ToString().ToLower().Contains("academicyear") ? "active" : "", 4007, 85, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 4121, "\"", 4164, 1);
#nullable restore
#line 72 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 4128, Url.Action("Index", "AcademicYear"), 4128, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-calendar\"></i> <span>السنين الدراسية</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 4333, "\"", 4427, 2);
            WriteAttributeValue("", 4341, "treeview", 4341, 8, true);
#nullable restore
#line 76 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 4349, Context.Request.Path.ToString().ToLower().Contains("term") ? "active" : "", 4350, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 4456, "\"", 4491, 1);
#nullable restore
#line 77 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 4463, Url.Action("Index", "Term"), 4463, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-list\"></i> <span>الترمات</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 4648, "\"", 4745, 2);
            WriteAttributeValue("", 4656, "treeview", 4656, 8, true);
#nullable restore
#line 81 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 4664, Context.Request.Path.ToString().ToLower().Contains("subject") ? "active" : "", 4665, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 4774, "\"", 4812, 1);
#nullable restore
#line 82 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 4781, Url.Action("Index", "Subject"), 4781, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-book-open\"></i> <span>المواد</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 4973, "\"", 5068, 2);
            WriteAttributeValue("", 4981, "treeview", 4981, 8, true);
#nullable restore
#line 86 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 4989, Context.Request.Path.ToString().ToLower().Contains("copun") ? "active" : "", 4990, 78, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 5097, "\"", 5133, 1);
#nullable restore
#line 87 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 5104, Url.Action("Index", "Copun"), 5104, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-percent\"></i> <span>كوبونات الخصم</span>\n                        </a>\n                    </li>\n                </ul>\n            </li>\n\n            <li");
            BeginWriteAttribute("class", "  class=\"", 5332, "\"", 5436, 2);
            WriteAttributeValue("", 5341, "treeview", 5341, 8, true);
#nullable restore
#line 94 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 5349, Context.Request.Path.ToString().ToLower().Contains("systemsetting") ? "active" : "", 5350, 86, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a href=\"#\">\n                    <i class=\"fa fa-cogs\"></i> <span>اعدادات النظام</span>\n                </a>\n                <ul class=\"treeview-menu\">\n                    <li");
            BeginWriteAttribute("class", "  class=\"", 5630, "\"", 5740, 2);
            WriteAttributeValue("", 5639, "treeview", 5639, 8, true);
#nullable restore
#line 99 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 5647, Context.Request.Path.ToString().ToLower().Contains("systemsetting/index") ? "active" : "", 5648, 92, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 5769, "\"", 5813, 1);
#nullable restore
#line 100 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 5776, Url.Action("Index", "SystemSetting"), 5776, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-cog\"></i> <span>اعدادات النظام</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", "  class=\"", 5976, "\"", 6091, 2);
            WriteAttributeValue("", 5985, "treeview", 5985, 8, true);
#nullable restore
#line 104 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 5993, Context.Request.Path.ToString().ToLower().Contains("systemsetting/systemfees") ? "active" : "", 5994, 97, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 6120, "\"", 6169, 1);
#nullable restore
#line 105 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 6127, Url.Action("SystemFees", "SystemSetting"), 6127, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-money-bill-wave\"></i> <span>الرسوم</span>\n                        </a>\n                    </li>\n                    <li");
            BeginWriteAttribute("class", " class=\"", 6336, "\"", 6461, 2);
            WriteAttributeValue("", 6344, "treeview", 6344, 8, true);
#nullable restore
#line 109 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 6352, Context.Request.Path.ToString().ToLower().Contains("systemsetting/researchadditionratio") ? "active" : "", 6353, 108, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <a");
            BeginWriteAttribute("href", " href=\"", 6490, "\"", 6550, 1);
#nullable restore
#line 110 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 6497, Url.Action("ResearchAdditionRatio", "SystemSetting"), 6497, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <i class=\"fa fa-percent\"></i> <span>نسب مكملات البحث</span>\n                        </a>\n                    </li>\n                </ul>\n            </li>\n            <li");
            BeginWriteAttribute("class", "  class=\"", 6751, "\"", 6852, 2);
            WriteAttributeValue("", 6760, "treeview", 6760, 8, true);
#nullable restore
#line 116 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 6768, Context.Request.Path.ToString().ToLower().Contains("membership") ? "active" : "", 6769, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a");
            BeginWriteAttribute("href", " href=\"", 6873, "\"", 6914, 1);
#nullable restore
#line 117 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 6880, Url.Action("Index", "Membership"), 6880, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <i class=\"fa fa-id-card\"></i> <span>العضويات</span>\n                </a>\n            </li>\n            <li");
            BeginWriteAttribute("class", "  class=\"", 7043, "\"", 7149, 2);
            WriteAttributeValue("", 7052, "treeview", 7052, 8, true);
#nullable restore
#line 121 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 7060, Context.Request.Path.ToString().ToLower().Contains("servicecategory") ? "active" : "", 7061, 88, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a");
            BeginWriteAttribute("href", " href=\"", 7170, "\"", 7216, 1);
#nullable restore
#line 122 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 7177, Url.Action("Index", "ServiceCategory"), 7177, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <i class=\"fa fa-list-alt\"></i> <span>تصنيفات الخدمات</span>\n                </a>\n            </li>\n            <li");
            BeginWriteAttribute("class", "  class=\"", 7353, "\"", 7451, 2);
            WriteAttributeValue("", 7362, "treeview", 7362, 8, true);
#nullable restore
#line 126 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue(" ", 7370, Context.Request.Path.ToString().ToLower().Contains("service") ? "active" : "", 7371, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <a");
            BeginWriteAttribute("href", " href=\"", 7472, "\"", 7510, 1);
#nullable restore
#line 127 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Partials\AdminSideMenu.cshtml"
WriteAttributeValue("", 7479, Url.Action("Index", "Service"), 7479, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <i class=\"fa fa-tasks\"></i> <span>الخدمات</span>\n                </a>\n            </li>\n");
            WriteLiteral("        </ul>\n    </section>\n    <!-- /.sidebar -->\n</aside>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRBLACK.Models.ViewModels.SideMenuVM> Html { get; private set; }
    }
}
#pragma warning restore 1591