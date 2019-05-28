using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ex3.Models
{
	public class SaveFlightModel : DisplayLocationModel
	{

		static private string pathToAppData;

		private XmlSerializer serializer;

		private string fileName;

		public SaveFlightModel(string ip, int port, string flightName) : base(ip, port)
		{
			serializer = new XmlSerializer(typeof(FlightInfo));
			fileName = flightName;
			pathToAppData = Path.Combine(getProjectDirectoryPath(), "App_Data");
		}

		public override Location XY
		{
			get
			{
				Location val = base.XY;

				// save to db:
				try
				{
					FlightInfo info = new FlightInfo();
					info.Name = fileName;

					info.FlightBlackBoxMoment = new FlightInfo.FlightPointInfo();
					info.FlightBlackBoxMoment.Lon = val.X;
					info.FlightBlackBoxMoment.Lat = val.Y;
					info.FlightBlackBoxMoment.Rudder = 0;
					info.FlightBlackBoxMoment.Throttle = 0;

					using (TextWriter writer = File.AppendText(Path.Combine(pathToAppData, fileName)))
					{
						serializer.Serialize(writer, info);
					}
				}
				catch
				{
					Console.WriteLine("failed to serialize file for flight {0}", fileName);
				}

				return val;
			}
		}

		public string getProjectDirectoryPath()
		{
			//Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "App_Data");
			return "C:\\Users\\omrif\\Documents\\Bar Ilan CS\\2019_half2\\advnce2\\Ex3\\ex3-code\\Ex3\\App_Data";
		}

	}


}