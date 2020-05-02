namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    public interface IRemoteDataProviderService : IUserData, IStationData, IRouteData, ITicketData
    {
        WebApiTypes ApiType { get; set; }
    }
}
