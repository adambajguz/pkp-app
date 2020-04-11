using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using TrainsOnline.Desktop.Core.Models;
using TrainsOnline.Desktop.Core.Services;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace TrainsOnline.Desktop.ViewModels
{
    public class TreeViewViewModel : ViewModelBase
    {
        private ICommand _itemInvokedCommand;
        private object _selectedItem;

        public object SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public ObservableCollection<SampleCompany> SampleItems { get; } = new ObservableCollection<SampleCompany>();

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.TreeViewItemInvokedEventArgs>(OnItemInvoked));

        public TreeViewViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            System.Collections.Generic.IEnumerable<SampleCompany> data = await SampleDataService.GetTreeViewDataAsync();
            foreach (SampleCompany item in data)
            {
                SampleItems.Add(item);
            }
        }

        private void OnItemInvoked(WinUI.TreeViewItemInvokedEventArgs args)
        {
            SelectedItem = args.InvokedItem;
        }
    }
}
