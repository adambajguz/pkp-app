namespace TrainsOnline.Desktop
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.ViewModels;
    using TrainsOnline.Desktop.ViewModels.Example;
    using TrainsOnline.Desktop.ViewModels.Route;
    using TrainsOnline.Desktop.ViewModels.Station;
    using TrainsOnline.Desktop.ViewModels.Ticket;

    public static class DependecyInjection
    {
        public static void AddPresentation(this WinRTContainer _container)
        {
            _container.RegisterWinRTServices();

            _container.PerRequest<ShellViewModel>();
            _container.PerRequest<HomeViewModel>();
            _container.PerRequest<SettingsViewModel>();

            _container.PerRequest<ExampleBlankViewModel>();
            _container.PerRequest<ExampleMasterDetailViewModel>();
            _container.PerRequest<ExampleContentGridDetailViewModel>();
            _container.PerRequest<ExampleContentGridViewModel>();
            _container.PerRequest<ExampleDataGridViewModel>();
            _container.PerRequest<ExampleMapViewModel>();

            _container.PerRequest<RouteDataGridViewModel>();

            _container.PerRequest<StationMasterDetailViewModel>();

            _container.PerRequest<TicketContentGridDetailViewModel>();
            _container.PerRequest<TicketContentGridViewModel>();
        }
    }
}
