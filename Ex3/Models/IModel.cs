﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
	public interface IModel
	{
		Location XY { get; }
		int NumberOfPoints { get; set; }
	}
}
