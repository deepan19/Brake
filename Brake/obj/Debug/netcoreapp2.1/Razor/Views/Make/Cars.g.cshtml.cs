#pragma checksum "C:\Projects\Brake\Brake\Views\Make\Cars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db062f804a10c25385b0eacd2ebc9061f06d0464"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Make_Cars), @"mvc.1.0.view", @"/Views/Make/Cars.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Make/Cars.cshtml", typeof(AspNetCore.Views_Make_Cars))]
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
#line 1 "C:\Projects\Brake\Brake\Views\_ViewImports.cshtml"
using Brake;

#line default
#line hidden
#line 2 "C:\Projects\Brake\Brake\Views\_ViewImports.cshtml"
using Brake.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db062f804a10c25385b0eacd2ebc9061f06d0464", @"/Views/Make/Cars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba0d34e9cf0dadcde82859a01bb964bfbf8c5f05", @"/Views/_ViewImports.cshtml")]
    public class Views_Make_Cars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Brake.Models.Make>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Brake\Brake\Views\Make\Cars.cshtml"
  
    ViewData["Title"] = "Cars";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(113, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(120, 10, false);
#line 7 "C:\Projects\Brake\Brake\Views\Make\Cars.cshtml"
Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(130, 9, true);
            WriteLiteral("</h2>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Brake.Models.Make> Html { get; private set; }
    }
}
#pragma warning restore 1591
