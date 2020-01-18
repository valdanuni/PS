using AutoMapper;
using DbUp;
using DbUp.Engine;
using PS.Mapping.Profiles;
using PS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupDatabase();
            ConfigurationAutoMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void SetupDatabase()
        {
            EnsureDatabase.For.SqlDatabase(DataContext.GetDatabaseConnectionString());
            UpgradeEngine dbUpgradeEngine = DeployChanges.To.SqlDatabase(DataContext.GetDatabaseConnectionString())
                                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                        .LogToConsole()
                                        .Build();

            DatabaseUpgradeResult dbUpgradeResult = dbUpgradeEngine.PerformUpgrade();
            if (!dbUpgradeResult.Successful)
            {
                throw new ApplicationException("Database setup failed", dbUpgradeResult.Error);
            }
        }
        private static void ConfigurationAutoMapper()
        {
#pragma warning disable CS0618 // We want to use the static way, not dependency injection
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<ApplicationMappingProfile>();
            });
#pragma warning restore CS0618
        }
    }
}
