#pragma checksum "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbdfc20a36f9135af9b2424827dfd5cece4b0819"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Lists), @"mvc.1.0.view", @"/Views/Company/Lists.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/Lists.cshtml", typeof(AspNetCore.Views_Company_Lists))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbdfc20a36f9135af9b2424827dfd5cece4b0819", @"/Views/Company/Lists.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf35dfe81a586e00972607d16d0f676cb042a396", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Lists : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EthicsCap2.Models.Company>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
  
    ViewBag.Title = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(125, 454, true);
            WriteLiteral(@"    <style type=""text/css"">

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
<h2>List</h2>

<p>
    ");
            EndContext();
            BeginContext(580, 39, false);
#line 32 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
            EndContext();
            BeginContext(619, 36, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n \r\n\r\n");
            EndContext();
#line 37 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(687, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(724, 46, false);
#line 40 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
       Write(Html.DisplayFor(modelItem => item.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(770, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(814, 42, false);
#line 43 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
       Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(856, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(900, 50, false);
#line 46 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
       Write(Html.DisplayFor(modelItem => item.GroupAdminToken));

#line default
#line hidden
            EndContext();
            BeginContext(950, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(994, 50, false);
#line 49 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
       Write(Html.DisplayFor(modelItem => item.AssessmentToken));

#line default
#line hidden
            EndContext();
            BeginContext(1044, 56, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n           \r\n            ");
            EndContext();
            BeginContext(1101, 37, false);
#line 53 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
       Write(Html.ActionLink("Edit", "Edit", item));

#line default
#line hidden
            EndContext();
            BeginContext(1138, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
            BeginContext(1200, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1213, 41, false);
#line 55 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
       Write(Html.ActionLink("Delete", "Delete", item));

#line default
#line hidden
            EndContext();
            BeginContext(1254, 40, true);
            WriteLiteral("\r\n          \r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 59 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Company\Lists.cshtml"
}

#line default
#line hidden
            BeginContext(1297, 12, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EthicsCap2.Models.Company>> Html { get; private set; }
    }
}
#pragma warning restore 1591