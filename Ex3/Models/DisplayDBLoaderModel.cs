using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Ex3.Models
{
	public class DisplayDBLoaderModel : IModel
	{

		private int index = 0;
		private FlightInfo flightInfo;

		public DisplayDBLoaderModel(string flightName)
		{
			// load data base of flightName into member or something.
			string pathToAppData = Path.Combine(getProjectDirectoryPath(), "App_Data");
			XmlSerializer unserializer = new XmlSerializer(typeof(FlightInfo));
			using (XmlReader reader = XmlReader.Create(Path.Combine(pathToAppData, flightName)))
			{
				flightInfo = (FlightInfo)unserializer.Deserialize(reader);
			}
			index = 0;
		}

		public Location XY
		{
			// get from database:
			get
			{
				Location loc = new Location();
				FlightInfo.FlightPointInfo point = flightInfo.FlightBlackBox[index];
				loc.X = point.Lon;
				loc.Y = point.Lat;
				index++;

				return loc;
				
			}
		}
		public string getProjectDirectoryPath()
		{
			//Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "App_Data");
			return "C:\\Users\\omrif\\Documents\\Bar Ilan CS\\2019_half2\\advnce2\\Ex3\\ex3-code\\Ex3";
		}
	}
}