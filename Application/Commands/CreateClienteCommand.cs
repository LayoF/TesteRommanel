using MediatR;

namespace Application.Commands
{
    public record CreateClienteCommand : IRequest<Guid>
    {
        public string NomeRazaoSocial { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public char TipoPessoa { get; set; } 
        public string? InscricaoEstadual { get; set; }
        public bool? IsentoIE { get; set; }
    }
}
