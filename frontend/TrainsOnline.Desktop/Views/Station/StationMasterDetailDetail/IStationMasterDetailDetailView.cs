namespace TrainsOnline.Desktop.Views.Route
{
    using TrainsOnline.Desktop.Domain.Station;

    internal interface IStationMasterDetailDetailView
    {
        void ShowDestinationOnMap(GetStationDetailsResponse stationDetails);
        void ShowRouteOnMap(GetStationDetailsResponse stationDetails);
        void BuyTicket(GetStationDetailsResponse stationDetails);
    }
}
