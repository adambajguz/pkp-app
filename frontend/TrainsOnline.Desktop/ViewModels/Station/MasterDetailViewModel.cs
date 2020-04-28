namespace TrainsOnline.Desktop.ViewModels.Station
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using Microsoft.Toolkit.Uwp.UI.Controls;
    using TrainsOnline.Desktop.Application.Models;
    using TrainsOnline.Desktop.Application.Services;

    public class MasterDetailViewModel : ViewModelBase
    {
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public MasterDetailViewModel()
        {

        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            System.Collections.Generic.IEnumerable<SampleOrder> data = await SampleDataService.GetMasterDetailDataAsync();

            foreach (SampleOrder item in data)
                SampleItems.Add(item);

            if (viewState == MasterDetailsViewState.Both)
                Selected = SampleItems.First();
        }
    }
}
