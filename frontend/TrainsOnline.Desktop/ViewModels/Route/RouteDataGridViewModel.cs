namespace TrainsOnline.Desktop.ViewModels.Route
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Common.GeoHelpers;
    using TrainsOnline.Desktop.Domain.Models.General;
    using TrainsOnline.Desktop.Domain.ValueObjects.RouteComponents;
    using TrainsOnline.Desktop.ViewModels.General;
    using TrainsOnline.Desktop.Views.Route;
    using Windows.UI.Xaml.Data;

    public class RouteDataGridViewModel : Screen, IRouteDataGridViewEvents
    {
        private INavigationService NavService { get; }
        private IRemoteDataProviderService RemoteDataProvider { get; }

        public ObservableCollection<GroupInfoCollection<RouteDetailsValueObject>> Source { get; } = new ObservableCollection<GroupInfoCollection<RouteDetailsValueObject>>();
        public CollectionViewSource GroupedSource { get; } = new CollectionViewSource();

        public RouteDataGridViewModel(INavigationService navigationService,
                                      IRemoteDataProviderService remoteDataProvider)
        {
            NavService = navigationService;
            RemoteDataProvider = remoteDataProvider;
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            IList<RouteDetailsValueObject> data = await RemoteDataProvider.GetRoutes();

            //foreach (RouteLookupModel route in data.Routes)
            //{
            //    GetRouteDetailsResponse details = await RemoteDataProvider.GetRoute(route.Id);

            //    Source.Add(info);
            //}

            var query = from item in data.Routes
                        group item by item.From.Id.ToString() into g
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupInfoCollection<RouteDetailsValueObject> info = new GroupInfoCollection<RouteDetailsValueObject>
                {
                    Key = g.GroupName
                };

                foreach (RouteLookupModel item in g.Items)
                {
                    RouteDetailsValueObject details = await RemoteDataProvider.GetRoute(item.Id);
                    info.Add(details);
                }

                Source.Add(info);
            }

            GroupedSource.IsSourceGrouped = true;
            GroupedSource.Source = Source;
        }

        public void ShowDepartureOnMap(RouteDetailsValueObject route)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(route.From.Latitude, route.From.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void ShowDestinationOnMap(RouteDetailsValueObject route)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(route.To.Latitude, route.To.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void ShowRouteOnMap(RouteDetailsValueObject route)
        {
            GeoCoordinate[] coords = new GeoCoordinate[] {
                new GeoCoordinate(route.From.Latitude, route.From.Longitude),
                new GeoCoordinate(route.To.Latitude, route.To.Longitude)
            };

            NavService.NavigateToViewModel<GeneralMapViewModel>(new GeneralMapViewParameters(coords));
        }

        public void DeleteRoute(RouteDetailsValueObject route)
        {

        }

        public void EditRoute(RouteDetailsValueObject route)
        {

        }

        public void BuyTicket(RouteDetailsValueObject route)
        {

        }

        public void LoadingRowGroup(DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            RouteDetailsValueObject item = group.GroupItems[0] as RouteDetailsValueObject;
            e.RowGroupHeader.PropertyValue = item?.From?.Name;
        }
    }

    //// Filtering implementation using LINQ
    //public enum FilterOptions
    //{
    //    All = -1,
    //    Rank_Low = 0,
    //    Rank_High = 1,
    //    Height_Low = 2,
    //    Height_High = 3
    //}

    //public ObservableCollection<DataGridDataItem> FilterData(FilterOptions filterBy)
    //{
    //    switch (filterBy)
    //    {
    //        case FilterOptions.All:
    //            return new ObservableCollection<DataGridDataItem>(_items);

    //        case FilterOptions.Rank_Low:
    //            return new ObservableCollection<DataGridDataItem>(from item in _items
    //                                                              where item.Rank < 50
    //                                                              select item);

    //        case FilterOptions.Rank_High:
    //            return new ObservableCollection<DataGridDataItem>(from item in _items
    //                                                              where item.Rank > 50
    //                                                              select item);

    //        case FilterOptions.Height_High:
    //            return new ObservableCollection<DataGridDataItem>(from item in _items
    //                                                              where item.Height_m > 8000
    //                                                              select item);

    //        case FilterOptions.Height_Low:
    //            return new ObservableCollection<DataGridDataItem>(from item in _items
    //                                                              where item.Height_m < 8000
    //                                                              select item);
    //    }

    //    return _items;
    //}

}
