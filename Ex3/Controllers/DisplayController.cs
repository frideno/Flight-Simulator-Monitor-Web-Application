using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {
		[HttpGet]
		public ActionResult Display(string ip, int port)
		{
			DisplayCurrentPointModel model = new DisplayCurrentPointModel();
			return View("CurrentLocationView", model);
		}
	}
}