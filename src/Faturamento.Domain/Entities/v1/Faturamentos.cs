namespace Faturamento.Domain.Entities.v1;

public class Faturamentos
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public string? NomeCliente { get; set; }
    public double ValorTotalPedido { get; set; }
}
