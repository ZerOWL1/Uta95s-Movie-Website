#pragma checksum "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06d17170f95a61a6b454e8a18fee3d9912cc712f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_MActor), @"mvc.1.0.view", @"/Views/Manager/MActor.cshtml")]
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
#line 1 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\_ViewImports.cshtml"
using Uta95s_Movie_Web___BETA_0._1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\_ViewImports.cshtml"
using Uta95s_Movie_Web___BETA_0._1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\_ViewImports.cshtml"
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\_ViewImports.cshtml"
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06d17170f95a61a6b454e8a18fee3d9912cc712f", @"/Views/Manager/MActor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d223b6492fbaf1bdb6fc906766e59671a5d21e5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_MActor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "MActor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-movie-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
  
    ViewData["Title"] = "MActor";
    Layout = "~/Views/Shared/_ManagerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"add-container\" style=\"margin: 30px 15px 20px;\">\r\n    <div class=\"umanager-head\">\r\n        <span>Add Movie Actor</span>\r\n    </div>\r\n    <div class=\"umanager-form\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 289, "\"", 297, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""collapseUserForm"" aria-labelledby=""headingOne"" data-bs-parent=""#sidenavAccordion"">
            <div class=""row-pricing umanager-form mx-0"">
                <div class=""col-card-6 col-c-sm-12 umanager-col"">
                    <nav class=""sb-sidenav-menu-nested nav"">
                        <div class=""add-movie"">
");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06d17170f95a61a6b454e8a18fee3d9912cc712f6850", async() => {
                WriteLiteral("\r\n                                <div class=\"select-bx mv-bx\">\r\n");
                WriteLiteral("                                    <label>Movie Name</label>\r\n                                    <select class=\"form-control select-movie-form\" name=\"mid\">\r\n");
#nullable restore
#line 23 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                         if (ViewBag.M != null) {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                             foreach(var item in ViewBag.M) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06d17170f95a61a6b454e8a18fee3d9912cc712f7978", async() => {
#nullable restore
#line 25 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                                                                                Write(item.Title);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                                                     WriteLiteral(item.MID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </div>\r\n                                <div class=\"select-bx mv-bx\">\r\n");
                WriteLiteral("                                    <label>Actor Name</label>\r\n                                    <select class=\"form-control select-movie-form\" name=\"aid\">\r\n");
#nullable restore
#line 34 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                         if (ViewBag.A != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                             foreach (var item in ViewBag.A)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06d17170f95a61a6b454e8a18fee3d9912cc712f11661", async() => {
#nullable restore
#line 38 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                                                                                    Write(item.ActorName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                                                     WriteLiteral(item.ActorID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 39 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\MActor.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </select>\r\n                                </div>\r\n");
                WriteLiteral("                                <div class=\"submit-btn\">\r\n                                    <input type=\"submit\" value=\"ADD\"/>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Route = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </nav>
                </div>
                <div class=""col-card-6 col-c-sm-12 umanager-col"">
                    <div class=""umanager-right"">
                        <span class=""u-r-title"">Important Note</span>
                        <p class=""u-r-item"">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. </p>
                        <p class=""u-r-item"">Viverra tellus in hac habitasse platea dictumst vestibulum rhoncus. </p>
                        <p class=""u-r-item"">Tempor orci eu lobortis elementum. Eget felis eget nunc lobortis mattis aliquam faucibus. Auctor neque vitae tempus quam. Tristique sollicitudin nibh sit amet.</p>
                        <p class=""u-r-item""> Ullamcorper eget nulla facilisi etiam dignissim. Dignissim sodales ut eu sem. Mauris nunc congue nisi vitae suscipit tellus mauris a. Lectus arcu bibendum at varius vel pharetra vel.</p>
                ");
            WriteLiteral("    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
