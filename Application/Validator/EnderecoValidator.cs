using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Matches(@"^\d{5}-?\d{3}$").WithMessage("Formato de CEP inválido.");

            RuleFor(e => e.Rua)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .MaximumLength(255).WithMessage("O endereço pode ter no máximo 255 caracteres.");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("O número é obrigatório.")
                .MaximumLength(10).WithMessage("O número pode ter no máximo 10 caracteres.");

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("O bairro é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro pode ter no máximo 100 caracteres.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade pode ter no máximo 100 caracteres.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve ter exatamente 2 caracteres.");
        }
    }
}
