namespace TrainsOnline.Desktop.ViewModels.Station
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Common.GeoHelpers;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Domain.Models.General;
    using TrainsOnline.Desktop.ViewModels.General;
    using TrainsOnline.Desktop.Views.Route;
    using static TrainsOnline.Desktop.Domain.DTO.Station.GetStationDetailsResponse;
    using static TrainsOnline.Desktop.Domain.DTO.Station.GetStationsListResponse;

    public class StationMasterDetailDetailViewModel : Screen, IStationMasterDetailDetailView
    {
        private INavigationService NavService { get; }

        public StationMasterDetailDetailViewModel(INavigationService navigationService, StationLookupModel item)
        {
            NavService = navigationService;
            Item = item;
        }

        public StationLookupModel Item { get; }
        public GetStationDetailsResponse Details { get; set; }

        public void ShowStationOnMap()
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(Details.Latitude, Details.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void ShowDestinationOnMap(RouteDeparturesLookupModel stationDetails)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(stationDetails.To.Latitude, stationDetails.To.Longitude),
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void ShowRouteOnMap(RouteDeparturesLookupModel stationDetails)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(Details.Latitude, Details.Longitude),
                new GeoCoordinate(stationDetails.To.Latitude, stationDetails.To.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void BuyTicket(RouteDeparturesLookupModel stationDetails)
        {

        }
    }
}
