using doLittle.Concepts;

namespace Concepts
{
    public class Location : Value<Location>
    {
        public static readonly Location NotSet;
        static Location()
        {
            NotSet = new Location(-1d, -1d);
        }
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
