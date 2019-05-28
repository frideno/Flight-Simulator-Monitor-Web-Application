using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
	public class SaveFlightModel : DisplayLocationModel
	{
		public SaveFlightModel(string ip, int port, string flightName) : base(ip, port)
		{
			// open new database set for that flightName, and save a reffrence to it as a member.
		}

		public override double X
		{
			get
			{
				double val = base.X;
				// save to database.
				return val;

			}
		}
		public override double Y
		{
			get
			{
				double val = base.Y;
				// save to database.
				return val;
			}
		}
	}

	
}