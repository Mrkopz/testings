using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOptimizer
{
    public static class Helper
    {
        private const double EARTH_RADIUS_KM = 6378.137;
        private const double DegToRadians = Math.PI / 180;

        public static double CalculateDistance(
            double fromLat, double fromLng,
            double toLat, double toLng)
        {
            var rLat1 = fromLat * DegToRadians;
            var rLat2 = toLat * DegToRadians;
            var rLon1 = fromLng * DegToRadians;
            var rLon2 = toLng * DegToRadians;

            var distance = EARTH_RADIUS_KM *
                Math.Acos
                (
                    Math.Sin(rLat1) * Math.Sin(rLat2)
                    + Math.Cos(rLat1) * Math.Cos(rLat2)
                    * Math.Cos(rLon2 - rLon1)
                );

            if (double.IsNaN(distance)) return 0;
            else return Math.Round(distance, 3);
        }
    }
}
