﻿using System.Collections.Generic;
using System.Linq;

using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Core.DataContracts.Enums;
using BetterCms.Core.Mvc.Commands;

using BetterCms.Module.Pages.Models;
using BetterCms.Module.Pages.Services;
using BetterCms.Module.Pages.ViewModels.Page;

using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Mvc.Helpers;

using NHibernate.Linq;

namespace BetterCms.Module.Pages.Command.Page.ClonePage
{
    /// <summary>
    /// A command to clone given page.
    /// </summary>
    public class ClonePageCommand : CommandBase, ICommand<ClonePageViewModel, ClonePageViewModel>
    {
        /// <summary>
        /// Gets or sets the page service.
        /// </summary>
        /// <value>
        /// The page service.
        /// </value>
        public IPageService PageService { get; set; }
        
        /// <summary>
        /// Gets or sets the url service.
        /// </summary>
        /// <value>
        /// The url service.
        /// </value>
        public IUrlService UrlService { get; set; }

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <param name="request">The page view model.</param>
        /// <returns>true if page cloned successfully; false otherwise.</returns>
        public virtual ClonePageViewModel Execute(ClonePageViewModel request)
        {
            // Create / fix page url
            var pageUrl = request.PageUrl;
            if (pageUrl == null && !string.IsNullOrWhiteSpace(request.PageTitle))
            {
                pageUrl = PageService.CreatePagePermalink(request.PageTitle, null);
            }
            else
            {
                pageUrl = UrlService.FixUrl(pageUrl);

                // Validate Url
                PageService.ValidatePageUrl(pageUrl);
            }

            var page = Repository.AsQueryable<PageProperties>()
                                      .Where(f => f.Id == request.PageId)
                                      .FetchMany(f => f.Options)
                                      .FetchMany(f => f.PageContents).ThenFetch(f => f.Region)
                                      .FetchMany(f => f.PageContents).ThenFetch(f => f.Content)
                                      .FetchMany(f => f.PageContents).ThenFetchMany(f => f.Options)
                                      .FetchMany(f => f.PageTags).ThenFetch(f => f.Tag)
                                      .ToList().FirstOne();

            UnitOfWork.BeginTransaction();

            var pageContents = page.PageContents.Distinct().ToList();
            var pageTags = page.PageTags.Distinct().ToList();
            var pageOptions = page.Options.Distinct().ToList();

            // Clone page with security
            var newPage = ClonePageOnly(page, request.PageTitle, pageUrl);

            // Clone contents.
            pageContents.ForEach(pageContent => ClonePageContent(pageContent, newPage));

            // Clone tags.
            pageTags.ForEach(pageTag => ClonePageTags(pageTag, newPage));

            // Clone options.
            pageOptions.ForEach(pageOption => ClonePageOption(pageOption, newPage));
           
            UnitOfWork.Commit();

            Events.PageEvents.Instance.OnPageCloned(newPage);

            return new ClonePageViewModel
                       {
                           PageId = newPage.Id,
                           Version = newPage.Version,
                           PageTitle = newPage.Title,
                           PageUrl = newPage.PageUrl
                       };
        }

        /// <summary>
        /// Clones the page tags.
        /// </summary>
        /// <param name="pageTag">The page tag.</param>
        /// <param name="newPage">The new page.</param>
        private void ClonePageTags(PageTag pageTag, PageProperties newPage)
        {
            var newPageHtmlControl = new PageTag
            {
                Page = newPage,
                Tag = pageTag.Tag
            };

            Repository.Save(newPageHtmlControl);
        }

        /// <summary>
        /// Clones the page only.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="newPageTitle">The new page title.</param>
        /// <param name="newPageUrl">The new page URL.</param>
        /// <returns>Copy for <see cref="PageProperties"/>.</returns>
        private PageProperties ClonePageOnly(PageProperties page, string newPageTitle, string newPageUrl)
        {
            var newPage = page.Duplicate();

            newPage.Title = newPageTitle;
            newPage.MetaTitle = newPageTitle;
            newPage.PageUrl = newPageUrl;
            newPage.PageUrlLowerTrimmed = newPageUrl.LowerTrimmedUrl();
            newPage.Status = PageStatus.Unpublished;

            // Add security.
            AddAccessRules(newPage);

            Repository.Save(newPage);

            return newPage;
        }

        /// <summary>
        /// Clones the content of the page.
        /// </summary>
        /// <param name="pageContent">Content of the page.</param>
        /// <param name="newPage">The new page.</param>
        private void ClonePageContent(PageContent pageContent, PageProperties newPage)
        {
            var newPageContent = new PageContent();
            newPageContent.Page = newPage;
            newPageContent.Order = pageContent.Order;
            newPageContent.Region = pageContent.Region;

            if (pageContent.Content is HtmlContentWidget || pageContent.Content is ServerControlWidget)
            {
                // Do not need to clone widgets.
                newPageContent.Content = pageContent.Content;
            }
            else
            {
                newPageContent.Content = pageContent.Content.Clone();

                var draft = pageContent.Content.History.FirstOrDefault(c => c.Status == ContentStatus.Draft && !c.IsDeleted);
                if (pageContent.Content.Status == ContentStatus.Published && draft != null)
                {
                    if (newPageContent.Content.History == null)
                    {
                        newPageContent.Content.History = new List<Root.Models.Content>();
                    }

                    var draftClone = draft.Clone();
                    draftClone.Original = newPageContent.Content;
                    newPageContent.Content.History.Add(draftClone);
                    Repository.Save(draftClone);
                }
            }

            // Clone page content options.
            foreach (var option in pageContent.Options.Distinct())
            {
                if (newPageContent.Options == null)
                {
                    newPageContent.Options = new List<PageContentOption>();
                }

                var newOption = new PageContentOption
                                    {
                                        Key = option.Key,
                                        Value = option.Value,
                                        Type = option.Type,
                                        PageContent = newPageContent
                                    };
                newPageContent.Options.Add(newOption);
                Repository.Save(newOption);
            }

            Repository.Save(newPageContent);
        }

        private void AddAccessRules(PageProperties newPage)
        {
            var defaultAccessRules = AccessControlService.GetDefaultAccessList(Context.Principal);
            AccessControlService.UpdateAccessControl(newPage, defaultAccessRules);
        }

        private void ClonePageOption(PageOption pageOption, PageProperties newPage)
        {
            var newPageOption = new PageOption
                                    {
                                        Key = pageOption.Key,
                                        Type = pageOption.Type,
                                        Value = pageOption.Value,
                                        Page = newPage                                        
                                    };

            if (newPage.Options == null)
            {
                newPage.Options = new List<PageOption>();
            }

            newPage.Options.Add(newPageOption);
            Repository.Save(newPageOption);            
        }
    }
}