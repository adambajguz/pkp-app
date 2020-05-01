namespace TrainsOnline.Desktop.ViewModels.Route
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.Route;
    using TrainsOnline.Desktop.Views.Route;
    using static TrainsOnline.Desktop.Domain.Route.GetRoutesListResponse;

    public class RouteDataGridViewModel : Screen, IRouteDataGridView
    {
        private GetRouteDetailsResponse _selecteditem;
        public GetRouteDetailsResponse Selecteditem
        {
            get => _selecteditem;
            set
            {
                _selecteditem = value;
                NotifyOfPropertyChange(() => Selecteditem);
            }
        }

        private IRemoteDataProviderService RemoteDataProvider { get; }

        public ObservableCollection<GetRouteDetailsResponse> Source { get; } = new ObservableCollection<GetRouteDetailsResponse>();

        public RouteDataGridViewModel(IRemoteDataProviderService remoteDataProvider)
        {
            RemoteDataProvider = remoteDataProvider;
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            GetRoutesListResponse data = await RemoteDataProvider.GetRoutes();

            foreach (RouteLookupModel route in data.Routes)
            {
                GetRouteDetailsResponse details = await RemoteDataProvider.GetRoute(route.Id);

                Source.Add(details);
            }
        }

        public void DeleteRoute(GetRouteDetailsResponse user)
        {
            // Do work
        }

        public void EditRoute(GetRouteDetailsResponse user)
        {
            // Do work
        }

        public void BuyTicket(GetRouteDetailsResponse user)
        {
            // Do work
        }
    }
}
