namespace TrainsOnline.Desktop.ViewModels.Ticket
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Services;
    using TrainsOnline.Desktop.Views.Example;
    using TrainsOnline.Desktop.Views.Ticket;

    public class TicketContentGridViewModel : Screen, ITicketContentGridViewEvents
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

            if (data is null)
                return;

            // TODO WTS: Replace this with your actual data
            foreach (UserTicketLookupModel ticket in data.Tickets)
            {
                Source.Add(ticket);
            }
        }

        public void OnItemSelected(UserTicketLookupModel clickedItem)
        {
            if (clickedItem != null)
            {
                _connectedAnimationService.SetListDataItemForNextConnectedAnimation(clickedItem);
                _navigationService.Navigate(typeof(ExampleContentGridDetailPage), clickedItem.Id);
            }
        }
    }
}
