#pragma checksum "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed3461f4438b4bcfc04f80ef21301cb4a05cb1e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_ActorManage), @"mvc.1.0.view", @"/Views/Manager/ActorManage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed3461f4438b4bcfc04f80ef21301cb4a05cb1e8", @"/Views/Manager/ActorManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d223b6492fbaf1bdb6fc906766e59671a5d21e5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_ActorManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "DeleteA", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("delete-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Do you want to delete this actor?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "EditA", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("edit-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "AManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-movie-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
  
    ViewData["Title"] = "Actor";
    Layout = "~/Views/Shared/_ManagerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""umanager-container px-4"">
    <div class=""umanager-head"">
        <h2 class=""mt-4"">Actor Management</h2>
        <span>Actor Control</span>
        <p>Admin can modify actor at this page. Add, delete, update actor. Please be careful before modified actors.</p>
    </div>
<div class=""umanager-body"">
<div class=""umanager-table"">
");
            WriteLiteral("<div class=\"card mb-4\">\r\n<div class=\"card-header\">\r\n    <i class=\"fas fa-table me-1\"></i>\r\n    Actor DataTable\r\n</div>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 22 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
         if (ViewBag.user != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
             if (ViewBag.user.Role == 1 || ViewBag.user.Role == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table id=""datatablesSimple"">
                    <thead>
                    <tr>
                        <th>ActorName</th>
                        <th>ActorWiki</th>
                        <th>Delete</th>
                        <th>Edit</th>
                    </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 36 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                     foreach (Actor actor in ViewBag.listA)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 39 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                           Write(actor.ActorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                           Write(actor.ActorWiki);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed3461f4438b4bcfc04f80ef21301cb4a05cb1e89838", async() => {
                WriteLiteral("Delete&nbsp;<i class=\"far fa-trash-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                                                         WriteLiteral(actor.ActorID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed3461f4438b4bcfc04f80ef21301cb4a05cb1e812343", async() => {
                WriteLiteral("Edit&nbsp;<i class=\"far fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                                                       WriteLiteral(actor.ActorID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 47 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
            }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>PLEASE SIGN IN</span>\r\n");
#nullable restore
#line 49 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>PLEASE SIGN IN</span>\r\n");
#nullable restore
#line 54 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>
</div>
</div>
<div class=""add-container mx-0"">
    <div class=""umanager-head"">
        <span>Actor Modify</span>
    </div>
    <div class=""umanager-form"">
        <a class=""nav-link collapsed add-movie-btn"" href=""#"" data-bs-toggle=""collapse"" data-bs-target=""#collapseActorForm"">
            <div class=""sb-nav-link-icon""><i class=""far fa-plus-square""></i></div>
            <span>Add New Actor</span>
            <div class=""sb-sidenav-collapse-arrow""><i class=""fas fa-angle-down""></i></div>
        </a>
        <div class=""collapse"" id=""collapseActorForm"" aria-labelledby=""headingOne"" data-bs-parent=""#sidenavAccordion"">
            <div class=""row-pricing umanager-form mx-0"">
                <div class=""col-card-6 col-c-sm-12 umanager-col"">
                    <nav class=""sb-sidenav-menu-nested nav"">
                        <div class=""add-movie"">
");
#nullable restore
#line 74 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                         if (ViewBag.user != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                             if (ViewBag.user.Role == 1 || ViewBag.user.Role == 2)
                            {
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed3461f4438b4bcfc04f80ef21301cb4a05cb1e817581", async() => {
                WriteLiteral("\r\n                                    <div class=\"actorName-bx mv-bx\">\r\n                                        <label>Actor Name</label>\r\n                                        <input type=\"text\" class=\"form-control movie-form-input\" name=\"acName\"");
                BeginWriteAttribute("title", " title=\"", 3477, "\"", 3485, 0);
                EndWriteAttribute();
                WriteLiteral(@"/>
                                    </div>
                                    <div class=""actorWiki-bx mv-bx"">
                                        <label>Actor Wiki</label>
                                        <input type=""text"" class=""form-control movie-form-input"" name=""acWiki""");
                BeginWriteAttribute("title", " title=\"", 3781, "\"", 3789, 0);
                EndWriteAttribute();
                WriteLiteral(@"/>
                                    </div>
                                    <div class=""submit-btn"">
                                        <input type=""submit"" value=""ADD""/>
                                    </div>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Route = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 92 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                            }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>PLEASE SIGN IN</span>\r\n");
#nullable restore
#line 94 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>PLEASE SIGN IN</span>\r\n");
#nullable restore
#line 99 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\ActorManage.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
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
            WriteLiteral("  </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</div>\r\n\r\n\r\n");
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
