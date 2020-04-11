namespace TrainsOnline.Application.Main.Authentication.Queries.GetValidToken
{
    using System;
    using Application.CommonDTO;

    public class JwtTokenModel : IDataTransferObject
    {
        public string Token { get; set; } = default!;
        public TimeSpan Lease { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
