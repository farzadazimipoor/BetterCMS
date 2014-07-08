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

namespace BetterCms.Module.Pages.Views.Sitemap
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
    
    #line 1 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Pages.Command.History.GetSitemapHistory;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Pages.Content.Resources;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Pages.Controllers;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Pages.ViewModels.History;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Root.Models;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Root.Mvc;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Root.Mvc.Grids.Extensions;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Root.Mvc.Grids.TableRenderers;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Sitemap\History.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Sitemap\History.cshtml"
    using Microsoft.Web.Mvc;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Sitemap\History.cshtml"
    using MvcContrib.UI.Grid;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Sitemap/History.cshtml")]
    public partial class History : System.Web.Mvc.WebViewPage<SitemapHistoryViewModel>
    {

public System.Web.WebPages.HelperResult PreviewLink(SitemapHistoryItem item)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 15 "..\..\Views\Sitemap\History.cshtml"
 

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    <a class=\"bcms-icn-preview\" data-id=\"");



#line 16 "..\..\Views\Sitemap\History.cshtml"
          WriteTo(@__razor_helper_writer, item.Id);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">");



#line 16 "..\..\Views\Sitemap\History.cshtml"
                    WriteTo(@__razor_helper_writer, RootGlobalization.Button_Preview);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</a>\r\n");



#line 17 "..\..\Views\Sitemap\History.cshtml"

#line default
#line hidden

});

}


public System.Web.WebPages.HelperResult RestoreLink(SitemapHistoryItem item)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 19 "..\..\Views\Sitemap\History.cshtml"
 
    if (item.CanCurrentUserRestoreIt)
    {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "        <a class=\"bcms-icn-restore\" data-id=\"");



#line 22 "..\..\Views\Sitemap\History.cshtml"
              WriteTo(@__razor_helper_writer, item.Id);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" data-version=\"");



#line 22 "..\..\Views\Sitemap\History.cshtml"
                                      WriteTo(@__razor_helper_writer, item.Version);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">");



#line 22 "..\..\Views\Sitemap\History.cshtml"
                                                     WriteTo(@__razor_helper_writer, RootGlobalization.Button_Restore);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</a>\r\n");



#line 23 "..\..\Views\Sitemap\History.cshtml"
    }
    else
    {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    ");

WriteLiteralTo(@__razor_helper_writer, "&nbsp;\r\n");



#line 27 "..\..\Views\Sitemap\History.cshtml"
    }

#line default
#line hidden

});

}


        public History()
        {
        }
        public override void Execute()
        {















WriteLiteral("\r\n");



WriteLiteral("\r\n");


            
            #line 29 "..\..\Views\Sitemap\History.cshtml"
  
    Action<ColumnBuilder<SitemapHistoryItem>> columns = column =>
    {
        column.For(f => PreviewLink(f))
               .Encode(false)
               .Named("&nbsp;")
               .Sortable(false)
               .HeaderAttributes(@style => "width: 40px; padding: 10px;", @class => "bcms-tables-nohover")
               .Attributes(@style => "width: 40px;");

        column.For(m => m.SitemapTitle)
               .Named(NavigationGlobalization.SitemapHistory_Column_Title)
               .SortColumnName("SitemapTitle")
               .HeaderAttributes(@style => "width: 410px;")
               .Attributes(@style => "width: 410px;");

        column.For(m => m.ArchivedOn.ToFormattedDateString())
               .Named(NavigationGlobalization.SitemapHistory_Column_ArchivedOn)
               .SortColumnName("ArchivedOn")
               .HeaderAttributes(@style => "width: 100px;")
               .Attributes(@style => "width: 100px;");

        column.For(m => m.ArchivedByUser)
               .Named(NavigationGlobalization.SitemapHistory_Column_ArchivedBy)
               .SortColumnName("ArchivedByUser")
               .HeaderAttributes(@style => "width: 100px;")
               .Attributes(@style => "width: 100px;");

        column.For(m => m.StatusName)
               .Named(NavigationGlobalization.SitemapHistory_Column_Status)
               .SortColumnName("StatusName")
               .Encode(false)
               .HeaderAttributes(@style => "width: 90px;");

        column.For(f => RestoreLink(f))
               .Encode(false)
               .Named("&nbsp;")
               .Sortable(false)
               .HeaderAttributes(@style => "width: 80px;", @class => "bcms-tables-nohover");
    };


            
            #line default
            #line hidden
WriteLiteral("<div class=\"bcms-scroll-window\">\r\n    <div class=\"bcms-history-preview-holder\">\r\n" +
"        ");


            
            #line 72 "..\..\Views\Sitemap\History.cshtml"
   Write(Html.TabbedContentMessagesBox());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div class=\"bcms-history-preview\">\r\n            <div id=\"bcms-history-p" +
"review\" class=\"bcms-sitemap-history\">\r\n                <div class=\"bcms-history-" +
"info\" style=\"display: block;\">");


            
            #line 75 "..\..\Views\Sitemap\History.cshtml"
                                                                  Write(PagesGlobalization.ContentHistory_SelectVersionToPreviewMessage);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                <div class=\"bcms-history-content\"></div>\r\n            </d" +
"iv>\r\n        </div>\r\n    </div>\r\n");


            
            #line 80 "..\..\Views\Sitemap\History.cshtml"
     if (Model != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div class=\"bcms-history-table-holder\">\r\n");


            
            #line 83 "..\..\Views\Sitemap\History.cshtml"
             using (Html.BeginForm<SitemapController>(f => f.ShowSitemapHistory((GetSitemapHistoryRequest)null), FormMethod.Post, new { @id = "bcms-sitemaphistory-form", @class = "bcms-ajax-form" }))
            {
                
            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\Sitemap\History.cshtml"
           Write(Html.HiddenGridOptions(Model.GridOptions));

            
            #line default
            #line hidden
            
            #line 85 "..\..\Views\Sitemap\History.cshtml"
                                                          
                
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Sitemap\History.cshtml"
           Write(Html.HiddenFor(model => model.SitemapId));

            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Sitemap\History.cshtml"
                                                         

            
            #line default
            #line hidden
WriteLiteral("                <div class=\"bcms-history-table-top\">\r\n                    <div cl" +
"ass=\"bcms-large-titles\">");


            
            #line 88 "..\..\Views\Sitemap\History.cshtml"
                                              Write(PagesGlobalization.ContentHistory_OlderVersions);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");



WriteLiteral("\r\n");



WriteLiteral("\r\n");



WriteLiteral("\r\n");



WriteLiteral("\r\n");



WriteLiteral("\r\n                </div>\r\n");


            
            #line 95 "..\..\Views\Sitemap\History.cshtml"
                
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\Sitemap\History.cshtml"
           Write(Html.Grid(Model.Items).Sort(Model.GridOptions).Columns(columns).Attributes(@class => "bcms-tables bcms-history-grid").RenderUsing(new ScrollableEditableHtmlTableGridRenderer<SitemapHistoryItem>() { InternalTableCssClass = "bcms-history-cell" }));

            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\Sitemap\History.cshtml"
                                                                                                                                                                                                                                                                     
                
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\Sitemap\History.cshtml"
           Write(Html.HiddenSubmit());

            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\Sitemap\History.cshtml"
                                    
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n");


            
            #line 99 "..\..\Views\Sitemap\History.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");


        }
    }
}
#pragma warning restore 1591
