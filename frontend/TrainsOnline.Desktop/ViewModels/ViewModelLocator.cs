namespace TrainsOnline.Desktop.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;
    using TrainsOnline.Desktop.Services;

    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;
        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<Home.ShellViewModel>();

            // Home
            Register<Home.MainViewModel, Views.Home.MainPage>();
            Register<Home.SettingsViewModel, Views.Home.SettingsPage>();

            // Authentication
            Register<LogInViewModel, Views.Authentication.LogInPage>();

            // Examples
            Register<Examples.BlankViewModel, Views.Examples.BlankPage>();
            Register<Examples.MasterDetailViewModel, Views.Examples.MasterDetailPage>();
            Register<Examples.TreeViewViewModel, Views.Examples.TreeViewPage>();
            Register<Examples.DataGridViewModel, Views.Examples.DataGridPage>();
            Register<Examples.MapViewModel, Views.Examples.MapPage>();

            //Route
            //Register<Station.MasterDetailViewModel, Views.Station.MasterDetailPage>();

            //Station
            Register<Station.MasterDetailViewModel, Views.Station.MasterDetailPage>();

            //Ticket
            //Register<Station.MasterDetailViewModel, Views.Station.MasterDetailPage>();
        }

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();
        public Home.ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<Home.ShellViewModel>();

        // Authentication
        public LogInViewModel LogInViewModel => SimpleIoc.Default.GetInstance<LogInViewModel>();

        // Home
        public Home.MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<Home.MainViewModel>();
        public Home.SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<Home.SettingsViewModel>();

        // Examples
        public Examples.BlankViewModel BlankViewModel => SimpleIoc.Default.GetInstance<Examples.BlankViewModel>();
        public Examples.MasterDetailViewModel MasterDetailViewModel => SimpleIoc.Default.GetInstance<Examples.MasterDetailViewModel>();
        public Examples.TreeViewViewModel TreeViewViewModel => SimpleIoc.Default.GetInstance<Examples.TreeViewViewModel>();
        public Examples.DataGridViewModel DataGridViewModel => SimpleIoc.Default.GetInstance<Examples.DataGridViewModel>();
        public Examples.MapViewModel MapViewModel => SimpleIoc.Default.GetInstance<Examples.MapViewModel>();

        // Route
        public Route.DataGridViewModel RouteDataGridViewModel => SimpleIoc.Default.GetInstance<Route.DataGridViewModel>();

        // Station
        public Station.MasterDetailViewModel StationMasterDetailViewModel => SimpleIoc.Default.GetInstance<Station.MasterDetailViewModel>();

        // Ticket
        public Ticket.MasterDetailViewModel TicketMasterDetailViewModel => SimpleIoc.Default.GetInstance<Ticket.MasterDetailViewModel>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
