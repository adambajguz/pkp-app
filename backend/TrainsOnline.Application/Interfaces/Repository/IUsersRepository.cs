﻿namespace TrainsOnline.Application.Interfaces.Repository
{
    using System.Threading.Tasks;
    using Application.Interfaces.Repository.Generic;
    using Domain.Entities;

    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<bool> IsEmailInUseAsync(string? email);
    }
}