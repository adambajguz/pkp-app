namespace TrainsOnline.Desktop.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;
    using TrainsOnline.Desktop.Services;
    using TrainsOnline.Desktop.ViewModels.Examples;
    using TrainsOnline.Desktop.ViewModels.Home;
    using TrainsOnline.Desktop.Views.Authentication;
    using TrainsOnline.Desktop.Views.Examples;
    using TrainsOnline.Desktop.Views.Home;

    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();

            // Home
            Register<MainViewModel, MainPage>();
            Register<SettingsViewModel, SettingsPage>();

            // Authentication
            Register<LogInViewModel, LogInPage>();

            // Examples
            Register<BlankViewModel, BlankPage>();
            Register<MasterDetailViewModel, MasterDetailPage>();
            Register<TreeViewViewModel, TreeViewPage>();
            Register<DataGridViewModel, DataGridPage>();
            Register<MapViewModel, MapPage>();
        }

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();
        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        // Authentication
        public LogInViewModel LogInViewModel => SimpleIoc.Default.GetInstance<LogInViewModel>();

        // Home
        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        // Examples
        public BlankViewModel BlankViewModel => SimpleIoc.Default.GetInstance<BlankViewModel>();
        public MasterDetailViewModel MasterDetailViewModel => SimpleIoc.Default.GetInstance<MasterDetailViewModel>();
        public TreeViewViewModel TreeViewViewModel => SimpleIoc.Default.GetInstance<TreeViewViewModel>();
        public DataGridViewModel DataGridViewModel => SimpleIoc.Default.GetInstance<DataGridViewModel>();
        public MapViewModel MapViewModel => SimpleIoc.Default.GetInstance<MapViewModel>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
