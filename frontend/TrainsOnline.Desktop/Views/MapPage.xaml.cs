
using TrainsOnline.Desktop.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TrainsOnline.Desktop.Views
{
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
