namespace TrainsOnline.Desktop.Core.Interfaces
{
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.Station;

    internal interface IRemoteDataProviderService
    {
        bool UseSoapApi { get; set; }
        Task<GetStationsListResponse> GetStations();
    }
}
