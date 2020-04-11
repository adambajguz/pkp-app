
using TrainsOnline.Desktop.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TrainsOnline.Desktop.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get => GetValue(MasterMenuItemProperty) as SampleOrder;
            set => SetValue(MasterMenuItemProperty, value);
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(MasterDetailDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MasterDetailDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MasterDetailDetailControl control = d as MasterDetailDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
