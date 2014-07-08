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
    
    #line 1 "..\..\Views\Page\Partial\TemplatesList.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Page/Partial/TemplatesList.cshtml")]
    public partial class TemplatesList : System.Web.Mvc.WebViewPage<IList<BetterCms.Module.Pages.ViewModels.Page.TemplateViewModel> >
    {

public System.Web.WebPages.HelperResult Templates(IList<BetterCms.Module.Pages.ViewModels.Page.TemplateViewModel> model)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 4 "..\..\Views\Page\Partial\TemplatesList.cshtml"
 
    if (model != null && model.Count > 0)
    {
        
#line default
#line hidden


#line 7 "..\..\Views\Page\Partial\TemplatesList.cshtml"
WriteTo(@__razor_helper_writer, Html.Raw("<div class=\"bcms-grid-holder\">"));

#line default
#line hidden


#line 7 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                                                     

        for (var i = 0; i < model.Count; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                
#line default
#line hidden


#line 13 "..\..\Views\Page\Partial\TemplatesList.cshtml"
WriteTo(@__razor_helper_writer, Html.Raw("</div>"));

#line default
#line hidden


#line 13 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                                   
                
#line default
#line hidden


#line 14 "..\..\Views\Page\Partial\TemplatesList.cshtml"
WriteTo(@__razor_helper_writer, Html.Raw("<div class=\"bcms-grid-holder\">"));

#line default
#line hidden


#line 14 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                                                             
            }

            
#line default
#line hidden


#line 17 "..\..\Views\Page\Partial\TemplatesList.cshtml"
WriteTo(@__razor_helper_writer, Html.Partial("Partial/Template", model[i]));

#line default
#line hidden


#line 17 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                                                       
        }

        
#line default
#line hidden


#line 20 "..\..\Views\Page\Partial\TemplatesList.cshtml"
WriteTo(@__razor_helper_writer, Html.Raw("</div>"));

#line default
#line hidden


#line 20 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                           
    }
    else
    {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "        <p>");



#line 24 "..\..\Views\Page\Partial\TemplatesList.cshtml"
WriteTo(@__razor_helper_writer, Html.Raw(RootGlobalization.Message_NoItemToSelect));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</p>\r\n");



#line 25 "..\..\Views\Page\Partial\TemplatesList.cshtml"
    }

#line default
#line hidden

});

}


        public TemplatesList()
        {
        }
        public override void Execute()
        {




WriteLiteral("\r\n");


            
            #line 27 "..\..\Views\Page\Partial\TemplatesList.cshtml"
  
    var active = Model.FirstOrDefault(m => m.IsActive);
    var selectFirstTab = active == null || !active.IsMasterPage;


            
            #line default
            #line hidden
WriteLiteral("<div class=\"bcms-inner-tabs-holder\">\r\n    <div class=\"bcms-tab-header bcms-tab-he" +
"ader-inner\">\r\n        <a class=\"bcms-tab ");


            
            #line 33 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                       Write(selectFirstTab ? "bcms-tab-active" : string.Empty);

            
            #line default
            #line hidden
WriteLiteral("\" data-name=\"#bcms-tab-a\">Templates</a>\r\n        <a class=\"bcms-tab ");


            
            #line 34 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                       Write(!selectFirstTab ? "bcms-tab-active" : string.Empty);

            
            #line default
            #line hidden
WriteLiteral("\" data-name=\"#bcms-tab-b\">Master Pages</a>\r\n    </div>\r\n    <div id=\"bcms-tab-a\" " +
"class=\"bcms-tab-single\" style=\"display: ");


            
            #line 36 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                                                             Write(selectFirstTab ? "block" : "none");

            
            #line default
            #line hidden
WriteLiteral(";padding-top: 15px;\">\r\n        ");


            
            #line 37 "..\..\Views\Page\Partial\TemplatesList.cshtml"
   Write(Templates(Model.Where(m => !m.IsMasterPage).ToList()));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div id=\"bcms-tab-b\" class=\"bcms-tab-single\" style=\"display: ");


            
            #line 39 "..\..\Views\Page\Partial\TemplatesList.cshtml"
                                                             Write(!selectFirstTab ? "block" : "none");

            
            #line default
            #line hidden
WriteLiteral(";padding-top: 15px;\">\r\n        ");


            
            #line 40 "..\..\Views\Page\Partial\TemplatesList.cshtml"
   Write(Templates(Model.Where(m => m.IsMasterPage).ToList()));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
