using Ex3.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
	public class DataManager
	{
		IClient flightSimulatorClient;

		public DataManager(IClient client)
		{
			flightSimulatorClient = client;
		}

		/**
		 * getting attribute value from simulator server.
		 */

		public double GetFlightAttribute(string attributeName)
		{

			string getline = flightSimulatorClient.Request("get " + attributeName + "\r\n");

			// the format it return from server: position/longitude-deg = '-157.9104004' (double)
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