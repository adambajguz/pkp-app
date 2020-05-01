namespace TrainsOnline.Desktop.Application.Events
{
    public class ShowRouteOnMapEvent
    {
        public double LatitudeStart { get; }
        public double LongitudeStart { get; }

        public double LatitudeEnd { get; }
        public double LongitudeEnd { get; }

        public ShowRouteOnMapEvent(double latitudeStart, double longitudeStart, double latitudeEnd, double longitudeEnd)
        {
            LatitudeStart = latitudeStart;
            LongitudeStart = longitudeStart;

            LatitudeEnd = latitudeEnd;
            LongitudeEnd = longitudeEnd;
        }
    }
}
