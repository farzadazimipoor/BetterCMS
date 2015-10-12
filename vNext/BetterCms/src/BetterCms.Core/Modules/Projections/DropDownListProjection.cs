using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using BetterCms.Core.DataContracts;

using BetterModules.Core.Web.Modules;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;

namespace BetterCms.Core.Modules.Projections
{
    /// <summary>
    /// Defines client side action attached to side menu button.
    /// </summary>
    public class DropDownListProjection : HtmlElementProjection
    {
        /// <summary>
        /// Module action marker css class.
        /// </summary>
        private const string ModuleActionMarkerCssClass = "bcms-onchange-action";

        /// <summary>
        /// Html element attribute name to mark module name.
        /// </summary>
        private const string ModuleNameAttribute = "data-bcms-module";

        /// <summary>
        /// Html element attribute name to mark module action name.
        /// </summary>
        private const string ModuleActionAttribute = "data-bcms-action";

        /// <summary>
        /// Gets or sets the client side parent module.
        /// </summary>
        /// <value>
        /// The client side parent module.
        /// </value>
        private readonly JsIncludeDescriptor parentModuleInclude;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownListProjection" /> class.
        /// </summary>
        /// <param name="parentModuleInclude">The parent module (should contain on change action).</param>
        /// <param name="items">A list of select items.</param>
        /// <param name="onChangeAction">Name of the action to execute after select item changed.</param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public DropDownListProjection(JsIncludeDescriptor parentModuleInclude, IEnumerable<Func<IPage, DropDownListProjectionItem>> items, Func<IPage, string> onChangeAction)
            : base("div")
        {
            this.parentModuleInclude = parentModuleInclude;
            Items = items;
            OnChangeAction = onChangeAction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownListProjection" /> class.
        /// </summary>
        /// <param name="parentModuleInclude">The parent module (should contain on change action).</param>
        /// <param name="onChangeAction">Name of the action to execute after select item changed.</param>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public DropDownListProjection(JsIncludeDescriptor parentModuleInclude, Func<IPage, string> onChangeAction)
            : base("div")
        {
            this.parentModuleInclude = parentModuleInclude;
            OnChangeAction = onChangeAction;
        }

        /// <summary>
        /// Gets or sets drop down list items enumerator.
        /// </summary>
        public IEnumerable<Func<IPage, DropDownListProjectionItem>> Items { get; set; }

        /// <summary>
        /// Gets or sets the callback function attached to action.
        /// </summary>
        /// <value>
        /// The callback function.
        /// </value>
        public Func<IPage, string> OnChangeAction { get; set; }

        /// <summary>
        /// Called before render methods sends element to response output.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="html">The html helper.</param>
        protected override void OnPreRender(TagBuilder builder, IPage page, HtmlHelper html)
        {
            base.OnPreRender(builder, page, html);

            if (Items != null && Items.Any())
            {
                var innerDiv = new TagBuilder("div");
                
                var items = Items
                    .Select(f => f(page))
                    .OrderBy(f => f.Order)
                    .Select(
                        f => new SelectListItem
                        {
                            Selected = f.IsSelected,
                            Text = f.Text != null ? f.Text() : string.Empty,
                            Value = f.Value
                        })
                    .ToList();

                foreach (var item in items)
                {
                    var option = new TagBuilder("div");
                    option.InnerHtml.Append(item.Text);
                    //option.Controls.Add(new LiteralControl(item.Text));
                    option.Attributes["value"] = item.Value;
                    if (item.Selected)
                    {
                        option.Attributes["selected"] = "selected";
                    }

                    innerDiv.InnerHtml.Append(option);
                }
                builder.InnerHtml.Append(innerDiv);
            }

            if (OnChangeAction != null && parentModuleInclude != null)
            {
                string cssClass = builder.Attributes["class"];
                if (!string.IsNullOrEmpty(cssClass) && !cssClass.Contains(ModuleActionMarkerCssClass))
                {
                    cssClass = string.Concat(cssClass, " ", ModuleActionMarkerCssClass);
                }
                else
                {
                    cssClass = ModuleActionMarkerCssClass;
                }

                builder.Attributes["class"] = cssClass;
                builder.Attributes.Add(ModuleNameAttribute, parentModuleInclude.Name);
                builder.Attributes.Add(ModuleActionAttribute, OnChangeAction(page));
            }
        }
    }
}