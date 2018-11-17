using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace A2v10.Standalone.Site.Controllers
{
	public class ModelController : Controller
	{
		A2v10.Request.StandaloneController _baseController;

		public ModelController()
		{
			_baseController = new A2v10.Request.StandaloneController();
		}

		public ActionResult Index(String pathInfo)
		{
			throw new NotImplementedException();
		}

		[HttpGet]
		public async Task Load(String pathInfo)
		{
			//await _baseController.LoadModel(Response, pathInfo, 0);
		}
	}
}