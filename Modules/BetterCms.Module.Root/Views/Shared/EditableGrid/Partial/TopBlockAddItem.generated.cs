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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditableGrid/Partial/TopBlockAddItem.cshtml")]
    public partial class _Views_Shared_EditableGrid_Partial_TopBlockAddItem_cshtml : System.Web.Mvc.WebViewPage<BetterCms.Module.Root.ViewModels.Shared.EditableGridViewModel>
    {
        public _Views_Shared_EditableGrid_Partial_TopBlockAddItem_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Shared\EditableGrid\Partial\TopBlockAddItem.cshtml"
 if (Model.CanAddNewItems)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"bcms-btn-links-main\"");

WriteLiteral(" data-bind=\"click: addNewItem\"");

WriteLiteral(">");

            
            #line 5 "..\..\Views\Shared\EditableGrid\Partial\TopBlockAddItem.cshtml"
                                                              Write(Model.AddNewTitle);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" id=\"bcms-multi-opts\"");

WriteLiteral(" data-bind=\"visible: isAddNewSelected\"");

WriteLiteral(">\r\n            <!-- ko foreach: optionTypes -->\r\n            <div");

WriteLiteral(" class=\"bcms-multi-opt-item\"");

WriteLiteral(" data-bind=\"text: name, click: $parent.addNewSelectedItem.bind(\'$data\', id)\"");

WriteLiteral("></div>\r\n            <!-- /ko -->\r\n        </div>\r\n");

            
            #line 11 "..\..\Views\Shared\EditableGrid\Partial\TopBlockAddItem.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"bcms-btn-links-main\"");

WriteLiteral(">&nbsp;</div>\r\n");

            
            #line 15 "..\..\Views\Shared\EditableGrid\Partial\TopBlockAddItem.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
