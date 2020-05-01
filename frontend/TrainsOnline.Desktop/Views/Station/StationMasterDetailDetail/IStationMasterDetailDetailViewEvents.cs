namespace TrainsOnline.Desktop.Views.Route
{
    using TrainsOnline.Desktop.Domain.DTO.Station;

    internal interface IStationMasterDetailDetailView
    {
        void ShowStationOnMap();
        void ShowDestinationOnMap(GetStationDetailsResponse stationDetails);
        void ShowRouteOnMap(GetStationDetailsResponse stationDetails);
        void BuyTicket(GetStationDetailsResponse stationDetails);
    }
}
