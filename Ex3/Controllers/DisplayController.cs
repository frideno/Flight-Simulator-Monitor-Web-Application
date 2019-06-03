using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;


namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {

		private static IModel Model { get; set; }
		
		/**
		 * Display page controller method: for parameters ip, port.
		 */
		[HttpGet]
		public ActionResult Display(string prm1, int prm2)
		{
			// if the first parameter is an ip, we want to get data from server.
			IPAddress tmpAdress;
			if (IPAddress.TryParse(prm1, out tmpAdress))
			{
				return DisplayFromSimulator(prm1, prm2);
			}
			// else, we would like to get data from database with that file name.
			else
			{
				return DisplayFromDB(prm1, prm2);
			}
		}

		public ActionResult DisplayFromSimulator(string ip, int port)
		{
			try
			{
				Model = new DisplayLocationModel(ip, port);
				ViewBag.UpdateFrequency = 1;
				ViewBag.Duration = 1;
				ViewBag.toAlert = "false";
				return View("FlightPathView");

			}
			catch
			{
				return View("ErrorView");
			}
		}

		/**
		 * Display page controller method: for parameters ip, port, frequency.
		 */
		[HttpGet]
		public ActionResult DisplayPath(string ip, int port, double updateFrequency)
		{
			try
			{
				Model = new DisplayLocationModel(ip, port);
				ViewBag.UpdateFrequency = updateFrequency;
				ViewBag.Duration = 10000;
				ViewBag.toAlert = "false";
				return View("FlightPathView");

			}
			catch
			{
				return View("ErrorView");
			}
		}

		//private FlightInfoContext db = new FlightInfoContext();
		/**
		 * Display flight and saves it to database by parameters.
		 */
		[HttpGet]
		public ActionResult Save(string ip, int port, double updateFrequency, double duration, string flightName)
		{
			try
			{

				Model = new SaveFlightModel(ip, port, flightName);
				ViewBag.UpdateFrequency = updateFrequency;
				ViewBag.Duration = duration;
				Model.NumberOfPoints = (int)(duration * updateFrequency);
				ViewBag.toAlert = "false";

				return View("FlightPathView");
			}
			catch
			{
				return View("ErrorView");
			}
	
		}

		/**
		 * Display flight path from database of flightName.
		 */
		[HttpGet]
		public ActionResult DisplayFromDB(string flightName, double updateFrequency)

		{
			try
			{
				Model = new DisplayDBLoaderModel(flightName);
				ViewBag.UpdateFrequency = updateFrequency;
				ViewBag.Duration = Model.NumberOfPoints / updateFrequency;
				ViewBag.toAlert = "true";
				return View("FlightPathView");
			}
			catch
			{
				return View("ErrorView");
			}
	
		}

		[HttpPost]
		public JObject GetLocation()
		{

			JObject data = new JObject();
			var xy = Model.XY;
			data["x"] = xy.X;
			data["y"] = xy.Y;
			return data;
		}
	}
}