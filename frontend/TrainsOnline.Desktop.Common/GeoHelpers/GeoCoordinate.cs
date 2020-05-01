namespace TrainsOnline.Desktop.Common.GeoHelpers
{
    using System;

    public class GeoCoordinate
    {
        public GeoAngle Latitude { get; }
        public GeoAngle Longitude { get; }

        public GeoCoordinate(GeoAngle latitude, GeoAngle longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static GeoCoordinate FromDouble(double latitude, double longitude)
        {
            GeoAngle lat = GeoAngle.FromDouble(latitude);
            GeoAngle lon = GeoAngle.FromDouble(longitude);

            return new GeoCoordinate(lat, lon);
        }

        public GeoAngle GetPart(GeoCoordinatePart type)
        {
            switch (type)
            {
                case GeoCoordinatePart.Latitude:
                    return Latitude;

                case GeoCoordinatePart.Longitude:
                    return Longitude;

                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return ToString(GeoCoordinatePart.Latitude) + "; " + ToString(GeoCoordinatePart.Longitude);
        }      
        
        public string ToString(string separator)
        {
            return ToString(GeoCoordinatePart.Latitude) + separator + ToString(GeoCoordinatePart.Longitude);
        }

        public string ToString(GeoCoordinatePart type)
        {
            switch (type)
            {
                case GeoCoordinatePart.Latitude:
                    return string.Format("{0}° {1:00}' {2:00}\".{3:000} {4}",
                                         Latitude.Degrees,
                                         Latitude.Minutes,
                                         Latitude.Seconds,
                                         Latitude.Milliseconds,
                                         Latitude.IsNegative ? 'N' : 'S');

                case GeoCoordinatePart.Longitude:
                    return string.Format("{0}° {1:00}' {2:00}\".{3:000} {4}",
                                         Longitude.Degrees,
                                         Longitude.Minutes,
                                         Longitude.Seconds,
                                         Longitude.Milliseconds,
                                         Longitude.IsNegative ? 'W' : 'E');

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
