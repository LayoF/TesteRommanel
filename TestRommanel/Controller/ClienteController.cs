using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestRommanel.Controller
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommand command)
        {
            var clienteId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateCliente), new { id = clienteId }, clienteId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] UpdateClienteCommand command)
        {
            if (id != command.Id) return BadRequest("ID do cliente inválido.");
            var atualizado = await _mediator.Send(command);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var removido = await _mediator.Send(new DeleteClienteCommand(id));
            return removido ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(Guid id)
        {
            var cliente = await _mediator.Send(new GetClienteByIdQuery(id));
            return cliente != null ? Ok(cliente) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _mediator.Send(new GetAllClientesQuery());
            return Ok(clientes);
        }
    }
}
