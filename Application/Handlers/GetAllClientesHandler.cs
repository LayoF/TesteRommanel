using Application.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class GetAllClientesHandler : IRequestHandler<GetAllClientesQuery, List<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetAllClientesHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync();
            if (clientes == null)
                return null;

            return clientes.ToList();
        }
    }
}
