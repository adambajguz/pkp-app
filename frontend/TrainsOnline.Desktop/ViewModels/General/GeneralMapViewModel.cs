namespace TrainsOnline.Desktop.ViewModels.General
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Events;
    using TrainsOnline.Desktop.Helpers;
    using TrainsOnline.Desktop.Views.Example;
    using Windows.Devices.Geolocation;

    public class GeneralMapViewModel : Screen, IHandle<ShowOnMapEvent>, IHandle<ShowRouteOnMapEvent>
    {
        private IEventAggregator Events { get; }

        // TODO WTS: Set your preferred default zoom level
        private const double DefaultZoomLevel = 17;

        // TODO WTS: Set your preferred default location if a geolock can't be found.
        private readonly BasicGeoposition _defaultPosition = new BasicGeoposition()
        {
            Latitude = 47.609425,
            Longitude = -122.3417
        };

        private double _zoomLevel;

        public double ZoomLevel
        {
            get => _zoomLevel;
            set => Set(ref _zoomLevel, value);
        }

        private Geopoint _center;

        public Geopoint Center
        {
            get => _center;
            set => Set(ref _center, value);
        }

        private string _mapServiceToken;

        public string MapServiceToken
        {
            get => _mapServiceToken;
            get => _mapServiceToken;
            set => Set(ref _mapServiceToken, value);
        }

        public GeneralMapViewModel(IEventAggregator events)
        {
            Events = events;
            Events.Subscribe(this);

            Center = new Geopoint(_defaultPosition);
            ZoomLevel = DefaultZoomLevel;
        }

        void IHandle<ShowOnMapEvent>.Handle(ShowOnMapEvent message)
        {

        }

        void IHandle<ShowRouteOnMapEvent>.Handle(ShowRouteOnMapEvent message)
        {

        }

        protected override void OnInitialize()
        {
            base.OnInitialize();


            Center = new Geopoint(_defaultPosition);

            // TODO WTS: Set your map service token. If you don't have one, request from https://www.bingmapsportal.com/
            MapServiceToken = "ioTqhTtWjH1AHQSTdqM3~cwrvRdJBaUYH_uufKdr50g~Au3dHttbUXjJxBL8I9fV6ItiDau37iX6PKfggfU9nq2VgR8IsSoOVYICu88E93in"; //TODO: add to some sort of config
            IExampleMapView view = GetView() as IExampleMapView;

            view?.AddMapIcon(Center, "Map_YourLocation".GetLocalized());
        }
    }
}
