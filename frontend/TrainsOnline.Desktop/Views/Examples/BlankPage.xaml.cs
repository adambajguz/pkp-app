namespace TrainsOnline.Desktop.Views.Examples
{
    using TrainsOnline.Desktop.ViewModels;
    using TrainsOnline.Desktop.ViewModels.Examples;
    using Windows.UI.Xaml.Controls;

    public sealed partial class BlankPage : Page
    {
        private BlankViewModel ViewModel => ViewModelLocator.Current.BlankViewModel;

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
