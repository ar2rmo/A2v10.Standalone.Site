using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using A2v10.Data;
using A2v10.Data.Interfaces;
using A2v10.Infrastructure;
using A2v10.Request;
using A2v10.Web.Config;

namespace A2v10.Standalone.Site
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			ServiceLocator.Start = (locator) =>
			{
				IProfiler profiler = new WebProfiler();
				IApplicationHost host = new WebApplicationHost(profiler);
				ILocalizer localizer = new WebLocalizer(host);
				IDbContext dbContext = new SqlDbContext(
					profiler as IDataProfiler,
					host as IDataConfiguration,
					localizer as IDataLocalizer,
					host as ITenantManager);
				IDataScripter scripter = new VueDataScripter();
				ILogger logger = new WebLogger(host, dbContext);

				locator.RegisterService<IDbContext>(dbContext);
				locator.RegisterService<IProfiler>(profiler);
				locator.RegisterService<IApplicationHost>(host);
				locator.RegisterService<ILocalizer>(localizer);
				locator.RegisterService<IDataScripter>(scripter);
				locator.RegisterService<ILogger>(logger);

				HttpContext.Current.Items.Add("ServiceLocator", locator);
			};

			ServiceLocator.GetCurrentLocator = () =>
			{
				var locator = HttpContext.Current.Items["ServiceLocator"];
				if (locator == null)
					new ServiceLocator();
				return HttpContext.Current.Items["ServiceLocator"] as IServiceLocator;
			};
		}
	}
}
