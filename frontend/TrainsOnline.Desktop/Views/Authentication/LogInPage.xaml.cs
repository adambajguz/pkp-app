namespace TrainsOnline.Desktop.Views.Authentication
{
    using TrainsOnline.Desktop.ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class LogInPage : Page
    {
        private LogInViewModel ViewModel => ViewModelLocator.Current.LogInViewModel;

        public LogInPage()
        {
            InitializeComponent();
        }
    }
}
