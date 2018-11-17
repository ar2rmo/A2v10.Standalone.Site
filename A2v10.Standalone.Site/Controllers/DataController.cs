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
		private readonly A2v10.Request.SiteController _siteController;

		public DataController()
		{
			_siteController = new A2v10.Request.SiteController();
			// user id may be needed
			_siteController.UserId = () => 0;
		}

		[HttpPost]
		public async Task Reload()
		{
			await TryCatch(() => _siteController.Data("reload", Request, Response));
		}

		public async Task Save()
		{
			await TryCatch(() => _siteController.Data("save", Request, Response));
		}

		public async Task Invoke()
		{
			await TryCatch(() => _siteController.Data("invoke", Request, Response));
		}

		public Task TryCatch(Func<Task> action)
		{
			try
			{
				return action();
			}
			catch (Exception ex)
			{
				_siteController.WriteExceptionStatus(ex, Response);
			}
			return null;
		}
	}
}