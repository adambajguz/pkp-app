namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    public interface IRemoteDataProviderService : IUserData, IStationtData, IRouteData, ITicketData
    {
        WebApiTypes ApiType { get; set; }
    }
}
