using Application.Commands;
using Application.DTOs;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class GetClienteByIdHandler : IRequestHandler<GetClienteByIdQuery, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClienteByIdHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                NomeRazaoSocial = cliente.NomeRazaoSocial,
                CPF_CNPJ = cliente.CPF_CNPJ,
                DataNascimento = cliente.DataNascimento,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                TipoPessoa = cliente.TipoPessoa
            };
        }
    }
}
