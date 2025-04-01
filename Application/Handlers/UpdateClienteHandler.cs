using Application.Commands;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IValidator<UpdateClienteCommand> _validator;

        public UpdateClienteHandler(IClienteRepository clienteRepository, IValidator<UpdateClienteCommand> validator)
        {
            _clienteRepository = clienteRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                return false;

            cliente.NomeRazaoSocial = request.NomeRazaoSocial;
            cliente.Telefone = request.Telefone;
            cliente.Email = request.Email;

            _clienteRepository.Update(cliente);
            await _clienteRepository.SaveChangesAsync();
            return true;
        }
    }

}
