using MediatR;

namespace Faturamento.Domain.Commands.v1.Faturamento.Update;

public class UpdateFaturamentoCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public string? NomeCliente { get; set; }
    public double ValorTotalPedido { get; set; }
}
