namespace TrainsOnline.Desktop.Views.Route
{
    using static TrainsOnline.Desktop.Domain.DTO.Station.GetStationDetailsResponse;

    internal interface IStationMasterDetailDetailView
    {
        void ShowStationOnMap();
        void ShowDestinationOnMap(RouteDeparturesLookupModel stationDetails);
        void ShowRouteOnMap(RouteDeparturesLookupModel stationDetails);
        void BuyTicket(RouteDeparturesLookupModel stationDetails);
    }
}
