using System;

namespace Empresa1.Models
{
    public class Funcionario : Pessoa
    {
        public Guid DepartamentoId{ get; set; }
        public decimal Salario { get; set; }
        public Departamento Departamento { get; set; }

    }
}