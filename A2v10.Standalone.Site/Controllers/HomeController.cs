using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace A2v10.Standalone.Site.Controllers
{
	public class HomeController : Controller
	{
		A2v10.Request.SiteController _siteController = new A2v10.Request.SiteController();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public async Task<ActionResult> Test(String id)
		{
			// {path}/{action}/{id}
			var viewInfo = await _siteController.LoadView($"home/edit/{id}");
			// view from ~/Views.
			// viewInfo.View - view from ~/App_apps
			return View(viewInfo);
		}
	}
};