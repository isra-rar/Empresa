using Empresa1.Interfaces;
using Empresa1.Models;
using Empresa1.Models.Validations;
using Empresa1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Services
{
    public class DepartamentoService : BaseService, IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository,
            INotifier notification) : base(notification)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<bool> Add(Departamento departamento)
        {
            if (!ExecuteValidation(new DepartamentoValidation(), departamento)) return false;

            if (_departamentoRepository.Find(f => f.NomeDepartamento == departamento.NomeDepartamento).Result.Any())
            {
                Notify("Já existe um departamento com este Nome");
                return false;
            }
            await _departamentoRepository.Add(departamento);
            return true;

        }

        public void Dispose()
        {
            _departamentoRepository?.Dispose();
        }

        public async Task<bool> Remove(Guid id)
        {
            var depart = _departamentoRepository.GetById(id);
            if (depart == null)
            {
                Notify("Departamento com esse ID não existe");
                return false;
            }

            await _departamentoRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Departamento departamento)
        {
            if (!ExecuteValidation(new DepartamentoValidation(), departamento)) return false;

            if (_departamentoRepository.Find(f => f.NomeDepartamento == departamento.NomeDepartamento
            && f.Id == departamento.Id).Result.Any())
            {
                Notify("Já existe um Departamento com este Nome");
                return false;
            }

            await _departamentoRepository.Update(departamento);
            return true;

        }
    }
}
