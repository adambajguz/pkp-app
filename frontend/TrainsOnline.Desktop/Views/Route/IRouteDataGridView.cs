namespace TrainsOnline.Desktop.Views.Route
{
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Domain.Route;
    using Windows.UI.Xaml.Controls;

    internal interface IRouteDataGridView
    {
        void DeleteRoute(GetRouteDetailsResponse user);
        void EditRoute(GetRouteDetailsResponse user);
        void BuyTicket(GetRouteDetailsResponse user);
        void LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e);
    }
}
