
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
		private IClient flightSimulatorClient;

		// data manager for getting lan lot.
		private DataManager dataManager;

		public DisplayLocationModel(string ip, int port)
		{
			IClient flightSimulatorClient = new RequestResponeClient();
			flightSimulatorClient.IpAndPort = new IPEndPoint(IPAddress.Parse(ip), port);
			dataManager = new DataManager(flightSimulatorClient);

		}


		private IPEndPoint IPEndPoint()
		{
			throw new NotImplementedException();
		}

		public virtual double X
		{
			get
			{
				return dataManager.getFlightAttribute("position/longitude-deg");
			}
		}

		public virtual double Y
		{
			get
			{
				return dataManager.getFlightAttribute("position/latitude-deg");
			}
		}
	}
}