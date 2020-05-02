namespace TrainsOnline.Desktop.ViewModels.Station
{
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Common.GeoHelpers;
    using TrainsOnline.Desktop.Domain.Models.General;
    using TrainsOnline.Desktop.Domain.ValueObjects.StationComponents;
    using TrainsOnline.Desktop.ViewModels.General;
    using TrainsOnline.Desktop.Views.Route;

    public class StationMasterDetailDetailViewModel : Screen, IStationMasterDetailDetailView
    {
        private INavigationService NavService { get; }
        private IRemoteDataProviderService RemoteDataProvider { get; }

        public StationMasterDetailDetailViewModel(INavigationService navigationService,
                                                  IRemoteDataProviderService remoteDataProvider,
                                                  StationLookupModel item)
        {
            NavService = navigationService;
            RemoteDataProvider = remoteDataProvider;
            Item = item;
        }

        private StationLookupModel _item;
        public StationLookupModel Item
        {
            get => _item;
            set => Set(ref _item, value);
        }

        private StationDetailsValueObject _details;
        public StationDetailsValueObject Details
        {
            get => _details;
            set => Set(ref _details, value);
        }

        public async Task LoadDetails()
        {
            StationDetailsValueObject data = await RemoteDataProvider.GetStation(Item.Id);
            Details = data;
            //Refresh();
        }

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
