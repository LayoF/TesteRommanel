using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class GetClienteByIdQuery : IRequest<ClienteDto>
    {
        public Guid Id { get; set; }

        public GetClienteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
