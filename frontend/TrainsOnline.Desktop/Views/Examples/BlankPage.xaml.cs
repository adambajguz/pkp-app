
using TrainsOnline.Desktop.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TrainsOnline.Desktop.Views
{
    public sealed partial class BlankPage : Page
    {
        private BlankViewModel ViewModel => ViewModelLocator.Current.BlankViewModel;

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
