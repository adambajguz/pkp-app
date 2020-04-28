namespace TrainsOnline.Desktop.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;
    using TrainsOnline.Desktop.Services;
    using TrainsOnline.Desktop.ViewModels.Examples;
    using TrainsOnline.Desktop.ViewModels.Home;
    using TrainsOnline.Desktop.Views;

    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<BlankViewModel, BlankPage>();
            Register<MasterDetailViewModel, MasterDetailPage>();
            Register<TreeViewViewModel, TreeViewPage>();
            Register<DataGridViewModel, DataGridPage>();
            Register<MapViewModel, MapPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<LogInViewModel, LogInPage>();
        }

        public LogInViewModel LogInViewModel => SimpleIoc.Default.GetInstance<LogInViewModel>();

        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public MapViewModel MapViewModel => SimpleIoc.Default.GetInstance<MapViewModel>();

        public DataGridViewModel DataGridViewModel => SimpleIoc.Default.GetInstance<DataGridViewModel>();

        public TreeViewViewModel TreeViewViewModel => SimpleIoc.Default.GetInstance<TreeViewViewModel>();

        public MasterDetailViewModel MasterDetailViewModel => SimpleIoc.Default.GetInstance<MasterDetailViewModel>();

        public BlankViewModel BlankViewModel => SimpleIoc.Default.GetInstance<BlankViewModel>();

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
