using Autofac;
using Autofac.Integration.Mvc;
using MvcSiteMapProvider.Loader;
using RunShawn.Core.Features.News.News.Repositories;
using RunShawn.Core.Features.Pages.Repositories;
using RunShawn.Core.Features.Pages.Services;
using RunShawn.Core.Features.Roles.Repositories;
using RunShawn.Core.Features.Roles.Services;
using RunShawn.Core.Features.Users.Repositories;
using RunShawn.Web.DI.Autofac.Modules;
using System.Web.Mvc;

namespace RunShawn.Web.App_Start
{
    public static class AutofacConfig
    {
        #region InitInjection()

        public static void InitInjection()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new MvcSiteMapProviderModule());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            RegisterDepenecies(builder);
            SetUpReSetResolversor(builder);
        }

        #endregion InitInjection()

        #region RegisterDepenecies()

        private static void RegisterDepenecies(ContainerBuilder builder)
        {
            builder.RegisterType<UsersRepository>().As<IUsersRepository>();
            builder.RegisterType<ArticlesRepository>().As<IArticlesRepository>();
            builder.RegisterType<PermissionsRepository>().As<IPermissionsRepository>();
            builder.RegisterType<RolesRepository>().As<IRolesRepository>();
            builder.RegisterType<RolesService>().As<IRolesService>();
            builder.RegisterType<PageService>().As<IPagesService>();
            builder.RegisterType<PagesRepository>().As<IPagesRepository>();

            #region Tools
            builder.RegisterInstance(AutoMapperConfiguration.GetConfig());
            #endregion
        }

        #endregion RegisterDepenecies()

        #region SetUpReSetResolversor()

        private static void SetUpReSetResolversor(ContainerBuilder builder)
        {
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            MvcSiteMapProvider.SiteMaps.Loader = container.Resolve<ISiteMapLoader>();
        }

        #endregion SetUpReSetResolversor()
    }
}