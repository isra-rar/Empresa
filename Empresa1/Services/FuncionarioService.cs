using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa1.Interfaces;
using Empresa1.Models;
using Empresa1.Models.Validations;
using Empresa1.Services.Interfaces;

namespace Empresa1.Services
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {

        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository,
            INotification notification) : base(notification)
        {
            _funcionarioRepository = funcionarioRepository;
        }


        public async Task<bool> Add(Funcionario funcionario)
        {
            if (!ExecuteValidation(new FuncionarioValidation(), funcionario)) return false;

            if (_funcionarioRepository.Find(f => f.Documento == funcionario.Documento).Result.Any())
            {
                Notify("Já existe um funcionario com este documento");
                return false;
            }
            await _funcionarioRepository.Add(funcionario);
            return true;
        }

        public async Task<bool> Update(Funcionario funcionario)
        {
            if (!ExecuteValidation(new FuncionarioValidation(), funcionario)) return false;

            if (_funcionarioRepository.Find(f => f.Documento == funcionario.Documento 
            && f.Id == funcionario.Id).Result.Any())
            {
                Notify("Já existe um funcionario com este documento");
                return false;
            }

            await _funcionarioRepository.Update(funcionario);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var funcionario = _funcionarioRepository.GetById(id);
            if (funcionario == null)
            {
                Notify("Funcionario com esse ID não existe");
                return false;
            }

            await _funcionarioRepository.Remove(id);
            return true;
        }
        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
        }
    }
}
