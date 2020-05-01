namespace TrainsOnline.Desktop.ViewModels.Route
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.Route;
    using TrainsOnline.Desktop.Views.Route;
    using static TrainsOnline.Desktop.Domain.Route.GetRoutesListResponse;
    using Microsoft.Toolkit.Collections;
    using System.Linq;
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using Microsoft.Toolkit.Uwp.UI.Extensions;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;
    using System.Collections.Generic;

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

        public ObservableCollection<GroupInfoCollection<GetRouteDetailsResponse>> Source { get; } = new ObservableCollection<GroupInfoCollection<GetRouteDetailsResponse>>();
        public CollectionViewSource GroupedSource { get; } = new CollectionViewSource();

        public RouteDataGridViewModel(IRemoteDataProviderService remoteDataProvider)
        {
            RemoteDataProvider = remoteDataProvider;
        }

            public async Task LoadDataAsync()
        {
            Source.Clear();

            GetRoutesListResponse data = await RemoteDataProvider.GetRoutes();

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

        public void LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            GetRouteDetailsResponse item = group.GroupItems[0] as GetRouteDetailsResponse;
            e.RowGroupHeader.PropertyValue = item.From.Id.ToString();
            e.RowGroupHeader.PropertyValue = item.From.Name;
        }
    }



    public class GroupInfoCollection<T> : ObservableCollection<T>
    {
        public object Key { get; set; }

        public new IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)base.GetEnumerator();
        }
    }

    // Filtering implementation using LINQ
    public enum FilterOptions
    {
        All = -1,
        Rank_Low = 0,
        Rank_High = 1,
        Height_Low = 2,
        Height_High = 3
    }

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
