using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Infrastructure.Data;

namespace Task.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            //Register DbContext
            services.AddDbContext<TaskDBContext>(options);

            //Register AutoMapper 
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            return services;
        }
    }
}
