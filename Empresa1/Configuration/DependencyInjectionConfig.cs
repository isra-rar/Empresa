using Empresa1.Data.Context;
using Empresa1.Data.Repository;
using Empresa1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDepedencies(this IServiceCollection services)
        {

            services.AddScoped<EmpresaContext>();
            services.AddScoped<SeedingService>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            return services;
        }
    }
}
