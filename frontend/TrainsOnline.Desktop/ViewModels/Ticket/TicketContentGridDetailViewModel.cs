namespace TrainsOnline.Desktop.ViewModels.Ticket
{
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Domain.Models.Ticket;
    using TrainsOnline.Desktop.Domain.ValueObjects.TicketComponents;
    using TrainsOnline.Desktop.Services;

    public class TicketContentGridDetailViewModel : Screen
    {
        private readonly IConnectedAnimationService _connectedAnimationService;
        private IRemoteDataProviderService RemoteDataProvider { get; }

        private TicketDetailsValueObject _item;
        public TicketDetailsValueObject Item
        {
            get => _item;
            set => Set(ref _item, value);
        }

        public TicketContentGridDetailsParameters Parameter { get; set; }

        public TicketContentGridDetailViewModel(IConnectedAnimationService connectedAnimationService,
                                                IRemoteDataProviderService remoteDataProvider)
        {
            _connectedAnimationService = connectedAnimationService;
            RemoteDataProvider = remoteDataProvider;
        }

        public async Task InitializeAsync()
        {
            TicketDetailsValueObject data = await RemoteDataProvider.GetTicket(Parameter.TicketId);

            Item = data;
        }

        public void SetListDataItemForNextConnectedAnimation()
        {
            _connectedAnimationService.SetListDataItemForNextConnectedAnimation(Item);
        }
    }
}
