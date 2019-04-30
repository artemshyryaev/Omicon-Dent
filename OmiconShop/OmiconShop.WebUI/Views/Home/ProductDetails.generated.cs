﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Views\Home\ProductDetails.cshtml"
    using OmiconShop.Domain.Enumerations;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Home\ProductDetails.cshtml"
    using OmiconShop.WebUI.HtmlHelpers;

#line default
#line hidden
    using OmiconShop.WebUI;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/ProductDetails.cshtml")]
    public partial class _Views_Home_ProductDetails_cshtml : System.Web.Mvc.WebViewPage<OmiconShop.Domain.Entities.Product>
    {
        public _Views_Home_ProductDetails_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Home\ProductDetails.cshtml"
  
    ViewBag.Title = "ProductDetails";
    var selectedUom = UOM.PCS;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Product Details</h2>\r\n\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Home\ProductDetails.cshtml"
Write(Html.RouteLink("Back to overview", new { action = "ProductsList", controller = "Home", type = ViewData["Type"],
        page = ViewData["Page"]}));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

            
            #line 17 "..\..\Views\Home\ProductDetails.cshtml"
 if (Model.ImageUrl != null)
{

            
            #line default
            #line hidden
WriteLiteral("    <div>\r\n        <img");

WriteLiteral(" class=\"img-thumbnail\"");

WriteLiteral(" width=\"75\"");

WriteLiteral(" height=\"75\"");

WriteAttribute("src", Tuple.Create("\r\n             src=\"", 500), Tuple.Create("\"", 535)
            
            #line 21 "..\..\Views\Home\ProductDetails.cshtml"
, Tuple.Create(Tuple.Create("", 520), Tuple.Create<System.Object, System.Int32>(Model.ImageUrl
            
            #line default
            #line hidden
, 520), false)
);

WriteLiteral(">\r\n    </div>\r\n");

            
            #line 23 "..\..\Views\Home\ProductDetails.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n    <div>");

            
            #line 26 "..\..\Views\Home\ProductDetails.cshtml"
    Write(Model.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div>Item no.  ");

            
            #line 27 "..\..\Views\Home\ProductDetails.cshtml"
              Write(Model.ProductId);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div>Price: ");

            
            #line 28 "..\..\Views\Home\ProductDetails.cshtml"
           Write(Model.Price);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div>Description: ");

            
            #line 29 "..\..\Views\Home\ProductDetails.cshtml"
                 Write(Model.Description);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n</div>\r\n\r\n<div>\r\n");

            
            #line 33 "..\..\Views\Home\ProductDetails.cshtml"
    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Home\ProductDetails.cshtml"
     using (Html.BeginForm("AddToCart", "Basket"))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div>\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Views\Home\ProductDetails.cshtml"
       Write(Html.TextBox("Quantity", 1, new { @class = "form-control", type = "number", step = "1", min = "1" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        <div>\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Views\Home\ProductDetails.cshtml"
       Write(Html.UomEnumDropdownList("uom", selectedUom, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        <div>\r\n");

WriteLiteral("            ");

            
            #line 42 "..\..\Views\Home\ProductDetails.cshtml"
       Write(Html.Hidden("productId", Model.ProductId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 43 "..\..\Views\Home\ProductDetails.cshtml"
       Write(Html.Hidden("returnUrl", Request.Url.PathAndQuery));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-success\"");

WriteLiteral(" value=\"Add to cart\"");

WriteLiteral(">\r\n        </div>\r\n");

            
            #line 46 "..\..\Views\Home\ProductDetails.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
