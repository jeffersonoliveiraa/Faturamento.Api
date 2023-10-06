using Faturamento.Domain.Entities.v1;
using MediatR;

namespace Faturamento.Domain.Commands.v1.Faturamento.Create;

public class CreateFaturamentosCommand : IRequest<Faturamentos>
{
    public int PedidoId { get; set; }
    public string? NomeCliente { get; set; }
    public double ValorTotalPedido { get; set; }

    public CreateFaturamentosCommand(int pedidoId, string? nomeCliente, double valorTotalPedido)
    {
        PedidoId = pedidoId;
        NomeCliente = nomeCliente;
        ValorTotalPedido = valorTotalPedido;
    }
}
