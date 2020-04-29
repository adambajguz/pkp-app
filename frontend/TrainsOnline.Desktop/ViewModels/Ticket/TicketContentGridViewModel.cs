namespace TrainsOnline.Desktop.ViewModels.Ticket
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Services;
    using TrainsOnline.Desktop.Domain.Models;
    using TrainsOnline.Desktop.Services;
    using TrainsOnline.Desktop.Views.Example;

    public class TicketContentGridViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public TicketContentGridViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            System.Collections.Generic.IEnumerable<SampleOrder> data = await SampleDataService.GetContentGridDataAsync();
            foreach (SampleOrder item in data)
            {
                Source.Add(item);
            }
        }

        public void OnItemSelected(SampleOrder clickedItem)
        {
            if (clickedItem != null)
            {
                _connectedAnimationService.SetListDataItemForNextConnectedAnimation(clickedItem);
                _navigationService.Navigate(typeof(ExampleContentGridDetailPage), clickedItem.OrderID);
            }
        }
    }
}
