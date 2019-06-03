using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {
		/**
		 * Display page controller method: for parameters ip, port.
		 */
		[HttpGet]
		public ActionResult Display(string ip, int port)
		{
			IModel model = new DisplayLocationModel(ip, port);
			return View("CurrentLocationView", model);
		}

		/**
		 * Display page controller method: for parameters ip, port, frequency.
		 */
		[HttpGet]
		public ActionResult DisplayPath(string ip, int port, double updateFrequency)
		{
			IModel model = new DisplayLocationModel(ip, port);
			ViewBag.UpdateFrequency = updateFrequency;
			ViewBag.Duration = double.MaxValue;
			return View("FlightPathView", model);
		}


		//private FlightInfoContext db = new FlightInfoContext();
		/**
		 * Display flight and saves it to database by parameters.
		 */
		[HttpGet]
		public ActionResult Save(string ip, int port, double updateFrequency, double duration, string flightName)
		{
			IModel model = new SaveFlightModel(ip, port, flightName);
			ViewBag.UpdateFrequency = updateFrequency;
			ViewBag.Duration = duration;
			//return View("CurrentLocationView", model);
			return View("FlightPathView", model);

		}

		/**
		 * Display flight path from database of flightName.
		 */
		[HttpGet]
		public ActionResult DisplayFromDB(string flightName, double updateFrequency)
		{
			IModel model = new DisplayDBLoaderModel(flightName);
			ViewBag.UpdateFrequency = updateFrequency;
			return View("FlightPathView", model);
			//return View("CurrentLocationView", model);
		}
	}
}