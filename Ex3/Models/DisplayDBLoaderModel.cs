using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
	public class DisplayDBLoaderModel : IModel
	{

		// private int state = 0;
		// private XmlSerializer unserializer;

		public DisplayDBLoaderModel(string flightName)
		{
			// load data base of flightName into member or something.
		}

		public Location XY
		{
			// get from database:
			get
			{
				Location loc = new Location();
				loc.X = 0;
				loc.Y = 0;
				return loc;
			}
		}
	}
}