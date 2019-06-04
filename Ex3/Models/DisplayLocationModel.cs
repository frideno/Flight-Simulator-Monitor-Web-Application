
using Ex3.Models;
using Ex3.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Ex3.Models
{
	public class DisplayLocationModel: IModel
	{
		// simulator client for get and set requests.
		// data manager for getting lan lot.
		protected DataManager dataManager1;
		protected DataManager dataManager2;

		public DisplayLocationModel(string ip, int port)
		{
			try
			{
				IClient flightSimulatorClient1 = new RequestResponeClient();
				IClient flightSimulatorClient2 = new RequestResponeClient();
				flightSimulatorClient1.IpAndPort = new IPEndPoint(IPAddress.Parse(ip), port);
				flightSimulatorClient2.IpAndPort = new IPEndPoint(IPAddress.Parse(ip), port);
				flightSimulatorClient1.Connect();
				flightSimulatorClient2.Connect();
				dataManager1 = new DataManager(flightSimulatorClient1);
				dataManager2 = new DataManager(flightSimulatorClient2);
				NumberOfPoints = 0;
			}
			catch
			{
				Console.WriteLine("Connection Failed on ip: {0}, port: {1}. Try again with different parameters.", ip, port);
				throw;
			}
		}


		private IPEndPoint IPEndPoint()
		{
			throw new NotImplementedException();
		}


		public virtual Location XY
		{
			get
			{
				double x = dataManager1.GetFlightAttribute("position/longitude-deg");
				double y = dataManager2.GetFlightAttribute("position/latitude-deg");
				return new Location { X = x, Y = y };
			}
		}

		public int NumberOfPoints { get; set; }

	}
}