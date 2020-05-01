namespace TrainsOnline.Desktop.Views.Route
{
    using TrainsOnline.Desktop.Domain.Route;

    internal interface IRouteDataGridView
    {
        void DeleteRoute(GetRouteDetailsResponse user);
        void EditRoute(GetRouteDetailsResponse user);
        void BuyTicket(GetRouteDetailsResponse user);
    }
}
