#pragma checksum "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "067ec1d943da5e372be44bc343b5f9e26932ba16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"067ec1d943da5e372be44bc343b5f9e26932ba16", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee02553289e73062cf6e44df968440cb04ba53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRBLACK.Models.ViewModels.IndexPageVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/advertising.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/course-1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/trainers/trainer-1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_WebsiteLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section id=\"hero\"");
            BeginWriteAttribute("class", " class=\"", 165, "\"", 173, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 185, "\"", 193, 0);
            EndWriteAttribute();
            WriteLiteral(" data-aos=\"zoom-in\" data-aos-delay=\"100\">\r\n        <div>\r\n            <div class=\"owl-slider\" id=\"owl-slider-hero\">\r\n                <!-- slide 01 -->\r\n");
#nullable restore
#line 12 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                 for (int i = 0; i < Model.SlideShow.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"slide\">\r\n                        <div class=\"owl-slide\"");
            BeginWriteAttribute("style", " style=\"", 518, "\"", 666, 13);
            WriteAttributeValue("", 526, "background:", 526, 11, true);
            WriteAttributeValue(" ", 537, "linear-gradient(to", 538, 19, true);
            WriteAttributeValue(" ", 556, "right,", 557, 7, true);
            WriteAttributeValue(" ", 563, "rgba(0,", 564, 8, true);
            WriteAttributeValue(" ", 571, "0,", 572, 3, true);
            WriteAttributeValue(" ", 574, "0,", 575, 3, true);
            WriteAttributeValue(" ", 577, "0.7),", 578, 6, true);
            WriteAttributeValue(" ", 583, "rgba(0,", 584, 8, true);
            WriteAttributeValue(" ", 591, "0,", 592, 3, true);
            WriteAttributeValue(" ", 594, "0,", 595, 3, true);
            WriteAttributeValue(" ", 597, "0.7)),url(\'/Uploads/Images/SlideShow/", 598, 38, true);
#nullable restore
#line 15 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
WriteAttributeValue("", 635, Model.SlideShow[i].ImageUrl, 635, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 663, "\');", 663, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <div class=\"owl-text text-center\">\r\n                                <h2>");
#nullable restore
#line 17 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                               Write(Model.SlideShow[i].Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 838, "\"", 869, 1);
#nullable restore
#line 18 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
WriteAttributeValue("", 845, Model.SlideShow[i].Link, 845, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-get-started\">Get Started</a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 22 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                }              

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</section><!-- End Hero -->\r\n\r\n<main id=\"main\">\r\n\r\n\r\n    <section class=\"advertising\">\r\n        <div class=\"container\" data-aos=\"fade-up\">\r\n            <div class=\"img\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba169057", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </section>\r\n    <!-- ======= Popular Courses Section ======= -->\r\n");
#nullable restore
#line 40 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
     foreach(var category in Model.categoryWithServices)
    {
        if (category.Services.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <section id=\"popular-courses\" class=\"courses\">\r\n        <div class=\"container\" data-aos=\"fade-up\">\r\n            <div class=\"section-title\">\r\n                <div class=\"title\">\r\n                    <h2>");
#nullable restore
#line 48 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                   Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <p>");
#nullable restore
#line 49 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                  Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"btn-title\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1950, "\"", 1994, 2);
            WriteAttributeValue("", 1957, "Home/Services?CategoryId=", 1957, 25, true);
#nullable restore
#line 52 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
WriteAttributeValue("", 1982, category.Id, 1982, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"title-btn\">\r\n                        see-more\r\n                    </a>\r\n                </div>\r\n            </div>\r\n\r\n\r\n            <div class=\"owl-carousel courses-carousel\" data-aos=\"zoom-in\" data-aos-delay=\"100\">\r\n");
#nullable restore
#line 60 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                 foreach (var service in category.Services)
                {




#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"course-item\">\r\n                    <a href=\"course-details.html\">\r\n");
#nullable restore
#line 67 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                         if (string.IsNullOrEmpty(service.ImageUrl))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                             ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1612953", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 70 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1614461", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2701, "~/Uploads/Images/Services/", 2701, 26, true);
#nullable restore
#line 73 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 2727, service.ImageUrl, 2727, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 74 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"course-content\">\r\n                            <div class=\"d-flex justify-content-between align-items-center mb-3\">\r\n                                <h4>");
#nullable restore
#line 77 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                               Write(service.LeefCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p class=\"price\">$");
#nullable restore
#line 78 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                                             Write(service.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <h3><a href=\"course-details.html\">");
#nullable restore
#line 81 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                                                         Write(service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                            <p>\r\n                                ");
#nullable restore
#line 83 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                           Write(service.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                            <div class=""trainer d-flex justify-content-between align-items-center"">
                                <div class=""trainer-profile d-flex align-items-center"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1618146", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <span>");
#nullable restore
#line 88 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                                     Write(service.ProviderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                                <div class=\"trainer-rank d-flex align-items-center\">\r\n                                    <i class=\'bx bxs-star\'></i><span>");
#nullable restore
#line 91 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                                                                Write(service.ProviderRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </a>\r\n                </div>\r\n");
#nullable restore
#line 98 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                }        

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section><!-- End Popular Courses Section -->\r\n");
#nullable restore
#line 102 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <section class=\"advertising\">\r\n        <div class=\"container\" data-aos=\"fade-up\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"img\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1621123", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-md-6\">\r\n\r\n                    <div class=\"img\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1622492", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ======= Trainers Section ======= -->
    <section id=""trainers"" class=""trainers"">
        <div class=""container"" data-aos=""fade-up"">

            <div class=""section-title"">
                <h2>professor</h2>
                <p>Our Professional professor</p>
            </div>

            <div class=""owl-carousel trainers-carousel"" data-aos=""zoom-in"" data-aos-delay=""100"">
");
#nullable restore
#line 132 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                 foreach (var provider in Model.Providers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"member\">\r\n");
#nullable restore
#line 135 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                     if (string.IsNullOrEmpty(provider.ImageUrl))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1624837", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 138 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067ec1d943da5e372be44bc343b5f9e26932ba1626330", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5657, "~/Uploads/Images/Users/", 5657, 23, true);
#nullable restore
#line 141 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 5680, provider.ImageUrl, 5680, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 142 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"member-content\">\r\n                        <h4>");
#nullable restore
#line 144 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                       Write(provider.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
            WriteLiteral("                        <p>\r\n                           ");
#nullable restore
#line 147 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                      Write(provider.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <div class=\"trainer-rank d-flex align-items-center\">\r\n                            <i class=\'bx bxs-star\'></i><span>");
#nullable restore
#line 150 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                                                        Write(provider.Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 155 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

              
            </div>

        </div>
    </section><!-- End Trainers Section -->
    <!-- ======= Counts Section ======= -->
    <section id=""counts"" class=""counts section-bg"">
        <div class=""container"">

            <div class=""row counters"">

                <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">1232</span>
                    <p>Students</p>
                </div>

                <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">64</span>
                    <p>cases</p>
                </div>

                <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">42</span>
                    <p>Events</p>
                </div>

                <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">");
#nullable restore
#line 185 "D:\My Work\Free Lancing Projects\Mr. Black\Project\V2\MRBLACK\Views\Home\Index.cshtml"
                                              Write(Model.Providers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <p>professor</p>\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </section><!-- End Counts Section -->\r\n\r\n</main><!-- End #main -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRBLACK.Models.ViewModels.IndexPageVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
