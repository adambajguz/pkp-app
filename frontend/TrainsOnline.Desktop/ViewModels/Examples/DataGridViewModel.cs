namespace TrainsOnline.Desktop.ViewModels.Examples
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using TrainsOnline.Desktop.Application.Models;
    using TrainsOnline.Desktop.Application.Services;

    public class DataGridViewModel : ViewModelBase
    {
        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public DataGridViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            System.Collections.Generic.IEnumerable<SampleOrder> data = await SampleDataService.GetGridDataAsync();

            foreach (SampleOrder item in data)
                Source.Add(item);
        }
    }
}
