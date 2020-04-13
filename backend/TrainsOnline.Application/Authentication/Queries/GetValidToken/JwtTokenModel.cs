namespace TrainsOnline.Application.Authentication.Queries.GetValidToken
{
    using System;
    using TrainsOnline.Application.DTO;

    public class JwtTokenModel : IDataTransferObject
    {
        public string Token { get; set; } = default!;
        public TimeSpan Lease { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
