#pragma checksum "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Camel\OverallRegulatoryKnowledge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "071f7603e9a8be7927772054cef9790ccc9253f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Camel_OverallRegulatoryKnowledge), @"mvc.1.0.view", @"/Views/Camel/OverallRegulatoryKnowledge.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Camel/OverallRegulatoryKnowledge.cshtml", typeof(AspNetCore.Views_Camel_OverallRegulatoryKnowledge))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"071f7603e9a8be7927772054cef9790ccc9253f9", @"/Views/Camel/OverallRegulatoryKnowledge.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf35dfe81a586e00972607d16d0f676cb042a396", @"/Views/_ViewImports.cshtml")]
    public class Views_Camel_OverallRegulatoryKnowledge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EthicsCap2.Models.Camels.OverallRegulatoryScores>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Camel\OverallRegulatoryKnowledge.cshtml"
  
    ViewData["Title"] = "Overall Regulatory Knowledge ";

#line default
#line hidden
            BeginContext(122, 2506, true);
            WriteLiteral(@"
<h1>Overall Regulatory Knowledge</h1>
<div class=""form-horizontal"">
    <hr />
    <table class=""table table-bordered table-responsive table-hover d-xl-table"">
        <tr>
            <th rowspan=""2""></th>
            <th colspan=""2"" rowspan=""1"" align=""center"">
                Targeted Regulatory Outcomes
            </th>
            <th rowspan=""2"" colspan=""2"" align=""center"">
                Assessment Scoring
                (Category Average Scores)
            </th>
        </tr>
        <tr>
            <th align=""center"">Targeted Regulatory Exam Outcomes</th>
            <th align=""center"">Target Financial/Risk OutComes</th>
        </tr>
        <tr>
            <td width=""10"">C</td>
            <td width=""100""><ul>2</ul> Capital Adequacy Rating</td>
            <td width=""100"">
                Tier 1 Capital Ratio > 10%
                Total Capital Ratios > 12%
            </td>
            <td width=""100"">
                Average Score: = 2
            </td>
        <");
            WriteLiteral(@"/tr>
        <tr>
            <td width=""10"">A</td>
            <td width=""100""> <ul>2</ul>  Asset Quality Rating</td>
            <td width=""100"">Adversly Classified Rating Items Ratio < 40% </td>
            <td width=""100"">
                Average Score: = 2
            </td>
        </tr>
        <tr>
            <td width=""10"">M</td>
            <td width=""100""> <ul>2</ul>  Managment Effectivness Rating Satisfactory CRA Rating</td>
            <td width=""100"">Efficiency Ratio < 60 %</td>
            <td width=""100"">
                Average Score: = 2
            </td>
        </tr>
        <tr>
            <td width=""10"">E</td>
            <td width=""100""><ul>2</ul>  Earnings Sustainability Rating</td>
            <td width=""100"">ROAA > 1.25%</td>
            <td width=""100"">
                Average Score: = 2
            </td>
        </tr>
        <tr>
            <td width=""10"">L</td>
            <td width=""100""><ul>2</ul>  Liquidity Risk Rating </td>
            <td width=");
            WriteLiteral(@"""100"">Adversly Stressed Liquidity  > 20%</td>
            <td width=""100"">
                Average Score: = 2
            </td>
        </tr>
        <tr>
            <td width=""10"">S</td>
            <td width=""100""><ul>2</ul>  Senisitivity to Market Rating </td>
            <td width=""100"">Adversily Stressed NIM > 3.50%</td>
            <td width=""100"">
                Average Score: = 2
            </td>
        </tr>

    </table>
    ");
            EndContext();
            BeginContext(2629, 40, false);
#line 77 "C:\Users\surfe\source\repos\EthicsCapital\EthicsCap2\Views\Camel\OverallRegulatoryKnowledge.cshtml"
Write(Html.ActionLink("Next", "Index", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(2669, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EthicsCap2.Models.Camels.OverallRegulatoryScores> Html { get; private set; }
    }
}
#pragma warning restore 1591