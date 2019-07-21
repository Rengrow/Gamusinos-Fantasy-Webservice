using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamusinosProject.Model
{
    public class Coordinate
    {
        public double Latitude { set; get; }
        public double Longitude { set; get; }

        public Coordinate(double Latitude, double Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

        public Coordinate()
        {
        }
    }
}
