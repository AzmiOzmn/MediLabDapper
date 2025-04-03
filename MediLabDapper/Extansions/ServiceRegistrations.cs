﻿using MediLabDapper.Context;
using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddRepositoriesExt(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<IDeparatmentRepository, DepartmentRepository>();
        }
    }
}
