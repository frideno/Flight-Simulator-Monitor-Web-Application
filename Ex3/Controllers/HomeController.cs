using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Ex3.Controllers
{
	public class HomeController : Controller
	{

		[HttpGet]
		public ActionResult Index()
		{
			return View("HomeView");

		}

	}
}