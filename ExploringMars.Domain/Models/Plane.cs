using ExploringMars.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExploringMars.Domain.Models
{
	public sealed class Plane
	{
        public Plane()
        {
            Min = new Point(0, 0);
            Probes = new List<Probe>();
        }

		public Point Max { get; set; }
        public Point Min { get; set; }
        public List<Probe> Probes { get; set; }
    }
}
