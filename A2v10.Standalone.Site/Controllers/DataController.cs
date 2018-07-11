using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A2v10.Standalone.Site.Controllers
{
    public class DataController : Controller
    {
		public DataController()
		{

		}

		// GET: Data
		[HttpGet]
		public ActionResult Default(String pathInfo)
        {
            return new EmptyResult();
        }

		[HttpPost]
		public ActionResult Model(String pathInfo)
		{
			return new EmptyResult();
		}
    }
}