#pragma checksum "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8d4a8694682b5c16109fe4369b295dd16bde978"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DeleteProfile), @"mvc.1.0.view", @"/Views/Admin/DeleteProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/DeleteProfile.cshtml", typeof(AspNetCore.Views_Admin_DeleteProfile))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8d4a8694682b5c16109fe4369b295dd16bde978", @"/Views/Admin/DeleteProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf35dfe81a586e00972607d16d0f676cb042a396", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DeleteProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EthicsCap2.Models.Contact>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
  
    ViewBag.Title = "DeleteProfile";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(128, 175, true);
            WriteLiteral("\r\n<h2>DeleteProfile</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Contact</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(304, 45, false);
#line 16 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.CompanyId));

#line default
#line hidden
            EndContext();
            BeginContext(349, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(395, 41, false);
#line 20 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayFor(model => model.CompanyId));

#line default
#line hidden
            EndContext();
            BeginContext(436, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(482, 47, false);
#line 24 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(529, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(575, 43, false);
#line 28 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayFor(model => model.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(618, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(664, 45, false);
#line 32 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(709, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(755, 41, false);
#line 36 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(796, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(842, 44, false);
#line 40 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(886, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(932, 40, false);
#line 44 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(972, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1018, 47, false);
#line 48 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1065, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1111, 43, false);
#line 52 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1154, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1200, 48, false);
#line 56 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1248, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1294, 44, false);
#line 60 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.DisplayFor(model => model.EmailAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1338, 32, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
            EndContext();
#line 65 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
     using (Html.BeginForm()) {
        

#line default
#line hidden
            BeginContext(1412, 23, false);
#line 66 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(1439, 135, true);
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
            EndContext();
            BeginContext(1575, 40, false);
#line 70 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(1615, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 72 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Admin\DeleteProfile.cshtml"
    }

#line default
#line hidden
            BeginContext(1640, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EthicsCap2.Models.Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591