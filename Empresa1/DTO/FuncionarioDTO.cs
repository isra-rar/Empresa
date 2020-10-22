using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.DTO
{
    public class FuncionarioDTO : PessoaDTO
    {
        public Guid DepartamentoId { get; set; }
        public decimal Salario { get; set; }

    }
}
