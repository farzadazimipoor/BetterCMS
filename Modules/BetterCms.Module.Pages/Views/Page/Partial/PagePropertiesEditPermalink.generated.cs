﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterCms.Module.Pages.Views.Page.Partial
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
    using BetterCms.Module.Pages.Content.Resources;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Page/Partial/PagePropertiesEditPermalink.cshtml")]
    public partial class PagePropertiesEditPermalink : System.Web.Mvc.WebViewPage<BetterCms.Module.Pages.ViewModels.Page.EditPagePropertiesViewModel>
    {
        public PagePropertiesEditPermalink()
        {
        }
        public override void Execute()
        {



WriteLiteral("\r\n");


WriteLiteral("<div class=\"bcms-input-list-holder\">\r\n    ");


            
            #line 7 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
Write(Html.Tooltip(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_PageUrl_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div class=\"bcms-content-titles\">");


            
            #line 8 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_PageUrl_Title);

            
            #line default
            #line hidden
WriteLiteral("<a onclick=\"return false\" id=\"bcms-pageproperties-editpermalink\">");


            
            #line 8 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                                                                                                                                                           Write(RootGlobalization.Button_Edit);

            
            #line default
            #line hidden
WriteLiteral("</a></div>\r\n    <div class=\"bcms-editseo-urlpath\" id=\"bcms-page-permalink-info\">");


            
            #line 9 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                                                Write(string.IsNullOrWhiteSpace(Model.PageUrl) ? Html.Raw("&nbsp;") : new MvcHtmlString(Html.Encode(Model.PageUrl)));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n</div>\r\n\r\n<div class=\"bcms-edit-urlpath-box\" style=\"display: none;\">\r\n   " +
" ");


            
            #line 13 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
Write(Html.Hidden("PagePermalinkHidden", Model.PageUrl, new { @id = "bcms-page-permalink" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <div class=\"bcms-custom-input-box\">\r\n        ");


            
            #line 16 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
   Write(Html.TextBoxFor(model => model.PageUrl, new { @id = "bcms-page-permalink-edit", @class = "bcms-editor-field-box", @style = "width: 503px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");


            
            #line 17 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
   Write(Html.BcmsValidationMessageFor(f => f.PageUrl));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"bcms-btn-small\" id=\"bcms-save-permalink\">");


            
            #line 20 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                                    Write(RootGlobalization.Button_Ok);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div class=\"bcms-btn-links-small\">");


            
            #line 21 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                 Write(RootGlobalization.Button_Cancel);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div class=\"bcms-edit-check-field\">\r\n        ");


            
            #line 23 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
   Write(Html.CheckBoxFor(model => model.RedirectFromOldUrl));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div class=\"bcms-edit-label\">");


            
            #line 24 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_CreatePermanentRedirectToOldUrl_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    </div>\r\n    <div class=\"bcms-edit-check-field\">\r\n        ");


            
            #line 27 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
   Write(Html.CheckBoxFor(model => model.UseCanonicalUrl));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div class=\"bcms-edit-label\">");


            
            #line 28 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_UseCanonicalUrl);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    </div>\r\n");


            
            #line 30 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
     if (Model.IsInSitemap)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div class=\"bcms-edit-check-field\">\r\n            ");


            
            #line 33 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
       Write(Html.CheckBoxFor(model => model.UpdateSitemap));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div class=\"bcms-edit-label\">");


            
            #line 34 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
                                    Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_UpdateSitemap_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n");


            
            #line 36 "..\..\Views\Page\Partial\PagePropertiesEditPermalink.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


        }
    }
}
#pragma warning restore 1591
