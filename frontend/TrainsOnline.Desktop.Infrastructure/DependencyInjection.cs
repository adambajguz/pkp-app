﻿namespace TrainsOnline.Desktop.Domain
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Domain.RemoteDataProvider;

    public static class DependencyInjection
    {
        public static void AddInfrastructure(this SimpleContainer _container)
        {
            _container.Singleton<ITicketData, RemoteDataProviderService>();
        }
    }
}