namespace TrainsOnline.Desktop.Views.Route
{
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Domain.DTO.Route;

    internal interface IRouteDataGridView
    {
        void ShowDestinationOnMap(GetRouteDetailsResponse route);
        void ShowRouteOnMap(GetRouteDetailsResponse route);
        void DeleteRoute(GetRouteDetailsResponse route);
        void EditRoute(GetRouteDetailsResponse route);
        void BuyTicket(GetRouteDetailsResponse route);
        void LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e);
    }
}
