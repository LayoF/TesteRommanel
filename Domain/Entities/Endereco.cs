namespace Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        // Propriedade de navegação
        public Cliente Cliente { get; set; }

        // Construtor privado para o EF
        private Endereco() { }

        // Construtor para criação de um novo endereço
        public Endereco(Guid clienteId, string cep, string rua, string numero, string bairro, string cidade, string estado)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
            CEP = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
