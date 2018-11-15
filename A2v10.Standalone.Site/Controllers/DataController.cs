using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace A2v10.Standalone.Site.Controllers
{
	public class DataController : Controller
	{
		A2v10.Request.StandaloneController _baseController;

		public DataController()
		{
			_baseController = new A2v10.Request.StandaloneController();
		}

		[HttpPost]
		public async Task Load()
		{
			await _baseController.LoadData(Request, Response);
		}

		public async Task Save()
		{
			await _baseController.SaveData(Request, Response, 0);
		}

		public async Task Invoke()
		{
			//await _baseController.Invoke(Request, Response);
		}
	}
}