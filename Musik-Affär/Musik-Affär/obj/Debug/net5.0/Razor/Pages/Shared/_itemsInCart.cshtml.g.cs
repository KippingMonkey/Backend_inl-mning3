#pragma checksum "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Shared\_itemsInCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53ebc2846112f2b841ba8dcb4862ca8b5ba47749"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Musik_Affär.Pages.Shared.Pages_Shared__itemsInCart), @"mvc.1.0.view", @"/Pages/Shared/_itemsInCart.cshtml")]
namespace Musik_Affär.Pages.Shared
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
#nullable restore
#line 1 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Shared\_itemsInCart.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Shared\_itemsInCart.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ebc2846112f2b841ba8dcb4862ca8b5ba47749", @"/Pages/Shared/_itemsInCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e7d1e1d7014f6b894f2961101bb3077431b76d3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__itemsInCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\User\source\repos\Backend_inl-mning3\Musik-Affär\Musik-Affär\Pages\Shared\_itemsInCart.cshtml"
  
    
    //IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
    //var Cart = await _context.Carts.Include(c => c.User)
    //                                       .Where(c => c.UserID == user.Id)
    //                                       .FirstOrDefaultAsync();
                
    //var CartItems = await _context.CartItems.Include(ci => ci.Product).Where(ci => ci.CartID == Cart.ID).ToListAsync();

    //var TotalProductPrices = CartItems.Select(ci => ci.Quantity * ci.Product.Price).ToList();
    //var TotalProductQty = CartItems.Sum(ci => ci.Quantity);
  

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div>\r\n");
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext _context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> _userManager { get; private set; }
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
