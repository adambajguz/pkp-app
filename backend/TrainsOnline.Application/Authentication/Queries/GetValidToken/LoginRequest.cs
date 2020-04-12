﻿namespace TrainsOnline.Application.Authentication.Queries.GetValidToken
{
    using TrainsOnline.Application.Common.DTO;

    public class LoginRequest : IDataTransferObject
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
