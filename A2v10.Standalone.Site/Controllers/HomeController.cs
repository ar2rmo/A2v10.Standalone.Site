using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2v10.Standalone.Site.Controllers
{
	public class HomeController : Controller
	{
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

		public ActionResult Test()
		{
			ViewBag.Message = "Your Test Page";

			String path = Server.MapPath("~/App_Data/Home/test.js");
			String script = System.IO.File.ReadAllText(path);
			ViewBag.Script = script;
			return View();
		}
	}
};