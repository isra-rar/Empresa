using Empresa1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Services.Interfaces
{
    public interface IDepartamentoService : IDisposable
    {
        Task<bool> Add(Departamento departamento);
        Task<bool> Update(Departamento departamento);
        Task<bool> Remove(Guid id);
    }
}
