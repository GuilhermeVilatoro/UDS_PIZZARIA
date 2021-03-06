﻿using AutoMapper;

namespace Pizzaria.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<ViewModelToBusinessDtoMappingProfile>();
                x.AddProfile<BusinessDtoToViewModelMappingProfile>();
                x.AddProfile<DomainToBusinessDtoMappingProfile>();
            });
        }
    }
}