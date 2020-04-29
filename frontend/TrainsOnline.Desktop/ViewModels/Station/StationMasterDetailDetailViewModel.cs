namespace TrainsOnline.Desktop.ViewModels.Station
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Domain.Station;

    public class StationMasterDetailDetailViewModel : Screen
    {
        public StationMasterDetailDetailViewModel(StationLookupModel item)
        {
            Item = item;
        }

        public StationLookupModel Item { get; }
        public GetStationDetailsResponse Details { get; set; }
    }
}
