#pragma checksum "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58f447359a8ba53a2d58e0540d3fa696e4067623"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Manager), @"mvc.1.0.view", @"/Views/Manager/Manager.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58f447359a8ba53a2d58e0540d3fa696e4067623", @"/Views/Manager/Manager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d223b6492fbaf1bdb6fc906766e59671a5d21e5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Manager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
  
    ViewData["Title"] = "Dash Board";
    Layout = "~/Views/Shared/_ManagerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid px-4\">\r\n<h2 class=\"mt-4\">General</h2>\r\n<div class=\"dashboard-p\">\r\n    <div class=\"dashboard-p-head\">\r\n        <span> \r\n            ");
#nullable restore
#line 12 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
        Write((ViewBag.user != null) ? @ViewBag.user.Name : "Please Sign IN" );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            - Admin General
        </span>
        <p>Welcome admin, as a admin, you've have permission to modified user and other data, but please be careful what you did, make sure you not doing something affect to systems.</p>
    </div>
    <div class=""dashboard-p-body"">
");
#nullable restore
#line 18 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
         if(ViewBag.user != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"p-body-content\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 703, "\"", 749, 2);
            WriteAttributeValue("", 709, "data:image/png;base64,", 709, 22, true);
#nullable restore
#line 20 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
WriteAttributeValue("", 731, ViewBag.user.UIMG, 731, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 750, "\"", 756, 0);
            EndWriteAttribute();
            WriteLiteral("/>\r\n        </div>\r\n");
#nullable restore
#line 22 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<div class=""dashboard-d"">
    <div class=""dashboard-p-head"">
        <span>Dashboard</span>
        <p>This is UTA95S admin digital control include total video, total user, total profit, request and session chart. Admin and technical team will update more infors soon.</p>
    </div>
    <div class=""dashboard-d-body"">
        <div class=""row"">
");
            WriteLiteral(@"            <div class=""col-xl-3 col-md-6"">
                <div class=""card bg-primary text-white mb-4"">
                    <div class=""card-body card-b"">
                        <div class=""card-left"">
                            <span>Total Video</span>
");
#nullable restore
#line 39 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                             if (ViewBag.user != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                 if (ViewBag.user.Role == 1 || ViewBag.user.Role == 2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 43 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                     Write(ViewBag.countmovie);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 44 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                }else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>SIGN IN PLEASE</span>\r\n");
#nullable restore
#line 47 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                 
                            }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>Bro! Sign IN</span>\r\n");
#nullable restore
#line 50 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                        <div class=""card-right"">
                            <i class=""fab fa-youtube""></i>
                        </div>
                    </div>
                    <div class=""card-footer d-flex align-items-center justify-content-between"">
                        <a class=""small text-white stretched-link"" href=""#"">View Details</a>
                        <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
                    </div>
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""col-xl-3 col-md-6"">
                <div class=""card bg-warning text-white mb-4"">
                    <div class=""card-body card-b"">
                        <div class=""card-left"">
                            <span>Total User</span>
");
#nullable restore
#line 68 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                             if (ViewBag.user != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                 if (ViewBag.user.Role == 1 || ViewBag.user.Role == 2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 72 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                     Write(ViewBag.countuser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 73 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                }else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>SIGN IN PLEASE</span>\r\n");
#nullable restore
#line 76 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                                 
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>Bro! Sign IN</span>\r\n");
#nullable restore
#line 81 "C:\Users\Ryuu\Desktop\New folder\Uta95s-Movie-Website\Views\Manager\Manager.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                        <div class=""card-right"">
                            <i class=""fas fa-users""></i>
                        </div>
                    </div>
                    <div class=""card-footer d-flex align-items-center justify-content-between"">
                        <a class=""small text-white stretched-link"" href=""#"">View Details</a>
                        <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
                    </div>
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""col-xl-3 col-md-6"">
                <div class=""card bg-success text-white mb-4"">
                    <div class=""card-body card-b"">
                        <div class=""card-left"">
                            <span>Total Profit</span>
                            <span>$1400</span>
                        </div>
                        <div class=""card-right"">
                            <i class=""far fa-chart-bar""></i>
                        </div>
                    </div>
                    <div class=""card-footer d-flex align-items-center justify-content-between"">
                        <a class=""small text-white stretched-link"" href=""#"">View Details</a>
                        <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
                    </div>
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""col-xl-3 col-md-6"">
                <div class=""card bg-danger text-white mb-4"">
                    <div class=""card-body card-b"">
                        <div class=""card-left"">
                            <span>Pending Request</span>
                            <span>150</span>
                        </div>
                        <div class=""card-right"">
                            <i class=""far fa-comments""></i>
                        </div>
                    </div>
                    <div class=""card-footer d-flex align-items-center justify-content-between"">
                        <a class=""small text-white stretched-link"" href=""#"">View Details</a>
                        <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
            WriteLiteral(@"<div class=""row"">
    <div class=""col-xl-6"">
        <div class=""card mb-4"">
            <div class=""card-header"">
                <i class=""fas fa-chart-area me-1""></i>
                Session Chart
            </div>
            <div class=""card-body""><canvas id=""myAreaChart"" width=""100%"" height=""40""></canvas></div>
        </div>
    </div>
    <div class=""col-xl-6"">
        <div class=""card mb-4"">
            <div class=""card-header"">
                <i class=""fas fa-chart-bar me-1""></i>
                Revenue Chart
            </div>
            <div class=""card-body""><canvas id=""myBarChart"" width=""100%"" height=""40""></canvas></div>
        </div>
    </div>
</div>
</div>");
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
