﻿using System;
using System.Collections.Generic;

using Autofac;

using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Core.DataContracts;
using BetterCms.Core.Dependencies;
using BetterCms.Core.Exceptions;
using BetterCms.Core.Exceptions.Mvc;
using BetterCms.Core.Modules;
using BetterCms.Core.Modules.Projections;
using BetterCms.Core.Security;
using BetterCms.Core.Services;
using BetterCms.Events;
using BetterCms.Module.Root.Content.Resources;
using BetterCms.Module.Root.Controllers;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Projections;
using BetterCms.Module.Root.Registration;
using BetterCms.Module.Root.Services;

namespace BetterCms.Module.Root
{
    /// <summary>
    /// Root functionality module descriptor.
    /// </summary>
    public class RootModuleDescriptor : ModuleDescriptor
    {        
        /// <summary>
        /// The module name.
        /// </summary>
        internal const string ModuleName = "root";

        /// <summary>
        /// The root area name.
        /// </summary>
        internal const string RootAreaName = "bcms-root";

        private readonly AuthenticationJsModuleIncludeDescriptor authenticationJsModuleIncludeDescriptor;

        private readonly SiteSettingsJsModuleIncludeDescriptor siteSettingsJsModuleIncludeDescriptor;

        /// <summary>
        /// bcms.tags.js java script module descriptor.
        /// </summary>
        private readonly TagsJsModuleIncludeDescriptor tagsJsModuleIncludeDescriptor;

        /// <summary>
        /// Initializes a new instance of the <see cref="RootModuleDescriptor" /> class.
        /// </summary>
        public RootModuleDescriptor(ICmsConfiguration configuration) : base(configuration)
        {    
            authenticationJsModuleIncludeDescriptor = new AuthenticationJsModuleIncludeDescriptor(this);
            siteSettingsJsModuleIncludeDescriptor = new SiteSettingsJsModuleIncludeDescriptor(this);
            tagsJsModuleIncludeDescriptor = new TagsJsModuleIncludeDescriptor(this);

            InitializeSecurity();            
        }        

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
        {
            get
            {
                return ModuleName;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public override string Description
        {
            get
            {
                return "Root functionality module for Better CMS.";
            }
        }

        /// <summary>
        /// Gets the name of the module area.
        /// </summary>
        /// <value>
        /// The name of the module area.
        /// </value>
        public override string AreaName
        {
            get
            {
                return RootAreaName;
            }
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public override int Order
        {
            get
            {
                return int.MaxValue;
            }
        }

        /// <summary>
        /// Registers module types.
        /// </summary>
        /// <param name="context">The area registration context.</param>
        /// <param name="containerBuilder">The container builder.</param>
        public override void RegisterModuleTypes(ModuleRegistrationContext context, ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DefaultSecurityService>().AsImplementedInterfaces().SingleInstance();
            containerBuilder.RegisterType<PageContentProjectionFactory>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DefaultContentService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DefaultRenderingService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PageStylesheetProjectionFactory>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PageJavaScriptProjectionFactory>().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DefaultOptionService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DefaultAccessControlService>().AsImplementedInterfaces().InstancePerLifetimeScope();

        }

        /// <summary>
        /// Registers a routes.
        /// </summary>
        /// <param name="context">The area registration context.</param>
        /// <param name="containerBuilder">The container builder.</param>
        public override void RegisterCustomRoutes(ModuleRegistrationContext context, ContainerBuilder containerBuilder)
        {            
            context.MapRoute(
                "bcms_" + AreaName + "_MainJs",
                string.Format(RootModuleConstants.AutoGeneratedJsFilePathPattern, "bcms.main.js").TrimStart('/'),
                new
                    {
                        area = AreaName,
                        controller = "Rendering",
                        action = "RenderMainJsFile"
                    },
                new[] { typeof(RenderingController).Namespace });
           
            context.MapRoute(
                "bcms_" + AreaName + "_ProcessorJs",
                string.Format(RootModuleConstants.AutoGeneratedJsFilePathPattern, "bcms.processor.js").TrimStart('/'),                
                new
                    {
                        area = AreaName,
                        controller = "Rendering",
                        action = "RenderProcessorJsFile"
                    },  
                new[] { typeof(RenderingController).Namespace });            
            
            context.MapRoute(
                "bcms_" + AreaName + "_PreviewPage",
                "bcms/preview/{pageId}/{pageContentId}",
                new
                {
                    area = AreaName,
                    controller = "Preview",
                    action = "Index"
                },
                new[] { typeof(PreviewController).Namespace });


            CreateEmbeddedResourcesRoutes(context);

            // All CMS Pages:
            context.MapRoute("bcms_" + AreaName + "_AllPages", 
                "{*data}", 
                new
                    {
                        area = AreaName, 
                        controller = "Cms", 
                        action = "Index"
                    }, 
                    new[] { typeof(CmsController).Namespace });
        }

        public override IEnumerable<CssIncludeDescriptor> RegisterCssIncludes()
        {
            return new[]
                       {
                           new CssIncludeDescriptor(this, "base.css"),
                           new CssIncludeDescriptor(this, "bcms.messages.css")
                       };
        }

        public override IEnumerable<JsIncludeDescriptor> RegisterJsIncludes()
        {
            return new []
                {
                    authenticationJsModuleIncludeDescriptor,                    
                    new ContentJsModuleIncludeDescriptor(this),       
                    new DatePickerJsModuleIncludeDescriptor(this), 
                    new DynamicContentJsModuleIncludeDescriptor(this), 
                    new FormsJsModuleIncludeDescriptor(this),
                    new JsIncludeDescriptor(this, "bcms.grid"), 
                    new HtmlEditorJsModuleIncludeDescriptor(this),                     
                    new InlineEditorJsModuleIncludeDescriptor(this),
                    new JsIncludeDescriptor(this, "bcms.jquery", "bcms.jquery-1.7.2"),
                    new JsIncludeDescriptor(this, "bcms.jqueryui", "bcms.jquery-ui-1.9.0"),
                    new JsIncludeDescriptor(this, "bcms.jquery.unobtrusive", "bcms.jquery.unobtrusive-ajax"),
                    new JsIncludeDescriptor(this, "bcms.jquery.validate"),
                    new JsIncludeDescriptor(this, "bcms.jquery.validate.unobtrusive"),
                    new JsIncludeDescriptor(this, "bcms.jquery.autocomplete"),
                    new JsIncludeDescriptor(this, "bcms.autocomplete"),
                    new JsIncludeDescriptor(this, "bcms"), 
                    new KnockoutExtendersJsModuleIncludeDescriptor(this), 
                    new JsIncludeDescriptor(this, "bcms.ko.grid"),                    
                    new SecurityJsModuleIncludeDescriptor(this), 
                    new MessagesJsModuleIncludeDescriptor(this), 
                    new ModalJsModuleIncludeDescriptor(this), 
                    new PreviewJsModuleIncludeDescriptor(this), 
                    new RedirectJsModuleIncludeDescriptor(this),
                    new SidemenuJsModuleIncludeDescriptor(this),                     
                    siteSettingsJsModuleIncludeDescriptor,
                    new JsIncludeDescriptor(this, "bcms.slides.jquery"),
                    new JsIncludeDescriptor(this, "bcms.spinner.jquery"),
                    new TabsJsModuleIncludeDescriptor(this), 
                    new TooltipJsModuleIncludeDescriptor(this),                    
                    new JsIncludeDescriptor(this,"bcms.processor", isAutoGenerated:true),
                    new JsIncludeDescriptor(this, "knockout", "bcms.knockout-2.2.1.js", "bcms.knockout-2.2.1.min.js"), 
                    new JsIncludeDescriptor(this, "ckeditor", "ckeditor/ckeditor.js", "ckeditor/ckeditor.js"),
                    tagsJsModuleIncludeDescriptor,
                    new OptionsJsModuleIncludeDescriptor(this)
                };
        }

        public override IEnumerable<IPageActionProjection> RegisterSidebarHeaderProjections(ContainerBuilder containerBuilder)
        {
            return new IPageActionProjection[]
                {
                    new ButtonActionProjection(authenticationJsModuleIncludeDescriptor, () => RootGlobalization.Sidebar_LogoutButton, page => "logout")
                        {
                            Order = 10,
                            CssClass = page => "bcms-logout-btn",
                        },
                    new RenderActionProjection<AuthenticationController>(f => f.Info())
                };
        }

        public override IEnumerable<IPageActionProjection> RegisterSidebarMainProjections(ContainerBuilder containerBuilder)
        {
            return new IPageActionProjection[]
                {                    
                    new ButtonActionProjection(siteSettingsJsModuleIncludeDescriptor, page => "openSiteSettings")
                        {
                            Title = () => RootGlobalization.Sidebar_SiteSettingsButtonTitle,
                            CssClass = page => "bcms-sidemenu-btn bcms-btn-settings",
                            Order = 500,
                        }
                };
        }

        /// <summary>
        /// Registers the site settings projections.
        /// </summary>
        /// <param name="containerBuilder">The container builder.</param>
        /// <returns>Settings action projections.</returns>
        public override IEnumerable<IPageActionProjection> RegisterSiteSettingsProjections(ContainerBuilder containerBuilder)
        {
            return new IPageActionProjection[]
                {
                    new LinkActionProjection(tagsJsModuleIncludeDescriptor, page => "loadSiteSettingsCategoryList")
                        {
                            Order = 2000,
                            Title = () => RootGlobalization.SiteSettings_CategoriesMenuItem,
                            CssClass = page => "bcms-sidebar-link",
                            AccessRole = RootModuleConstants.UserRoles.EditContent
                        },
                   new LinkActionProjection(tagsJsModuleIncludeDescriptor, page => "loadSiteSettingsTagList")
                        {
                            Order = 2100,
                            Title = () => RootGlobalization.SiteSettings_TagsMenuItem,
                            CssClass = page => "bcms-sidebar-link",
                            AccessRole = RootModuleConstants.UserRoles.EditContent
                        }

                };
        }

        /// <summary>
        /// Creates the resource routes for 6 levels folder structure.
        /// </summary>
        /// <param name="context">The context.</param>
        private void CreateEmbeddedResourcesRoutes(ModuleRegistrationContext context)
        {
            string[] urls = new[]
                {
                    "file/{area}/{file}.{resourceType}/{*all}",
                    "file/{area}/{folder1}/{file}.{resourceType}/{*all}",
                    "file/{area}/{folder1}/{folder2}/{file}.{resourceType}/{*all}",
                    "file/{area}/{folder1}/{folder2}/{folder3}/{file}.{resourceType}/{*all}",
                    "file/{area}/{folder1}/{folder2}/{folder3}/{folder4}/{file}.{resourceType}/{*all}",
                    "file/{area}/{folder1}/{folder2}/{folder3}/{folder4}/{folder5}/{file}.{resourceType}/{*all}",
                    "file/{area}/{folder1}/{folder2}/{folder3}/{folder4}/{folder5}/{folder6}/{file}.{resourceType}/{*all}"
                };

            int i = 0;
            foreach (var url in urls)
            {
                context.MapRoute(
                    AreaName + "-level" + i++,
                    url,
                    new
                    {
                        controller = "EmbeddedResources",
                        action = "Index"
                    },
                    new
                    {
                        resourceType = new MimeTypeRouteConstraint()
                    },
                    new[] { typeof(EmbeddedResourcesController).Namespace });
            }
        }

        private void InitializeSecurity()
        {
            if (Configuration.Security.AccessControlEnabled)
            {
                CoreEvents.Instance.EntitySaving += OnEntityUpdate;
                CoreEvents.Instance.EntityDeleting += OnEntityUpdate;
            }
        }

        private void OnEntityUpdate(SingleItemEventArgs<IEntity> args)
        {
            if (Configuration.Security.AccessControlEnabled && 
                args.Item.Id != Guid.Empty && args.Item is IAccessSecuredObject)
            {
                try
                {
                    using (var container = ContextScopeProvider.CreateChildContainer())
                    {
                        var unitOfWork = container.Resolve<IUnitOfWork>();
                        var securedObject = unitOfWork.Session.Get(args.Item.GetType(), args.Item.Id);

                        var accessControlService = container.Resolve<IAccessControlService>();
                        var securityService = container.Resolve<ISecurityService>();

                        var principal = securityService.GetCurrentPrincipal();

                        if (accessControlService.GetAccessLevel((IAccessSecuredObject)securedObject, principal) != AccessLevel.ReadWrite)
                        {
                            throw new ValidationException(
                                () => string.Format(RootGlobalization.Validation_CurrentUserHasNoRightsToUpdateOrDelete_Message, principal.Identity.Name),
                                string.Format("Current user {0} has no rights to update or delete secured object {1}.", principal.Identity.Name, args.Item));
                        }
                    }
                }
                catch (ValidationException)
                {
                    throw;
                }
                catch (Exception ex)
                {                    
                    throw new CmsException(string.Format("Failed to check an access level of current user for the record {0}.", args.Item), ex);
                }
            }
        }
    }
}
