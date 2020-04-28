namespace TrainsOnline.Desktop.ViewModels.Station
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Application.Helpers;
    using TrainsOnline.Desktop.Domain.Station;
    using TrainsOnline.Desktop.Infrastructure;

    public class MasterDetailViewModel : ViewModelBase
    {
        private GetStationDetailsResponse _selected;

        public GetStationDetailsResponse Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        public ObservableCollection<StationLookupModel> SampleItems { get; private set; } = new ObservableCollection<StationLookupModel>();

        private RemoteDataProvider DataProvider { get; } = Singleton<RemoteDataProvider>.Instance;

        public MasterDetailViewModel()
        {

        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            GetStationsListResponse data = await DataProvider.GetStations();

            foreach (StationLookupModel item in data.Stations)
                SampleItems.Add(item);

            if (viewState == MasterDetailsViewState.Both)
                Selected = SampleItems.First();
        }
    }
}
