#pragma checksum "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec94b282c867c57a893afcd1e375a903b27fd3eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leaderboard_Index), @"mvc.1.0.view", @"/Views/Leaderboard/Index.cshtml")]
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
#line 1 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/_ViewImports.cshtml"
using AsteroidDodge;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/_ViewImports.cshtml"
using AsteroidDodge.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec94b282c867c57a893afcd1e375a903b27fd3eb", @"/Views/Leaderboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fcfd835df1ec4b9257c9ba4bbb8960627ec4deb", @"/Views/_ViewImports.cshtml")]
    public class Views_Leaderboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<string, int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1>Leaderboard</h1>
<table class=""table table-striped table-dark"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">First</th>
            <th scope=""col"">Score</th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 14 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml"
          
            int count = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml"
         foreach (string username in Model.Keys)
        {
            count++;
            var name = username;
            var score = Model[username];


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 24 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml"
                           Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 25 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml"
               Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml"
               Write(score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "/Users/sambridge/Projects/AsteroidDodge/AsteroidDodge/AsteroidDodge/Views/Leaderboard/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<string, int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
