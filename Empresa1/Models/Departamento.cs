using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Models
{
    public class Departamento : Entity
    {
        public string NomeDepartamento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }

    }
}
