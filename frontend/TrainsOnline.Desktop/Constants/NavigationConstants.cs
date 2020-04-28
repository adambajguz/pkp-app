namespace TrainsOnline.Desktop.Constants
{
    public static class NavigationConstants
    {
        public static string Shell_Home_Main { get; } = typeof(ViewModels.Home.MainViewModel).FullName;

        public static string Shell_Examples_Blank { get; } = typeof(ViewModels.Examples.BlankViewModel).FullName;
        public static string Shell_Examples_MasterDetail { get; } = typeof(ViewModels.Examples.MasterDetailViewModel).FullName;
        public static string Shell_Examples_TreeView { get; } = typeof(ViewModels.Examples.TreeViewViewModel).FullName;
        public static string Shell_Examples_DataGrid { get; } = typeof(ViewModels.Examples.DataGridViewModel).FullName;
        public static string Shell_Examples_Map { get; } = typeof(ViewModels.Examples.MapViewModel).FullName;

        public static string Shell_Station_MasterDetail { get; } = typeof(ViewModels.Station.MasterDetailViewModel).FullName;
    }
}
