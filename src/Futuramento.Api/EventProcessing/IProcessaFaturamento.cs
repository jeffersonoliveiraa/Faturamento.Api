namespace Faturamento.Api.EventProcessing;

public interface IProcessaFaturamento
{
    void ProcessaFaturamento(string dadosFaturamento);
}
