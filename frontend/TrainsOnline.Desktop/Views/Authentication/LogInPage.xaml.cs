
using TrainsOnline.Desktop.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TrainsOnline.Desktop.Views
{
    public sealed partial class LogInPage : Page
    {
        private LogInViewModel ViewModel => ViewModelLocator.Current.LogInViewModel;

        public LogInPage()
        {
            InitializeComponent();
        }
    }
}
