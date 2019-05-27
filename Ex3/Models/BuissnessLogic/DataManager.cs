using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
	public class DataManager
	{
		RequestResponeClient flightSimulatorClient;

		public DataManager()
		{
			flightSimulatorClient = new RequestResponeClient();
		}

		double Lon
		{
			get
			{
				var getline = flightSimulatorClient.Request("get /position/longitude-deg\r\n");
				//position/longitude-deg = '-157.9104004' (double)
				try
				{
					string val = getline.Split('=')[1].Split('\'')[1];
					return Double.Parse(val);
				}

				catch
				{
					Console.WriteLine("Exception in command channel: {0}", getline);
					return 0;
				}
			}	

		}

		double Lat
		{
			get
			{
				var getline = flightSimulatorClient.Request("get /position/latitude-deg\r\n");
				//position/longitude-deg = '-157.9104004' (double)
				try
				{
					string val = getline.Split('=')[1].Split('\'')[1];
					return Double.Parse(val);
				}

				catch
				{
					Console.WriteLine("Exception in command channel: {0}", getline);
					return 0;
				}
			}

		}


	}
}