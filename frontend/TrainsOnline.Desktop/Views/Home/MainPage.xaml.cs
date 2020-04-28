namespace TrainsOnline.Desktop.Views
{
    using TrainsOnline.Desktop.ViewModels;
    using TrainsOnline.Desktop.ViewModels.Home;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => ViewModelLocator.Current.MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
