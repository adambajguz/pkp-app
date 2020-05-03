namespace TrainsOnline.Desktop.ViewModels.Route
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Common.GeoHelpers;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.Models.General;
    using TrainsOnline.Desktop.Domain.ValueObjects.RouteComponents;
    using TrainsOnline.Desktop.ViewModels.General;
    using TrainsOnline.Desktop.ViewModels.User;
    using TrainsOnline.Desktop.Views.Route;
    using Windows.UI.Xaml.Data;
    using static TrainsOnline.Desktop.Domain.DTO.Route.GetRoutesListResponse;

    public class RouteDataGridViewModel : Screen, IRouteDataGridViewEvents
    {
        private INavigationService NavService { get; }
        private IRemoteDataProviderService RemoteDataProvider { get; }

        public ObservableCollection<GroupInfoCollection<GetRouteDetailsResponse>> Source { get; } = new ObservableCollection<GroupInfoCollection<GetRouteDetailsResponse>>();
        public CollectionViewSource GroupedSource { get; } = new CollectionViewSource();

        public RouteDataGridViewModel(INavigationService navigationService,
                                      IRemoteDataProviderService remoteDataProvider)
        {
            NavService = navigationService;
            RemoteDataProvider = remoteDataProvider;
        }

        public async Task LoadDataAsync()
        {
            GetRoutesListResponse data = await RemoteDataProvider.GetRoutes();

            //foreach (RouteLookupModel route in data.Routes)
            //{
            //    GetRouteDetailsResponse details = await RemoteDataProvider.GetRoute(route.Id);

            //    Source.Add(info);
            //}

            await LoadDataAsync(data);
        }

        private async Task LoadDataAsync(GetRoutesListResponse data)
        {
            Source.Clear();

            var query = from item in data.Routes
                        group item by item.From.Id.ToString() into g
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupInfoCollection<GetRouteDetailsResponse> info = new GroupInfoCollection<GetRouteDetailsResponse>
                {
                    Key = g.GroupName
                };

                foreach (RouteLookupModel item in g.Items)
                {
                    GetRouteDetailsResponse details = await RemoteDataProvider.GetRoute(item.Id);
                    info.Add(details);
                }

                Source.Add(info);
            }

            GroupedSource.IsSourceGrouped = true;
            GroupedSource.Source = Source;
        }

        public void ShowDepartureOnMap(GetRouteDetailsResponse route)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(route.From.Latitude, route.From.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void ShowDestinationOnMap(GetRouteDetailsResponse route)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(route.To.Latitude, route.To.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void ShowRouteOnMap(GetRouteDetailsResponse route)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(route.From.Latitude, route.From.Longitude),
                new GeoCoordinate(route.To.Latitude, route.To.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void DeleteRoute(GetRouteDetailsResponse route)
        {

        }

        public void EditRoute(GetRouteDetailsResponse route)
        {

        }

        public async void BuyTicket(GetRouteDetailsResponse route)
        {
            if (!RemoteDataProvider.IsAuthenticated)
            {
                NavService.NavigateToViewModel<LoginRegisterViewModel>();
                return;
            }

            await RemoteDataProvider.CreateTicketForCurrentUser(route.Id);
        }

        public void LoadingRowGroup(DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            RouteDetailsValueObject item = group.GroupItems[0] as RouteDetailsValueObject;
            e.RowGroupHeader.PropertyValue = item?.From?.Name;
        }

        public async void Search()
        {
           await LoadDataAsync();
        }

        public async void ResetView()
        {
            await LoadDataAsync();
        }
    }
}
