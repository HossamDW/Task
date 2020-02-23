using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Entities = Task.Core.Entities;
using Dtos = Task.Core.DTOs;

namespace Task.Infrastructure
{
    public class AutoMapperProfiles
    {
        public class AreaProfile : Profile
        {
            public AreaProfile()
            {
                CreateMap<Entities.Area, Dtos.Area>();
                CreateMap<Dtos.Area, Entities.Area>();
            }
        }

        public class CityProfile : Profile
        {
            public CityProfile()
            {
                CreateMap<Entities.City, Dtos.City>();
                CreateMap<Dtos.City, Entities.City>();
            }
        }

        public class DistrictProfile : Profile
        {
            public DistrictProfile()
            {
                CreateMap<Entities.District, Dtos.District>();
                CreateMap<Dtos.District, Entities.District>();
            }
        }
    }
}
