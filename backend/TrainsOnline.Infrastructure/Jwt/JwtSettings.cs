namespace TrainsOnline.Infrastructure.Main.Jwt
{
    using System;

    public sealed class JwtSettings
    {
        public string? Key { get; set; }
        public TimeSpan Lease { get; set; }
    }
}
