using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tutoring.Core.Domain;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Leader, LeaderDto>();
                cfg.CreateMap<Course, CourseDto>();
            })
            .CreateMapper();

            return config;
        }
    }
}
