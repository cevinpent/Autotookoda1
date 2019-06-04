using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autotookoda1.Models
{
	public class Volkswagen
	{
		public int id { get; set; }

		public string tellija { get; set; }
		public string auto { get; set; }
		public string viga { get; set; }
		public int parandatud { get; set; } = -1;
		public int tasutud { get; set; } = -1;
	}
}