﻿namespace TrainsOnline.Application.Handlers
{
    using Application.Constants;
    using FluentValidation;
    using TrainsOnline.Application.DTO;

    public class EntityRequestByIdValidator<TEntity> : AbstractValidator<EntityRequestByIdValidator<TEntity>.Model>
    {
        public EntityRequestByIdValidator()
        {
            RuleFor(x => x.Data.Id).NotEmpty().Must((request, val, token) =>
            {
                return request.Entity != null;
            }).WithMessage(ValidationMessages.General.IsIncorrectId);
        }

        public class Model
        {
            public IdRequest Data { get; set; }
            public TEntity Entity { get; set; }

            public Model(IdRequest data, TEntity entity)
            {
                Data = data;
                Entity = entity;
            }
        }
    }
}
