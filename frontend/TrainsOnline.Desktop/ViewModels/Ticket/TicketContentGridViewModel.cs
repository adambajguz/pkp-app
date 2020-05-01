namespace TrainsOnline.Desktop.ViewModels.Ticket
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.Models;
    using TrainsOnline.Desktop.Services;
    using TrainsOnline.Desktop.Views.Example;

    public class TicketContentGridViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;
        private IRemoteDataProviderService RemoteDataProvider { get; }

        public ObservableCollection<UserTicketLookupModel> Source { get; } = new ObservableCollection<UserTicketLookupModel>();

        public TicketContentGridViewModel(INavigationService navigationService,
                                          IConnectedAnimationService connectedAnimationService,
                                          IRemoteDataProviderService remoteDataProvider)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
            RemoteDataProvider = remoteDataProvider;
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            GetUserTicketsListResponse data = await RemoteDataProvider.GetCurrentUserTickets();

            // TODO WTS: Replace this with your actual data
            foreach (UserTicketLookupModel ticket in data.Tickets)
            {
                Source.Add(ticket);
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
