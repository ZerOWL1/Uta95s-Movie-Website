#pragma checksum "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\EditActor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "797d1a2b23b86a96d642a0bcb3f0974ad9038502"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_EditActor), @"mvc.1.0.view", @"/Views/Manager/EditActor.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"797d1a2b23b86a96d642a0bcb3f0974ad9038502", @"/Views/Manager/EditActor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d223b6492fbaf1bdb6fc906766e59671a5d21e5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_EditActor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "EditA", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-movie-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\EditActor.cshtml"
  
    ViewData["Title"] = "EditActor";
    Layout = "~/Views/Shared/_ManagerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"add-container\" style=\"margin: 30px 15px 20px;\">\r\n    <div class=\"umanager-head\">\r\n        <span>Edit Actor</span>\r\n    </div>\r\n    <div class=\"umanager-form\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 287, "\"", 295, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""collapseActorForm"" aria-labelledby=""headingOne"" data-bs-parent=""#sidenavAccordion"">
            <div class=""row-pricing umanager-form mx-0"">
                <div class=""col-card-6 col-c-sm-12 umanager-col"">
                    <nav class=""sb-sidenav-menu-nested nav"">
                        <div class=""add-movie"">
");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "797d1a2b23b86a96d642a0bcb3f0974ad90385026045", async() => {
                WriteLiteral("\r\n                                <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 820, "\"", 850, 1);
#nullable restore
#line 19 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\EditActor.cshtml"
WriteAttributeValue("", 828, ViewBag.actor.ActorID, 828, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"aid\">\r\n                                <div class=\"actorName-bx mv-bx\">\r\n                                    <label>Actor Name</label>\r\n                                    <input type=\"text\" class=\"form-control movie-form-input\" name=\"acName\"");
                BeginWriteAttribute("title", " title=\"", 1100, "\"", 1108, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1109, "\"", 1141, 1);
#nullable restore
#line 22 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\EditActor.cshtml"
WriteAttributeValue("", 1117, ViewBag.actor.ActorName, 1117, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"/>
                                </div>
                                <div class=""actorWiki-bx mv-bx"">
                                    <label>Actor Wiki</label>
                                    <input type=""text"" class=""form-control movie-form-input"" name=""acWiki""");
                BeginWriteAttribute("title", " title=\"", 1421, "\"", 1429, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1430, "\"", 1462, 1);
#nullable restore
#line 26 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\EditActor.cshtml"
WriteAttributeValue("", 1438, ViewBag.actor.ActorWiki, 1438, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n                                </div>\r\n                                <div class=\"submit-btn\">\r\n                                    <input type=\"submit\" value=\"UPDATE\"/>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Route = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
            WriteLiteral("    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
