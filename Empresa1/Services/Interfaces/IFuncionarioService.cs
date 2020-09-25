using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa1.Models;

namespace Empresa1.Services.Interfaces
{
    public interface IFuncionarioService : IDisposable
    {
        Task<bool> Add(Funcionario funcionario);
        Task<bool> Update(Funcionario funcionario);
        Task<bool> Remove(Guid id);

    }
}
