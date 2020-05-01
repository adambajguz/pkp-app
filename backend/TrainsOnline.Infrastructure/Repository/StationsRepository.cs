﻿namespace TrainsOnline.Infrastructure.Repository
{
    using System;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using TrainsOnline.Application.Interfaces.Repository;
    using TrainsOnline.Domain.Entities;

    public class StationsRepository : GenericRepository<Station>, IStationsRepository
    {
        public StationsRepository(ICurrentUserService currentUserService,
                                  IPKPAppDbContext context,
                                  IMapper mapper) : base(currentUserService, context, mapper)
        {

        }

        public async Task<Station> GetStationFullDetails(Guid id)
        {
            return await _dbSet.Include(x => x.Departures)
                               .ThenInclude(x => x.To)
                               .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
