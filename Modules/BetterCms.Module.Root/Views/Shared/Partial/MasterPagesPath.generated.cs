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
    
    #line 1 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
    using BetterCms.Module.Root.ViewModels.Cms;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Partial/MasterPagesPath.cshtml")]
    public partial class _Views_Shared_Partial_MasterPagesPath_cshtml : System.Web.Mvc.WebViewPage<RenderPageViewModel>
    {

#line 25 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
public System.Web.WebPages.HelperResult RenderMasterPage(RenderPageViewModel viewModel)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 26 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
 
    if (viewModel.MasterPage != null)
    {
        

#line default
#line hidden

#line 29 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
WriteTo(__razor_helper_writer, RenderMasterPage(viewModel.MasterPage));


#line default
#line hidden

#line 29 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
                                               


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <div");

WriteLiteralTo(__razor_helper_writer, " class=\"bcms-layout-path-item bcms-path-master\"");

WriteLiteralTo(__razor_helper_writer, " data-url=\"");


#line 30 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
                                        WriteTo(__razor_helper_writer, viewModel.MasterPage.PageUrl);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\"");

WriteLiteralTo(__razor_helper_writer, ">");


#line 30 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
                                                                       WriteTo(__razor_helper_writer, viewModel.MasterPage.Title);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</div>\r\n");


#line 31 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
    }


#line default
#line hidden
});

#line 32 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
}
#line default
#line hidden

        public _Views_Shared_Partial_MasterPagesPath_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
 if (Model.CanManageContent)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"bcms-layout-path\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"bcms-path-arrow-left bcms-path-arrow-inactive\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" class=\"bcms-path-arrow-right\"");

WriteLiteral("></div>\r\n        <div");

WriteLiteral(" class=\"bcms-layout-path-inner\"");

WriteLiteral(">\r\n");

            
            #line 11 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
            
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
             if (Model.RenderingPage != null)
            {
                
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
           Write(RenderMasterPage(Model.RenderingPage));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
                                                      
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div");

WriteLiteral(" id=\"bcms-path-draggable\"");

WriteLiteral(" style=\"position: absolute\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"bcms-path-drag-handle\"");

WriteLiteral(" style=\"font-family: Comic Sans MS, cursive, sans-serif; width: 65px; height: 25p" +
"x; background-color: pink; font-size: 10px\"");

WriteLiteral(">DRAG ME</div>\r\n            <div");

WriteLiteral(" class=\"bcms-layout-path-handle\"");

WriteLiteral(">\r\n                Hide Path\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 23 "..\..\Views\Shared\Partial\MasterPagesPath.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
