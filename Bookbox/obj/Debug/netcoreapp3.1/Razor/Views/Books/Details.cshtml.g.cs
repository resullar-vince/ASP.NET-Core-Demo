#pragma checksum "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af9b2a40fe6d5534e8c4ab5fb72cc0654de4bd45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Details), @"mvc.1.0.view", @"/Views/Books/Details.cshtml")]
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
#line 1 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\_ViewImports.cshtml"
using Bookbox;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\_ViewImports.cshtml"
using Bookbox.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af9b2a40fe6d5534e8c4ab5fb72cc0654de4bd45", @"/Views/Books/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d039e798c550e3cb99b49cb68b30f82f43f4a1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bookbox.Models.Books.BookModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
  
    ViewData["Title"] = @Html.DisplayFor(model => model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Book Details</h1>\r\n\r\n<div class=\"book-details-card\">\r\n    <h4>");
#nullable restore
#line 10 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
   Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <div class=\"details-primary-container\">\r\n        <img class=\"book-details-image\"");
            BeginWriteAttribute("src", " src=\"", 322, "\"", 369, 1);
#nullable restore
#line 13 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
WriteAttributeValue("", 328, Html.DisplayFor(model => model.ImageUrl), 328, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 370, "\"", 414, 1);
#nullable restore
#line 13 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
WriteAttributeValue("", 376, Html.DisplayFor(model => model.Title), 376, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <dl class=\"details-primary-dl\">\r\n            <dt>\r\n                ");
#nullable restore
#line 16 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.AuthorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 19 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
           Write(Html.DisplayFor(model => model.AuthorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 22 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                $");
#nullable restore
#line 25 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
            Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 28 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.PublishedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 31 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
           Write(Html.DisplayFor(model => model.PublishedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 34 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryIds));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n");
#nullable restore
#line 37 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
                 foreach (var category in Model.BookCategories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>");
#nullable restore
#line 39 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
                     Write(category.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 40 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n        </dl>\r\n    </div>\r\n    <hr />\r\n    <div class=\"row\">\r\n        <h5>");
#nullable restore
#line 46 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Synopsis));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <br />\r\n        <p>\r\n            ");
#nullable restore
#line 49 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
       Write(Html.DisplayFor(model => model.Synopsis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n</div>\r\n<div class=\"mini-nav\">\r\n    ");
#nullable restore
#line 54 "D:\Learning\.Net\Exercises\Core MVC\Bookbox\Views\Books\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af9b2a40fe6d5534e8c4ab5fb72cc0654de4bd458712", async() => {
                WriteLiteral("Back to List");
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
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bookbox.Models.Books.BookModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
