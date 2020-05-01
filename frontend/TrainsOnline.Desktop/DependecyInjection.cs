namespace TrainsOnline.Desktop
{
    using Caliburn.Micro;
    using VM = ViewModels;

    public static class DependecyInjection
    {
        public static void AddPresentation(this WinRTContainer _container)
        {
            _container.RegisterWinRTServices();

            _container.PerRequest<VM.ShellViewModel>();
            _container.PerRequest<VM.HomeViewModel>();
            _container.PerRequest<VM.SettingsViewModel>();

            _container.PerRequest<VM.General.GeneralMapViewModel>();

            _container.PerRequest<VM.Example.ExampleBlankViewModel>();
            _container.PerRequest<VM.Example.ExampleMasterDetailViewModel>();
            _container.PerRequest<VM.Example.ExampleContentGridDetailViewModel>();
            _container.PerRequest<VM.Example.ExampleContentGridViewModel>();
            _container.PerRequest<VM.Example.ExampleDataGridViewModel>();
            _container.PerRequest<VM.Example.ExampleMapViewModel>();

            _container.PerRequest<VM.Route.RouteDataGridViewModel>();

            _container.PerRequest<VM.Station.StationMasterDetailViewModel>();

            _container.PerRequest<VM.Ticket.TicketContentGridDetailViewModel>();
            _container.PerRequest<VM.Ticket.TicketContentGridViewModel>();
        }
    }
}
