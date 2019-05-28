using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
	public class DisplayDBLoaderModel : IModel
	{
		public DisplayDBLoaderModel(string flightName)
		{
			// load data base of flightName into member or something.
		}

		public double X
		{
			get
			{
				// get from database;
				double val = 0;
				return val;
			}
		}

		public double Y
		{
			get
			{
				// get from database;
				double val = 0;
				return val;
			}
		}
	}
}