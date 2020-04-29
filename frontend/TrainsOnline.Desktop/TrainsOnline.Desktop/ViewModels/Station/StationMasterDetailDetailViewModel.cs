namespace TrainsOnline.Desktop.ViewModels.Station
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Domain.Models;

    public class StationMasterDetailDetailViewModel : Screen
    {
        public StationMasterDetailDetailViewModel(SampleOrder item)
        {
            Item = item;
        }

        public SampleOrder Item { get; }
    }
}
