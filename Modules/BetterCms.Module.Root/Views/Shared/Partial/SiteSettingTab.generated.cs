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

namespace BetterCms.Module.Root.Views.Shared.Partial
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
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Partial/SiteSettingTab.cshtml")]
    public partial class SiteSettingTab : System.Web.Mvc.WebViewPage<dynamic>
    {
        public SiteSettingTab()
        {
        }
        public override void Execute()
        {
WriteLiteral("<script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"bcms-site-setting-tab-template\"");

WriteLiteral(@">
    <div class=""bcms-innertab-header"">
        <!-- ko foreach: tabs -->
        <a class=""bcms-tab"" data-bind=""
            text: title, 
            attr: {'data-name': href}, 
            click: tabClick, clickBubble: true""></a>
        <!-- /ko -->
    </div>
    <!-- ko foreach: tabs -->
    <div class=""bcms-tab-single"" data-bind=""attr: {id: tabId}, stopBinding: true"">
        ");

WriteLiteral("\r\n        <div></div>\r\n    </div>\r\n    <!-- /ko -->\r\n</script>");

        }
    }
}
#pragma warning restore 1591
