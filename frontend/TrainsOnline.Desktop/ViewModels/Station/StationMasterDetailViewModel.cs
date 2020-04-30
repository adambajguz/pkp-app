namespace TrainsOnline.Desktop.ViewModels.Station
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.Station;

    public class StationMasterDetailViewModel : Conductor<StationMasterDetailDetailViewModel>.Collection.OneActive
    {
        private IRemoteDataProviderService RemoteDataProvider { get; }

        public StationMasterDetailViewModel(IRemoteDataProviderService remoteDataProvider)
        {
            RemoteDataProvider = remoteDataProvider;
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();

            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            Items.Clear();

            GetStationsListResponse data = await RemoteDataProvider.GetStations();

            Items.AddRange(data.Stations.Select(d => new StationMasterDetailDetailViewModel(d)));
        }

        public override async void ActivateItem(StationMasterDetailDetailViewModel item)
        {
            base.ActivateItem(item);

            if (item?.Item is null)
                return;

            GetStationDetailsResponse data = await RemoteDataProvider.GetStation(item.Item.Id);
            item.Details = data;
            item.Refresh();
        }
    }
}
