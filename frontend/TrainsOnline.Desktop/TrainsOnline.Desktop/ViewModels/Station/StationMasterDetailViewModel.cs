namespace TrainsOnline.Desktop.ViewModels.Station
{
    using System.Linq;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Services;

    public class StationMasterDetailViewModel : Conductor<StationMasterDetailDetailViewModel>.Collection.OneActive
    {
        protected override async void OnInitialize()
        {
            base.OnInitialize();

            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            Items.Clear();

            System.Collections.Generic.IEnumerable<Domain.Models.SampleOrder> data = await SampleDataService.GetMasterDetailDataAsync();

            Items.AddRange(data.Select(d => new StationMasterDetailDetailViewModel(d)));
        }
    }
}
