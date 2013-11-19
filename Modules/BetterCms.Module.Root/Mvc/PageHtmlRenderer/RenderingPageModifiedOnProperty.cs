﻿namespace BetterCms.Module.Root.Mvc.PageHtmlRenderer
{
    public class RenderingPageModifiedOnProperty : RenderingPagePropertyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingPageModifiedOnProperty" /> class.
        /// </summary>
        public RenderingPageModifiedOnProperty()
            : base(RenderingPageProperties.PageModifiedOn)
        {
        }

        /// <summary>
        /// Gets the replaced HTML.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="model">The model.</param>
        /// <returns>HTML with replace</returns>
        public override System.Text.StringBuilder GetReplacedHtml(System.Text.StringBuilder stringBuilder, ViewModels.Cms.RenderPageViewModel model)
        {
            return GetReplacedHtml(stringBuilder, model.ModifiedOn);
        }
    }
}