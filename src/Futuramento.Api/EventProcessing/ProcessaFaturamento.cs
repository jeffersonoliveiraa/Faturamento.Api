using Faturamento.Domain.Contracts.v1.Repository;
using Faturamento.Domain.Dtos.v1;
using Faturamento.Domain.Entities.v1;
using System.Text.Json;

namespace Faturamento.Api.EventProcessing;

public class ProcessaFaturamento : IProcessaFaturamento
{
    private readonly IFaturamentoRepository _faturamentoRepository;

    public ProcessaFaturamento(IFaturamentoRepository faturamentoRepository)
    {
        _faturamentoRepository = faturamentoRepository;
    }

    async void IProcessaFaturamento.ProcessaFaturamento(string dadosFaturamento)
    {
        var dadoFaturamentoPublish = JsonSerializer.Deserialize<FaturamentoDto>(dadosFaturamento);

        Faturamentos faturamentos = new()
        {
            NomeCliente = dadoFaturamentoPublish!.NomeCliente,
            PedidoId = dadoFaturamentoPublish.Id,
            ValorTotalPedido = dadoFaturamentoPublish.ValorTotalPedido
        };

        await _faturamentoRepository.CreateFaturamentosAsync(faturamentos);
    }
}
