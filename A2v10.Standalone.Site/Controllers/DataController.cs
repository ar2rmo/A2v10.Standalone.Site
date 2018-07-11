using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2v10.Standalone.Site.Controllers
{
	public class DataController : Controller
	{
		A2v10.Request.BaseController _baseController;

		public DataController()
		{
			_baseController = new A2v10.Request.BaseController();
		}

		// GET: Data
		[HttpPost]
		public void Load(String pathInfo)
		{
			_baseController.StandaloneLoadData(Request, Response, pathInfo);
		}
	}
}