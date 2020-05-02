namespace TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.ValueObjects.Station;

    public interface IStationtData
    {
        Task<StationDetailsValueObject> GetStation(Guid id);
        Task<IList<StationDetailsValueObject>> GetStations();
    }
}
