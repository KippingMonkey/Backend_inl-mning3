#pragma checksum "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67ff9e83824d4a848a7d354653a8209eda078d80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Musik_Affär.Pages.Carts.Pages_Carts_Index), @"mvc.1.0.razor-page", @"/Pages/Carts/Index.cshtml")]
namespace Musik_Affär.Pages.Carts
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
#line 1 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\_ViewImports.cshtml"
using Musik_Affär;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\_ViewImports.cshtml"
using Musik_Affär.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67ff9e83824d4a848a7d354653a8209eda078d80", @"/Pages/Carts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e7d1e1d7014f6b894f2961101bb3077431b76d3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Carts_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("crud-links"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Min Kundkorg</h1>\r\n<h2>");
#nullable restore
#line 9 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
Write(Model.Cart.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<table class=\"table\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 14 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 15 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Product.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 16 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Product.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 17 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Product.Brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 18 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Product.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>Antal</th>\r\n            <th>Totalt</th>\r\n            <th>Ändra</th>\r\n        </tr>\r\n    </thead>\r\n       <tbody>\r\n");
#nullable restore
#line 25 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
 for(int i = 0; i < Model.CartItems.Count(); i++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td> ");
#nullable restore
#line 27 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.CartItems[i].Product.Name ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 28 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.CartItems[i].Product.Category ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 29 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.CartItems[i].Product.Color ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 30 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.CartItems[i].Product.Brand ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 31 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.CartItems[i].Product.Price ));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SEK</td>\r\n            <td> ");
#nullable restore
#line 32 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.CartItems[i].Quantity ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 33 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.TotalProductPrices[i]));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67ff9e83824d4a848a7d354653a8209eda078d809699", async() => {
                WriteLiteral("\r\n                    <button type=\"submit\">+</button>\r\n                    \r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
                                                             WriteLiteral(Model.CartItems[i].ProductID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67ff9e83824d4a848a7d354653a8209eda078d8012371", async() => {
                WriteLiteral("Detaljer");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
                                          WriteLiteral(Model.CartItems[i].ProductID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 42 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("       <tr></tr>\r\n        <tr>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td>Totalt: </td>\r\n            <td>");
#nullable restore
#line 49 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
           Write(Html.DisplayFor(model => model.TotalProductQty));

#line default
#line hidden
#nullable disable
            WriteLiteral(" produkter</td>\r\n            <td> ");
#nullable restore
#line 50 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Carts\Index.cshtml"
            Write(Html.DisplayFor(model => model.TotalOrderPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" SEK</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Musik_Affär.Pages.Carts.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Musik_Affär.Pages.Carts.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Musik_Affär.Pages.Carts.IndexModel>)PageContext?.ViewData;
        public Musik_Affär.Pages.Carts.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
