namespace TrainsOnline.Desktop.Views.Route
{
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Domain.ValueObjects.RouteComponents;

    internal interface IRouteDataGridViewEvents
    {
        void ShowDepartureOnMap(RouteDetailsValueObject route);
        void ShowDestinationOnMap(RouteDetailsValueObject route);
        void ShowRouteOnMap(RouteDetailsValueObject route);
        void DeleteRoute(RouteDetailsValueObject route);
        void EditRoute(RouteDetailsValueObject route);
        void BuyTicket(RouteDetailsValueObject route);

        void LoadingRowGroup(DataGridRowGroupHeaderEventArgs e);
    }
}
