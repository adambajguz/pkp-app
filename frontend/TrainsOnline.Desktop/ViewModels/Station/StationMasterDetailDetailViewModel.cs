namespace TrainsOnline.Desktop.ViewModels.Station
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Domain.Station;
    using TrainsOnline.Desktop.Views.Route;

    public class StationMasterDetailDetailViewModel : Screen, IStationMasterDetailDetailView
    {
        public StationMasterDetailDetailViewModel(StationLookupModel item)
        {
            Item = item;
        }

        public StationLookupModel Item { get; }
        public GetStationDetailsResponse Details { get; set; }

        public void ShowDestinationOnMap(GetStationDetailsResponse stationDetails)
        {

        }

        public void ShowRouteOnMap(GetStationDetailsResponse stationDetails)
        {

        }

        public void BuyTicket(GetStationDetailsResponse stationDetails)
        {

        }
    }
}
