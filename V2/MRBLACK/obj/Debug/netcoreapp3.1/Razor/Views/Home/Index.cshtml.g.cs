#pragma checksum "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cad18bb5dbf2c5b9c35d30c642dc5901860451e"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cad18bb5dbf2c5b9c35d30c642dc5901860451e", @"/Views/Home/Index.cshtml")]
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
#line 2 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_WebsiteLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section id=\"hero\"");
            BeginWriteAttribute("class", " class=\"", 143, "\"", 151, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 163, "\"", 171, 0);
            EndWriteAttribute();
            WriteLiteral(" data-aos=\"zoom-in\" data-aos-delay=\"100\">\r\n        <div>\r\n            <div class=\"owl-slider\" id=\"owl-slider-hero\">\r\n                <!-- slide 01 -->\r\n");
#nullable restore
#line 12 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                 for (int i = 0; i < Model.SlideShow.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"slide\">\r\n                        <div class=\"owl-slide\"");
            BeginWriteAttribute("style", " style=\"", 496, "\"", 644, 13);
            WriteAttributeValue("", 504, "background:", 504, 11, true);
            WriteAttributeValue(" ", 515, "linear-gradient(to", 516, 19, true);
            WriteAttributeValue(" ", 534, "right,", 535, 7, true);
            WriteAttributeValue(" ", 541, "rgba(0,", 542, 8, true);
            WriteAttributeValue(" ", 549, "0,", 550, 3, true);
            WriteAttributeValue(" ", 552, "0,", 553, 3, true);
            WriteAttributeValue(" ", 555, "0.7),", 556, 6, true);
            WriteAttributeValue(" ", 561, "rgba(0,", 562, 8, true);
            WriteAttributeValue(" ", 569, "0,", 570, 3, true);
            WriteAttributeValue(" ", 572, "0,", 573, 3, true);
            WriteAttributeValue(" ", 575, "0.7)),url(\'/Uploads/Images/SlideShow/", 576, 38, true);
#nullable restore
#line 15 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
WriteAttributeValue("", 613, Model.SlideShow[i].ImageUrl, 613, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 641, "\');", 641, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <div class=\"owl-text text-center\">\r\n                                <h2>");
#nullable restore
#line 17 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                               Write(Model.SlideShow[i].Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 816, "\"", 847, 1);
#nullable restore
#line 18 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
WriteAttributeValue("", 823, Model.SlideShow[i].Link, 823, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-get-started\">Get Started</a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 22 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                }              

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</section><!-- End Hero -->\r\n\r\n<main id=\"main\">\r\n\r\n\r\n    <section class=\"advertising\">\r\n        <div class=\"container\" data-aos=\"fade-up\">\r\n            <div class=\"img\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1cad18bb5dbf2c5b9c35d30c642dc5901860451e8882", async() => {
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
#line 40 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
     foreach(var category in Model.categoryWithServices)
    { 

#line default
#line hidden
#nullable disable
            WriteLiteral("            <section id=\"popular-courses\" class=\"courses\">\r\n        <div class=\"container\" data-aos=\"fade-up\">\r\n            <div class=\"section-title\">\r\n                <div class=\"title\">\r\n                    <h2>");
#nullable restore
#line 46 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                   Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <p>");
#nullable restore
#line 47 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                  Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"btn-title\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1876, "\"", 1883, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"title-btn\">\r\n                        see-more\r\n                    </a>\r\n                </div>\r\n            </div>\r\n\r\n\r\n            <div class=\"owl-carousel courses-carousel\" data-aos=\"zoom-in\" data-aos-delay=\"100\">\r\n");
#nullable restore
#line 58 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                 foreach(var service in category.Services)
                {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"course-item\">\r\n                    <a href=\"course-details.html\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1cad18bb5dbf2c5b9c35d30c642dc5901860451e12063", async() => {
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
            WriteLiteral("\r\n                        <div class=\"course-content\">\r\n                            <div class=\"d-flex justify-content-between align-items-center mb-3\">\r\n                                <h4>");
#nullable restore
#line 66 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                               Write(service.LeefCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p class=\"price\">$");
#nullable restore
#line 67 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                                             Write(service.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <h3><a href=\"course-details.html\">");
#nullable restore
#line 70 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                                                         Write(service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                            <p>\r\n                                ");
#nullable restore
#line 72 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                           Write(service.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                            <div class=""trainer d-flex justify-content-between align-items-center"">
                                <div class=""trainer-profile d-flex align-items-center"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1cad18bb5dbf2c5b9c35d30c642dc5901860451e14976", async() => {
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
#line 77 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                                     Write(service.ProviderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                                <div class=\"trainer-rank d-flex align-items-center\">\r\n                                    <i class=\'bx bxs-star\'></i><span>");
#nullable restore
#line 80 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                                                                Write(service.ProviderRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </a>\r\n                </div>\r\n");
#nullable restore
#line 87 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
                }        

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section><!-- End Popular Courses Section -->\r\n");
#nullable restore
#line 91 "F:\EngMohamed\BlackBoard\MR.BLACK\V2\MRBLACK\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <section class=\"advertising\">\r\n        <div class=\"container\" data-aos=\"fade-up\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"img\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1cad18bb5dbf2c5b9c35d30c642dc5901860451e17873", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1cad18bb5dbf2c5b9c35d30c642dc5901860451e19242", async() => {
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
                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-1.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 4941, "\"", 4947, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>Walter White</h4>
                        <span>Web Development</span>
                        <p>
                            Magni qui quod omnis unde et eos fuga et exercitationem. Odio veritatis perspiciatis quaerat qui aut
                            aut aut
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>3.5</span>

                        </div>
                    </div>
                </div>

                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-2.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 5687, "\"", 5693, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>Sarah Jhinson</h4>
                        <span>Marketing</span>
                        <p>
                            Repellat fugiat adipisci nemo illum nesciunt voluptas repellendus. In architecto rerum rerum
                            temporibus
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>5</span>

                        </div>
                    </div>
                </div>

                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-3.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 6421, "\"", 6427, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>William Anderson</h4>
                        <span>Content</span>
                        <p>
                            Voluptas necessitatibus occaecati quia. Earum totam consequuntur qui porro et laborum toro des clara
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>4.5</span>

                        </div>
                    </div>
                </div>
                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-1.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 7124, "\"", 7130, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>Walter White</h4>
                        <span>Web Development</span>
                        <p>
                            Magni qui quod omnis unde et eos fuga et exercitationem. Odio veritatis perspiciatis quaerat qui aut
                            aut aut
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>5</span>

                        </div>
                    </div>
                </div>

                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-2.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 7868, "\"", 7874, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>Sarah Jhinson</h4>
                        <span>Marketing</span>
                        <p>
                            Repellat fugiat adipisci nemo illum nesciunt voluptas repellendus. In architecto rerum rerum
                            temporibus
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>4.5</span>

                        </div>
                    </div>
                </div>

                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-3.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 8604, "\"", 8610, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>William Anderson</h4>
                        <span>Content</span>
                        <p>
                            Voluptas necessitatibus occaecati quia. Earum totam consequuntur qui porro et laborum toro des clara
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>5</span>

                        </div>
                    </div>
                </div>
                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-1.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 9305, "\"", 9311, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>Walter White</h4>
                        <span>Web Development</span>
                        <p>
                            Magni qui quod omnis unde et eos fuga et exercitationem. Odio veritatis perspiciatis quaerat qui aut
                            aut aut
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>4</span>

                        </div>
                    </div>
                </div>

                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-2.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 10049, "\"", 10055, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>Sarah Jhinson</h4>
                        <span>Marketing</span>
                        <p>
                            Repellat fugiat adipisci nemo illum nesciunt voluptas repellendus. In architecto rerum rerum
                            temporibus
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>5</span>

                        </div>
                    </div>
                </div>

                <div class=""member"">
                    <img src=""assets/img/trainers/trainer-3.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 10783, "\"", 10789, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""member-content"">
                        <h4>William Anderson</h4>
                        <span>Content</span>
                        <p>
                            Voluptas necessitatibus occaecati quia. Earum totam consequuntur qui porro et laborum toro des clara
                        </p>
                        <div class=""trainer-rank d-flex align-items-center"">
                            <i class='bx bxs-star'></i><span>5</span>

                        </div>
                    </div>
                </div>
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

       ");
            WriteLiteral(@"         <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">64</span>
                    <p>cases</p>
                </div>

                <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">42</span>
                    <p>Events</p>
                </div>

                <div class=""col-lg-3 col-6 text-center"">
                    <span data-toggle=""counter-up"">15</span>
                    <p>professor</p>
                </div>

            </div>

        </div>
    </section><!-- End Counts Section -->

</main><!-- End #main -->");
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
