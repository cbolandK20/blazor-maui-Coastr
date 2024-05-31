using CoastR.Model;

namespace Coastr.Services
{
    public class LocationUtils
    {
        public static GeoPosition ToPosition(Location source)
        {
            return new GeoPosition() { Latitude = source.Latitude, Longitude = source.Longitude, Altitude = source.Altitude.Value };
        }

        public static bool IsNear(GeoPosition source, GeoPosition target, int threshold)
        {
            if (source == null || target == null)
            {
                return false;
            }
            var sourceLoc = new Location(source.Latitude, source.Longitude, source.Altitude);
            var targetLoc = new Location(target.Latitude, target.Longitude, target.Altitude);
            return sourceLoc.CalculateDistance(targetLoc, DistanceUnits.Kilometers) <= (threshold / 1000d);
        }
    }
}
