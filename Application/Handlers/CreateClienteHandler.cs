using Application.Commands;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IValidator<CreateClienteCommand> _validator;

        public CreateClienteHandler(IClienteRepository clienteRepository, IValidator<CreateClienteCommand> validator)
        {
            _clienteRepository = clienteRepository;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var cliente = new Cliente(
                request.NomeRazaoSocial,
                request.CPF_CNPJ,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.TipoPessoa,
                request.InscricaoEstadual,
                request.IsentoIE
            );

            await _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            return cliente.Id;
        }
    }
}
