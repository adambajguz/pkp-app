namespace TrainsOnline.Desktop.Views.User
{
    using TrainsOnline.Desktop.ViewModels.User;
    using Windows.UI.Xaml.Controls;

    public sealed partial class UserDetailsPage : Page
    {
        public UserDetailsPage()
        {
            InitializeComponent();
        }

        private UserDetailsViewModel ViewModel => DataContext as UserDetailsViewModel;
    }
}
