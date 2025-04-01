namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public char TipoPessoa { get; set; } // 'F' para Física, 'J' para Jurídica
        public string? InscricaoEstadual { get; set; }
        public bool? IsentoIE { get; set; }
        public DateTime DataCadastro { get; set; }

        // Relacionamento 1:N com Endereços
        public List<Endereco> Enderecos { get; set; } = new();

        // Construtor privado para o EF
        private Cliente() { }

        // Construtor para criação de um novo cliente
        public Cliente(string nomeRazaoSocial, string cpfCnpj, DateTime? dataNascimento, string telefone, string email, char tipoPessoa, string? inscricaoEstadual, bool? isentoIE)
        {
            Id = Guid.NewGuid();
            NomeRazaoSocial = nomeRazaoSocial;
            CPF_CNPJ = cpfCnpj;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            TipoPessoa = tipoPessoa;
            InscricaoEstadual = tipoPessoa == 'J' ? inscricaoEstadual : null;
            IsentoIE = tipoPessoa == 'J' ? isentoIE : null;
            DataCadastro = DateTime.UtcNow;
        }

        // Método para adicionar endereço
        public void AdicionarEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }
    }
}
