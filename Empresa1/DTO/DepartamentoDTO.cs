using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.DTO
{
    public class DepartamentoDTO
    {

        [Key]
        public Guid Id { get; set; }

        public string NomeDepartamento { get; set; }
     
    }
}
