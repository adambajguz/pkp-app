namespace TrainsOnline.Desktop.Views.Ticket
{
    using System;
    using TrainsOnline.Desktop.ViewModels.Ticket;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class TicketContentGridDetailPage : Page
    {
        public TicketContentGridDetailPage()
        {
            InitializeComponent();
        }

        private TicketContentGridDetailViewModel ViewModel => DataContext as TicketContentGridDetailViewModel;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Guid ticketId)
            {
                await ViewModel.InitializeAsync(ticketId);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                ViewModel.SetListDataItemForNextConnectedAnimation();
            }
        }
    }
}
