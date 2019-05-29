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
		private FlightInfo info;

		public SaveFlightModel(string ip, int port, string flightName) : base(ip, port)
		{
			serializer = new XmlSerializer(typeof(FlightInfo));
			fileName = flightName;	
			pathToAppData = Path.Combine(getProjectDirectoryPath(), "App_Data");

			info = new FlightInfo();
			info.Name = fileName;
			info.FlightBlackBox = new List<FlightInfo.FlightPointInfo>();

		}

		public override Location XY
		{
			get
			{
				Location val = base.XY;

				// add to info new point of x,y.
				
				FlightInfo.FlightPointInfo point = new FlightInfo.FlightPointInfo();
				point.Lon = val.X;
				point.Lat = val.Y;
				point.Rudder = 0;
				point.Throttle = 0;

				info.FlightBlackBox.Add(point);

				// save current list to db (don't know when we should stop).
				using (TextWriter writer = File.CreateText(Path.Combine(pathToAppData, fileName)))
				{
					serializer.Serialize(writer, info);
				}

				return val;
			}
		}

		public string getProjectDirectoryPath()
		{
			//Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "App_Data");
			return "C:\\Users\\omrif\\Documents\\Bar Ilan CS\\2019_half2\\advnce2\\Ex3\\ex3-code\\Ex3";
		}

	}


}