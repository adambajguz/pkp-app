namespace TrainsOnline.Desktop.Application.Events
{
    public class ShowOnMapEvent
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public ShowOnMapEvent(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
