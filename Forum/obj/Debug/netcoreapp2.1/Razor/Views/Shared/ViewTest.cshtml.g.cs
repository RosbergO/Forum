#pragma checksum "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6461552f4081f42ee820b8430293799a519eec60"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ViewTest), @"mvc.1.0.view", @"/Views/Shared/ViewTest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/ViewTest.cshtml", typeof(AspNetCore.Views_Shared_ViewTest))]
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
#line 1 "C:\Users\oscar\source\repos\Forum\Forum\Views\_ViewImports.cshtml"
using Forum;

#line default
#line hidden
#line 2 "C:\Users\oscar\source\repos\Forum\Forum\Views\_ViewImports.cshtml"
using Forum.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6461552f4081f42ee820b8430293799a519eec60", @"/Views/Shared/ViewTest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ac609fd15eba99a48942b04c8579a10a24406fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ViewTest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Forum.Models.TblPosts>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
  
    ViewData["Title"] = "ViewTest";

#line default
#line hidden
            BeginContext(91, 28, true);
            WriteLiteral("\r\n<h2>View</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(119, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81331c701aff4e87bfce13c3696bf3bc", async() => {
                BeginContext(142, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(156, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(249, 40, false);
#line 17 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayNameFor(model => model.PoId));

#line default
#line hidden
            EndContext();
            BeginContext(289, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(345, 42, false);
#line 20 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayNameFor(model => model.PoName));

#line default
#line hidden
            EndContext();
            BeginContext(387, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(443, 45, false);
#line 23 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayNameFor(model => model.PoContent));

#line default
#line hidden
            EndContext();
            BeginContext(488, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(544, 42, false);
#line 26 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayNameFor(model => model.PoDate));

#line default
#line hidden
            EndContext();
            BeginContext(586, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(642, 44, false);
#line 29 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayNameFor(model => model.PoAuthor));

#line default
#line hidden
            EndContext();
            BeginContext(686, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(742, 46, false);
#line 32 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayNameFor(model => model.PoCategory));

#line default
#line hidden
            EndContext();
            BeginContext(788, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 38 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(906, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(955, 39, false);
#line 41 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayFor(modelItem => item.PoId));

#line default
#line hidden
            EndContext();
            BeginContext(994, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1050, 41, false);
#line 44 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayFor(modelItem => item.PoName));

#line default
#line hidden
            EndContext();
            BeginContext(1091, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1147, 44, false);
#line 47 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayFor(modelItem => item.PoContent));

#line default
#line hidden
            EndContext();
            BeginContext(1191, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1247, 41, false);
#line 50 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayFor(modelItem => item.PoDate));

#line default
#line hidden
            EndContext();
            BeginContext(1288, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1344, 43, false);
#line 53 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayFor(modelItem => item.PoAuthor));

#line default
#line hidden
            EndContext();
            BeginContext(1387, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1443, 45, false);
#line 56 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.DisplayFor(modelItem => item.PoCategory));

#line default
#line hidden
            EndContext();
            BeginContext(1488, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1544, 65, false);
#line 59 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1609, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1630, 71, false);
#line 60 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1701, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1722, 69, false);
#line 61 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1791, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 64 "C:\Users\oscar\source\repos\Forum\Forum\Views\Shared\ViewTest.cshtml"
}

#line default
#line hidden
            BeginContext(1830, 28, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n  \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Forum.Models.TblPosts>> Html { get; private set; }
    }
}
#pragma warning restore 1591
