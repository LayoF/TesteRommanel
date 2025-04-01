using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateClienteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
