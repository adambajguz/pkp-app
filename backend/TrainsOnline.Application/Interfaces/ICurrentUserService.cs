namespace TrainsOnline.Application.Interfaces
{
    internal interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }
    }
}
