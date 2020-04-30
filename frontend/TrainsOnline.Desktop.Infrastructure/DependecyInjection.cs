namespace TrainsOnline.Desktop.Infrastructure
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Infrastructure.RemoteDataProvider;

    public static class DependecyInjection
    {
        public static void AddInfrastructure(this SimpleContainer _container)
        {
            _container.Singleton<IRemoteDataProviderService, RemoteDataProviderService>();
        }
    }
}
