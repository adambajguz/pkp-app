namespace TrainsOnline.Desktop.ViewModels.Ticket
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.Models.Ticket;
    using TrainsOnline.Desktop.Services;
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

            await RemoteDataProvider.Login("test0@test.pl", "test1234");

            GetUserTicketsListResponse data = await RemoteDataProvider.GetCurrentUserTickets();

            if (data is null)
                return;

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
                _navigationService.NavigateToViewModel<TicketContentGridDetailViewModel>(new TicketContentGridDetailsParameters(clickedItem.Id));
            }
        }
    }
}
