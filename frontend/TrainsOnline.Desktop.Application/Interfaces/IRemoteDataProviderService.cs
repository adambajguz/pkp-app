namespace TrainsOnline.Desktop.Application.Interfaces
{
    public interface IRemoteDataProviderService : IDataProvider
    {
        WebApiTypes ApiType { get; set; }
    }
}
