using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Models.Validations
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .EmailAddress()
                .WithMessage("O campo {PropertyName} não é um Email valido");

            RuleFor(f => f.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Must(BeOver18)
                .WithMessage("{PropertyName} precisa ser maior que 18 anos");

            RuleFor(f => f.Sexo)
                .IsInEnum().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }

        protected bool BeOver18(DateTime dateTime)
        {
            var idade = DateTime.Now.Year - dateTime.Year;
            return idade >= 18;
        }
    }
}
