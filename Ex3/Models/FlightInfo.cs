using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
	public class FlightInfo
	{
		public class FlightPointInfo
		{

			public double Lon { get; set; }

			public double Lat { get; set; }

			public double Throttle { get; set; }

			public double Rudder { get; set; }
		}


		[Required]
		// flight name to save/load from:
		public string Name { get; set; }

		// flight List of info points.
		public List<FlightPointInfo> FlightBlackBox { get; set; }
	}

}