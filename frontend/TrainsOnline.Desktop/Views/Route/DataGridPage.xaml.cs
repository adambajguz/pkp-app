namespace TrainsOnline.Desktop.Views.Route
{
    using TrainsOnline.Desktop.ViewModels;
    using TrainsOnline.Desktop.ViewModels.Route;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class DataGridPage : Page
    {
        private DataGridViewModel ViewModel => ViewModelLocator.Current.RouteDataGridViewModel;

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on DataGridPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public DataGridPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
