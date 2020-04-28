namespace TrainsOnline.Desktop.Views.Examples
{
    using TrainsOnline.Desktop.ViewModels;
    using TrainsOnline.Desktop.ViewModels.Examples;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class MapPage : Page
    {
        private MapViewModel ViewModel => ViewModelLocator.Current.MapViewModel;

        public MapPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}
