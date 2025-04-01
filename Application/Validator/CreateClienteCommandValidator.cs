using Application.Commands;
using Domain.Entities;
using FluentValidation;

namespace Application.Validator
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(c => c.NomeRazaoSocial)
                .NotEmpty().WithMessage("O nome ou razão social é obrigatório.")
                .MaximumLength(255).WithMessage("O nome pode ter no máximo 255 caracteres.");

            RuleFor(c => c.CPF_CNPJ)
                .NotEmpty().WithMessage("CPF/CNPJ é obrigatório.")
                .Must(IsValidCpfCnpj).WithMessage("CPF/CNPJ inválido.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("Telefone inválido.");

            RuleFor(c => c.TipoPessoa)
                .Must(t => t == 'F' || t == 'J').WithMessage("Tipo de pessoa deve ser 'F' para Física ou 'J' para Jurídica.");

            RuleFor(c => c.DataNascimento)
                .Must((c, data) => ValidarIdadeMinima(c.TipoPessoa, data))
                .WithMessage("Para pessoas físicas, a idade mínima deve ser 18 anos.");

            RuleFor(c => c.InscricaoEstadual)
                .NotEmpty().When(c => c.TipoPessoa == 'J' && c.IsentoIE == false)
                .WithMessage("A inscrição estadual é obrigatória para empresas não isentas.");
        }

        private bool IsValidCpfCnpj(string cpfCnpj)
        {
            // Implementar validação de CPF/CNPJ
            return !string.IsNullOrEmpty(cpfCnpj);
        }

        private bool ValidarIdadeMinima(char tipoPessoa, DateTime? dataNascimento)
        {
            if (tipoPessoa == 'F' && dataNascimento.HasValue)
            {
                return dataNascimento.Value.AddYears(18) <= DateTime.Today;
            }
            return true;
        }
    }
}
