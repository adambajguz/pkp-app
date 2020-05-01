namespace TrainsOnline.Desktop.Views.Route
{
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using static TrainsOnline.Desktop.Domain.DTO.Station.GetStationDetailsResponse;

    internal interface IStationMasterDetailDetailView
    {
        void ShowStationOnMap();
        void ShowDestinationOnMap(RouteDeparturesLookupModel stationDetails);
        void ShowRouteOnMap(RouteDeparturesLookupModel stationDetails);
        void BuyTicket(RouteDeparturesLookupModel stationDetails);
    }
}
