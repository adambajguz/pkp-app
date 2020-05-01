namespace TrainsOnline.Desktop.ViewModels.Station
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Views.Route;
    using static TrainsOnline.Desktop.Domain.DTO.Station.GetStationsListResponse;

    public class StationMasterDetailDetailViewModel : Screen, IStationMasterDetailDetailView
    {
        public StationMasterDetailDetailViewModel(StationLookupModel item)
        {
            Item = item;
        }

        public StationLookupModel Item { get; }
        public GetStationDetailsResponse Details { get; set; }

        public void ShowStationOnMap()
        {

        }

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
