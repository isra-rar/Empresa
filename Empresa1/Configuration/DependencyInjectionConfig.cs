using Empresa1.Data.Context;
using Empresa1.Data.Repository;
using Empresa1.Interfaces;
using Empresa1.Notifications;
using Empresa1.Services;
using Empresa1.Services.Interfaces;
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
            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();

            return services;
        }
    }
}
