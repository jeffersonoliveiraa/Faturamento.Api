using Faturamento.Domain.Commands.v1.Faturamento.Create;
using Faturamento.Domain.Commands.v1.Faturamento.Delete;
using Faturamento.Domain.Commands.v1.Faturamento.Update;
using Faturamento.Domain.Entities.v1;
using Faturamento.Infra.Data.Queries.Queries.v1.GetAll;
using Faturamento.Infra.Data.Queries.Queries.v1.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Faturamento.Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public class FaturamentosController : ControllerBase
{
    private readonly IMediator _mediator;

    public FaturamentosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetFaturamentosAsync()
    {
        try
        {
            return Ok(await _mediator.Send(new GetAllFaturamentosQuery { }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetFaturamentosByIdAsync(int id)
    {
        try
        {
            return Ok(await _mediator.Send(new GetFaturamentosByIdQuery { Id = id }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFaturamentoAsync([FromBody] Faturamentos faturamentos)
    {
        try
        {
            return Ok(await _mediator.Send(new CreateFaturamentosCommand(faturamentos.PedidoId, faturamentos.NomeCliente, faturamentos.ValorTotalPedido)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFaturamentoAsync(int id)
    {
        try
        {
            return Ok(await _mediator.Send(new DeleteFaturamentosCommand() { Id = id }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateFaturamentoAsync([FromBody] Faturamentos faturamentos)
    {
        try
        {
            return Ok(await _mediator.Send(
                new UpdateFaturamentoCommand
                { 
                    Id = faturamentos.Id , 
                    NomeCliente = faturamentos.NomeCliente, 
                    PedidoId = faturamentos.PedidoId, 
                    ValorTotalPedido = faturamentos.ValorTotalPedido
                }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
