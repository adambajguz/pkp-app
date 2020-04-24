﻿namespace TrainsOnline.Infrastructure.Repository
{
    using Application.Interfaces;
    using AutoMapper;
    using TrainsOnline.Application.Interfaces.Repository;
    using TrainsOnline.Domain.Entities;

    public class StationsRepository : GenericRepository<Station>, IStationsRepository
    {
        public StationsRepository(ICurrentUserService currentUserService,
                                  IPKPAppDbContext context,
                                  IMapper mapper) : base(currentUserService, context, mapper)
        {

        }
    }
}
