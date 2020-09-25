using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa1.Data.Context;
using Empresa1.Interfaces;
using Empresa1.Models;

namespace Empresa1.Data.Repository
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(EmpresaContext db) : base(db)
        {
        }
    }
}
