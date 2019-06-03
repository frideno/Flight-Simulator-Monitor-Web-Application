
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
		protected IClient flightSimulatorClient;

		// data manager for getting lan lot.
		protected DataManager dataManager;

		public DisplayLocationModel(string ip, int port)
		{
			try
			{
				IClient flightSimulatorClient = new RequestResponeClient();
				flightSimulatorClient.IpAndPort = new IPEndPoint(IPAddress.Parse(ip), port);
				flightSimulatorClient.Connect();
				dataManager = new DataManager(flightSimulatorClient);
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
				Location loc = new Location();
				loc.X = dataManager.getFlightAttribute("position/longitude-deg");
				loc.Y = dataManager.getFlightAttribute("position/latitude-deg");
				return loc;
			}
		}

		public int NumberOfPoints { get; set; }

	}
}