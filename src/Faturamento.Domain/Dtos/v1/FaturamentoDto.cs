namespace Faturamento.Domain.Dtos.v1;

public class FaturamentoDto
{
    public int Id { get; set; }
    public string? NomeCliente { get; set; }
    public double ValorTotalPedido { get; set; }
    public string? Evento { get; set; }
}
