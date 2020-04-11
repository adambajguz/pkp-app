
using TrainsOnline.Desktop.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TrainsOnline.Desktop.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => ViewModelLocator.Current.MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
