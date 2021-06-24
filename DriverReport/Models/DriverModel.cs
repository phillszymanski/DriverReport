using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverReport.Models
{
    public class DriverModel
    {
        public DriverModel(string driverName, int miles, double speed)
        {
            DriverName = driverName;
            Miles = miles;
            Speed = speed;
        }

        public string DriverName { get; set; }
        public int Miles { get; set; }
        public double Speed { get; set; }
    }
}
