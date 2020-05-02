namespace TrainsOnline.Desktop.Views.Route
{
    internal interface IStationMasterDetailDetailView
    {
        void ShowStationOnMap();
        void ShowDestinationOnMap(RouteDeparturesLookupModel stationDetails);
        void ShowRouteOnMap(RouteDeparturesLookupModel stationDetails);
        void BuyTicket(RouteDeparturesLookupModel stationDetails);
    }
}
