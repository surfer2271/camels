#pragma checksum "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c9aa1478e63066311f4f84f127ad9714e3e97fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Lists), @"mvc.1.0.view", @"/Views/Login/Lists.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Login/Lists.cshtml", typeof(AspNetCore.Views_Login_Lists))]
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
#line 1 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\_ViewImports.cshtml"
using EthicsCap2;

#line default
#line hidden
#line 2 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c9aa1478e63066311f4f84f127ad9714e3e97fa", @"/Views/Login/Lists.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf35dfe81a586e00972607d16d0f676cb042a396", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Lists : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EthicsCap2.Models.Login>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
  
    ViewBag.Title = "List Logins";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(130, 392, true);
            WriteLiteral(@"
<style type=""text/css"">

    a:link {
        color: blue;
        text-decoration: none;
    }

    a:visited {
        color: red;
        text-decoration: none;
    }

    a:hover {
        color: #006632;
        text-decoration: underline;
    }

    a:active {
        color: blue;
        text-decoration: none;
    }
</style>

<h2>ListLogins</h2>

<p>
    ");
            EndContext();
            BeginContext(523, 39, false);
#line 34 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
            EndContext();
            BeginContext(562, 35, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n\r\n\r\n");
            EndContext();
#line 39 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(638, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(687, 43, false);
#line 43 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(730, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(786, 43, false);
#line 46 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
           Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
            EndContext();
            BeginContext(829, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(885, 37, false);
#line 49 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
           Write(Html.ActionLink("Edit", "Edit", item));

#line default
#line hidden
            EndContext();
            BeginContext(922, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
            BeginContext(988, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1005, 41, false);
#line 51 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
           Write(Html.ActionLink("Delete", "Delete", item));

#line default
#line hidden
            EndContext();
            BeginContext(1046, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 54 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Login\Lists.cshtml"
    }

#line default
#line hidden
            BeginContext(1089, 12, true);
            WriteLiteral("\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EthicsCap2.Models.Login>> Html { get; private set; }
    }
}
#pragma warning restore 1591
